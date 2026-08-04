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
      ProgramSettings?.Colors = settings?.Colors != null ? (AppColors)settings.Colors.Clone() : null;

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
        NumericUpDownErgebnisAutomatischLeeren.BackColor = ProgramSettings.Colors.AppBackColor;
        NumericUpDownErgebnisAutomatischLeeren.ForeColor = ProgramSettings.Colors.AppForeColor;
        ButtonForeColor.BackColor = ProgramSettings.Colors.AppForeColor;
        ButtonForeColorInactive.BackColor = ProgramSettings.Colors.AppForeColorInactive;
        ButtonBackColor.BackColor = ProgramSettings.Colors.AppBackColor;
        ButtonSplitterColor.BackColor = ProgramSettings.Colors.AppSplitterColor;
        ComboBoxColorThemes.BackColor = ProgramSettings.Colors.AppBackColor;
        ComboBoxColorThemes.ForeColor = ProgramSettings.Colors.AppForeColor;
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
      ButtonForeColor.BackColor = ProgramSettings.Colors.AppForeColor;
      ButtonForeColorInactive.BackColor = ProgramSettings.Colors.AppForeColorInactive;
      ButtonBackColor.BackColor = ProgramSettings.Colors.AppBackColor;
      ButtonSplitterColor.BackColor = ProgramSettings.Colors.AppSplitterColor;
      CheckBoxCompactMode.Checked = ProgramSettings.CompactMode;
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

    private void ComboBoxTaste_SelectedIndexChanged(object sender, EventArgs e) {
      ProgramSettings.GlobalHotkey = Enum.Parse<Keys>($"{(sender as ComboBox).SelectedItem}");
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

    private void CheckBoxDpiUnaware_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.DpiUnaware = CheckBoxDpiUnaware.Checked;
    }

    private void CheckBoxFensterAusblenden_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.AutoCloseHideWindows = CheckBoxFensterAusblenden.Checked;
    }

    private void CheckBoxCompactMode_CheckedChanged(object sender, EventArgs e) {
      ProgramSettings.CompactMode = CheckBoxCompactMode.Checked;
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
      CheckBoxCompactMode.Text = CurrentLocalization.Settings.Display.Compact_Mode;
      LabelFarben.Text = CurrentLocalization.Settings.Display.Colors;
      ButtonFarbenStandard.Text = CurrentLocalization.Settings.Buttons.Standard;
      ButtonFarbenStandard.Text = CurrentLocalization.Settings.Display.Default_Colors;
      SetToolTip(ButtonForeColor, CurrentLocalization.Settings.Display.Fore_Color);
      SetToolTip(ButtonForeColorInactive, CurrentLocalization.Settings.Display.Fore_Color_Inactive);
      SetToolTip(ButtonBackColor, CurrentLocalization.Settings.Display.Back_Color);
      SetToolTip(ButtonSplitterColor, CurrentLocalization.Settings.Display.Splitter_Color);

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

      ResumeLayout();
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

    private void ToolTipHandleQuery_Draw(object sender, DrawToolTipEventArgs e) {
      e.DrawBackground();
      e.DrawBorder();
      e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
    }

    public void SetToolTip(Control control, string text = null) {
      ToolTipSettings.SetToolTip(control, text ?? control.Text);
    }

  }

}
