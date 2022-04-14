using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormHandleQuery : Form {

    private readonly int InitialWindowStyle = 0;
    private readonly Translation ProgramTranslation;
    private Settings ProgramSettings;
    private GlobalHotKey HotKey;
    private AutoCompleteStringCollection AutoCompleteCollection;
    private bool ShowInitialBalloonTip = false;
    private static bool IsDebug = false;

    private readonly Regex RgxIdCmHandleEnlistedFluency = new("<strong class=\"value\">(.+)</strong>", RegexOptions.Multiline | RegexOptions.Compiled);
    private readonly Regex RgxAvatar = new("<div class=\"thumb\">\\s+<img src=\"(.+)\" \\/>", RegexOptions.Multiline | RegexOptions.Compiled);
    private readonly Regex RgxDisplayTitle = new("<span class=\"icon\">\\s+<img src=\"(.+)\"\\/>\\s+<\\/span>\\s+<span class=\"value\">(.+)<", RegexOptions.Multiline | RegexOptions.Compiled);
    private readonly Regex RgxMainOrganization = new("<a href=\"\\/orgs\\/(.+)\"><img src=\"(.+)\" \\/><\\/a>\\s+<span class=\"members\">(\\d+) members<\\/span>[\\W\\w]+class=\"value\">(.+)<\\/a>[\\W\\w]+Organization rank<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Prim. Activity<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Sec. Activity<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Commitment<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>", RegexOptions.Multiline | RegexOptions.Compiled);
    private readonly Regex RgxOrganizationStars = new("<span class=\"active\">", RegexOptions.Multiline | RegexOptions.Compiled);
    private readonly Regex RgxOrganization = new("<a href=\"\\/orgs\\/(.+)\"><img src=\"(.+)\" \\/><\\/a>\\s+<span class=\"members\">(\\d+) members<\\/span>[\\W\\w]+class=\"value\\s[\\w\\d]*\">(.+)<\\/a>[\\W\\w]+Organization rank<\\/span>\\s+<strong class=\"value\\s[\\w\\d]*\">(.+)<\\/strong>", RegexOptions.Multiline | RegexOptions.Compiled);

    public FormHandleQuery() {
      InitializeComponent();

      if (Environment.GetCommandLineArgs().Any(x => x.Equals("-debug", StringComparison.InvariantCultureIgnoreCase))) {
        IsDebug = true;
      }

      // Standard-Sprachen erstellen
      CreateDefaultLocalizations();

      // Programm-Einstellungen auslesen
      ProgramSettings = GetProgramSettings();

      // Prüfen, ob die Programm-Einstellungen geladen werden konnten
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        // Ggf. Alt + Tab ermöglichen und Fenster in der Taskbar anzeigen
        if (ProgramSettings.AltTabEnabled) {
          ShowInTaskbar = true;
        }

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLong(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLong(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }

        if (ProgramSettings.ShowCacheType) {
          // Cache-Typ anzeigen
          TextBoxHandle.Size = new Size(251, TextBoxHandle.Height);
          LabelCacheType.Visible = true;
        }

        // Programm-Sprache auslesen
        ProgramTranslation = GetProgramLocalization();

        // Sprache für Controls setzen
        SetProgramLocalization();

        // Ggf. BalloonTip anzeigen
        if (ShowInitialBalloonTip) {
          NotifyIconHandleQuery.ShowBalloonTip(10000, Text, ProgramTranslation.Notification.Notify_Icon_Info, ToolTipIcon.Info);
        }

        // Veraltete Cache-Dateien löschen
        ClearCache(true);

        // Kontextmenü aktivieren
        EnableContextMenu();

        // Ggf. nach Programm-Update suchen
        if (ProgramSettings.AutoCheckForUpdate) {
          _ = CheckForUpdate(true);
        }
      }

    }

    private void UpdateAutoComplete(string handle = null) {
      // Autovervollständigung aktualisieren
      if (AutoCompleteCollection == null && handle == null) {
        AutoCompleteCollection = new();
        string handleCachePath = GetCachePath(CacheDirectoryType.Handle);
        if (Directory.Exists(handleCachePath)) {
          List<string> autoCompleteSource = new();
          foreach (string filePath in Directory.GetFiles(handleCachePath, "*.json")) {
            autoCompleteSource.Add(Path.GetFileNameWithoutExtension(filePath));
          }
          AutoCompleteCollection.AddRange(autoCompleteSource.ToArray());
        }
        TextBoxHandle.AutoCompleteCustomSource = AutoCompleteCollection;
      } else if (handle != string.Empty && !AutoCompleteCollection.Contains(handle)) {
        AutoCompleteCollection.Add(handle);
      }
    }

    private static void CreateDefaultLocalizations() {
      // Falls noch nicht vorhanden, Localization-Verzeichnis erstellen
      string localizationPath = FormSettings.GetLocalizationPath();
      if (!Directory.Exists(localizationPath)) {
        Directory.CreateDirectory(localizationPath);
      }

      // Datei für die Sprache "Deutsch" erstellen
      File.WriteAllText(Path.Combine(localizationPath, "de-DE.json"), Encoding.UTF8.GetString(Properties.Resources.de_DE), Encoding.Default);

      // Falls noch nicht vorhanden, Datei für die Sprache "English" erstellen
      File.WriteAllText(Path.Combine(localizationPath, "en-US.json"), Encoding.UTF8.GetString(Properties.Resources.en_US), Encoding.Default);
    }

    internal Translation GetProgramLocalization() {
      Translation rtnVal = null;

      // Aktuell konfigurierte Sprache ermitteln
      string localizationPath = FormSettings.GetLocalizationPath();
      foreach (string languagePath in Directory.GetFiles(localizationPath, "*.json")) {
        Translation translation = JsonSerializer.Deserialize<Translation>(File.ReadAllText(languagePath, Encoding.UTF8));
        if (translation?.Language == ProgramSettings.Language) {
          rtnVal = translation;
          break;
        }
      }

      // Fallback auf Standard-Sprache
      if (rtnVal == null) {
        rtnVal = new();
      }

      return rtnVal;
    }

    private void SetProgramLocalization() {
      // Sprache für Controls setzen
      LabelHandle.Text = ProgramTranslation.Window.Handle;
      TextBoxHandle.PlaceholderText = ProgramTranslation.Window.Handle_Placeholder;
      AnzeigenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Show;
      EinstellungenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Settings;
      LokalerCacheToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Local_Cache;
      BeendenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Close;
      UeberToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.About;
      AufUpdatePruefenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Check_For_Update;
    }

    internal Settings GetProgramSettings() {
      Settings rtnVal = null;

      // Einstellungen aus Datei lesen
      string settingsFilePath = GetSettingsFilePath();
      if (File.Exists(settingsFilePath)) {
        rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsFilePath));
      } else {
        Version programVersion = GetProgramVersion();
        foreach (string directory in Directory.GetDirectories(Directory.GetParent(GetSaveFilesRootPath()).FullName).OrderByDescending(x => x)) {
          Version version = new(Path.GetFileName(directory) + ".0");
          if (version < programVersion) {
            string legacySettingsFilePath = Path.Combine(directory, GetSettingsFileName());
            if (File.Exists(legacySettingsFilePath)) {
              rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(legacySettingsFilePath));
              if (rtnVal != null) {
                File.Copy(legacySettingsFilePath, settingsFilePath);
              }
            }
            break;
          }
        }
      }

      // Wenn die Einstellungen nicht geladen werden konnten, Einstellungen-Fenster anzeigen
      if (rtnVal == null) {
        rtnVal = ShowProperties();
      }

      if (rtnVal == null) {
        rtnVal = new();
      }

      return rtnVal;
    }

    internal static string GetSettingsFilePath() {
      return Path.Combine(GetSaveFilesRootPath(), GetSettingsFileName());
    }

    internal static string GetSettingsFileName() {
      return $"{Application.ProductName}.settings.json";
    }

    protected override CreateParams CreateParams {
      // Fenster von Alt + Tab verbergen
      get {
        CreateParams cp = base.CreateParams;
        if (ProgramSettings != null && !ProgramSettings.AltTabEnabled) {
          // turn on WS_EX_TOOLWINDOW style bit
          cp.ExStyle |= 0x80;
        }
        return cp;
      }
    }

    private void ShowWindow() {
      // Fenster einblenden
      Visible = true;
      if (!User32Wrappers.SetForegroundWindow(Handle)) {
        Activate();
        BringToFront();
      }
      TextBoxHandle.SelectAll();
      TextBoxHandle.Focus();
    }

    private void FormHandleQuery_Shown(object sender, EventArgs e) {
      // Fenster-Größe initlal verkleinern
      Size = new Size(Width, 31);

      // Fenster an die richtige Position bringen
      if (ProgramSettings?.RememberWindowLocation == true && ProgramSettings?.WindowLocation != Point.Empty && ModifierKeys != Keys.Shift) {
        Location = ProgramSettings.WindowLocation;
      } else {
        MoveWindowToDefaultLocation();
      }

      // Autovervollständigung aktualisieren
      UpdateAutoComplete();

      // Ggf. Globale Tastenabfrage erstellen
      if (ProgramSettings.GlobalHotkey != Keys.None) {
        HotKey = new();
        HotKey.KeyDown += HotKey_KeyDown;
        HotKey.HookedKeys.Add(ProgramSettings.GlobalHotkey);
        HotKey.Hook();
      }
    }

    private void MoveWindowToDefaultLocation() {
      CenterToScreen();
      Location = new Point(Location.X, 0);
    }

    private void HotKey_KeyDown(object sender, KeyEventArgs e) {
      // Prüfen, ob die Modifizierer exakt übereinstimmen
      if (ProgramSettings.GlobalHotkeyModifierCtrl == e.Control &&
        ProgramSettings.GlobalHotkeyModifierAlt == e.Alt &&
        ProgramSettings.GlobalHotkeyModifierShift == e.Shift) {
        e.SuppressKeyPress = true;
        // Fenster einblenden
        ShowWindow();
      }
    }

    private async Task<bool> CheckForUpdate(bool batch = false) {
      // Prüfen, ob auf GitHub eine aktuellere Version des Tools veröffentlicht wurde
      using HttpClient client = new();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
      bool error = true;
      try {
        string jsonResult = await client.GetStringAsync("https://api.github.com/repos/Kuehlwagen/Star-Citizen-Handle-Query/releases/latest");
        if (!string.IsNullOrWhiteSpace(jsonResult)) {
          GitHubRelease gitHubRelease = JsonSerializer.Deserialize<GitHubRelease>(jsonResult);
          if (gitHubRelease != null && !string.IsNullOrEmpty(gitHubRelease.tag_name) && gitHubRelease.tag_name.StartsWith("v")) {
            if (GetProgramVersion() < new Version(gitHubRelease.tag_name[1..])) {
              NotifyIconHandleQuery.BalloonTipClicked += NotifyIconHandleQuery_BalloonTipClicked;
              NotifyIconHandleQuery.Tag = gitHubRelease;
              NotifyIconHandleQuery.ShowBalloonTip(30000, Text, $"{ProgramTranslation.Notification.Update_Info}: {gitHubRelease.tag_name}\r\n{ProgramTranslation.Notification.Update_Info_Show_Release_Notes}", ToolTipIcon.Info);
            } else if (!batch) {
              NotifyIconHandleQuery.ShowBalloonTip(30000, Text, $"{ProgramTranslation.Notification.Update_Up_To_Date}", ToolTipIcon.Info);
            }
            error = false;
          }
        }
      } catch { }
      if (error && !batch) {
        NotifyIconHandleQuery.ShowBalloonTip(30000, Text, $"{ProgramTranslation.Notification.Update_Error}", ToolTipIcon.Warning);
      }
      return !error;
    }

    private static void OpenGitHubReleasePage(GitHubRelease gitHubRelease) {
      Process.Start("explorer", gitHubRelease.html_url);
    }

    private void NotifyIconHandleQuery_BalloonTipClicked(object sender, EventArgs e) {
      // GitHub-Seite mit Informationen zum Update öffnen
      if ((sender as NotifyIcon).Tag is GitHubRelease gitHubRelease) {
        OpenGitHubReleasePage(gitHubRelease);
        NotifyIconHandleQuery.Click -= NotifyIconHandleQuery_BalloonTipClicked;
      }
    }

    private async void TextBoxHandle_KeyDown(object sender, KeyEventArgs e) {
      // Handle-Textbox Tastendrücke verarbeiten
      switch (e.KeyCode) {
        case Keys.Oemplus:
        case Keys.Add:
          // Ggf. Handle-Kommentar aktivieren
          e.SuppressKeyPress = true;
          if (PanelInfo.Controls.Count > 0) {
            (PanelInfo.Controls[0] as UserControlHandle).ActivateComment();
          }
          break;
        case Keys.Enter:
          e.SuppressKeyPress = true;
          TextBoxHandle.Text = TextBoxHandle.Text.Trim();
          bool forceLive = e.Control;
          if (!string.IsNullOrWhiteSpace(TextBoxHandle.Text)) {
            // Ggf. existierendes UserControl entfernen
            RemoveUserControls();
            // Cache-Typ leeren
            LabelCacheType.Text = string.Empty;
            // Textbox bis zum Ergebnis deaktivieren
            TextBoxHandle.Enabled = false;
            // Handle-Informationen auslesen
            HandleInfo handleInfo = await GetHandleInfo<HandleInfo>(forceLive, TextBoxHandle.Text, ProgramSettings, CacheDirectoryType.Handle);

            // Cache-Typ darstellen
            if (ProgramSettings.ShowCacheType && !string.IsNullOrWhiteSpace(handleInfo?.Source)) {
              LabelCacheType.Text = handleInfo.Source.ToUpper();
              switch (LabelCacheType.Text) {
                case "LIVE":
                  LabelCacheType.ForeColor = Color.Green;
                  break;
                case "LOCAL":
                  LabelCacheType.ForeColor = Color.OrangeRed;
                  break;
              }
            }

            // Ggf. Cache-Verzeichnisse erstellen
            CreateDirectory(CacheDirectoryType.Handle);
            CreateDirectory(CacheDirectoryType.HandleAdditional);
            CreateDirectory(CacheDirectoryType.HandleAvatar);
            CreateDirectory(CacheDirectoryType.HandleDisplayTitle);
            CreateDirectory(CacheDirectoryType.OrganizationAvatar);

            // UserControl mit Handle-Informationen hinzufügen
            PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, forceLive));
            Size = new Size(Size.Width, Size.Height + 78);

            // Ggf. UserControl mit Organisation-Informationen hinzufügen
            if (handleInfo?.HttpResponse?.StatusCode == HttpStatusCode.OK && handleInfo.Organizations.MainOrganization != null) {
              PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.Organizations.MainOrganization, ProgramSettings, true, forceLive));
              Size = new Size(Size.Width, Size.Height + (handleInfo.Organizations.MainOrganization.Name != string.Empty ? 78 : 25));
            }

            // Ggf. UserControls mit Affiliate-Informationen hinzufügen
            if (handleInfo?.Organizations?.Affiliations?.Count > 0) {
              int affiliatesAdded = 0;
              for (int i = 0; i < handleInfo.Organizations.Affiliations.Count && affiliatesAdded < ProgramSettings.AffiliationsMax; i++) {
                // Prüfen, ob ausgeblendete Affiliationen dargestellt werden sollen
                if (!handleInfo.Organizations.Affiliations[i].Redacted || !ProgramSettings.HideRedactedAffiliations) {
                  PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.Organizations.Affiliations[i], ProgramSettings, false, forceLive));
                  Size = new Size(Size.Width, Size.Height + (!string.IsNullOrWhiteSpace(handleInfo.Organizations.Affiliations[i].Name) ? 78 : 25));
                  affiliatesAdded++;
                }
              }
            }

            // Autovervollständigung aktualisieren
            UpdateAutoComplete(handleInfo?.HttpResponse?.StatusCode == HttpStatusCode.OK && handleInfo?.Profile?.Handle != null ? handleInfo.Profile.Handle : String.Empty);

            // Textbox wieder aktivieren und Text markieren
            TextBoxHandle.Enabled = true;
            TextBoxHandle.SelectAll();
            TextBoxHandle.Focus();
          }
          break;
        case Keys.Escape:
          e.SuppressKeyPress = true;
          // Fenster verstecken
          Visible = false;
          break;
      }
    }

    private void RemoveUserControls() {
      // Ggf. UserControl entfernen
      if (PanelInfo.Controls.Count > 0) {
        for (int i = PanelInfo.Controls.Count - 1; i >= 0; i--) {
          Control control = PanelInfo.Controls[i];
          if (control is UserControlHandle ctrlHandle) {
            ctrlHandle.PictureBoxHandleAvatar.Image?.Dispose();
            ctrlHandle.PictureBoxHandleAvatar.Image = null;
            ctrlHandle.PictureBoxDisplayTitle.Image?.Dispose();
            ctrlHandle.PictureBoxDisplayTitle.Image = null;
            ctrlHandle.Dispose();
          } else if (control is UserControlOrganization ctrlOrganization) {
            ctrlOrganization.PictureBoxOrganization.Image?.Dispose();
            ctrlOrganization.PictureBoxOrganization.Image = null;
            ctrlOrganization.PictureBoxOrganizationRank.Image?.Dispose();
            ctrlOrganization.PictureBoxOrganizationRank.Image = null;
            ctrlOrganization.Dispose();
          }
        }
        PanelInfo.Controls.Clear();
      }
      Size = new Size(Width, 31);
    }

    public async Task<HandleInfo> GetHandleInfo<T>(bool forceLive, string name, Settings programSettings, CacheDirectoryType infoType) where T : new() {
      HandleInfo rtnVal = default;

      // Informationen aus Datei auslesen
      string infoJsonPath = GetCachePath(infoType, name);
      if (File.Exists(infoJsonPath) && new FileInfo(infoJsonPath).LastWriteTime > DateTime.Now.AddDays(programSettings.LocalCacheMaxAge * -1)) {
        rtnVal = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(infoJsonPath, Encoding.UTF8));
        if (rtnVal != null) {
          rtnVal.Source = "Local";
          rtnVal.HttpResponse = new() {
            StatusCode = HttpStatusCode.OK
          };
        }
      }

      // Informationen live auslesen, wenn die Datei nicht gelesen werden konnte
      if (rtnVal == null || forceLive) {
        rtnVal = await GetLiveHandleInfo(name);
      }

      // Neues HandleInfo-Objekt erstellen, wenn der Rückgabewert null sein sollte
      if (rtnVal == null) {
        rtnVal = new();
      }

      return rtnVal;
    }

    public async Task<HandleInfo> GetLiveHandleInfo(string handle) {
      HandleInfo reply = new() {
        Profile = new() {
          Handle = handle,
          Url = $"https://robertsspaceindustries.com/citizens/{handle}"
        }
      };

      if (!string.IsNullOrWhiteSpace(handle)) {
        reply.HttpResponse = await GetSource($"{handle}_Profile", reply.Profile.Url);
        if (reply.HttpResponse.StatusCode == HttpStatusCode.OK && reply.HttpResponse.Source != null) {

          // Live
          reply.Source = "Live";

          // UEE Citizen Record, Community Monicker, Handle, Enlisted, Fluency
          MatchCollection mcIdCmHandleEnlistedFluency = RgxIdCmHandleEnlistedFluency.Matches(reply.HttpResponse.Source);
          if (mcIdCmHandleEnlistedFluency.Count >= 5) {
            reply.Profile.UeeCitizenRecord = mcIdCmHandleEnlistedFluency[0].Groups[1].Value;
            reply.Profile.CommunityMonicker = HttpUtility.HtmlDecode(mcIdCmHandleEnlistedFluency[1].Groups[1].Value);
            reply.Profile.Handle = mcIdCmHandleEnlistedFluency[2].Groups[1].Value;
            if (DateTime.TryParseExact(mcIdCmHandleEnlistedFluency[3].Groups[1].Value, "MMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime enlisted)) {
              reply.Profile.Enlisted = enlisted;
            }
            reply.Profile.Fluency.AddRange(mcIdCmHandleEnlistedFluency[4].Groups[1].Value.Replace(" ", string.Empty).Split(","));
          }

          // Avatar
          MatchCollection mcAvatar = RgxAvatar.Matches(reply.HttpResponse.Source);
          if (mcAvatar.Count == 1) {
            reply.Profile.AvatarUrl = CorrectUrl(mcAvatar[0].Groups[1].Value);
          }

          // Display Title
          MatchCollection mcDisplayTitle = RgxDisplayTitle.Matches(reply.HttpResponse.Source);
          if (mcDisplayTitle.Count == 1 && mcDisplayTitle[0].Groups.Count == 3) {
            reply.Profile.DisplayTitle = mcDisplayTitle[0].Groups[2].Value;
            reply.Profile.DisplayTitleAvatarUrl = CorrectUrl(mcDisplayTitle[0].Groups[1].Value);
          }

          // Organizations
          reply.Organizations = await GetOrganizationsInfo(handle);

        } else {
          reply.HttpResponse.StatusCode = reply.HttpResponse.StatusCode != null ? reply.HttpResponse.StatusCode : HttpStatusCode.InternalServerError;
          reply.HttpResponse.ErrorText = reply.HttpResponse.ErrorText;
        }
      } else {
        reply.HttpResponse.StatusCode = HttpStatusCode.BadRequest;
        reply.HttpResponse.ErrorText = $"{reply.HttpResponse.StatusCode}: No handle provided";
      }

      return reply;
    }

    private async Task<OrganizationsInfo> GetOrganizationsInfo(string handle) {
      OrganizationsInfo reply = new();

      HttpInfo httpInfo = await GetSource($"{handle}_Organizations", $"https://robertsspaceindustries.com/citizens/{handle}/organizations");
      if (httpInfo.StatusCode.HasValue && httpInfo.StatusCode == HttpStatusCode.OK && httpInfo.Source != null) {

        string[] organizations = httpInfo.Source.Split("<div class=\"title\">");
        if (organizations.Length > 1) {

          foreach (string organization in organizations) {
            if (organization.StartsWith("Main organization")) {

              // Main Organization
              MatchCollection mcMainOrganization = RgxMainOrganization.Matches(organization);
              if (mcMainOrganization.Count == 1 && mcMainOrganization[0].Groups.Count == 9) {
                reply.MainOrganization = new() {
                  Url = $"https://robertsspaceindustries.com/orgs/{mcMainOrganization[0].Groups[1].Value}",
                  Sid = mcMainOrganization[0].Groups[1].Value,
                  AvatarUrl = CorrectUrl(mcMainOrganization[0].Groups[2].Value),
                  Members = Convert.ToInt32(mcMainOrganization[0].Groups[3].Value),
                  Name = mcMainOrganization[0].Groups[4].Value,
                  RankName = mcMainOrganization[0].Groups[5].Value,
                  PrimaryActivity = mcMainOrganization[0].Groups[6].Value,
                  SecondaryActivity = mcMainOrganization[0].Groups[7].Value,
                  Commitment = mcMainOrganization[0].Groups[8].Value,
                  Redacted = false
                };
                // Main Organization Rank Stars
                MatchCollection mcMainOrganizationRankStars = RgxOrganizationStars.Matches(organization);
                reply.MainOrganization.RankStars = mcMainOrganizationRankStars.Count;
              } else {
                reply.MainOrganization = new() {
                  Redacted = true
                };
              }

            } else if (organization.StartsWith("Affiliation")) {

              // Affiliation
              MatchCollection mcOrganization = RgxOrganization.Matches(organization);
              if (mcOrganization.Count > 0 && mcOrganization[0].Groups.Count == 6) {
                if (reply.Affiliations == null) {
                  reply.Affiliations = new List<OrganizationInfo>();
                }
                reply.Affiliations.Add(new OrganizationInfo() {
                  Url = $"https://robertsspaceindustries.com/orgs/{mcOrganization[0].Groups[1].Value}",
                  Sid = mcOrganization[0].Groups[1].Value,
                  AvatarUrl = CorrectUrl(mcOrganization[0].Groups[2].Value),
                  Members = Convert.ToInt32(mcOrganization[0].Groups[3].Value),
                  Name = mcOrganization[0].Groups[4].Value,
                  RankName = mcOrganization[0].Groups[5].Value,
                  Redacted = false
                });
                // Affiliation Rank Stars
                MatchCollection mcAffiliationRankStars = RgxOrganizationStars.Matches(organization);
                reply.Affiliations[^1].RankStars = mcAffiliationRankStars.Count;
              } else {
                reply.Affiliations.Add(new OrganizationInfo() {
                  Redacted = true
                });
              }

            }
          }

        }

      }

      return reply;
    }

    private static async Task<HttpInfo> GetSource(string sourceExportName, string url) {
      HttpInfo rtnVal = new();

      using HttpClient client = new();
      try {
        rtnVal.Source = await client.GetStringAsync(url);
        int index = rtnVal.Source.IndexOf("<div class=\"page-wrapper\">");
        if (index >= 0) {
          rtnVal.Source = rtnVal.Source[index..];
        }
        index = rtnVal.Source.IndexOf("<script type=\"text/plain\" data-cookieconsent=\"statistics\">");
        if (index >= 0) {
          rtnVal.Source = rtnVal.Source[..index];
        }
        if (IsDebug) {
          ExportSource(sourceExportName, rtnVal.Source);
        }
        rtnVal.StatusCode = HttpStatusCode.OK;
      } catch (HttpRequestException ex) {
        rtnVal.Source = string.Empty;
        rtnVal.ErrorText = $"{ex.StatusCode}: {ex.Message}";
        rtnVal.StatusCode = ex.StatusCode;
      }

      return rtnVal;
    }

    private static string CorrectUrl(string url) {
      return url.StartsWith("/") ? $"https://robertsspaceindustries.com{url}" : url;
    }

    private static void ExportSource(string handle, string source) {
      CreateDirectory(CacheDirectoryType.Source);
      File.WriteAllText(Path.Combine(GetCachePath(CacheDirectoryType.Source), $"{handle}.txt"), source, Encoding.Default);
    }

    private void BeendenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Programm beenden
      Application.Exit();
    }

    private void NotifyIconHandleQuery_MouseClick(object sender, MouseEventArgs e) {
      // Fenster einblenden, in den Vordergrund holen und Textbox fokussieren
      if (e.Button == MouseButtons.Left) {
        ShowWindow();
      }
    }

    private void AnzeigenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Fenster einblenden, in den Vordergrund holen und Textbox fokussieren
      ShowWindow();
    }

    private void EinstellungenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Einstellungen anzeigen
      EnableContextMenu(false);
      ShowProperties(true);
      EnableContextMenu();
    }

    private Settings ShowProperties(bool mitProgramSettings = false) {
      Settings rtnVal = null;

      // Einstellungen-Dialog anzeigen
      using FormSettings frm = new(mitProgramSettings ? ProgramSettings : null);
      if (frm.ShowDialog() == DialogResult.OK) {
        rtnVal = frm.ProgramSettings;
      }

      if (rtnVal != null) {

        if (mitProgramSettings) {
          ProgramSettings = rtnVal;
          RestartProgram();
        } else {
          ShowInitialBalloonTip = true;
        }

      }

      return rtnVal;
    }

    private void ResetHandle() {
      TextBoxHandle.Text = string.Empty;
      LabelCacheType.Text = string.Empty;
    }

    private void LokalerCacheToolStripMenuItem_Click(object sender, EventArgs e) {
      // Lokalen Cache leeren
      EnableContextMenu(false);
      RemoveUserControls();
      ResetHandle();
      using FormLocalCache frm = new(ProgramSettings, ProgramTranslation);
      switch (frm.ShowDialog()) {
        case DialogResult.Yes:
          ClearCache(false);
          break;
      }
      EnableContextMenu();
    }

    private void ClearCache(bool onlyExpired) {
      bool weiter = true;
      if (!onlyExpired) {
        weiter = MessageBox.Show(ProgramTranslation.Window.MessageBoxes.Clear_Local_Cache_Question,
          Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
      }

      if (weiter) {
        // Ggf. UserControl entfernen
        RemoveUserControls();

        ResetHandle();

        // Cache leeren
        DeleteDirectoryFiles(CacheDirectoryType.Handle, onlyExpired);
        if (!onlyExpired) {
          DeleteDirectoryFiles(CacheDirectoryType.HandleAdditional, onlyExpired);
        }
        DeleteDirectoryFiles(CacheDirectoryType.HandleAvatar, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.HandleDisplayTitle, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.Organization, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.OrganizationAvatar, onlyExpired);

        // Autovervollständigung neu einlesen
        if (!onlyExpired) {
          AutoCompleteCollection.Clear();
          AutoCompleteCollection = null;
          UpdateAutoComplete();
        }

        if (!onlyExpired) {
          MessageBox.Show(ProgramTranslation.Window.MessageBoxes.Local_Cache_Cleared, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    private void DeleteDirectoryFiles(CacheDirectoryType type, bool onlyExpired) {
      // Dateien aus dem Verzeichnis löschen
      string cachePath = GetCachePath(type);
      if (Directory.Exists(cachePath)) {
        foreach (string filePath in Directory.GetFiles(cachePath)) {
          try {
            if (!onlyExpired || new FileInfo(filePath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
              File.SetAttributes(filePath, FileAttributes.Normal);
              File.Delete(filePath);
            }
          } catch { }
        }
      }
    }

    private void UeberToolStripMenuItem_Click(object sender, EventArgs e) {
      // Über-Hinweismeldung anzeigen
      EnableContextMenu(false);
      MessageBox.Show($"{GetProgramVersionString()} by Kuehlwagen", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      EnableContextMenu();
    }

    private static Version GetProgramVersion() {
      // Programmversion ermitteln
      return Assembly.GetExecutingAssembly().GetName().Version;
    }

    private static string GetProgramVersionString() {
      // Programmversion als String ermitteln
      return GetVersionString(GetProgramVersion());
    }

    private static string GetVersionString(Version version) {
      // Version als String ermitteln
      return $"v{version.Major}.{ version.Minor}.{ version.Build}";
    }

    private async void AufUpdatePruefenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Nach Programmaktualisierung suchen
      EnableContextMenu(false);
      await CheckForUpdate();
      EnableContextMenu();
    }

    internal static string GetCachePath(CacheDirectoryType type, string name = "") {
      string rtnVal = string.Empty;

      // Verzeichnis ermitteln
      switch (type) {
        case CacheDirectoryType.Root:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache");
          break;
        case CacheDirectoryType.Handle:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), $@"Cache\Handle\{(!string.IsNullOrWhiteSpace(name) ? $"{name}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.HandleAvatar:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Handle_Avatar\");
          break;
        case CacheDirectoryType.HandleAdditional:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), $@"Cache\Handle_Additional\{(!string.IsNullOrWhiteSpace(name) ? $"{name}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.HandleDisplayTitle:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Handle_DisplayTitle\");
          break;
        case CacheDirectoryType.Organization:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), $@"Cache\Organization\{(!string.IsNullOrWhiteSpace(name) ? $"{name}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.OrganizationAvatar:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Organization_Avatar\");
          break;
        case CacheDirectoryType.Source:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Source");
          break;
      }

      return rtnVal;
    }

    internal static string GetSaveFilesRootPath() {
      return Application.LocalUserAppDataPath;
    }

    public enum CacheDirectoryType {
      Root,
      Handle,
      HandleAdditional,
      HandleAvatar,
      HandleDisplayTitle,
      Organization,
      OrganizationAvatar,
      Source
    }

    private void RestartProgram() {
      RemoveUserControls();
      Application.Restart();
    }

    private void FormHandleQuery_FormClosing(object sender, FormClosingEventArgs e) {
      // Globale Taste wieder freigeben
      if (HotKey?.HookedKeys?.Count > 0) {
        HotKey.Unhook();
        HotKey = null;
      }

      // Fensterposition merken
      ProgramSettings.WindowLocation = ProgramSettings.RememberWindowLocation ? Location : Point.Empty;
      string settingsFilePath = GetSettingsFilePath();
      try {
        File.WriteAllText(settingsFilePath, JsonSerializer.Serialize(ProgramSettings, new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }), Encoding.UTF8);
      } catch { }
    }

    public static string GetString(string value, string preValue = "") {
      return !string.IsNullOrWhiteSpace(value) ? $"{(!string.IsNullOrWhiteSpace(preValue) ? preValue : string.Empty)}{value}" : string.Empty;
    }

    public static async Task<Image> GetImage(CacheDirectoryType imageType, string url, string name, int localCacheMaxAge, bool forceLive = false) {
      Image rtnVal = null;

      if (!string.IsNullOrWhiteSpace(url)) {
        if (url.Count(x => x == '/') > 2) {
          string filePath = GetImagePath(imageType, url, name);
          if (forceLive || !File.Exists(filePath) || new FileInfo(filePath).LastWriteTime < DateTime.Now.AddDays(localCacheMaxAge * -1)) {
            using Stream urlStream = await GetImageFromUrl(url);
            if (urlStream != null) {
              try {
                using FileStream fileStream = new(filePath, FileMode.OpenOrCreate);
                urlStream.CopyTo(fileStream);
              } catch { }
            }
          }
          if (File.Exists(filePath)) {
            rtnVal = Image.FromFile(filePath);
          }
        }
      }

      if (rtnVal == null && imageType == CacheDirectoryType.HandleAvatar) {
        rtnVal = Properties.Resources.Avatar_Default;
      }

      return rtnVal;
    }

    public static string GetImagePath(CacheDirectoryType imageType, string url, string name) {
      string rtnVal = string.Empty;

      switch (imageType) {
        case CacheDirectoryType.HandleAvatar:
        case CacheDirectoryType.OrganizationAvatar:
        case CacheDirectoryType.HandleDisplayTitle:
          rtnVal = Path.Combine(GetCachePath(imageType), GetCorrectFileName($"{name}{url[url.LastIndexOf(".")..]}"));
          break;
      }

      return rtnVal;
    }

    public static string GetCorrectFileName(string name) {
      string rtnVal = name;
      foreach (Char c in Path.GetInvalidFileNameChars()) {
        rtnVal = rtnVal.Replace(c, '-');
      }
      return rtnVal;
    }

    public static async Task<Stream> GetImageFromUrl(string url) {
      Stream rtnVal = null;

      using HttpClient client = new();
      try {
        rtnVal = await client.GetStreamAsync(url);
      } catch { }

      return rtnVal;
    }

    public static void CreateDirectory(CacheDirectoryType imageType) {
      string directoryPath = GetCachePath(imageType);
      if (!Directory.Exists(directoryPath)) {
        Directory.CreateDirectory(directoryPath);
      }
    }

    private void EnableContextMenu(bool enable = true) {
      AnzeigenToolStripMenuItem.Enabled = enable;
      EinstellungenToolStripMenuItem.Enabled = enable;
      UeberToolStripMenuItem.Enabled = enable;
      LokalerCacheToolStripMenuItem.Enabled = enable;
      AufUpdatePruefenToolStripMenuItem.Enabled = enable;
    }

    private void TextBoxHandle_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrWhiteSpace((sender as TextBox).Text)) {
        RemoveUserControls();
      }
    }

    private void LabelHandle_MouseDown(object sender, MouseEventArgs e) {
      if (ModifierKeys == Keys.Control) {
        switch (e.Button) {
          case MouseButtons.Left:
            _ = User32Wrappers.ReleaseCapture();
            _ = User32Wrappers.SendMessage(Handle, User32Wrappers.WM_NCLBUTTONDOWN, User32Wrappers.HT_CAPTION, 0);
            break;
          case MouseButtons.Middle:
            MoveWindowToDefaultLocation();
            break;
        }
      }
    }

    private void LabelHandle_MouseCaptureChanged(object sender, EventArgs e) {
      SetHandleLableCursor();
    }

    private void LabelHandle_MouseMove(object sender, MouseEventArgs e) {
      SetHandleLableCursor();
    }

    private void SetHandleLableCursor() {
      LabelHandle.Cursor = ModifierKeys == Keys.Control ? Cursors.SizeAll : Cursors.Default;
    }

  }

}
