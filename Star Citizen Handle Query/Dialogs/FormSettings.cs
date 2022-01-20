using Star_Citizen_Handle_Query.Serialization;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormSettings : Form {

    public Settings ProgramSettings;

    public FormSettings(Settings settings = null) {
      InitializeComponent();

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
      NumericUpDownFensterDeckkraft.Value = ProgramSettings.WindowOpacity;
      CheckBoxFensterMauseingabenIgnorieren.Checked = ProgramSettings.WindowIgnoreMouseInput;
      NumericUpDownLokalerCacheAlter.Value = ProgramSettings.LocalCacheMaxAge;
      TextBoxApiKey.Text = ProgramSettings.ApiKey;
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
    }

  }

}
