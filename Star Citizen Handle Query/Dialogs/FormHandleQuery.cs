using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.ExternClasses.Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormHandleQuery : Form {

    private readonly int InitialWindowStyle = 0;
    private readonly Translation ProgramTranslation;
    private readonly Settings ProgramSettings;
    private GlobalHotKey HotKey;

    public FormHandleQuery() {
      InitializeComponent();

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

        // Veraltete Cache-Dateien löschen
        ClearCache(true);
      }

    }

    private void UpdateAutoComplete() {
      // Autovervollständigung aktualisieren
      string handleCachePath = GetCachePath(CacheDirectoryType.Handle);
      if (Directory.Exists(handleCachePath)) {
        List<string> autoCompleteSource = new();
        foreach (string filePath in Directory.GetFiles(handleCachePath, "*.json")) {
          autoCompleteSource.Add(Path.GetFileNameWithoutExtension(filePath));
        }
        AutoCompleteStringCollection collection = new();
        collection.AddRange(autoCompleteSource.ToArray());
        TextBoxHandle.AutoCompleteCustomSource = collection;
      }
    }

    private static void CreateDefaultLocalizations() {
      // Falls noch nicht vorhanden, Localization-Verzeichnis erstellen
      string localizationPath = FormSettings.GetLocalizationPath();
      if (!Directory.Exists(localizationPath)) {
        Directory.CreateDirectory(localizationPath);
      }

      // Falls noch nicht vorhanden, Datei für die Sprache "Deutsch" erstellen
      string deutschPath = Path.Combine(localizationPath, "de-DE.json");
      if (!File.Exists(deutschPath)) {
        File.WriteAllText(deutschPath, Encoding.UTF8.GetString(Properties.Resources.de_DE), Encoding.Default);
      }

      // Falls noch nicht vorhanden, Datei für die Sprache "English" erstellen
      string englishPath = Path.Combine(localizationPath, "en-US.json");
      if (!File.Exists(englishPath)) {
        File.WriteAllText(englishPath, Encoding.UTF8.GetString(Properties.Resources.en_US), Encoding.Default);
      }
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
      AnzeigenVersteckenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu_Show;
      EinstellungenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu_Settings;
      LokalenCacheLeerenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu_Clear_Local_Cache;
      NeustartenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu_Restart;
      BeendenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu_Close;
    }

    internal Settings GetProgramSettings() {
      Settings rtnVal = null;

      // Einstellungen aus Datei lesen
      string settingsFilePath = GetSettingsPath();
      if (File.Exists(settingsFilePath)) {
        rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsFilePath));
      }

      // Wenn die Einstellungen nicht geladen werden konnten, Einstellungen-Fenster anzeigen
      if (rtnVal == null || rtnVal.ApiKey.Length != 32) {
        rtnVal = ShowProperties();
      }

      return rtnVal;
    }

    internal static string GetSettingsPath() {
      return Path.Combine(Application.StartupPath, $"{Application.ProductName}.settings.json");
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
      CenterToScreen();
      Location = new Point(Location.X, 0);

      // Prüfen, ob der API-Key eingetragen wurde
      if (ProgramSettings?.ApiKey?.Length != 32) {
        MessageBox.Show($"Es muss ein 32-stelliger API-Key angegeben werden.{Environment.NewLine}Das Programm wird beendet.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Application.Exit();
      } else {
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

    private async void TextBoxHandle_KeyDown(object sender, KeyEventArgs e) {
      // Handle-Textbox Tastendrücke verarbeiten
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          if (!string.IsNullOrWhiteSpace(TextBoxHandle.Text)) {
            // Ggf. existierendes UserControl entfernen
            RemoveUserControls();
            // Cache-Typ leeren
            LabelCacheType.Text = string.Empty;
            // Textbox bis zum Ergebnis deaktivieren
            TextBoxHandle.Enabled = false;
            // Handle-Informationen auslesen
            HandleInfo handleInfo = await GetHandleInfo(e.Control);

            // Cache-Typ darstellen
            if (ProgramSettings.ShowCacheType && !string.IsNullOrWhiteSpace(handleInfo?.source)) {
              LabelCacheType.Text = handleInfo.source.ToUpper();
              switch (LabelCacheType.Text) {
                case "LIVE":
                  LabelCacheType.ForeColor = Color.Green;
                  break;
                case "CACHE":
                  LabelCacheType.ForeColor = Color.Orange;
                  break;
                case "LOCAL":
                  LabelCacheType.ForeColor = Color.OrangeRed;
                  break;
              }
            }

            // UserControl mit Handle-Informationen hinzufügen
            PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation));
            Size = new Size(Size.Width, Size.Height + 78);

            // Ggf. UserControl mit Organisation-Informationen hinzufügen
            if (handleInfo?.success == 1 && handleInfo?.data?.organization?.name != null) {
              PanelInfo.Controls.Add(new UserControlOrganization(handleInfo, ProgramSettings, -1));
              Size = new Size(Size.Width, Size.Height + (handleInfo.data.organization.name != string.Empty ? 78 : 25));
            }

            // Ggf. UserControls mit Affiliate-Informationen hinzufügen
            if (handleInfo?.data != null && handleInfo.data.affiliation != null && handleInfo.data.affiliation.Length > 0) {
              int affiliatesAdded = 0;
              for (int i = 0; i < handleInfo.data.affiliation.Length && affiliatesAdded < ProgramSettings.AffiliationsMax; i++) {
                // Prüfen, ob ausgeblendete Affiliationen dargestellt werden sollen
                if (!string.IsNullOrWhiteSpace(handleInfo.data.affiliation[i].name) || !ProgramSettings.HideRedactedAffiliations) {
                  PanelInfo.Controls.Add(new UserControlOrganization(handleInfo, ProgramSettings, i));
                  Size = new Size(Size.Width, Size.Height + (!string.IsNullOrWhiteSpace(handleInfo.data.affiliation[i].name) ? 78 : 25));
                  affiliatesAdded++;
                }
              }
            }

            // Autovervollständigung aktualisieren
            UpdateAutoComplete();
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
        foreach (UserControl control in PanelInfo.Controls) {
          if (control is UserControlHandle ctrlHandle) {
            ctrlHandle.PictureBoxHandleAvatar.Image?.Dispose();
            ctrlHandle.PictureBoxDisplayTitle.Image?.Dispose();
          } else if (control is UserControlOrganization ctrlOrganization) {
            ctrlOrganization.PictureBoxOrganization.Image?.Dispose();
            ctrlOrganization.PictureBoxOrganizationRank.Image?.Dispose();
          }
          control.Dispose();
        }
        PanelInfo.Controls.Clear();
      }
      Size = new Size(Width, 31);
    }

    private async Task<HandleInfo> GetHandleInfo(bool forceLive) {
      HandleInfo rtnVal = null;

      // Handle-Informationen aus Datei auslesen
      string handleJsonPath = GetCachePath(CacheDirectoryType.Handle, TextBoxHandle.Text);
      if (File.Exists(handleJsonPath) && new FileInfo(handleJsonPath).LastWriteTime > DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        rtnVal = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
        if (rtnVal != null) {
          rtnVal.source = "local";
        }
      }

      // Handle-Informationen via API auslesen, wenn die Datei nicht gelesen werden konnte
      if (rtnVal == null || forceLive) {
        string json = await GetApiHandleJson(ProgramSettings.ApiKey, TextBoxHandle.Text, forceLive);
        HandleInfo apiHandleInfo = null;
        try {
          apiHandleInfo = JsonSerializer.Deserialize<HandleInfo>(json);
        } catch { }
        if (apiHandleInfo == null) {
          apiHandleInfo = new HandleInfo() { message = json };
        }
        rtnVal = apiHandleInfo;
      }

      // Neues HandleInfo-Objekt erstellen, wenn der Rückgabewert null sein sollte
      if (rtnVal == null) {
        rtnVal = new();
      }

      return rtnVal;
    }

    private async Task<string> GetApiHandleJson(string apiKey, string handle, bool forceLive) {
      using HttpClient client = new();
      // JSON via API herunterladen
      string rtnVal;
      try {
        ApiMode mode = forceLive ? ApiMode.Live : ProgramSettings.ApiMode;
        rtnVal = await client.GetStringAsync($"https://api.starcitizen-api.com/{apiKey}/v1/{mode.ToString().ToLower()}/user/{handle}");
      } catch (HttpRequestException reqEx) {
        rtnVal = GetHttpClientError(reqEx.StatusCode);
      } catch (Exception ex) {
        rtnVal = ex.Message;
      }

      return rtnVal; ;
    }

    public static string GetHttpClientError(HttpStatusCode? code) {
      string rtnVal;

      // Fehlermeldung generieren
      if (code != null) {
        rtnVal = code switch {
          HttpStatusCode.NotFound => "API down", // This error is also triggered when the API is down.
          HttpStatusCode.InternalServerError => "Server error", // If the server encounters an unexpected error, and cannot process the request.
          HttpStatusCode.ServiceUnavailable => "API unavailable", // Triggered when the API is unavailable.
          _ => "Unknown error",
        };
      } else {
        rtnVal = "No Internet";
      }

      return rtnVal;
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

    private void AnzeigenVersteckenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Fenster einblenden, in den Vordergrund holen und Textbox fokussieren
      ShowWindow();
    }

    private void EinstellungenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Einstellungen anzeigen
      ShowProperties(true);
    }

    private Settings ShowProperties(bool mitProgramSettings = false) {
      Settings rtnVal = null;

      // Einstellungen-Dialog anzeigen
      using FormSettings frm = new(mitProgramSettings ? ProgramSettings : null);
      if (frm.ShowDialog() == DialogResult.OK) {
        rtnVal = frm.ProgramSettings;
      }

      if (rtnVal != null && mitProgramSettings) {
        RestartProgram();
      }

      return rtnVal;
    }

    private void LokalenCacheLeerenToolStripMenuItem_Click(object sender, EventArgs e) {
      ClearCache(false);
    }

    private void ClearCache(bool onlyExpired) {
      // Ggf. UserControl entfernen
      RemoveUserControls();

      bool weiter = true;
      if (!onlyExpired) {
        weiter = MessageBox.Show(ProgramTranslation.Window.MessageBoxes.Clear_Local_Cache_Question,
          Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
      }

      if (weiter) {
        // Cache leeren
        DeleteDirectoryFiles(CacheDirectoryType.Handle, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.HandleAvatar, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.HandleDisplayTitle, onlyExpired);
        DeleteDirectoryFiles(CacheDirectoryType.OrganizationAvatar, onlyExpired);

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

    internal static string GetCachePath(CacheDirectoryType type, string handle = "") {
      string rtnVal = string.Empty;

      // Verzeichnis ermitteln
      switch (type) {
        case CacheDirectoryType.Handle:
          rtnVal = Path.Combine(Application.StartupPath, $@"Cache\Handle\{(!string.IsNullOrWhiteSpace(handle) ? $"{handle}.json" : string.Empty)}");
          break;
        case CacheDirectoryType.HandleAvatar:
          rtnVal = Path.Combine(Application.StartupPath, @"Cache\Handle_Avatar\");
          break;
        case CacheDirectoryType.HandleDisplayTitle:
          rtnVal = Path.Combine(Application.StartupPath, @"Cache\Handle_DisplayTitle\");
          break;
        case CacheDirectoryType.OrganizationAvatar:
          rtnVal = Path.Combine(Application.StartupPath, @"Cache\Organization_Avatar\");
          break;
      }

      return rtnVal;
    }

    public enum CacheDirectoryType {
      Handle,
      HandleAvatar,
      HandleDisplayTitle,
      OrganizationAvatar
    }

    private void NeustartenToolStripMenuItem_Click(object sender, EventArgs e) {
      RestartProgram();
    }

    private void RestartProgram() {
      RemoveUserControls();
      Application.Restart();
    }

    private void FormHandleQuery_FormClosing(object sender, FormClosingEventArgs e) {
      if (HotKey?.HookedKeys?.Count > 0) {
        HotKey.Unhook();
        HotKey = null;
      }
    }
  }

}
