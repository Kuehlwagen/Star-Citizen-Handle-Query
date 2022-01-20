using Star_Citizen_Handle_Query.Serialization;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormSettings : Form {

    public Settings ProgramSettings;

    public FormSettings(Settings settings = null) {
      InitializeComponent();

      // API-Modus Werte hinzufügen
      ComboBoxApiModus.Items.AddRange(Enum.GetNames(typeof(ApiMode)));

      // Taste Werte hinzufügen
      ComboBoxTaste.Items.AddRange(Enum.GetNames(typeof(FKeys)));

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
      NumericUpDownFensterDeckkraft.Value = ProgramSettings.WindowOpacity;
      CheckBoxFensterMauseingabenIgnorieren.Checked = ProgramSettings.WindowIgnoreMouseInput;
      NumericUpDownLokalerCacheAlter.Value = ProgramSettings.LocalCacheMaxAge;
      TextBoxApiKey.Text = ProgramSettings.ApiKey;
      ComboBoxApiModus.SelectedIndex = (int)ProgramSettings.ApiMode;
      ComboBoxTaste.SelectedIndex = (int)ProgramSettings.GlobalHotkey;
      CheckBoxStrg.Checked = ProgramSettings.GlobalHotkeyModifierCtrl;
      CheckBoxAlt.Checked = ProgramSettings.GlobalHotkeyModifierAlt;
      CheckBoxUmschalt.Checked = ProgramSettings.GlobalHotkeyModifierShift;
    }

    private void ButtonSpeichern_Click(object sender, EventArgs e) {
      if (ProgramSettings.ApiKey.Length == 32) {
        string settingsFilePath = FormHandleQuery.GetSettingsPath();
        try {
          File.WriteAllText(settingsFilePath, JsonSerializer.Serialize<Settings>(ProgramSettings, new JsonSerializerOptions() { WriteIndented = true }), Encoding.UTF8);
          DialogResult = DialogResult.OK;
        } catch (Exception ex) {
          MessageBox.Show($"Das Speichern der Einstellungen ist fehlgeschlagen:{Environment.NewLine}Fehlermeldung: {ex.Message}");
        }
      } else {
        MessageBox.Show("Es muss ein 32-stelliger API-Key angegeben werden.", Text);
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
      string beschreibung = string.Empty;
      switch ((sender as ComboBox).SelectedIndex) {
        case (int)ApiMode.Live:
          beschreibung = "(immer Live-Daten)";
          break;
        case (int)ApiMode.Cache:
          beschreibung = "(immer Server-Cache)";
          break;
        case (int)ApiMode.Auto:
          beschreibung = "(Server-Cache / Live-Daten)";
          break;
        case (int)ApiMode.Eager:
          beschreibung = "(Live-Daten / Server-Cache)";
          break;
      }
      LabelModusBeschreibung.Text = beschreibung;
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
      ProgramSettings.GlobalHotkey = (FKeys)(sender as ComboBox).SelectedIndex;
      CheckBoxStrg.Enabled = ProgramSettings.GlobalHotkey != FKeys.Keine;
      CheckBoxAlt.Enabled = CheckBoxStrg.Enabled;
      CheckBoxUmschalt.Enabled = CheckBoxStrg.Enabled;
    }

    private void ButtonStandard_Click(object sender, EventArgs e) {
      ProgramSettings = new() { ApiKey = ProgramSettings.ApiKey };
      SetDialogValues();
    }

    private async void ButtonApiTest_Click(object sender, EventArgs e) {
      ApiKeyState state = await GetApiTestJson();
      if (state?.success == 1 && state.data != null) {
        LabelApiTestStatus.Text = $"{state?.message?.ToUpper()}, {state?.data?.value} Live-Abfragen übrig";
      } else {
        LabelApiTestStatus.Text = state?.message;
      }
    }

    private async Task<ApiKeyState> GetApiTestJson() {
      ApiKeyState rtnVal = null;

      using HttpClient client = new();
      string jsonText = await client.GetStringAsync($"https://api.starcitizen-api.com/{ProgramSettings.ApiKey}/v1/me");
      if (!string.IsNullOrWhiteSpace(jsonText)) {
        rtnVal = JsonSerializer.Deserialize<ApiKeyState>(jsonText);
      }

      if (rtnVal == null) {
        rtnVal = new() { message = "Fehler bei der Abfrage der API" };
      }

      return rtnVal;
    }
  }

}
