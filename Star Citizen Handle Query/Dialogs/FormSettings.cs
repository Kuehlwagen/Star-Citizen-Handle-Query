using Star_Citizen_Handle_Query.Serialization;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormSettings : Form {

    public Settings ProgramSettings;
    private Translation CurrentLocalization;
    private readonly List<Translation> Localizations = new();
    private readonly List<Keys> KeyCollection = new () {
      Keys.None, Keys.A, Keys.B, Keys.C, Keys.D, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
      Keys.Delete, Keys.E, Keys.End, Keys.F, Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10,
      Keys.F11, Keys.F12, Keys.G, Keys.H, Keys.Home, Keys.I, Keys.Insert, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q,
      Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z
    };

    public FormSettings(Settings settings = null) {
      InitializeComponent();

      // Sprachen hinzufügen
      ComboBoxSprache.Items.AddRange(GetLocalizations());

      // API-Modus Werte hinzufügen
      ComboBoxApiModus.Items.AddRange(Enum.GetNames(typeof(ApiMode)));

      // Taste Werte hinzufügen
      ComboBoxTaste.Items.AddRange(KeyCollection.ConvertAll(x => x.ToString()).ToArray());

      ProgramSettings = settings;

      if (ProgramSettings == null) {
        // Versuchen die Einstellungen aus der Einstellungen-Datei zu laden
        string settingsFilePath = FormHandleQuery.GetSettingsPath();
        if (File.Exists(settingsFilePath)) {
          string jsonSettings = File.ReadAllText(settingsFilePath, Encoding.UTF8);
          ProgramSettings = JsonSerializer.Deserialize<Settings>(jsonSettings);
        }
      }

      // Fallback auf leeres Settings-Objekt
      if (ProgramSettings == null) {
        ProgramSettings = new Settings();
      }

      // Einstellungen auf den Dialog übernehmen
      SetDialogValues();
    }

    private void SetDialogValues() {
      // Einstellungen auf den Dialog übernehmen
      if (ComboBoxSprache.Items.Contains(ProgramSettings.Language)) {
        ComboBoxSprache.SelectedIndex = Localizations.IndexOf(new Translation(ProgramSettings.Language));
      } else {
        ComboBoxSprache.SelectedIndex = Localizations.IndexOf(new Translation());
      }
      NumericUpDownFensterDeckkraft.Value = ProgramSettings.WindowOpacity;
      CheckBoxFensterMauseingabenIgnorieren.Checked = ProgramSettings.WindowIgnoreMouseInput;
      NumericUpDownLokalerCacheAlter.Value = ProgramSettings.LocalCacheMaxAge;
      TextBoxApiKey.Text = ProgramSettings.ApiKey;
      ComboBoxApiModus.SelectedIndex = (int)ProgramSettings.ApiMode;
      ComboBoxTaste.SelectedIndex = KeyCollection.IndexOf(ProgramSettings.GlobalHotkey);
      CheckBoxStrg.Checked = ProgramSettings.GlobalHotkeyModifierCtrl;
      CheckBoxAlt.Checked = ProgramSettings.GlobalHotkeyModifierAlt;
      CheckBoxUmschalt.Checked = ProgramSettings.GlobalHotkeyModifierShift;
      CheckBoxAltTabEnabled.Checked = ProgramSettings.AltTabEnabled;
    }

    private string[] GetLocalizations() {
      // Sprachdateien einlesen
      foreach (string jsonPath in Directory.GetFiles(GetLocalizationPath(), "*.json")) {
        Translation translation = JsonSerializer.Deserialize<Translation>(File.ReadAllText(jsonPath, Encoding.UTF8));
        if (translation != null && !Localizations.Contains(translation)) {
          Localizations.Add(translation);
        }
      }
      return Localizations.Select(x => x.Language).OrderBy(x => x).ToArray();
    }

    public static string GetLocalizationPath() {
      return Path.Combine(Application.StartupPath, "Localization");
    }

    private void ButtonSpeichern_Click(object sender, EventArgs e) {
      ButtonSpeichern.Focus();
      if (ProgramSettings.ApiKey.Length == 32) {
        string settingsFilePath = FormHandleQuery.GetSettingsPath();
        try {
          File.WriteAllText(settingsFilePath, JsonSerializer.Serialize(ProgramSettings, new JsonSerializerOptions() { WriteIndented = true }), Encoding.UTF8);
          DialogResult = DialogResult.OK;
        } catch (Exception ex) {
          MessageBox.Show($"{CurrentLocalization.Settings.MessageBoxes.Save_Fail} {ex.Message}");
        }
      } else {
        MessageBox.Show(CurrentLocalization.Settings.MessageBoxes.API_Key_Missing, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void ButtonSchliessen_Click(object sender, EventArgs e) {
      Close();
    }

    private void NumericUpDownFensterDeckkraft_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.WindowOpacity = Convert.ToInt32((sender as NumericUpDown).Value);
    }

    private void CheckBoxFensterMauseingabenIgnorieren_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.WindowIgnoreMouseInput = (sender as CheckBox).Checked;
    }

    private void NumericUpDownLokalerCacheAlter_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.LocalCacheMaxAge = Convert.ToInt32((sender as NumericUpDown).Value);
    }

    private void TextBoxApiKey_TextChanged(object sender, EventArgs e) {
      ProgramSettings.ApiKey = (sender as TextBox).Text;
      LabelApiTestStatus.Text = string.Empty;
      ButtonApiTest.Enabled = ProgramSettings.ApiKey.Length == 32;
    }

    private void ComboBoxApiModus_SelectedIndexChanged(object sender, EventArgs e) {
      ProgramSettings.ApiMode = (ApiMode)(sender as ComboBox).SelectedIndex;
      LabelModusBeschreibung.Text = GetApiModusBeschreibung((sender as ComboBox).SelectedIndex);
    }

    private string GetApiModusBeschreibung(int index) {
      string rtnVal = string.Empty;

      switch (index) {
        case (int)ApiMode.Live:
          rtnVal = CurrentLocalization.Settings.API.Mode_Description_Live;
          break;
        case (int)ApiMode.Cache:
          rtnVal = CurrentLocalization.Settings.API.Mode_Description_Cache;
          break;
        case (int)ApiMode.Auto:
          rtnVal = CurrentLocalization.Settings.API.Mode_Description_Auto;
          break;
        case (int)ApiMode.Eager:
          rtnVal = CurrentLocalization.Settings.API.Mode_Description_Eager;
          break;
      }

      return rtnVal;
    }

    private void CheckBoxStrg_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.GlobalHotkeyModifierCtrl = (sender as CheckBox).Checked;
    }

    private void CheckBoxAlt_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.GlobalHotkeyModifierAlt = (sender as CheckBox).Checked;
    }

    private void CheckBoxUmschalt_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.GlobalHotkeyModifierShift = (sender as CheckBox).Checked;
    }

    private void ComboBoxTaste_SelectedIndexChanged(object sender, EventArgs e) {
      ProgramSettings.GlobalHotkey = (Keys)Enum.Parse(typeof(Keys), $"{(sender as ComboBox).SelectedItem}");
      CheckBoxStrg.Enabled = ProgramSettings.GlobalHotkey != Keys.None;
      CheckBoxAlt.Enabled = CheckBoxStrg.Enabled;
      CheckBoxUmschalt.Enabled = CheckBoxStrg.Enabled;
    }

    private void CheckBoxAltTabEnabled_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.AltTabEnabled = (sender as CheckBox).Checked;
    }

    private void ComboBoxSprache_SelectedIndexChanged(object sender, EventArgs e) {
      ProgramSettings.Language = (sender as ComboBox).SelectedItem.ToString();
      CurrentLocalization = Localizations.FirstOrDefault(x => x.Language == ProgramSettings.Language);
      UpdateLocalization();
    }

    private void ButtonStandard_Click(object sender, EventArgs e) {
      ProgramSettings = new() { ApiKey = ProgramSettings.ApiKey, Language = ProgramSettings.Language };
      SetDialogValues();
    }

    private async void ButtonApiTest_Click(object sender, EventArgs e) {
      ApiKeyState state = await GetApiTestJson();
      if (state?.success == 1 && state.data != null) {
        LabelApiTestStatus.Text = $"{state?.message}, {state?.data?.value} {CurrentLocalization.Settings.API.Test_Information}";
      } else {
        LabelApiTestStatus.Text = state?.message;
      }
    }

    private async Task<ApiKeyState> GetApiTestJson() {
      ApiKeyState rtnVal = null;

      using HttpClient client = new();
      string jsonText = null;
      try {
        jsonText = await client.GetStringAsync($"https://api.starcitizen-api.com/{ProgramSettings.ApiKey}/v1/me");
      } catch (HttpRequestException reqEx) {
        rtnVal = new ApiKeyState() { message = FormHandleQuery.GetHttpClientError(reqEx.StatusCode) };
      } catch (Exception ex) {
        rtnVal = new ApiKeyState() { message = ex.Message };
      }

      if (!string.IsNullOrWhiteSpace(jsonText)) {
        rtnVal = JsonSerializer.Deserialize<ApiKeyState>(jsonText);
      }

      if (rtnVal == null) {
        rtnVal = new() { message = CurrentLocalization.Settings.API.Test_Error };
      }

      return rtnVal;
    }

    private void UpdateLocalization() {
      PerformLayout();

      Text = CurrentLocalization.Settings.Title;

      GroupBoxAPI.Text = CurrentLocalization.Settings.API.Group_Title;
      LabelApiKey.Text = CurrentLocalization.Settings.API.Key;
      TextBoxApiKey.PlaceholderText = CurrentLocalization.Settings.API.Key_Placeholder;
      LabelApiMode.Text = CurrentLocalization.Settings.API.Mode;
      LabelModusBeschreibung.Text = GetApiModusBeschreibung(ComboBoxApiModus.SelectedIndex);
      ButtonApiTest.Text = CurrentLocalization.Settings.API.Test;

      GroupBoxFenster.Text = CurrentLocalization.Settings.Window.Group_Title;
      LabelSprache.Text = CurrentLocalization.Settings.Window.Language;
      LabelFensterDeckkraft.Text = CurrentLocalization.Settings.Window.Opacity;
      LabelFensterDeckkraftProzent.Text = CurrentLocalization.Settings.Window.Opacity_Percent;
      LabelTastenkombination.Text = CurrentLocalization.Settings.Window.Global_Hotkey;
      CheckBoxStrg.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Ctrl;
      CheckBoxAlt.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Alt;
      CheckBoxUmschalt.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Shift;
      CheckBoxFensterMauseingabenIgnorieren.Text = CurrentLocalization.Settings.Window.Ignore_Mouseinput;
      CheckBoxAltTabEnabled.Text = CurrentLocalization.Settings.Window.Enable_Alt_Tab;

      GroupBoxLokalerCache.Text = CurrentLocalization.Settings.Local_Cache.Group_Title;
      LabelLokalerCacheAlter.Text = CurrentLocalization.Settings.Local_Cache.Max_Age;
      LabelLokalerCacheAlterTage.Text = CurrentLocalization.Settings.Local_Cache.Max_Age_Days;

      ButtonSpeichern.Text = CurrentLocalization.Settings.Buttons.Save;
      ButtonSchliessen.Text = CurrentLocalization.Settings.Buttons.Close;
      ButtonStandard.Text = CurrentLocalization.Settings.Buttons.Standard;

      ResumeLayout();
    }

  }

}
