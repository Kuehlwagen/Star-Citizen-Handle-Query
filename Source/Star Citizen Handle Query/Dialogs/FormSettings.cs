using Star_Citizen_Handle_Query.Serialization;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

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
    private readonly bool LoadingFinished = false;
    private const string ThemesResourcePrefix = "Star_Citizen_Handle_Query.Themes.";
    private readonly SortedDictionary<string, AppColors> AppColorThemes = [];
    private readonly Regex RgxDiscordWebhookUrl = RegexDiscordWebhookUrl();
    [GeneratedRegex(@"^https:\/\/discord.com\/api\/webhooks\/\d+\/[a-zA-Z0-9_]+$", RegexOptions.Compiled)]
    private static partial Regex RegexDiscordWebhookUrl();

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
        ProgramSettings.Colors = settings?.Colors != null ? (AppColors)settings.Colors.Clone() : null;
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

      // Farben setzen
      if (ProgramSettings?.Colors != null) {
        BackColor = ProgramSettings.Colors.AppBackColor;
        ForeColor = ProgramSettings.Colors.AppForeColor;
        ToolTipSettings.BackColor = ProgramSettings.Colors.AppBackColor;
        ToolTipSettings.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxAnzeige.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxFenster.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxBeziehungen.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxLocation.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxLogMonitor.ForeColor = ProgramSettings.Colors.AppForeColor;
        GroupBoxLokalerCache.ForeColor = ProgramSettings.Colors.AppForeColor;
        ComboBoxSprache.BackColor = ProgramSettings.Colors.AppBackColor;
        ComboBoxSprache.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownAffiliationenMaximum.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownAffiliationenMaximum.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownFensterDeckkraft.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownFensterDeckkraft.ForeColor = ProgramSettings.Colors.AppForeColor;
        ComboBoxTaste.BackColor = ProgramSettings.Colors.AppBackColor;
        ComboBoxTaste.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownLokalerCacheAlter.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownLokalerCacheAlter.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownOrteEintraegeMaximum.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownOrteEintraegeMaximum.ForeColor = ProgramSettings.Colors.AppForeColor;
        TextBoxLMB_URL.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxLMB_URL.ForeColor = ProgramSettings.Colors.AppBackColor;
        TextBoxMMB_URL.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxMMB_URL.ForeColor = ProgramSettings.Colors.AppBackColor;
        TextBoxRMB_URL.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxRMB_URL.ForeColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownRelationsEntriesMaximum.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownRelationsEntriesMaximum.ForeColor = ProgramSettings.Colors.AppForeColor;
        TextBoxGRPCURL.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxGRPCURL.ForeColor = ProgramSettings.Colors.AppBackColor;
        TextBoxGRPCChannel.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxGRPCChannel.ForeColor = ProgramSettings.Colors.AppBackColor;
        TextBoxGRPCChannelPassword.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxGRPCChannelPassword.ForeColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownLogEintraegeMaximum.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownLogEintraegeMaximum.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownLogEintragAnzeigedauer.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownLogEintragAnzeigedauer.ForeColor = ProgramSettings.Colors.AppForeColor;
        NumericUpDownErgebnisAutomatischLeeren.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownErgebnisAutomatischLeeren.ForeColor = ProgramSettings.Colors.AppForeColor;
        ButtonForeColor.BackColor = ProgramSettings.Colors.AppForeColor;
        ButtonForeColorInactive.BackColor = ProgramSettings.Colors.AppForeColorInactive;
        ButtonBackColor.BackColor = ProgramSettings.Colors.AppBackColor;
        ButtonSplitterColor.BackColor = ProgramSettings.Colors.AppSplitterColor;
        ButtonStatusInactiveForeColor.BackColor = ProgramSettings.Colors.AppStatusInactiveForeColor;
        ButtonStatusInactiveBackColor.BackColor = ProgramSettings.Colors.AppStatusInactiveBackColor;
        ButtonStatusInitializingForeColor.BackColor = ProgramSettings.Colors.AppStatusInitializingForeColor;
        ButtonStatusInitializingBackColor.BackColor = ProgramSettings.Colors.AppStatusInitializingBackColor;
        ButtonStatusActiveForeColor.BackColor = ProgramSettings.Colors.AppStatusActiveForeColor;
        ButtonStatusActiveBackColor.BackColor = ProgramSettings.Colors.AppStatusActiveBackColor;
        ButtonRelationFriendlyForeColor.BackColor = ProgramSettings.Colors.AppRelationFriendlyForeColor;
        ButtonRelationFriendlyBackColor.BackColor = ProgramSettings.Colors.AppRelationFriendlyBackColor;
        ButtonRelationNeutralForeColor.BackColor = ProgramSettings.Colors.AppRelationNeutralForeColor;
        ButtonRelationNeutralBackColor.BackColor = ProgramSettings.Colors.AppRelationNeutralBackColor;
        ButtonRelationBogeyForeColor.BackColor = ProgramSettings.Colors.AppRelationBogeyForeColor;
        ButtonRelationBogeyBackColor.BackColor = ProgramSettings.Colors.AppRelationBogeyBackColor;
        ButtonRelationBanditForeColor.BackColor = ProgramSettings.Colors.AppRelationBanditForeColor;
        ButtonRelationBanditBackColor.BackColor = ProgramSettings.Colors.AppRelationBanditBackColor;
        ButtonRelationOrganizationForeColor.BackColor = ProgramSettings.Colors.AppRelationOrganizationForeColor;
        ButtonRelationOrganizationBackColor.BackColor = ProgramSettings.Colors.AppRelationOrganizationBackColor;
        TextBoxLogMonitorHandleFilter.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxLogMonitorHandleFilter.ForeColor = ProgramSettings.Colors.AppBackColor;
        ComboBoxColorThemes.BackColor = ProgramSettings.Colors.AppBackColor;
        ComboBoxColorThemes.ForeColor = ProgramSettings.Colors.AppForeColor;
        TextBoxWebhookURL.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxWebhookURL.ForeColor = ProgramSettings.Colors.AppBackColor;
        TextBoxNPCNamen.BackColor = ProgramSettings.Colors.AppForeColor;
        TextBoxNPCNamen.ForeColor = ProgramSettings.Colors.AppBackColor;
      }

      // Einstellungen auf den Dialog übernehmen
      SetDialogValues();

      LoadingFinished = true;
    }

    private void AddThemes() {
      // Farb-Themen leeren
      AppColorThemes.Clear();
      ComboBoxColorThemes.Items.Clear();
      // Farb-Themen hinzufügen
      string themeName;
      string themeResourceString;
      foreach (string themeResourcePath in Assembly.GetEntryAssembly().GetManifestResourceNames()
        .Where(r => r.StartsWith(ThemesResourcePrefix, StringComparison.CurrentCultureIgnoreCase))) {
        themeName = themeResourcePath[ThemesResourcePrefix.Length..themeResourcePath.IndexOf('.', ThemesResourcePrefix.Length)].Replace('_', ' ');
        using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(themeResourcePath))
        using (StreamReader reader = new(stream)) {
          themeResourceString = reader.ReadToEnd();
        }
        if (CurrentLocalization.Settings.Display.Theme_Translations?.Count > 0) {
          if (CurrentLocalization.Settings.Display.Theme_Translations.TryGetValue(themeName, out string themeNameTranslation)) {
            themeName = themeNameTranslation;
          }
        }
        AppColorThemes.Add(themeName, JsonSerializer.Deserialize<AppColors>(themeResourceString));
      }
      string templatesDirectoryPath = GetTemplatesPath();
      if (Directory.Exists(templatesDirectoryPath)) {
        AppColors templateColors;
        string templateName;
        foreach (string templateFilePath in Directory.GetFiles(templatesDirectoryPath, "*.SC_Handle_Query.colors.json")) {
          templateColors = JsonSerializer.Deserialize<AppColors>(File.ReadAllText(templateFilePath, Encoding.UTF8));
          templateName = Path.GetFileName(templateFilePath);
          templateName = templateName[..templateName.IndexOf('.')].Replace('_', ' ');
          if (templateColors != null && !AppColorThemes.ContainsKey(templateName)) {
            AppColorThemes.Add(templateName, templateColors);
          }
        }
      }
      ComboBoxColorThemes.Items.Add("Thema...");
      ComboBoxColorThemes.Items.AddRange([.. AppColorThemes.Keys]);
      ComboBoxColorThemes.SelectedIndex = 0;
      ComboBoxColorThemes.Items[0] = CurrentLocalization.Settings.Display.Select_Theme;
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
      NumericUpDownErgebnisAutomatischLeeren.Value = ProgramSettings.AutoCloseDuration;
      CheckBoxFensterAusblenden.Checked = ProgramSettings.AutoCloseHideWindows;
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
      ButtonForeColor.BackColor = ProgramSettings.Colors.AppForeColor;
      ButtonForeColorInactive.BackColor = ProgramSettings.Colors.AppForeColorInactive;
      ButtonBackColor.BackColor = ProgramSettings.Colors.AppBackColor;
      ButtonSplitterColor.BackColor = ProgramSettings.Colors.AppSplitterColor;
      ButtonStatusInactiveForeColor.BackColor = ProgramSettings.Colors.AppStatusInactiveForeColor;
      ButtonStatusInactiveBackColor.BackColor = ProgramSettings.Colors.AppStatusInactiveBackColor;
      ButtonStatusInitializingForeColor.BackColor = ProgramSettings.Colors.AppStatusInitializingForeColor;
      ButtonStatusInitializingBackColor.BackColor = ProgramSettings.Colors.AppStatusInitializingBackColor;
      ButtonStatusActiveForeColor.BackColor = ProgramSettings.Colors.AppStatusActiveForeColor;
      ButtonStatusActiveBackColor.BackColor = ProgramSettings.Colors.AppStatusActiveBackColor;
      ButtonRelationFriendlyForeColor.BackColor = ProgramSettings.Colors.AppRelationFriendlyForeColor;
      ButtonRelationFriendlyBackColor.BackColor = ProgramSettings.Colors.AppRelationFriendlyBackColor;
      ButtonRelationNeutralForeColor.BackColor = ProgramSettings.Colors.AppRelationNeutralForeColor;
      ButtonRelationNeutralBackColor.BackColor = ProgramSettings.Colors.AppRelationNeutralBackColor;
      ButtonRelationBogeyForeColor.BackColor = ProgramSettings.Colors.AppRelationBogeyForeColor;
      ButtonRelationBogeyBackColor.BackColor = ProgramSettings.Colors.AppRelationBogeyBackColor;
      ButtonRelationBanditForeColor.BackColor = ProgramSettings.Colors.AppRelationBanditForeColor;
      ButtonRelationBanditBackColor.BackColor = ProgramSettings.Colors.AppRelationBanditBackColor;
      ButtonRelationOrganizationForeColor.BackColor = ProgramSettings.Colors.AppRelationOrganizationForeColor;
      ButtonRelationOrganizationBackColor.BackColor = ProgramSettings.Colors.AppRelationOrganizationBackColor;
      TextBoxLogMonitorHandleFilter.Text = string.Join(',', ProgramSettings.LogMonitor.HandleFilter);
      TextBoxWebhookURL.Text = ProgramSettings.LogMonitor.WebhookURL;
      CheckBoxNPCTodeAnzeigen.Checked = ProgramSettings.LogMonitor.Show_NPC_Deaths;
      TextBoxNPCNamen.Text = string.Join(',', ProgramSettings.LogMonitor.NPC_Filter);
    }

    private void GetLocalizations() {
      // Sprachen ermitteln
      Localizations.AddRange(FormHandleQuery.GetAllTranslations().Select(x => x.Value));
    }

    public static string GetLocalizationPath() {
      return Path.Combine(FormHandleQuery.GetSaveFilesRootPath(), "Localization");
    }

    public static string GetTemplatesPath() {
      return Path.Combine(FormHandleQuery.GetSaveFilesRootPath(), "Templates");
    }

    private readonly JsonSerializerOptions JsonSerOptions = new() { WriteIndented = true };
    private void ButtonSpeichern_Click(object sender, EventArgs e) {
      ButtonSpeichern.Focus();
      string settingsFilePath = FormHandleQuery.GetSettingsFilePath();
      try {
        File.WriteAllText(settingsFilePath, JsonSerializer.Serialize(ProgramSettings, JsonSerOptions), Encoding.UTF8);
        File.WriteAllText(FormHandleQuery.GetAppColorsFilePath(), JsonSerializer.Serialize(ProgramSettings.Colors, JsonSerOptions), Encoding.UTF8);
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
      AddThemes();
    }

    private void NumericUpDownErgebnisAutomatischLeeren_ValueChanged(object sender, EventArgs e) {
      ProgramSettings.AutoCloseDuration = Convert.ToInt32((sender as NumericUpDown).Value);
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
      TextBoxLogMonitorHandleFilter.Enabled = CheckBoxShowLog.Checked;
      TextBoxWebhookURL.Enabled = CheckBoxShowLog.Checked;
      CheckBoxNPCTodeAnzeigen.Enabled = CheckBoxShowLog.Checked;
      TextBoxNPCNamen.Enabled = CheckBoxShowLog.Checked;
      ButtonWebhookTest.Enabled = CheckBoxShowLog.Checked && IsValidDiscordWebhookUrl(ProgramSettings.LogMonitor.WebhookURL);
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

    private void CheckBoxFensterAusblenden_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.AutoCloseHideWindows = CheckBoxFensterAusblenden.Checked;
    }

    private void CheckBoxNPCTodeAnzeigen_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.Show_NPC_Deaths = CheckBoxNPCTodeAnzeigen.Checked;
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
      LabelErgebnisAutomatischLeeren.Text = CurrentLocalization.Settings.Display.Auto_Close_Duration;
      LabelErgebnisAutomatischLeerenSekunden.Text = CurrentLocalization.Settings.Display.Auto_Close_Duration_Seconds;
      CheckBoxFensterAusblenden.Text = CurrentLocalization.Settings.Display.Auto_Close_Hide_Windows;
      LabelFarben.Text = CurrentLocalization.Settings.Display.Colors;
      ButtonFarbenStandard.Text = CurrentLocalization.Settings.Buttons.Standard;
      CheckBoxErweitert.Text = CurrentLocalization.Settings.Display.Advanced;
      ButtonFarbenStandard.Text = CurrentLocalization.Settings.Display.Default_Colors;
      SetToolTip(ButtonForeColor, CurrentLocalization.Settings.Display.Fore_Color);
      SetToolTip(ButtonForeColorInactive, CurrentLocalization.Settings.Display.Fore_Color_Inactive);
      SetToolTip(ButtonBackColor, CurrentLocalization.Settings.Display.Back_Color);
      SetToolTip(ButtonSplitterColor, CurrentLocalization.Settings.Display.Splitter_Color);
      SetToolTip(ButtonStatusInactiveForeColor, $"{CurrentLocalization.Settings.Display.Status_Inactive} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonStatusInactiveBackColor, $"{CurrentLocalization.Settings.Display.Status_Inactive} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonStatusInitializingForeColor, $"{CurrentLocalization.Settings.Display.Status_Initializing} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonStatusInitializingBackColor, $"{CurrentLocalization.Settings.Display.Status_Initializing} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonStatusActiveForeColor, $"{CurrentLocalization.Settings.Display.Status_Active} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonStatusActiveBackColor, $"{CurrentLocalization.Settings.Display.Status_Active} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonRelationFriendlyForeColor, $"{CurrentLocalization.Local_Cache.Relation.Friendly} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonRelationFriendlyBackColor, $"{CurrentLocalization.Local_Cache.Relation.Friendly} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonRelationNeutralForeColor, $"{CurrentLocalization.Local_Cache.Relation.Neutral} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonRelationNeutralBackColor, $"{CurrentLocalization.Local_Cache.Relation.Neutral} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonRelationBogeyForeColor, $"{CurrentLocalization.Local_Cache.Relation.Bogey} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonRelationBogeyBackColor, $"{CurrentLocalization.Local_Cache.Relation.Bogey} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonRelationBanditForeColor, $"{CurrentLocalization.Local_Cache.Relation.Bandit} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonRelationBanditBackColor, $"{CurrentLocalization.Local_Cache.Relation.Bandit} ({CurrentLocalization.Settings.Display.Back_Color})");
      SetToolTip(ButtonRelationOrganizationForeColor, $"{CurrentLocalization.Local_Cache.Columns.Organization.ToUpper()} ({CurrentLocalization.Settings.Display.Fore_Color})");
      SetToolTip(ButtonRelationOrganizationBackColor, $"{CurrentLocalization.Local_Cache.Columns.Organization.ToUpper()} ({CurrentLocalization.Settings.Display.Back_Color})");

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
      LabelLogMonitorHandleFilter.Text = CurrentLocalization.Settings.Log_Monitor.Handle_Filter;
      LabelWebhookURL.Text = CurrentLocalization.Settings.Log_Monitor.Webhook_URL;
      CheckBoxNPCTodeAnzeigen.Text = CurrentLocalization.Settings.Log_Monitor.Show_NPC_Deaths;
      LabelNPCNamen.Text = CurrentLocalization.Settings.Log_Monitor.NPC_Filter;
      ButtonWebhookTest.Text = CurrentLocalization.Settings.Log_Monitor.Test_Webhook_URL;
      SetToolTip(TextBoxNPCNamen, $"{CurrentLocalization.Settings.Log_Monitor.Global_NPC_Names}:{Environment.NewLine}{string.Join(Environment.NewLine, ProgramSettings.LogMonitor.Global_NPC_Filter)}");

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

    private void ButtonForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonForeColor);
    }

    private void ButtonForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.ForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonForeColorInactive_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonForeColorInactive);
    }

    private void ButtonForeColorInactive_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.ForeColorInactive = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonBackColor);
    }

    private void ButtonBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.BackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusInactiveForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusInactiveForeColor);
    }

    private void ButtonStatusInactiveBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusInactiveBackColor);
    }

    private void ButtonStatusInitializingForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusInitializingForeColor);
    }

    private void ButtonStatusInitializingBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusInitializingBackColor);
    }

    private void ButtonStatusActiveForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusActiveForeColor);
    }

    private void ButtonStatusActiveBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonStatusActiveBackColor);
    }

    private void ButtonRelationFriendlyForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationFriendlyForeColor);
    }

    private void ButtonRelationFriendlyBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationFriendlyBackColor);
    }

    private void ButtonRelationNeutralForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationNeutralForeColor);
    }

    private void ButtonRelationNeutralBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationNeutralBackColor);
    }

    private void ButtonRelationBogeyForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationBogeyForeColor);
    }

    private void ButtonRelationBogeyBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationBogeyBackColor);
    }

    private void ButtonRelationBanditForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationBanditForeColor);
    }

    private void ButtonRelationBanditBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationBanditBackColor);
    }

    private void ButtonRelationOrganizationForeColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationOrganizationForeColor);
    }

    private void ButtonRelationOrganizationBackColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonRelationOrganizationBackColor);
    }

    private void ButtonSplitterColor_Click(object sender, EventArgs e) {
      SetSelectedColor(ButtonSplitterColor);
    }

    private void ButtonSplitterColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.SplitterColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void SetSelectedColor(Button btn) {
      using ColorDialog colorDialog = new() {
        Color = btn.BackColor,
        AnyColor = true,
        FullOpen = true,
        CustomColors = [
          ColorTranslator.ToOle(ProgramSettings.Colors.AppForeColor),
          ColorTranslator.ToOle(ProgramSettings.Colors.AppForeColorInactive),
          ColorTranslator.ToOle(ProgramSettings.Colors.AppBackColor),
          ColorTranslator.ToOle(ProgramSettings.Colors.AppSplitterColor)
        ]
      };
      if (colorDialog.ShowDialog() == DialogResult.OK) {
        btn.BackColor = colorDialog.Color;
      }
      ComboBoxColorThemes.SelectedIndex = 0;
    }

    private void ButtonEditPrcChannels_Paint(object sender, PaintEventArgs e) {
      base.OnPaint(e);
      FormHandleQuery.PaintSettingsIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive);
    }

    private void TextBoxLogMonitorHandleFilter_TextChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.HandleFilter = [.. TextBoxLogMonitorHandleFilter.Text.Split([',', ';', '|', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];
    }

    private void TextBoxNPCNamen_TextChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.NPC_Filter = [.. TextBoxNPCNamen.Text.Split([',', ';', '|', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];
    }

    private void TextBoxWebhookURL_TextChanged(object sender, EventArgs e) {
      ProgramSettings.LogMonitor.WebhookURL = TextBoxWebhookURL.Text;
      ButtonWebhookTest.Enabled = IsValidDiscordWebhookUrl(TextBoxWebhookURL.Text);
    }

    private void ButtonFarbenStandard_Click(object sender, EventArgs e) {
      ProgramSettings.Colors = new Settings().Colors;
      SetDialogValues();
    }

    private void ComboBoxColorThemes_SelectedIndexChanged(object sender, EventArgs e) {
      ComboBox cb = sender as ComboBox;
      if (cb.SelectedIndex > 0) {
        ProgramSettings.Colors = AppColorThemes[cb.SelectedItem.ToString()];
      }
      SetDialogValues();
    }

    private void ButtonStatusInactiveForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusInactiveForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusInactiveBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusInactiveBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusInitializingForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusInitializingForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusInitializingBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusInitializingBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusActiveForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusActiveForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonStatusActiveBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.StatusActiveBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationFriendlyForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationFriendlyForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationFriendlyBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationFriendlyBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationNeutralForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationNeutralForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationNeutralBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationNeutralBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationBogeyForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationBogeyForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationBogeyBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationBogeyBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationBanditForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationBanditForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationBanditBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationBanditBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationOrganizationForeColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationOrganizationForeColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ButtonRelationOrganizationBackColor_BackColorChanged(object sender, EventArgs e) {
      if (LoadingFinished && ProgramSettings?.Colors != null) {
        ProgramSettings.Colors.RelationOrganizationBackColor = ColorTranslator.ToHtml((sender as Button).BackColor);
      }
    }

    private void ToolTipHandleQuery_Draw(object sender, DrawToolTipEventArgs e) {
      e.DrawBackground();
      e.DrawBorder();
      e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
    }

    public void SetToolTip(Control control, string text = null) {
      ToolTipSettings.SetToolTip(control, text ?? control.Text);
    }

    private void CheckBoxErweitert_CheckedChanged(object sender, EventArgs e) {
      bool visible = !ButtonStatusInactiveForeColor.Visible;
      int buttonHeight = visible ? 12 : 20;
      ButtonForeColor.Height = buttonHeight;
      ButtonForeColorInactive.Height = buttonHeight;
      ButtonBackColor.Height = buttonHeight;
      ButtonSplitterColor.Height = buttonHeight;
      ButtonStatusInactiveForeColor.Visible = visible;
      ButtonStatusInactiveBackColor.Visible = visible;
      ButtonStatusInitializingForeColor.Visible = visible;
      ButtonStatusInitializingBackColor.Visible = visible;
      ButtonStatusActiveForeColor.Visible = visible;
      ButtonStatusActiveBackColor.Visible = visible;
      ButtonRelationFriendlyForeColor.Visible = visible;
      ButtonRelationFriendlyBackColor.Visible = visible;
      ButtonRelationNeutralForeColor.Visible = visible;
      ButtonRelationNeutralBackColor.Visible = visible;
      ButtonRelationBogeyForeColor.Visible = visible;
      ButtonRelationBogeyBackColor.Visible = visible;
      ButtonRelationBanditForeColor.Visible = visible;
      ButtonRelationBanditBackColor.Visible = visible;
      ButtonRelationOrganizationForeColor.Visible = visible;
      ButtonRelationOrganizationBackColor.Visible = visible;
    }

    private static bool IsValidDiscordWebhookUrl(string url) => RegexDiscordWebhookUrl().IsMatch(url);

    private void ButtonWebhookTest_Click(object sender, EventArgs e) {
      if (IsValidDiscordWebhookUrl(ProgramSettings.LogMonitor.WebhookURL)) {
        FormLogMonitor.PushDiscordWebhook(new(LogType.ActorDeath, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
          "Kuehlwagen",
          "Gentle81",
          $"Killed by: Gentle81{Environment.NewLine}Using: unknown (Class unknown){Environment.NewLine}Zone: TransitCarriage_RSI_Polaris_Rear_Elevator_1604048788858{Environment.NewLine}Damage Type: Crash",
          SCHQ_Protos.RelationValue.Friendly,
          SCHQ_Protos.RelationValue.Bandit),
          ProgramSettings.LogMonitor.WebhookURL,CurrentLocalization);
      }
    }

  }

}
