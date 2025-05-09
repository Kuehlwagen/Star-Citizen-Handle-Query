﻿using Star_Citizen_Handle_Query.Serialization;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormSettings : Form {

    public Settings ProgramSettings;
    private Translation CurrentLocalization;
    private readonly List<Translation> Localizations = [];
    private readonly List<Keys> KeyCollection = [
      Keys.None, Keys.A, Keys.B, Keys.C, Keys.D, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
      Keys.Delete, Keys.E, Keys.End, Keys.F, Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10,
      Keys.F11, Keys.F12, Keys.F13, Keys.F15, Keys.F16, Keys.F17, Keys.F18, Keys.F19, Keys.F20, Keys.F21, Keys.F22, Keys.F23, Keys.F24, Keys.G,
      Keys.H, Keys.Home, Keys.I, Keys.Insert, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U,
      Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z
    ];

    public FormSettings(Settings settings = null) {
      InitializeComponent();

      // Sprachen ermitteln
      GetLocalizations();

      // Sprachen hinzufügen
      ComboBoxSprache.Items.AddRange([.. Localizations.Select(x => x.Language)]);

      // Taste Werte hinzufügen
      ComboBoxTaste.Items.AddRange([.. KeyCollection.ConvertAll(x => x.ToString())]);

      // Kopie der Einstellungen erstellen
      ProgramSettings = settings != null ? (Settings)settings.Clone() : null;
      if (ProgramSettings != null) {
        ProgramSettings.LogMonitor = settings?.LogMonitor != null ? (LogMonitorSettings)settings.LogMonitor.Clone() : null;
        ProgramSettings.Locations = settings?.Locations != null ? (LocationsSettings)settings.Locations.Clone() : null;
        ProgramSettings.Relations = settings?.Locations != null ? (RelationsSettings)settings.Relations.Clone() : null;
      }

      if (ProgramSettings == null) {
        // Versuchen die Einstellungen aus der Einstellungen-Datei zu laden
        string settingsFilePath = FormHandleQuery.GetSettingsFilePath();
        if (File.Exists(settingsFilePath)) {
          string jsonSettings = File.ReadAllText(settingsFilePath, Encoding.UTF8);
          ProgramSettings = JsonSerializer.Deserialize<Settings>(jsonSettings);
        }
      }

      // Fallback auf leeres Settings-Objekt
      ProgramSettings ??= new Settings();

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
      ComboBoxTaste.SelectedIndex = KeyCollection.IndexOf(ProgramSettings.GlobalHotkey);
      CheckBoxStrg.Checked = ProgramSettings.GlobalHotkeyModifierCtrl;
      CheckBoxAlt.Checked = ProgramSettings.GlobalHotkeyModifierAlt;
      CheckBoxUmschalt.Checked = ProgramSettings.GlobalHotkeyModifierShift;
      CheckBoxAltTabEnabled.Checked = ProgramSettings.AltTabEnabled;
      CheckBoxPositionMerken.Checked = ProgramSettings.RememberWindowLocation;
      CheckBoxEscAusblenden.Checked = ProgramSettings.HideWindowOnEscPress;
      NumericUpDownAffiliationenMaximum.Value = ProgramSettings.AffiliationsMax;
      CheckBoxUnkenntlicheAffiliationenAusblenden.Checked = ProgramSettings.HideRedactedAffiliations;
      CheckBoxAutoCheckForUpdate.Checked = ProgramSettings.AutoCheckForUpdate;
      CheckBoxDpiUnaware.Checked = ProgramSettings.DpiUnaware;
      CheckBoxHideStreamLiveStatus.Checked = ProgramSettings.HideStreamLiveStatus;
      CheckBoxShowLog.Checked = ProgramSettings.LogMonitor.ShowWindow;
      NumericUpDownLogEintraegeMaximum.Value = ProgramSettings.LogMonitor.EntriesMax;
      NumericUpDownLogEintragAnzeigedauer.Value = ProgramSettings.LogMonitor.EntryDisplayDurationInMinutes;
      CheckBoxLogMonitorFilterCorpse.Checked = ProgramSettings.LogMonitor.Filter.Corpse;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Checked = ProgramSettings.LogMonitor.Filter.LoadingScreenDuration;
      CheckBoxCheckCompleteFile.Checked = ProgramSettings.LogMonitor.LoadCompleteFile;
      CheckBoxShowRelations.Checked = ProgramSettings.Relations.ShowWindow;
      CheckBoxSortRelationsAlphabetically.Checked = ProgramSettings.Relations.SortAlphabetically;
      NumericUpDownRelationsEntriesMaximum.Value = ProgramSettings.Relations.EntriesMax;
      CheckBoxShowLocations.Checked = ProgramSettings.Locations.ShowWindow;
      NumericUpDownOrteEintraegeMaximum.Value = ProgramSettings.Locations.EntriesMax;
      TextBoxLMB_URL.Text = ProgramSettings.Locations.LMB_URL;
      TextBoxMMB_URL.Text = ProgramSettings.Locations.MMB_URL;
      TextBoxRMB_URL.Text = ProgramSettings.Locations.RMB_URL;
      TextBoxGRPCURL.Text = ProgramSettings.Relations.RPC_URL;
      TextBoxGRPCChannel.Text = ProgramSettings.Relations.RPC_Channel;
      CheckBoxRPCSyncOnStartup.Checked = ProgramSettings.Relations.RPC_Sync_On_Startup;
      TextBoxGRPCChannelPassword.Text = ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted;
    }

    private void GetLocalizations() {
      // Sprachen ermitteln
      Localizations.AddRange(FormHandleQuery.GetAllTranslations().Select(x => x.Value));
    }

    public static string GetLocalizationPath() {
      return Path.Combine(FormHandleQuery.GetSaveFilesRootPath(), "Localization");
    }

    private readonly JsonSerializerOptions JsonSerOptions = new() { WriteIndented = true };
    private void ButtonSpeichern_Click(object sender, EventArgs e) {
      ButtonSpeichern.Focus();
      string settingsFilePath = FormHandleQuery.GetSettingsFilePath();
      try {
        File.WriteAllText(settingsFilePath, JsonSerializer.Serialize(ProgramSettings, JsonSerOptions), Encoding.UTF8);
        DialogResult = DialogResult.OK;
      } catch (Exception ex) {
        MessageBox.Show($"{CurrentLocalization.Settings.MessageBoxes.Save_Fail} {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void CheckBoxPositionMerken_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.RememberWindowLocation = (sender as CheckBox).Checked;
    }

    private void CheckBoxEscAusblenden_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.HideWindowOnEscPress = (sender as CheckBox).Checked;
    }

    private void NumericUpDownLokalerCacheAlter_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.LocalCacheMaxAge = Convert.ToInt32((sender as NumericUpDown).Value);
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

    private void CheckBoxRPCSyncOnStartup_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.RPC_Sync_On_Startup = (sender as CheckBox).Checked;
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

    private void NumericUpDownAffiliationenMaximum_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.AffiliationsMax = Convert.ToInt32((sender as NumericUpDown).Value);
    }

    private void CheckBoxUnkenntlicheAffiliationenAusblenden_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.HideRedactedAffiliations = (sender as CheckBox).Checked;
    }

    private void CheckBoxHideStreamLiveStatus_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.HideStreamLiveStatus = (sender as CheckBox).Checked;
    }

    private void CheckBoxAutoCheckForUpdate_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.AutoCheckForUpdate = (sender as CheckBox).Checked;
    }

    private void CheckBoxShowLog_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.ShowWindow = CheckBoxShowLog.Checked;
      NumericUpDownLogEintraegeMaximum.Enabled = CheckBoxShowLog.Checked;
      NumericUpDownLogEintragAnzeigedauer.Enabled = CheckBoxShowLog.Checked;
      CheckBoxLogMonitorFilterCorpse.Enabled = CheckBoxShowLog.Checked;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Enabled = CheckBoxShowLog.Checked;
      CheckBoxCheckCompleteFile.Enabled = CheckBoxShowLog.Checked;
    }

    private void NumericUpDownLogEintraegeMaximum_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.EntriesMax = Convert.ToInt32(NumericUpDownLogEintraegeMaximum.Value);
    }

    private void NumericUpDownLogEintragAnzeigedauer_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.EntryDisplayDurationInMinutes = Convert.ToInt32(NumericUpDownLogEintragAnzeigedauer.Value);
    }

    private void CheckBoxLogMonitorFilterCorpse_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.Filter.Corpse = CheckBoxLogMonitorFilterCorpse.Checked;
    }

    private void CheckBoxLogMonitorFilterLoadingScreenDuration_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.Filter.LoadingScreenDuration = CheckBoxLogMonitorFilterLoadingScreenDuration.Checked;
    }

    private void CheckBoxCheckCompleteFile_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.LoadCompleteFile = CheckBoxCheckCompleteFile.Checked;
    }

    private void CheckBoxShowRelations_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.ShowWindow = CheckBoxShowRelations.Checked;
      CheckBoxSortRelationsAlphabetically.Enabled = CheckBoxShowRelations.Checked;
      NumericUpDownRelationsEntriesMaximum.Enabled = CheckBoxShowRelations.Checked;
      TextBoxGRPCURL.Enabled = CheckBoxShowRelations.Checked;
      TextBoxGRPCChannel.Enabled = CheckBoxShowRelations.Checked;
      ButtonEditPrcChannels.Enabled = CheckBoxShowRelations.Checked;
      TextBoxGRPCChannelPassword.Enabled = CheckBoxShowRelations.Checked;
      CheckBoxRPCSyncOnStartup.Enabled = CheckBoxShowRelations.Checked;
    }

    private void CheckBoxSortRelationsAlphabetically_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.SortAlphabetically = CheckBoxSortRelationsAlphabetically.Checked;
    }

    private void CheckBoxDpiUnaware_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.DpiUnaware = CheckBoxDpiUnaware.Checked;
    }

    private void NumericUpDownRelationsEntriesMaximum_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.EntriesMax = Convert.ToInt32(NumericUpDownRelationsEntriesMaximum.Value);
    }

    private void TextBoxLMB_URL_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Locations.LMB_URL = TextBoxLMB_URL.Text;
    }

    private void TextBoxMMB_URL_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Locations.MMB_URL = TextBoxMMB_URL.Text;
    }

    private void TextBoxRMB_URL_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Locations.RMB_URL = TextBoxRMB_URL.Text;
    }

    private void TextBoxGRPCURL_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.RPC_URL = TextBoxGRPCURL.Text;
    }

    private void TextBoxGRPCChannel_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.RPC_Channel = TextBoxGRPCChannel.Text;
    }

    private void MaskedTextBoxGRPCKanalPasswort_TextChanged(object sender, EventArgs e) {
      ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted = TextBoxGRPCChannelPassword.Text;
    }

    private void ButtonStandard_Click(object sender, EventArgs e) {
      ProgramSettings = new() { Language = ProgramSettings.Language };
      SetDialogValues();
    }

    private void UpdateLocalization() {
      PerformLayout();

      Text = $"Star Citizen Handle Query - {CurrentLocalization.Settings.Title}";

      GroupBoxAnzeige.Text = CurrentLocalization.Settings.Display.Group_Title;
      LabelSprache.Text = CurrentLocalization.Settings.Display.Language;
      LabelMaxAffiliationen.Text = CurrentLocalization.Settings.Display.Affiliations_Max;
      CheckBoxUnkenntlicheAffiliationenAusblenden.Text = CurrentLocalization.Settings.Display.Hide_Redacted_Affiliations;
      CheckBoxHideStreamLiveStatus.Text = CurrentLocalization.Settings.Display.Hide_Stream_Live_Status;
      CheckBoxAutoCheckForUpdate.Text = CurrentLocalization.Settings.Display.Auto_Check_For_Update;
      CheckBoxDpiUnaware.Text = CurrentLocalization.Settings.Display.Use_Alternative_DPI_Calculation;

      GroupBoxFenster.Text = CurrentLocalization.Settings.Window.Group_Title;
      LabelFensterDeckkraft.Text = CurrentLocalization.Settings.Window.Opacity;
      LabelFensterDeckkraftProzent.Text = CurrentLocalization.Settings.Window.Opacity_Percent;
      LabelTastenkombination.Text = CurrentLocalization.Settings.Window.Global_Hotkey;
      CheckBoxStrg.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Ctrl;
      CheckBoxAlt.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Alt;
      CheckBoxUmschalt.Text = CurrentLocalization.Settings.Window.Global_Hotkey_Shift;
      CheckBoxFensterMauseingabenIgnorieren.Text = CurrentLocalization.Settings.Window.Ignore_Mouseinput;
      CheckBoxAltTabEnabled.Text = CurrentLocalization.Settings.Window.Enable_Alt_Tab;
      CheckBoxPositionMerken.Text = CurrentLocalization.Settings.Window.RememberWindowLocation;
      CheckBoxEscAusblenden.Text = CurrentLocalization.Settings.Window.HideWindowOnEscPress;

      GroupBoxLokalerCache.Text = CurrentLocalization.Settings.Local_Cache.Group_Title;
      LabelLokalerCacheAlter.Text = CurrentLocalization.Settings.Local_Cache.Max_Age;
      LabelLokalerCacheAlterTage.Text = CurrentLocalization.Settings.Local_Cache.Max_Age_Days;

      ButtonSpeichern.Text = CurrentLocalization.Settings.Buttons.Save;
      ButtonSchliessen.Text = CurrentLocalization.Settings.Buttons.Close;
      ButtonStandard.Text = CurrentLocalization.Settings.Buttons.Standard;

      GroupBoxLocation.Text = CurrentLocalization.Settings.Locations.Group_Title;
      CheckBoxShowLocations.Text = CurrentLocalization.Settings.Locations.Show_Locations;
      LabelOrteEintraegeMaximum.Text = CurrentLocalization.Settings.Locations.Locations_Entries_Max;
      LabelLMB_URL.Text = CurrentLocalization.Settings.Locations.LMB_URL;
      LabelMMB_URL.Text = CurrentLocalization.Settings.Locations.MMB_URL;
      LabelRMB_URL.Text = CurrentLocalization.Settings.Locations.RMB_URL;

      GroupBoxBeziehungen.Text = CurrentLocalization.Settings.Relations.Group_Title;
      CheckBoxShowRelations.Text = CurrentLocalization.Settings.Relations.Show_Relations;
      CheckBoxSortRelationsAlphabetically.Text = CurrentLocalization.Settings.Relations.Sort_Relations_Alphabetically;
      LabelRelationsEntriesMaximum.Text = CurrentLocalization.Settings.Relations.Relations_Entries_Max;
      LabelGRPCURL.Text = CurrentLocalization.Settings.Relations.RPC_Server_URL;
      LabelGRPCChannel.Text = CurrentLocalization.Settings.Relations.RPC_Server_Channel;
      LabelGRPCKanalPasswort.Text = CurrentLocalization.Settings.Relations.RPC_Channel_Password;
      CheckBoxRPCSyncOnStartup.Text = CurrentLocalization.Settings.Relations.RPC_Sync_On_Startup;

      GroupBoxLogMonitor.Text = CurrentLocalization.Settings.Log_Monitor.Group_Title;
      CheckBoxShowLog.Text = CurrentLocalization.Settings.Log_Monitor.Show_Log_Monitor;
      LabelLogEintraegeMaximum.Text = CurrentLocalization.Settings.Log_Monitor.Log_Entries_Max;
      LabelLogEintragAnzeigeDauer.Text = CurrentLocalization.Settings.Log_Monitor.Log_Entry_Display_Duration;
      LabelLogEintragAnzeigedauerMinuten.Text = CurrentLocalization.Settings.Log_Monitor.Log_Entry_Display_Duration_Minutes;
      CheckBoxLogMonitorFilterCorpse.Text = CurrentLocalization.Settings.Log_Monitor.Log_Show_Corpse;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Text = CurrentLocalization.Settings.Log_Monitor.Log_Show_Loading_Screen_Duration;
      CheckBoxCheckCompleteFile.Text = CurrentLocalization.Settings.Log_Monitor.Check_Complete_File;

      ResumeLayout();
    }

    private void CheckBoxShowLocations_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.Locations.ShowWindow = CheckBoxShowLocations.Checked;
      NumericUpDownOrteEintraegeMaximum.Enabled = CheckBoxShowLocations.Checked;
      TextBoxLMB_URL.Enabled = CheckBoxShowLocations.Checked;
      TextBoxMMB_URL.Enabled = CheckBoxShowLocations.Checked;
      TextBoxRMB_URL.Enabled = CheckBoxShowLocations.Checked;
    }

    private void NumericUpDownOrteEintraegeMaximum_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.Locations.EntriesMax = Convert.ToInt32((sender as NumericUpDown).Value);
    }

    private void ButtonEditPrcChannels_Click(object sender, EventArgs e) {
      using FormEditRpcChannels frm = new(ProgramSettings, CurrentLocalization);
      frm.ShowDialog();
      if (frm.DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(frm.SelectedChannel)) {
        TextBoxGRPCChannel.Text = frm.SelectedChannel;
        TextBoxGRPCChannel.Focus();
        TextBoxGRPCChannel.SelectAll();
      }
    }

  }

}
