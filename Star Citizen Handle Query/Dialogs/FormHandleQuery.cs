using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.ExternClasses.Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormHandleQuery : Form {

    private readonly int InitialWindowStyle = 0;
    private readonly Settings ProgramSettings;
    private GlobalHotKey HotKey;

    public FormHandleQuery() {
      InitializeComponent();

      // Größe des Fensters verkleinern, da ggf. Mauseingaben getätigt werden könnten
      Size = new Size(Width, 49);

      // Programm-Einstellungen auslesen
      ProgramSettings = GetProgramSettings();

      // Prüfen, ob die Programm-Einstellungen geladen werden konnten
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLong(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLong(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }

        // Icon für NotifyIcon setzen
        NotifyIconHandleQuery.Icon = SystemIcons.Information;
      }
    }

    private void UpdateAutoComplete() {
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

    internal Settings GetProgramSettings() {
      Settings rtnVal = null;

      // Einsetellungen aus Datei lesen
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
        // turn on WS_EX_TOOLWINDOW style bit
        cp.ExStyle |= 0x80;
        return cp;
      }
    }

    private void ShowHideWindow() {
      // Fenster ein-/ausblenden
      Visible = !Visible;
      if (Visible) {
        if (!User32Wrappers.SetForegroundWindow(Handle))
          ShowHideWindow();
        TextBoxHandle.SelectAll();
        TextBoxHandle.Focus();
      }
    }

    private void FormHandleQuery_Shown(object sender, EventArgs e) {
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
        if (ProgramSettings.GlobalHotkey != FKeys.Keine) {
          HotKey = new();
          HotKey.KeyDown += HotKey_KeyDown;
          HotKey.HookedKeys.Add(GetKeyByFKey());
          HotKey.Hook();
        }
      }
    }

    private void HotKey_KeyDown(object sender, KeyEventArgs e) {
      // Prüfen, ob die Modifizierer exakt übereinstimmen
      if (ProgramSettings.GlobalHotkeyModifierCtrl == e.Control &&
        ProgramSettings.GlobalHotkeyModifierAlt == e.Alt &&
        ProgramSettings.GlobalHotkeyModifierShift == e.Shift) {
        // Fenster ein-/ausblenden
        ShowHideWindow();
      }
    }

    private Keys GetKeyByFKey() {
      Keys rtnVal = Keys.None;

      // Keys-Wert über FKeys-Wert ermitteln
      switch (ProgramSettings.GlobalHotkey) {
        case FKeys.F1:
          rtnVal = Keys.F1;
          break;
        case FKeys.F2:
          rtnVal = Keys.F2;
          break;
        case FKeys.F3:
          rtnVal = Keys.F3;
          break;
        case FKeys.F4:
          rtnVal = Keys.F4;
          break;
        case FKeys.F5:
          rtnVal = Keys.F5;
          break;
        case FKeys.F6:
          rtnVal = Keys.F6;
          break;
        case FKeys.F7:
          rtnVal = Keys.F7;
          break;
        case FKeys.F8:
          rtnVal = Keys.F8;
          break;
        case FKeys.F9:
          rtnVal = Keys.F9;
          break;
        case FKeys.F10:
          rtnVal = Keys.F10;
          break;
        case FKeys.F11:
          rtnVal = Keys.F11;
          break;
        case FKeys.F12:
          rtnVal = Keys.F12;
          break;
      }

      return rtnVal;
    }

    private async void TextBoxHandle_KeyDown(object sender, KeyEventArgs e) {
      // Handle-Textbox Tastendrücke verarbeiten
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          if (!string.IsNullOrWhiteSpace(TextBoxHandle.Text)) {
            // Abfrage starten
            TextBoxHandle.SelectAll();
            // Ggf. existierendes UserControl entfernen
            RemoveUserControl();
            // Handle-Informationen auslesen
            HandleInfo handleInfo = await GetHandleInfo();
            // UserControl mit Handle-Informationen hinzufügen
            PanelHandleInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings));
            Size = new Size(Size.Width, 211);
            // Autovervollständigung aktualisieren
            UpdateAutoComplete();
          }
          break;
        case Keys.Escape:
          e.SuppressKeyPress = true;
          // Fenster verstecken
          Visible = false;
          break;
      }
    }

    private void RemoveUserControl() {
      // Ggf. UserControl entfernen
      if (PanelHandleInfo.Controls.Count > 0) {
        UserControlHandle control = PanelHandleInfo.Controls[0] as UserControlHandle;
        control.PictureBoxHandleAvatar.Image?.Dispose();
        control.PictureBoxDisplayTitle.Image?.Dispose();
        control.PictureBoxOrganization.Image?.Dispose();
        control.PictureBoxOrganizationRank.Image?.Dispose();
        control.Dispose();
        PanelHandleInfo.Controls.Clear();
      }
    }

    private async Task<HandleInfo> GetHandleInfo() {
      HandleInfo rtnVal = null;

      // Handle-Informationen aus Datei auslesen
      string handleJsonPath = GetCachePath(CacheDirectoryType.Handle, TextBoxHandle.Text);
      if (File.Exists(handleJsonPath) && new FileInfo(handleJsonPath).LastWriteTime > DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        rtnVal = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
      }

      // Handle-Informationen via API auslesen, wenn die Datei nicht gelesen werden konnte
      if (rtnVal == null) {
        string json = await GetApiHandleJson(ProgramSettings.ApiKey, TextBoxHandle.Text);
        HandleInfo apiHandleInfo = JsonSerializer.Deserialize<HandleInfo>(json);
        rtnVal = apiHandleInfo;
      }

      // Neues HandleInfo-Objekt erstellen, wenn der Rückgabewert null sein sollte
      if (rtnVal == null) {
        rtnVal = new();
      }

      return rtnVal;
    }

    private async Task<string> GetApiHandleJson(string apiKey, string handle) {
      // JSON via API herunterladen
      using HttpClient client = new();
      return await client.GetStringAsync($"https://api.starcitizen-api.com/{apiKey}/v1/{ProgramSettings.ApiMode.ToString().ToLower()}/user/{handle}");
    }

    private void BeendenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Programm beenden
      Application.Exit();
    }

    private void NotifyIconHandleQuery_MouseClick(object sender, MouseEventArgs e) {
      // Fenster einblenden, in den Vordergrund holen und Textbox fokussieren
      if (e.Button == MouseButtons.Left) {
        ShowHideWindow();
      }
    }

    private void AnzeigenVersteckenToolStripMenuItem_Click(object sender, EventArgs e) {
      // Fenster einblenden, in den Vordergrund holen und Textbox fokussieren
      ShowHideWindow();
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
      DeleteCache();
    }

    private void DeleteCache() {
      // Ggf. UserControl entfernen
      RemoveUserControl();
      // Cache leeren
      DeleteDirectoryFiles(CacheDirectoryType.Handle);
      DeleteDirectoryFiles(CacheDirectoryType.HandleAvatar);
      DeleteDirectoryFiles(CacheDirectoryType.HandleDisplayTitle);
      DeleteDirectoryFiles(CacheDirectoryType.OrganizationAvatar);
      MessageBox.Show("Der lokale Cache wurde geleert", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static void DeleteDirectoryFiles(CacheDirectoryType type) {
      // Dateien aus dem Verzeichnis löschen
      string cachePath = GetCachePath(type);
      if (Directory.Exists(cachePath)) {
        foreach (string filePath in Directory.GetFiles(cachePath)) {
          try {
            File.SetAttributes(filePath, FileAttributes.Normal);
            File.Delete(filePath);
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
      RemoveUserControl();
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
