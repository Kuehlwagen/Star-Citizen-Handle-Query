using SCHQ_Protos;
using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Properties;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Collections;
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

    internal const int SnapDistance = 10;
    private readonly int InitialWindowStyle = 0;
    private FormLogMonitor LogMonitorForm = null;
    private FormRelations RelationsForm = null;
    private FormLocations LocationsForm = null;
    private readonly Translation ProgramTranslation;
    private Settings ProgramSettings;
    private GlobalHotKey HotKey;
    private AutoCompleteStringCollection AutoCompleteCollection;
    private bool ShowInitialBalloonTip = false;
    private static bool IsDebug = false;
    internal static CancellationTokenSource CancelToken = new();

    #region Regex
    private readonly Regex RgxIdCmHandleEnlistedFluency = RgxIdCmHandleEnlistedFluencyMethod();
    private readonly Regex RgxLocation = RgxLocationMethod();
    private readonly Regex RgxAvatar = RgxAvatarMethod();
    private readonly Regex RgxDisplayTitle = RgxDisplayTitleMethod();
    private readonly Regex RgxMainOrganization = RgxMainOrganizationMethod();
    private readonly Regex RgxOrganizationStars = RgxOrganizationStarsMethod();
    private readonly Regex RgxOrganization = RgxOrganizationMethod();

    [GeneratedRegex("<strong class=\"value\">(.+)</strong>", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxIdCmHandleEnlistedFluencyMethod();
    [GeneratedRegex("<span class=\"label\">Location</span>\\s+<strong class=\"value\">(.+)</strong>\\s+</p>\\s+<p class=\"entry\">", RegexOptions.Compiled | RegexOptions.Singleline)]
    private static partial Regex RgxLocationMethod();
    [GeneratedRegex("<div class=\"thumb\">\\s+<img src=\"(.+)\" \\/>", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxAvatarMethod();
    [GeneratedRegex("<span class=\"icon\">\\s+<img src=\"(.+)\"\\/>\\s+<\\/span>\\s+<span class=\"value\">(.+)<", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxDisplayTitleMethod();
    [GeneratedRegex("<a href=\"\\/orgs\\/(.+)\"><img src=\"(.+)\" \\/><\\/a>\\s+<span class=\"members\">(\\d+) members<\\/span>[\\W\\w]+class=\"value\">(.+)<\\/a>[\\W\\w]+Organization rank<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Prim. Activity<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Sec. Activity<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>[\\W\\w]+Commitment<\\/span>\\s+<strong class=\"value\">(.+)<\\/strong>", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxMainOrganizationMethod();
    [GeneratedRegex("<span class=\"active\">", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxOrganizationStarsMethod();
    [GeneratedRegex("<a href=\"\\/orgs\\/(.+)\"><img src=\"(.+)\" \\/><\\/a>\\s+<span class=\"members\">(\\d+) members<\\/span>[\\W\\w]+class=\"value\\s[\\w\\d]*\">(.+)<\\/a>[\\W\\w]+Organization rank<\\/span>\\s+<strong class=\"value\\s[\\w\\d]*\">(.+)<\\/strong>", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex RgxOrganizationMethod();
    [GeneratedRegex("^[a-z]{2}-[A-Z]{2}_*\\w*$", RegexOptions.Compiled)]
    private static partial Regex RgxLocalizationMethod();
    #endregion

    public FormHandleQuery() {
      InitializeComponent();

#if DEBUG
      IsDebug = true;
#else
      if (Environment.GetCommandLineArgs().Any(x => x.Equals("-debug", StringComparison.InvariantCultureIgnoreCase))) {
        IsDebug = true;
      }
#endif

      // Ggf. Standard-Sprachdateien erstellen
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
          InitialWindowStyle = User32Wrappers.GetWindowLongA(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLongA(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);

          // Controls verstecken, verschieben und vergrößern
          LabelLockUnlock.Visible = false;
          LabelQuery.Visible = false;
          LabelSettings.Visible = false;
          LabelHandle.Location = new Point(LabelLockUnlock.Left, LabelHandle.Top);
          TextBoxHandle.Location = new Point(LabelHandle.Right + 2, TextBoxHandle.Top);
          TextBoxHandle.Width += LabelQuery.Width + LabelSettings.Width + LabelLockUnlock.Width + 6;
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

        // Ggf. Beziehungen bereitstellen/übernehmen anzeigen
        if (ProgramSettings.Relations.ShowWindow) {
          BeziehungenBereitstellenToolStripMenuItem.Visible = true;
          BeziehungenUebernehmenToolStripMenuItem.Visible = true;
          ToolStripSeparator1.Visible = true;
        }

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
        AutoCompleteCollection = [];
        string handleCachePath = GetCachePath(CacheDirectoryType.Handle);
        if (Directory.Exists(handleCachePath)) {
          List<string> autoCompleteSource = [];
          foreach (string filePath in Directory.GetFiles(handleCachePath, "*.json")) {
            autoCompleteSource.Add(Path.GetFileNameWithoutExtension(filePath));
          }
          AutoCompleteCollection.AddRange([.. autoCompleteSource]);
        }
        TextBoxHandle.AutoCompleteCustomSource = AutoCompleteCollection;
      } else if (handle != string.Empty && !AutoCompleteCollection.Contains(handle)) {
        AutoCompleteCollection.Add(handle);
      }
    }

    private static void CreateDefaultLocalizations() {
      // Localization-Verzeichnis erstellen, falls es noch nicht existiert
      string localizationPath = Path.Combine(FormSettings.GetLocalizationPath(), "Templates");
      if (!Directory.Exists(localizationPath)) {
        Directory.CreateDirectory(localizationPath);
      }

      // Datei für die Sprache "Deutsch" erstellen, falls sie noch nicht existiert
      string localizationFilePath = Path.Combine(localizationPath, "de-DE.json");
      if (!File.Exists(localizationFilePath)) {
        File.WriteAllText(localizationFilePath, Encoding.UTF8.GetString(Resources.de_DE), Encoding.Default);
      }

      // Datei für die Sprache "English" erstellen, falls sie noch nicht existiert
      localizationFilePath = Path.Combine(localizationPath, "en-US.json");
      if (!File.Exists(localizationFilePath)) {
        File.WriteAllText(localizationFilePath, Encoding.UTF8.GetString(Resources.en_US), Encoding.Default);
      }
    }

    internal Translation GetProgramLocalization() {
      // Konfigurierte Sprache ermitteln
      Translation rtnVal = GetAllTranslations().Values
        .FirstOrDefault(x => x.Language.Equals(ProgramSettings.Language, StringComparison.InvariantCultureIgnoreCase));

      // Fallback auf Standard-Sprache
      rtnVal ??= new();

      return rtnVal;
    }

    internal static Dictionary<string, Translation> GetAllTranslations() {
      // Ressourcenmanager nach Sprachen durchsuchen
      Dictionary<string, Translation> rtnVal = Resources.ResourceManager
        .GetResourceSet(CultureInfo.CurrentCulture, false, true)
        .Cast<DictionaryEntry>()
        .Where(x => x.Value.GetType() == typeof(byte[]) && RgxLocalizationMethod().IsMatch(x.Key.ToString()))
        .Select(x => new KeyValuePair<string, Translation>(x.Key.ToString(), JsonSerializer.Deserialize<Translation>(Encoding.UTF8.GetString(x.Value as byte[]))))
        .OrderBy(x => x.Value.Language)
        .ToDictionary(x => x.Key, y => y.Value);

      // Localization-Verzeichnis nach Sprachen durchsuchen
      foreach (string languagePath in Directory.GetFiles(FormSettings.GetLocalizationPath(), "*.json")) {
        Translation translation = JsonSerializer.Deserialize<Translation>(File.ReadAllText(languagePath, Encoding.UTF8));
        if (translation?.Language?.Length > 0) {
          string translationName = Path.GetFileNameWithoutExtension(languagePath);
          rtnVal[translationName] = translation;
        }
      }

      // Nach Sprache sortieren
      rtnVal = rtnVal
        .OrderBy(x => x.Value.Language)
        .ToDictionary(x => x.Key, y => y.Value);

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
      BeziehungenBereitstellenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Export_Relations;
      BeziehungenUebernehmenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Import_Relations;
      SetToolTip(LabelLockUnlock, ProgramTranslation.Window.ToolTips.Lock_Unlock_Window);
      SetToolTip(LabelQuery, ProgramTranslation.Window.ToolTips.Query_Handle);
      SetToolTip(LabelSettings, ProgramTranslation.Window.ToolTips.Settings);
    }

    internal Settings GetProgramSettings() {
      Settings rtnVal = null;

      // Einstellungen aus Datei lesen
      string newPath = GetSettingsFilePath();
      if (File.Exists(newPath)) {
        rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(newPath));
      } else {
        Version programVersion = GetProgramVersion();
        foreach (string directory in Directory.GetDirectories(Directory.GetParent(GetSaveFilesRootPath()).FullName).OrderByDescending(x => x).Select(x => x.Split('+')[0])) {
          Version version = new(Path.GetFileName(directory) + ".0");
          if (version < programVersion) {
            string legacyPath = Path.Combine(directory, GetSettingsFileName());
            if (File.Exists(legacyPath)) {
              rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(legacyPath));
              if (rtnVal != null) {
                try {
                  File.Move(legacyPath, newPath);
                } catch { }
              }
              legacyPath = Path.Combine(directory, "Relations.json");
              if (File.Exists(legacyPath)) {
                try {
                  File.Move(legacyPath, GetCachePath(CacheDirectoryType.Root, "Relations"));
                } catch { }
              }
              legacyPath = Path.Combine(directory, "Cache");
              newPath = GetCachePath(CacheDirectoryType.Root);
              if (Directory.Exists(legacyPath) && !Directory.Exists(newPath)) {
                try {
                  Directory.Move(legacyPath, newPath);
                } catch { }
              }
              legacyPath = Path.Combine(directory, @"Localization\Templates");
              if (Directory.Exists(legacyPath)) {
                foreach (string file in Directory.GetFiles(legacyPath)) {
                  try {
                    File.Delete(file);
                  } catch { }
                }
                try {
                  Directory.Delete(legacyPath);
                } catch { }
              }
              legacyPath = Path.Combine(legacyPath, @"..\");
              newPath = FormSettings.GetLocalizationPath();
              if (Directory.Exists(legacyPath) && Directory.Exists(newPath)) {
                foreach (string file in Directory.GetFiles(legacyPath)) {
                  try {
                    File.Move(file, Path.Combine(newPath, Path.GetFileName(file)));
                  } catch { }
                }
                try {
                  Directory.Delete(legacyPath);
                } catch { }
              }
              try {
                Directory.Delete(directory);
              } catch { }
            }
            break;
          }
        }
      }

      // Wenn die Einstellungen nicht geladen werden konnten, Einstellungen-Fenster anzeigen
      rtnVal ??= ShowProperties();

      rtnVal ??= new();

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

    internal void ShowWindow() {
      // Fenster einblenden
      User32Wrappers.ShowWindow(Handle, User32Wrappers.SW_MINIMIZE);
      User32Wrappers.ShowWindow(Handle, User32Wrappers.SW_RESTORE);
      User32Wrappers.SetForegroundWindow(Handle);
      Visible = true;
      if (LogMonitorForm != null) {
        LogMonitorForm.Visible = true;
      }
      if (RelationsForm != null) {
        RelationsForm.Visible = true;
      }
      if (LocationsForm != null) {
        LocationsForm.Visible = true;
      }
      Activate();
      TextBoxHandle.SelectAll();
      TextBoxHandle.Focus();
    }

    private void FormHandleQuery_Shown(object sender, EventArgs e) {
      // Fenster-Größe initlal verkleinern
      Height = LogicalToDeviceUnits(31);

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

      // Ggf. LogFileWatcher-Fenster anzeigen
      if (ProgramSettings.LogMonitor.ShowWindow) {
        LogMonitorForm = new(ProgramSettings, ProgramTranslation);
        LogMonitorForm.Show(this);
        if (ProgramSettings?.RememberWindowLocation == true && ProgramSettings?.LogMonitor?.WindowLocation != Point.Empty && ModifierKeys != Keys.Shift) {
          LogMonitorForm.Location = ProgramSettings.LogMonitor.WindowLocation;
        } else {
          LogMonitorForm.MoveWindowToDefaultLocation();
        }
      }

      // Ggf. Beziehungen-Fenster anzeigen
      if (ProgramSettings.Relations.ShowWindow) {
        RPC_Wrapper.SetURL(ProgramSettings.Relations.RPC_URL);
        RelationsForm = new(ProgramSettings, ProgramTranslation);
        RelationsForm.Show(this);
        if (ProgramSettings?.RememberWindowLocation == true && ProgramSettings?.Relations.WindowLocation != Point.Empty && ModifierKeys != Keys.Shift) {
          RelationsForm.Location = ProgramSettings.Relations.WindowLocation;
        } else {
          RelationsForm.MoveWindowToDefaultLocation();
        }
      }

      // Ggf. Orte-Fenster anzeigen
      if (ProgramSettings.Locations.ShowWindow) {
        LocationsForm = new(ProgramSettings, ProgramTranslation);
        LocationsForm.Show(this);
        if (ProgramSettings?.RememberWindowLocation == true && ProgramSettings?.Locations?.WindowLocation != Point.Empty && ModifierKeys != Keys.Shift) {
          LocationsForm.Location = ProgramSettings.Locations.WindowLocation;
        } else {
          LocationsForm.MoveWindowToDefaultLocation();
        }
      }

      // Fenster auf jeden Fall nochmal in den Vordergrund holen
      ShowWindow();
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
          if (gitHubRelease != null && !string.IsNullOrEmpty(gitHubRelease.tag_name) && gitHubRelease.tag_name.StartsWith('v')) {
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

    public void ChangeRelation(RelationType relationType, Keys key) {
      if (PanelInfo.Controls.Count > 0) {
        switch (relationType) {
          case RelationType.Handle:
            UserControlHandle handleControl = PanelInfo.Controls[0] as UserControlHandle;
            handleControl.ChangeRelation(key);
            RelationsForm?.UpdateRelation(handleControl.HandleName, RelationType.Handle, handleControl.HandleRelation);
            break;
          case RelationType.Organization:
            UserControlOrganization orgControl = null;
            if (!ProgramSettings.Relations.ShowWindow && PanelInfo.Controls.Count > 1 && PanelInfo.Controls[1] is UserControlOrganization) {
              orgControl = PanelInfo.Controls[1] as UserControlOrganization;
            } else if (ProgramSettings.Relations.ShowWindow && PanelInfo.Controls.Count > 2) {
              orgControl = PanelInfo.Controls[2] as UserControlOrganization;
            }
            if (orgControl != null) {
              orgControl.ChangeRelation(key);
              RelationsForm?.UpdateRelation(orgControl.SID, RelationType.Organization, orgControl.Relation);
            }
            break;
        }
      }
    }

    public RelationValue GetOrganizationRelation(string sid) {
      RelationValue rtnVal = RelationValue.NotAssigned;
      if (RelationsForm != null) {
        rtnVal = RelationsForm.GetOrganizationRelation(sid);
      }
      return rtnVal;
    }

    public RelationValue GetHandleRelation(string handle) {
      RelationValue rtnVal = RelationValue.NotAssigned;
      if (RelationsForm != null) {
        rtnVal = RelationsForm.GetHandleRelation(handle);
      }
      return rtnVal;
    }

    private void TextBoxHandle_KeyDown(object sender, KeyEventArgs e) {
      // Handle-Textbox Tastendrücke verarbeiten
      if (e.Control) {
        switch (e.KeyCode) {
          case Keys.D0:
          case Keys.D1:
          case Keys.D2:
          case Keys.D3:
          case Keys.D4:
          case Keys.NumPad0:
          case Keys.NumPad1:
          case Keys.NumPad2:
          case Keys.NumPad3:
          case Keys.NumPad4:
            e.SuppressKeyPress = true;
            e.Handled = true;
            ChangeRelation(RelationType.Handle, e.KeyCode);
            break;
          case Keys.Enter:
            e.SuppressKeyPress = true;
            e.Handled = true;
            QueryHandle(true);
            break;
        }
      } else if (e.Shift) {
        switch (e.KeyCode) {
          case Keys.D0:
          case Keys.D1:
          case Keys.D2:
          case Keys.D3:
          case Keys.D4:
          case Keys.NumPad0:
          case Keys.NumPad1:
          case Keys.NumPad2:
          case Keys.NumPad3:
          case Keys.NumPad4:
            e.SuppressKeyPress = true;
            e.Handled = true;
            ChangeRelation(RelationType.Organization, e.KeyCode);
            break;
          case Keys.Enter:
            e.SuppressKeyPress = true;
            e.Handled = true;
            QueryHandle(true);
            break;
        }
      } else if (e.Alt) {
        switch (e.KeyCode) {
          case Keys.Enter:
            LocationsForm?.ShowWindow();
            break;
          case Keys.D0:
          case Keys.D1:
          case Keys.D2:
          case Keys.D3:
          case Keys.D4:
          case Keys.D5:
          case Keys.NumPad0:
          case Keys.NumPad1:
          case Keys.NumPad2:
          case Keys.NumPad3:
          case Keys.NumPad4:
          case Keys.NumPad5:
            e.SuppressKeyPress = true;
            e.Handled = true;
            RelationsForm?.FilterRelations(e.KeyCode);
            break;
        }
      } else {
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
            e.Handled = true;
            QueryHandle(false);
            break;
          case Keys.Escape:
            e.Handled = true;
            e.SuppressKeyPress = true;
            // Fenster verstecken
            Visible = false;
            if (LogMonitorForm != null) {
              LogMonitorForm.Visible = false;
            }
            if (RelationsForm != null) {
              RelationsForm.Visible = false;
            }
            if (LocationsForm != null) {
              LocationsForm.Visible = false;
            }
            break;
        }
      }
    }

    private async void QueryHandle(bool forceLive) {
      TextBoxHandle.Text = TextBoxHandle.Text.Trim();
      if (!string.IsNullOrWhiteSpace(TextBoxHandle.Text)) {
        // Ggf. existierendes UserControl entfernen
        RemoveUserControls();
        // Textbox bis zum Ergebnis deaktivieren
        TextBoxHandle.Enabled = false;
        LabelLockUnlock.Enabled = false;
        LabelQuery.Enabled = false;
        // Handle-Informationen auslesen
        HandleInfo handleInfo = await GetHandleInfo(forceLive, TextBoxHandle.Text, ProgramSettings, CacheDirectoryType.Handle);
        // Ggf. Beziehung aktualisieren
        handleInfo.Relation = GetHandleRelation(handleInfo.Profile.Handle);

        // Ggf. Cache-Verzeichnisse erstellen
        CreateDirectory(CacheDirectoryType.Handle);
        CreateDirectory(CacheDirectoryType.HandleAvatar);
        CreateDirectory(CacheDirectoryType.HandleDisplayTitle);
        CreateDirectory(CacheDirectoryType.OrganizationAvatar);

        // UserControl mit Handle-Informationen hinzufügen
        PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, forceLive));
        Height += LogicalToDeviceUnits(78);

        if (handleInfo?.HttpResponse?.StatusCode == HttpStatusCode.OK) {
          // Ggf. Relations-Control hinzufügen
          if (ProgramSettings.Relations.ShowWindow && !ProgramSettings.WindowIgnoreMouseInput) {
            PanelInfo.Controls.Add(new UserControlHandleRelation(ProgramTranslation));
            Height += LogicalToDeviceUnits(23);
          }

          // Ggf. UserControl mit Organisation-Informationen hinzufügen
          if (handleInfo?.Organizations?.MainOrganization != null) {
            PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.Organizations.MainOrganization, ProgramSettings, true, forceLive));
            Height += LogicalToDeviceUnits(handleInfo.Organizations.MainOrganization.Name != string.Empty ? 78 : 25);
          }

          // Ggf. UserControls mit Affiliate-Informationen hinzufügen
          if (handleInfo?.Organizations?.Affiliations?.Count > 0) {
            int affiliatesAdded = 0;
            for (int i = 0; i < handleInfo.Organizations.Affiliations.Count && affiliatesAdded < ProgramSettings.AffiliationsMax; i++) {
              // Prüfen, ob ausgeblendete Affiliationen dargestellt werden sollen
              if (!handleInfo.Organizations.Affiliations[i].Redacted || !ProgramSettings.HideRedactedAffiliations) {
                PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.Organizations.Affiliations[i], ProgramSettings, false, forceLive));
                Height += LogicalToDeviceUnits(!string.IsNullOrWhiteSpace(handleInfo.Organizations.Affiliations[i].Name) ? 78 : 25);
                affiliatesAdded++;
              }
            }
          }

          // Autovervollständigung aktualisieren
          UpdateAutoComplete(handleInfo?.HttpResponse?.StatusCode == HttpStatusCode.OK && handleInfo?.Profile?.Handle != null ? handleInfo.Profile.Handle : string.Empty);
        }

        // Textbox wieder aktivieren und Text markieren
        TextBoxHandle.Enabled = true;
        LabelLockUnlock.Enabled = true;
        LabelQuery.Enabled = true;
        TextBoxHandle.SelectAll();
        TextBoxHandle.Focus();
      }
    }

    public void SetAndQueryHandle(string handle) {
      // Handle setzen und die Suche ausführen
      if (TextBoxHandle.Enabled) {
        if (!Visible) {
          ShowWindow();
        }
        TextBoxHandle.Text = handle;
        QueryHandle(ModifierKeys == Keys.Control);
      }
    }

    private void RemoveUserControls() {
      // Ggf. UserControl entfernen
      if (PanelInfo.Controls.Count > 0) {
        CancelToken.Cancel();
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
          } else if (control is UserControlHandleRelation ctrlHandleRelation) {
            ctrlHandleRelation.Dispose();
          }
        }
        PanelInfo.Controls.Clear();
        CancelToken = new CancellationTokenSource();
      }
      Height = LogicalToDeviceUnits(31);
    }

    public async Task<HandleInfo> GetHandleInfo(bool forceLive, string name, Settings programSettings, CacheDirectoryType infoType) {
      HandleInfo rtnVal = default;

      // Informationen aus Datei auslesen
      string infoJsonPath = GetCachePath(infoType, name);
      if (File.Exists(infoJsonPath) && new FileInfo(infoJsonPath).LastWriteTime > DateTime.Now.AddDays(programSettings.LocalCacheMaxAge * -1)) {
        rtnVal = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(infoJsonPath, Encoding.UTF8));
        if (rtnVal != null) {
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
      rtnVal ??= new();

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
        reply.HttpResponse = await GetRSISource($"{handle}_Profile", reply.Profile.Url, CancelToken);
        if (reply.HttpResponse.StatusCode == HttpStatusCode.OK && reply.HttpResponse.Source != null) {

          // UEE Citizen Record, Community Monicker, Handle, Enlisted, Fluency
          MatchCollection mcIdCmHandleEnlistedFluency = RgxIdCmHandleEnlistedFluency.Matches(reply.HttpResponse.Source);
          if (mcIdCmHandleEnlistedFluency.Count >= 5) {
            reply.Profile.UeeCitizenRecord = mcIdCmHandleEnlistedFluency[0].Groups[1].Value;
            reply.Profile.CommunityMonicker = CorrectText(mcIdCmHandleEnlistedFluency[1].Groups[1].Value);
            reply.Profile.Handle = CorrectText(mcIdCmHandleEnlistedFluency[2].Groups[1].Value);
            if (DateTime.TryParseExact(mcIdCmHandleEnlistedFluency[3].Groups[1].Value, "MMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime enlisted)) {
              reply.Profile.Enlisted = enlisted;
            }
            reply.Profile.Fluency.AddRange(mcIdCmHandleEnlistedFluency[4].Groups[1].Value.Replace(" ", string.Empty).Split(","));
          }

          Match matchLocation = RgxLocation.Match(reply.HttpResponse.Source);
          if (matchLocation?.Groups.Count > 1) {
            string[] countryRegion = matchLocation.Groups[1].Value.Split(",");
            reply.Profile.Country = countryRegion[0].Trim();
            reply.Profile.Region = countryRegion.Length > 1 ? countryRegion[1].Trim() : string.Empty;
          }

          // Avatar
          MatchCollection mcAvatar = RgxAvatar.Matches(reply.HttpResponse.Source);
          if (mcAvatar.Count == 1) {
            reply.Profile.AvatarUrl = CorrectUrl(mcAvatar[0].Groups[1].Value);
          }

          // Display Title
          MatchCollection mcDisplayTitle = RgxDisplayTitle.Matches(reply.HttpResponse.Source);
          if (mcDisplayTitle.Count == 1 && mcDisplayTitle[0].Groups.Count == 3) {
            reply.Profile.DisplayTitle = CorrectText(mcDisplayTitle[0].Groups[2].Value);
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

      HttpInfo httpInfo = await GetRSISource($"{handle}_Organizations", $"https://robertsspaceindustries.com/citizens/{handle}/organizations", CancelToken);
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
                  Sid = CorrectText(mcMainOrganization[0].Groups[1].Value),
                  AvatarUrl = CorrectUrl(mcMainOrganization[0].Groups[2].Value),
                  Members = Convert.ToInt32(mcMainOrganization[0].Groups[3].Value),
                  Name = CorrectText(mcMainOrganization[0].Groups[4].Value),
                  RankName = CorrectText(mcMainOrganization[0].Groups[5].Value),
                  PrimaryActivity = CorrectText(mcMainOrganization[0].Groups[6].Value),
                  SecondaryActivity = CorrectText(mcMainOrganization[0].Groups[7].Value),
                  Commitment = CorrectText(mcMainOrganization[0].Groups[8].Value),
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
              reply.Affiliations ??= [];
              if (mcOrganization.Count > 0 && mcOrganization[0].Groups.Count == 6) {
                reply.Affiliations.Add(new OrganizationInfo() {
                  Url = $"https://robertsspaceindustries.com/orgs/{mcOrganization[0].Groups[1].Value}",
                  Sid = CorrectText(mcOrganization[0].Groups[1].Value),
                  AvatarUrl = CorrectUrl(mcOrganization[0].Groups[2].Value),
                  Members = Convert.ToInt32(mcOrganization[0].Groups[3].Value),
                  Name = CorrectText(mcOrganization[0].Groups[4].Value),
                  RankName = CorrectText(mcOrganization[0].Groups[5].Value.Replace("&", "&&")),
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

    private static string CorrectText(string text) {
      return HttpUtility.HtmlDecode(text);
    }

    internal static async Task<HttpInfo> GetSource(string url, CancellationTokenSource cancellationToken) {
      HttpInfo rtnVal = new();

      using HttpClient client = new() {
        Timeout = TimeSpan.FromSeconds(10)
      };
      try {
        rtnVal.Source = await client.GetStringAsync(url, cancellationToken.Token).ConfigureAwait(false);
        rtnVal.StatusCode = HttpStatusCode.OK;
      } catch (HttpRequestException ex) {
        rtnVal.Source = string.Empty;
        rtnVal.ErrorText = $"{ex.StatusCode}: {ex.Message}";
        rtnVal.StatusCode = ex.StatusCode;
      } catch (OperationCanceledException ex) {
        rtnVal.Source = string.Empty;
        rtnVal.ErrorText = ex.Message;
        rtnVal.StatusCode = HttpStatusCode.BadGateway;
      }

      return rtnVal;
    }

    internal static async Task<HttpInfo> GetRSISource(string sourceExportName, string url, CancellationTokenSource cancellationToken, bool isCommunityHub = false) {
      HttpInfo rtnVal = await GetSource(url, cancellationToken);

      if (rtnVal.StatusCode == HttpStatusCode.OK) {
        if (!isCommunityHub) {
          int index = rtnVal.Source.IndexOf("<div class=\"page-wrapper\">");
          if (index >= 0) {
            rtnVal.Source = rtnVal.Source[index..];
          }
          index = rtnVal.Source.IndexOf("<script type=\"text/plain\" data-cookieconsent=\"statistics\">");
          if (index >= 0) {
            rtnVal.Source = rtnVal.Source[..index];
          }
        } else {
          int index = rtnVal.Source.IndexOf("{\"props\":");
          if (index >= 0) {
            rtnVal.Source = rtnVal.Source[index..];
          }
          index = rtnVal.Source.IndexOf("</script></body></html>");
          if (index >= 0) {
            rtnVal.Source = rtnVal.Source[..index];
          }
        }
      }
      if (IsDebug) {
        ExportSource(sourceExportName, rtnVal.Source);
      }

      return rtnVal;
    }

    private static string CorrectUrl(string url) {
      return url.StartsWith('/') ? $"https://robertsspaceindustries.com{url}" : url;
    }

    private static void ExportSource(string name, string source) {
      CreateDirectory(CacheDirectoryType.Source);
      File.WriteAllText(Path.Combine(GetCachePath(CacheDirectoryType.Source), $"{name}.html"), source, Encoding.Default);
    }

    private void BeendenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Programm beenden
      Close();
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
      ShowPropertiesForm();
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

        // Ggf. UserControls entfernen
        RemoveUserControls();

        ResetHandle();

        // Cache leeren
        DeleteDirectoryFiles(CacheDirectoryType.Root, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.Handle, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.HandleAvatar, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.HandleDisplayTitle, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.OrganizationAvatar, onlyExpired);

        // Autovervollständigung neu einlesen
        if (!onlyExpired) {
          AutoCompleteCollection.Clear();
          AutoCompleteCollection = null;
          UpdateAutoComplete();

          // Ggf. Beziehungen-UserControls entfernen
          RelationsForm?.ClearRelations();

          MessageBox.Show(ProgramTranslation.Window.MessageBoxes.Local_Cache_Cleared, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

          TextBoxHandle.Focus();
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
      return $"v{version.Major}.{version.Minor}.{version.Build}";
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
        case CacheDirectoryType.Base:
          rtnVal = GetSaveFilesRootPath();
          break;
        case CacheDirectoryType.Root:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), $@"Cache\{(!string.IsNullOrWhiteSpace(name) ? $"{name}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.Handle:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), $@"Cache\Data\{(!string.IsNullOrWhiteSpace(name) ? $"{name}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.HandleAvatar:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Images\Handle");
          break;
        case CacheDirectoryType.HandleDisplayTitle:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Images\Display Title");
          break;
        case CacheDirectoryType.OrganizationAvatar:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Images\Organization");
          break;
        case CacheDirectoryType.Source:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Data\Source");
          break;
        case CacheDirectoryType.Location:
          rtnVal = Path.Combine(GetSaveFilesRootPath(), @"Cache\Images\Location");
          break;
      }

      return rtnVal;
    }

    internal static string GetSaveFilesRootPath() {
      return Application.LocalUserAppDataPath;
    }

    public enum CacheDirectoryType {
      Base,
      Root,
      Handle,
      HandleAvatar,
      HandleDisplayTitle,
      OrganizationAvatar,
      Source,
      Location
    }

    private void RestartProgram() {
      RemoveUserControls();
      DialogResult = DialogResult.Retry;
      Close();
    }

    private readonly JsonSerializerOptions JsonSerOptions = new() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private void FormHandleQuery_FormClosing(object sender, FormClosingEventArgs e) {
      // Panel leeren
      RemoveUserControls();

      // Globale Taste wieder freigeben
      if (HotKey?.HookedKeys?.Count > 0) {
        HotKey.Unhook();
        HotKey = null;
      }

      // Fensterposition merken
      ProgramSettings.WindowLocation = ProgramSettings.RememberWindowLocation ? Location : Point.Empty;
      ProgramSettings.LogMonitor.WindowLocation = LogMonitorForm != null && ProgramSettings.RememberWindowLocation ? LogMonitorForm.Location : Point.Empty;
      ProgramSettings.Relations.WindowLocation = RelationsForm != null && ProgramSettings.RememberWindowLocation ? RelationsForm.Location : Point.Empty;
      ProgramSettings.Locations.WindowLocation = LocationsForm != null && ProgramSettings.RememberWindowLocation ? LocationsForm.Location : Point.Empty;
      string settingsFilePath = GetSettingsFilePath();
      try {
        File.WriteAllText(settingsFilePath, JsonSerializer.Serialize(ProgramSettings, JsonSerOptions), Encoding.UTF8);
      } catch { }

      LogMonitorForm?.Close();
      RelationsForm?.Close();
      LocationsForm?.Close();
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
        rtnVal = Resources.Avatar_Default;
      }

      return rtnVal;
    }

    public static string GetImagePath(CacheDirectoryType imageType, string url, string name) {
      string rtnVal = string.Empty;

      switch (imageType) {
        case CacheDirectoryType.HandleAvatar:
        case CacheDirectoryType.OrganizationAvatar:
        case CacheDirectoryType.HandleDisplayTitle:
        case CacheDirectoryType.Location:
          rtnVal = Path.Combine(GetCachePath(imageType), GetCorrectFileName($"{name}{url[url.LastIndexOf('.')..]}"));
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
      BeziehungenBereitstellenToolStripMenuItem.Enabled = enable;
      BeziehungenUebernehmenToolStripMenuItem.Enabled = enable &&
        string.IsNullOrWhiteSpace(ProgramSettings.Relations.RPC_URL) &&
        string.IsNullOrWhiteSpace(ProgramSettings.Relations.RPC_Channel);
    }

    private void TextBoxHandle_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrWhiteSpace((sender as TextBox).Text)) {
        RemoveUserControls();
      }
    }

    private void LabelHandle_MouseDown(object sender, MouseEventArgs e) {
      if (!WindowLocked) {
        switch (e.Button) {
          case MouseButtons.Left:
            _ = User32Wrappers.ReleaseCapture();
            _ = User32Wrappers.SendMessageA(Handle, User32Wrappers.WM_NCLBUTTONDOWN, User32Wrappers.HT_CAPTION, 0);
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
      LabelHandle.Cursor = !WindowLocked ? Cursors.SizeAll : Cursors.Default;
    }

    private bool WindowLocked = true;
    private void LabelLockUnlock_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        WindowLocked = !WindowLocked;
        LabelLockUnlock.Image = WindowLocked ? Resources.WindowLocked : Resources.WindowUnlocked;
        LogMonitorForm?.LockUnlockWindow(WindowLocked);
        RelationsForm?.LockUnlockWindow(WindowLocked);
        LocationsForm?.LockUnlockWindow(WindowLocked);
      }
    }

    private void LabelQuery_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        QueryHandle(ModifierKeys == Keys.Control);
      }
    }

    private void LabelSettings_MouseClick(object sender, MouseEventArgs e) {
      // Einstellungen anzeigen
      ShowPropertiesForm();
    }

    private void ShowPropertiesForm() {
      // Einstellungen anzeigen
      EnableContextMenu(false);
      ShowProperties(true);
      EnableContextMenu();
    }

    private void ToolTipHandleQuery_Draw(object sender, DrawToolTipEventArgs e) {
      e.DrawBackground();
      e.DrawBorder();
      e.DrawText();
    }

    public void SetToolTip(Control control, string text = null) {
      ToolTipHandleQuery.SetToolTip(control, text ?? control.Text);
    }

    public static Color GetRelationColor(RelationValue relation) {
      var colorRelation = relation switch {
        RelationValue.Friendly => Color.Green,
        RelationValue.Neutral => Color.Gray,
        RelationValue.Bogey => Color.Orange,
        RelationValue.Bandit => Color.Red,
        _ => Color.FromArgb(19, 26, 33),
      };
      return colorRelation;
    }

    public static Color GetRelationInactiveColor(RelationValue relation) {
      var colorRelation = relation switch {
        RelationValue.Friendly => Color.FromArgb(0, 64, 0),
        RelationValue.Neutral => Color.FromArgb(64, 64, 64),
        RelationValue.Bogey => Color.FromArgb(127, 82, 0),
        RelationValue.Bandit => Color.FromArgb(127, 0, 0),
        _ => Color.FromArgb(19, 26, 33),
      };
      return colorRelation;
    }

    internal static bool ShouldSnap(int pos, int edge) {
      int delta = pos - edge;
      return (delta < 0) || (delta > 0 && delta <= SnapDistance);
    }

    internal static void CheckSnap(Form form, Point location) {
      if (ModifierKeys != Keys.Alt) {
        Rectangle bounds = Screen.FromPoint(location).Bounds;
        if (ShouldSnap(form.Left, bounds.Left)) form.Left = bounds.Left;
        if (ShouldSnap(form.Top, bounds.Top)) form.Top = bounds.Top;
        if (ShouldSnap(bounds.Right, form.Right)) form.Left = bounds.Right - form.Width;
        if (ShouldSnap(bounds.Bottom, form.Bottom)) form.Top = bounds.Bottom - form.Height;
      }
    }

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      CheckSnap(this, Location);
    }

    private void BeziehungenBereitstellenToolStripMenuItem_Click(object sender, EventArgs e) {
      using SaveFileDialog svd = new() {
        DefaultExt = "json",
        FileName = "Relations.json",
        Filter = "JSON (*.json)|*.json",
        OverwritePrompt = true
      };
      if (svd.ShowDialog() == DialogResult.OK) {
        RelationsForm?.ExportRelationInfos(svd.FileName);
      }
    }

    private void BeziehungenUebernehmenToolStripMenuItem_Click(object sender, EventArgs e) {
      using OpenFileDialog ofd = new() {
        Filter = "JSON (*.json)|*.json"
      };
      if (ofd.ShowDialog() == DialogResult.OK) {
        RelationsForm?.ImportRelationInfos(ofd.FileName);
      }
    }

    public enum CommunityHubLiveState {
      Offline,
      Live,
      Error
    }

  }

}
