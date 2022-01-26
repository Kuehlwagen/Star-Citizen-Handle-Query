using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.ExternClasses.Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Net;
using System.Reflection;
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

      // Pr�fen, ob die Programm-Einstellungen geladen werden konnten
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        // Ggf. Alt + Tab erm�glichen und Fenster in der Taskbar anzeigen
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

        // Sprache f�r Controls setzen
        SetProgramLocalization();

        // Veraltete Cache-Dateien l�schen
        ClearCache(true);
      }

    }

    private void UpdateAutoComplete() {
      // Autovervollst�ndigung aktualisieren
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

      // Datei f�r die Sprache "Deutsch" erstellen
      File.WriteAllText(Path.Combine(localizationPath, "de-DE.json"), Encoding.UTF8.GetString(Properties.Resources.de_DE), Encoding.Default);

      // Falls noch nicht vorhanden, Datei f�r die Sprache "English" erstellen
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
      // Sprache f�r Controls setzen
      LabelHandle.Text = ProgramTranslation.Window.Handle;
      TextBoxHandle.PlaceholderText = ProgramTranslation.Window.Handle_Placeholder;
      AnzeigenVersteckenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Show;
      EinstellungenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Settings;
      LokalenCacheLeerenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Clear_Local_Cache;
      NeustartenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Restart;
      BeendenToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.Close;
      UeberToolStripMenuItem.Text = ProgramTranslation.Window.Context_Menu.About;
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
      // Fenster-Gr��e initlal verkleinern
      Size = new Size(Width, 31);

      // Fenster an die richtige Position bringen
      CenterToScreen();
      Location = new Point(Location.X, 0);

      // Pr�fen, ob der API-Key eingetragen wurde
      if (ProgramSettings?.ApiKey?.Length != 32) {
        MessageBox.Show($"Es muss ein 32-stelliger API-Key angegeben werden.{Environment.NewLine}Das Programm wird beendet.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Application.Exit();
      } else {
        // Autovervollst�ndigung aktualisieren
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
      // Pr�fen, ob die Modifizierer exakt �bereinstimmen
      if (ProgramSettings.GlobalHotkeyModifierCtrl == e.Control &&
        ProgramSettings.GlobalHotkeyModifierAlt == e.Alt &&
        ProgramSettings.GlobalHotkeyModifierShift == e.Shift) {
        e.SuppressKeyPress = true;
        // Fenster einblenden
        ShowWindow();
      }
    }

    private async void TextBoxHandle_KeyDown(object sender, KeyEventArgs e) {
      // Handle-Textbox Tastendr�cke verarbeiten
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          bool forceLive = e.Control;
          if (!string.IsNullOrWhiteSpace(TextBoxHandle.Text)) {
            // Ggf. existierendes UserControl entfernen
            RemoveUserControls();
            // Cache-Typ leeren
            LabelCacheType.Text = string.Empty;
            // Textbox bis zum Ergebnis deaktivieren
            TextBoxHandle.Enabled = false;
            // Handle-Informationen auslesen
            HandleInfo handleInfo = await GetHandleInfo(forceLive);

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

            // Ggf. Cache-Verzeichnisse erstellen
            CreateDirectory(CacheDirectoryType.Handle);
            CreateDirectory(CacheDirectoryType.HandleAvatar);
            CreateDirectory(CacheDirectoryType.HandleDisplayTitle);
            CreateDirectory(CacheDirectoryType.OrganizationAvatar);

            // UserControl mit Handle-Informationen hinzuf�gen
            PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, forceLive));
            Size = new Size(Size.Width, Size.Height + 78);

            // Ggf. UserControl mit Organisation-Informationen hinzuf�gen
            if (handleInfo?.success == 1 && handleInfo?.data?.organization?.name != null) {
              PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.data.organization, ProgramSettings, true, forceLive));
              Size = new Size(Size.Width, Size.Height + (handleInfo.data.organization.name != string.Empty ? 78 : 25));
            }

            // Ggf. UserControls mit Affiliate-Informationen hinzuf�gen
            if (handleInfo?.data != null && handleInfo.data.affiliation != null && handleInfo.data.affiliation.Length > 0) {
              int affiliatesAdded = 0;
              for (int i = 0; i < handleInfo.data.affiliation.Length && affiliatesAdded < ProgramSettings.AffiliationsMax; i++) {
                // Pr�fen, ob ausgeblendete Affiliationen dargestellt werden sollen
                if (!string.IsNullOrWhiteSpace(handleInfo.data.affiliation[i].name) || !ProgramSettings.HideRedactedAffiliations) {
                  PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.data.affiliation[i], ProgramSettings, false, forceLive));
                  Size = new Size(Size.Width, Size.Height + (!string.IsNullOrWhiteSpace(handleInfo.data.affiliation[i].name) ? 78 : 25));
                  affiliatesAdded++;
                }
              }
            }

            // Autovervollst�ndigung aktualisieren
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

      // Neues HandleInfo-Objekt erstellen, wenn der R�ckgabewert null sein sollte
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
      EinstellungenToolStripMenuItem.Enabled = false;
      ShowProperties(true);
      EinstellungenToolStripMenuItem.Enabled = true;
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
      // Lokalen Cache leeren
      LokalenCacheLeerenToolStripMenuItem.Enabled = false;
      ClearCache(false);
      LokalenCacheLeerenToolStripMenuItem.Enabled = true;
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
      // Dateien aus dem Verzeichnis l�schen
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
      // �ber-Hinweismeldung anzeigen
      UeberToolStripMenuItem.Enabled = false;
      Version version = Assembly.GetExecutingAssembly().GetName().Version;
      MessageBox.Show($"{Text} v{version.Major}.{ version.Minor}.{ version.Build} by Kuehlwagen", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      UeberToolStripMenuItem.Enabled = true;
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

    public static string GetString(string value, string preValue = "") {
      return !string.IsNullOrWhiteSpace(value) ? $"{(!string.IsNullOrWhiteSpace(preValue) ? preValue : string.Empty)}{value}" : string.Empty;
    }

    public static async Task<Image> GetImage(CacheDirectoryType imageType, string url, string name, int localCacheMaxAge, bool forceLive = false) {
      Image rtnVal = null;

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
      string directoryPath = Path.Combine(Application.StartupPath, GetCachePath(imageType));
      if (!Directory.Exists(directoryPath)) {
        Directory.CreateDirectory(Path.Combine(Application.StartupPath, directoryPath));
      }
    }

  }

}
