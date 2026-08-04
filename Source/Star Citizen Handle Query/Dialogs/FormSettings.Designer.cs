namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormSettings {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
      CheckBoxFensterMauseingabenIgnorieren = new CheckBox();
      LabelLokalerCacheAlter = new Label();
      NumericUpDownLokalerCacheAlter = new NumericUpDown();
      ButtonSpeichern = new Button();
      ButtonSchliessen = new Button();
      LabelFensterDeckkraftProzent = new Label();
      LabelLokalerCacheAlterTage = new Label();
      GroupBoxFenster = new GroupBox();
      CheckBoxEscAusblenden = new CheckBox();
      CheckBoxPositionMerken = new CheckBox();
      CheckBoxAltTabEnabled = new CheckBox();
      CheckBoxUmschalt = new CheckBox();
      CheckBoxAlt = new CheckBox();
      CheckBoxStrg = new CheckBox();
      ComboBoxTaste = new ComboBox();
      LabelTastenkombination = new Label();
      NumericUpDownFensterDeckkraft = new NumericUpDown();
      LabelFensterDeckkraft = new Label();
      LabelSprache = new Label();
      ComboBoxSprache = new ComboBox();
      GroupBoxLokalerCache = new GroupBox();
      ButtonStandard = new Button();
      GroupBoxAnzeige = new GroupBox();
      CheckBoxCompactMode = new CheckBox();
      ComboBoxColorThemes = new ComboBox();
      ButtonFarbenStandard = new Button();
      LabelFarben = new Label();
      LabelErgebnisAutomatischLeerenSekunden = new Label();
      LabelErgebnisAutomatischLeeren = new Label();
      CheckBoxHideStreamLiveStatus = new CheckBox();
      CheckBoxFensterAusblenden = new CheckBox();
      CheckBoxDpiUnaware = new CheckBox();
      CheckBoxAutoCheckForUpdate = new CheckBox();
      NumericUpDownErgebnisAutomatischLeeren = new NumericUpDown();
      NumericUpDownAffiliationenMaximum = new NumericUpDown();
      ButtonSplitterColor = new Button();
      ButtonBackColor = new Button();
      ButtonForeColorInactive = new Button();
      ButtonForeColor = new Button();
      LabelMaxAffiliationen = new Label();
      CheckBoxUnkenntlicheAffiliationenAusblenden = new CheckBox();
      ToolTipSettings = new ToolTip(components);
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLokalerCacheAlter).BeginInit();
      GroupBoxFenster.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownFensterDeckkraft).BeginInit();
      GroupBoxLokalerCache.SuspendLayout();
      GroupBoxAnzeige.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownErgebnisAutomatischLeeren).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownAffiliationenMaximum).BeginInit();
      SuspendLayout();
      // 
      // CheckBoxFensterMauseingabenIgnorieren
      // 
      CheckBoxFensterMauseingabenIgnorieren.AutoSize = true;
      CheckBoxFensterMauseingabenIgnorieren.Location = new Point(15, 105);
      CheckBoxFensterMauseingabenIgnorieren.Name = "CheckBoxFensterMauseingabenIgnorieren";
      CheckBoxFensterMauseingabenIgnorieren.Size = new Size(161, 19);
      CheckBoxFensterMauseingabenIgnorieren.TabIndex = 8;
      CheckBoxFensterMauseingabenIgnorieren.Text = "Mauseingaben ignorieren";
      CheckBoxFensterMauseingabenIgnorieren.UseVisualStyleBackColor = true;
      CheckBoxFensterMauseingabenIgnorieren.CheckedChanged += CheckBoxFensterMauseingabenIgnorieren_CheckedChanged;
      // 
      // LabelLokalerCacheAlter
      // 
      LabelLokalerCacheAlter.AutoSize = true;
      LabelLokalerCacheAlter.Location = new Point(15, 24);
      LabelLokalerCacheAlter.Name = "LabelLokalerCacheAlter";
      LabelLokalerCacheAlter.Size = new Size(94, 15);
      LabelLokalerCacheAlter.TabIndex = 0;
      LabelLokalerCacheAlter.Text = "Maximales Alter:";
      // 
      // NumericUpDownLokalerCacheAlter
      // 
      NumericUpDownLokalerCacheAlter.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownLokalerCacheAlter.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownLokalerCacheAlter.Location = new Point(173, 22);
      NumericUpDownLokalerCacheAlter.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
      NumericUpDownLokalerCacheAlter.Name = "NumericUpDownLokalerCacheAlter";
      NumericUpDownLokalerCacheAlter.Size = new Size(44, 23);
      NumericUpDownLokalerCacheAlter.TabIndex = 1;
      NumericUpDownLokalerCacheAlter.Value = new decimal(new int[] { 3, 0, 0, 0 });
      NumericUpDownLokalerCacheAlter.ValueChanged += NumericUpDownLokalerCacheAlter_ValueChanged;
      // 
      // ButtonSpeichern
      // 
      ButtonSpeichern.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ButtonSpeichern.FlatStyle = FlatStyle.Flat;
      ButtonSpeichern.Location = new Point(12, 368);
      ButtonSpeichern.Name = "ButtonSpeichern";
      ButtonSpeichern.Size = new Size(75, 28);
      ButtonSpeichern.TabIndex = 6;
      ButtonSpeichern.Text = "Speichern";
      ButtonSpeichern.UseVisualStyleBackColor = true;
      ButtonSpeichern.Click += ButtonSpeichern_Click;
      // 
      // ButtonSchliessen
      // 
      ButtonSchliessen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ButtonSchliessen.FlatStyle = FlatStyle.Flat;
      ButtonSchliessen.Location = new Point(93, 368);
      ButtonSchliessen.Name = "ButtonSchliessen";
      ButtonSchliessen.Size = new Size(75, 28);
      ButtonSchliessen.TabIndex = 7;
      ButtonSchliessen.Text = "Schließen";
      ButtonSchliessen.UseVisualStyleBackColor = true;
      ButtonSchliessen.Click += ButtonSchliessen_Click;
      // 
      // LabelFensterDeckkraftProzent
      // 
      LabelFensterDeckkraftProzent.AutoSize = true;
      LabelFensterDeckkraftProzent.Location = new Point(223, 24);
      LabelFensterDeckkraftProzent.Name = "LabelFensterDeckkraftProzent";
      LabelFensterDeckkraftProzent.Size = new Size(17, 15);
      LabelFensterDeckkraftProzent.TabIndex = 2;
      LabelFensterDeckkraftProzent.Text = "%";
      // 
      // LabelLokalerCacheAlterTage
      // 
      LabelLokalerCacheAlterTage.AutoSize = true;
      LabelLokalerCacheAlterTage.Location = new Point(223, 24);
      LabelLokalerCacheAlterTage.Name = "LabelLokalerCacheAlterTage";
      LabelLokalerCacheAlterTage.Size = new Size(40, 15);
      LabelLokalerCacheAlterTage.TabIndex = 2;
      LabelLokalerCacheAlterTage.Text = "Tag(e)";
      // 
      // GroupBoxFenster
      // 
      GroupBoxFenster.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      GroupBoxFenster.Controls.Add(CheckBoxEscAusblenden);
      GroupBoxFenster.Controls.Add(CheckBoxPositionMerken);
      GroupBoxFenster.Controls.Add(CheckBoxAltTabEnabled);
      GroupBoxFenster.Controls.Add(CheckBoxUmschalt);
      GroupBoxFenster.Controls.Add(CheckBoxAlt);
      GroupBoxFenster.Controls.Add(CheckBoxStrg);
      GroupBoxFenster.Controls.Add(ComboBoxTaste);
      GroupBoxFenster.Controls.Add(LabelTastenkombination);
      GroupBoxFenster.Controls.Add(NumericUpDownFensterDeckkraft);
      GroupBoxFenster.Controls.Add(LabelFensterDeckkraft);
      GroupBoxFenster.Controls.Add(CheckBoxFensterMauseingabenIgnorieren);
      GroupBoxFenster.Controls.Add(LabelFensterDeckkraftProzent);
      GroupBoxFenster.FlatStyle = FlatStyle.Flat;
      GroupBoxFenster.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxFenster.Location = new Point(370, 22);
      GroupBoxFenster.Name = "GroupBoxFenster";
      GroupBoxFenster.Size = new Size(379, 207);
      GroupBoxFenster.TabIndex = 1;
      GroupBoxFenster.TabStop = false;
      GroupBoxFenster.Text = "Fenster";
      // 
      // CheckBoxEscAusblenden
      // 
      CheckBoxEscAusblenden.AutoSize = true;
      CheckBoxEscAusblenden.Location = new Point(15, 180);
      CheckBoxEscAusblenden.Name = "CheckBoxEscAusblenden";
      CheckBoxEscAusblenden.Size = new Size(172, 19);
      CheckBoxEscAusblenden.TabIndex = 11;
      CheckBoxEscAusblenden.Text = "ESC blendet das Fenster aus";
      CheckBoxEscAusblenden.UseVisualStyleBackColor = true;
      CheckBoxEscAusblenden.CheckedChanged += CheckBoxEscAusblenden_CheckedChanged;
      // 
      // CheckBoxPositionMerken
      // 
      CheckBoxPositionMerken.AutoSize = true;
      CheckBoxPositionMerken.Location = new Point(15, 155);
      CheckBoxPositionMerken.Name = "CheckBoxPositionMerken";
      CheckBoxPositionMerken.Size = new Size(112, 19);
      CheckBoxPositionMerken.TabIndex = 10;
      CheckBoxPositionMerken.Text = "Position merken";
      CheckBoxPositionMerken.UseVisualStyleBackColor = true;
      CheckBoxPositionMerken.CheckedChanged += CheckBoxPositionMerken_CheckedChanged;
      // 
      // CheckBoxAltTabEnabled
      // 
      CheckBoxAltTabEnabled.AutoSize = true;
      CheckBoxAltTabEnabled.Location = new Point(15, 130);
      CheckBoxAltTabEnabled.Name = "CheckBoxAltTabEnabled";
      CheckBoxAltTabEnabled.Size = new Size(167, 19);
      CheckBoxAltTabEnabled.TabIndex = 9;
      CheckBoxAltTabEnabled.Text = "Erreichbarkeit via Alt + Tab";
      CheckBoxAltTabEnabled.UseVisualStyleBackColor = true;
      CheckBoxAltTabEnabled.CheckedChanged += CheckBoxAltTabEnabled_CheckedChanged;
      // 
      // CheckBoxUmschalt
      // 
      CheckBoxUmschalt.AutoSize = true;
      CheckBoxUmschalt.Location = new Point(273, 80);
      CheckBoxUmschalt.Name = "CheckBoxUmschalt";
      CheckBoxUmschalt.Size = new Size(76, 19);
      CheckBoxUmschalt.TabIndex = 7;
      CheckBoxUmschalt.Text = "Umschalt";
      CheckBoxUmschalt.UseVisualStyleBackColor = true;
      CheckBoxUmschalt.CheckedChanged += CheckBoxUmschalt_CheckedChanged;
      // 
      // CheckBoxAlt
      // 
      CheckBoxAlt.AutoSize = true;
      CheckBoxAlt.Location = new Point(226, 80);
      CheckBoxAlt.Name = "CheckBoxAlt";
      CheckBoxAlt.Size = new Size(41, 19);
      CheckBoxAlt.TabIndex = 6;
      CheckBoxAlt.Text = "Alt";
      CheckBoxAlt.UseVisualStyleBackColor = true;
      CheckBoxAlt.CheckedChanged += CheckBoxAlt_CheckedChanged;
      // 
      // CheckBoxStrg
      // 
      CheckBoxStrg.AutoSize = true;
      CheckBoxStrg.Location = new Point(173, 80);
      CheckBoxStrg.Name = "CheckBoxStrg";
      CheckBoxStrg.Size = new Size(47, 19);
      CheckBoxStrg.TabIndex = 5;
      CheckBoxStrg.Text = "Strg";
      CheckBoxStrg.UseVisualStyleBackColor = true;
      CheckBoxStrg.CheckedChanged += CheckBoxStrg_CheckedChanged;
      // 
      // ComboBoxTaste
      // 
      ComboBoxTaste.BackColor = Color.FromArgb(19, 26, 33);
      ComboBoxTaste.DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBoxTaste.FlatStyle = FlatStyle.Flat;
      ComboBoxTaste.ForeColor = Color.FromArgb(57, 206, 216);
      ComboBoxTaste.FormattingEnabled = true;
      ComboBoxTaste.Location = new Point(173, 51);
      ComboBoxTaste.MaxDropDownItems = 5;
      ComboBoxTaste.Name = "ComboBoxTaste";
      ComboBoxTaste.Size = new Size(78, 23);
      ComboBoxTaste.TabIndex = 4;
      ComboBoxTaste.SelectedIndexChanged += ComboBoxTaste_SelectedIndexChanged;
      // 
      // LabelTastenkombination
      // 
      LabelTastenkombination.AutoSize = true;
      LabelTastenkombination.Location = new Point(15, 54);
      LabelTastenkombination.Name = "LabelTastenkombination";
      LabelTastenkombination.Size = new Size(80, 15);
      LabelTastenkombination.TabIndex = 3;
      LabelTastenkombination.Text = "Globale Taste:";
      // 
      // NumericUpDownFensterDeckkraft
      // 
      NumericUpDownFensterDeckkraft.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownFensterDeckkraft.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownFensterDeckkraft.Location = new Point(173, 22);
      NumericUpDownFensterDeckkraft.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownFensterDeckkraft.Name = "NumericUpDownFensterDeckkraft";
      NumericUpDownFensterDeckkraft.Size = new Size(44, 23);
      NumericUpDownFensterDeckkraft.TabIndex = 1;
      NumericUpDownFensterDeckkraft.Value = new decimal(new int[] { 85, 0, 0, 0 });
      NumericUpDownFensterDeckkraft.ValueChanged += NumericUpDownFensterDeckkraft_ValueChanged;
      // 
      // LabelFensterDeckkraft
      // 
      LabelFensterDeckkraft.AutoSize = true;
      LabelFensterDeckkraft.Location = new Point(15, 24);
      LabelFensterDeckkraft.Name = "LabelFensterDeckkraft";
      LabelFensterDeckkraft.Size = new Size(60, 15);
      LabelFensterDeckkraft.TabIndex = 0;
      LabelFensterDeckkraft.Text = "Deckkraft:";
      // 
      // LabelSprache
      // 
      LabelSprache.AutoSize = true;
      LabelSprache.Location = new Point(15, 25);
      LabelSprache.Name = "LabelSprache";
      LabelSprache.Size = new Size(52, 15);
      LabelSprache.TabIndex = 0;
      LabelSprache.Text = "Sprache:";
      // 
      // ComboBoxSprache
      // 
      ComboBoxSprache.BackColor = Color.FromArgb(19, 26, 33);
      ComboBoxSprache.DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBoxSprache.FlatStyle = FlatStyle.Flat;
      ComboBoxSprache.ForeColor = Color.FromArgb(57, 206, 216);
      ComboBoxSprache.FormattingEnabled = true;
      ComboBoxSprache.Location = new Point(191, 22);
      ComboBoxSprache.MaxDropDownItems = 5;
      ComboBoxSprache.Name = "ComboBoxSprache";
      ComboBoxSprache.Size = new Size(147, 23);
      ComboBoxSprache.TabIndex = 1;
      ComboBoxSprache.SelectedIndexChanged += ComboBoxSprache_SelectedIndexChanged;
      // 
      // GroupBoxLokalerCache
      // 
      GroupBoxLokalerCache.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      GroupBoxLokalerCache.Controls.Add(LabelLokalerCacheAlterTage);
      GroupBoxLokalerCache.Controls.Add(NumericUpDownLokalerCacheAlter);
      GroupBoxLokalerCache.Controls.Add(LabelLokalerCacheAlter);
      GroupBoxLokalerCache.FlatStyle = FlatStyle.Flat;
      GroupBoxLokalerCache.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxLokalerCache.Location = new Point(370, 235);
      GroupBoxLokalerCache.Name = "GroupBoxLokalerCache";
      GroupBoxLokalerCache.Size = new Size(379, 124);
      GroupBoxLokalerCache.TabIndex = 2;
      GroupBoxLokalerCache.TabStop = false;
      GroupBoxLokalerCache.Text = "Lokaler Cache";
      // 
      // ButtonStandard
      // 
      ButtonStandard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ButtonStandard.FlatStyle = FlatStyle.Flat;
      ButtonStandard.Location = new Point(674, 368);
      ButtonStandard.Name = "ButtonStandard";
      ButtonStandard.Size = new Size(75, 28);
      ButtonStandard.TabIndex = 8;
      ButtonStandard.Text = "Standard";
      ButtonStandard.UseVisualStyleBackColor = true;
      ButtonStandard.Click += ButtonStandard_Click;
      // 
      // GroupBoxAnzeige
      // 
      GroupBoxAnzeige.Controls.Add(CheckBoxCompactMode);
      GroupBoxAnzeige.Controls.Add(ComboBoxColorThemes);
      GroupBoxAnzeige.Controls.Add(ButtonFarbenStandard);
      GroupBoxAnzeige.Controls.Add(LabelFarben);
      GroupBoxAnzeige.Controls.Add(LabelErgebnisAutomatischLeerenSekunden);
      GroupBoxAnzeige.Controls.Add(LabelErgebnisAutomatischLeeren);
      GroupBoxAnzeige.Controls.Add(CheckBoxHideStreamLiveStatus);
      GroupBoxAnzeige.Controls.Add(CheckBoxFensterAusblenden);
      GroupBoxAnzeige.Controls.Add(CheckBoxDpiUnaware);
      GroupBoxAnzeige.Controls.Add(CheckBoxAutoCheckForUpdate);
      GroupBoxAnzeige.Controls.Add(LabelSprache);
      GroupBoxAnzeige.Controls.Add(NumericUpDownErgebnisAutomatischLeeren);
      GroupBoxAnzeige.Controls.Add(NumericUpDownAffiliationenMaximum);
      GroupBoxAnzeige.Controls.Add(ButtonSplitterColor);
      GroupBoxAnzeige.Controls.Add(ButtonBackColor);
      GroupBoxAnzeige.Controls.Add(ButtonForeColorInactive);
      GroupBoxAnzeige.Controls.Add(ButtonForeColor);
      GroupBoxAnzeige.Controls.Add(LabelMaxAffiliationen);
      GroupBoxAnzeige.Controls.Add(CheckBoxUnkenntlicheAffiliationenAusblenden);
      GroupBoxAnzeige.Controls.Add(ComboBoxSprache);
      GroupBoxAnzeige.FlatStyle = FlatStyle.Flat;
      GroupBoxAnzeige.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxAnzeige.Location = new Point(12, 12);
      GroupBoxAnzeige.Name = "GroupBoxAnzeige";
      GroupBoxAnzeige.Size = new Size(352, 347);
      GroupBoxAnzeige.TabIndex = 0;
      GroupBoxAnzeige.TabStop = false;
      GroupBoxAnzeige.Text = "Anzeige";
      // 
      // CheckBoxCompactMode
      // 
      CheckBoxCompactMode.AutoSize = true;
      CheckBoxCompactMode.Location = new Point(15, 180);
      CheckBoxCompactMode.Name = "CheckBoxCompactMode";
      CheckBoxCompactMode.Size = new Size(111, 19);
      CheckBoxCompactMode.TabIndex = 8;
      CheckBoxCompactMode.Text = "Kompaktmodus";
      CheckBoxCompactMode.UseVisualStyleBackColor = true;
      CheckBoxCompactMode.CheckedChanged += CheckBoxCompactMode_CheckedChanged;
      // 
      // ComboBoxColorThemes
      // 
      ComboBoxColorThemes.BackColor = Color.FromArgb(19, 26, 33);
      ComboBoxColorThemes.DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBoxColorThemes.FlatStyle = FlatStyle.Flat;
      ComboBoxColorThemes.ForeColor = Color.FromArgb(57, 206, 216);
      ComboBoxColorThemes.FormattingEnabled = true;
      ComboBoxColorThemes.Location = new Point(191, 269);
      ComboBoxColorThemes.MaxDropDownItems = 5;
      ComboBoxColorThemes.Name = "ComboBoxColorThemes";
      ComboBoxColorThemes.Size = new Size(147, 23);
      ComboBoxColorThemes.TabIndex = 35;
      ComboBoxColorThemes.SelectedIndexChanged += ComboBoxColorThemes_SelectedIndexChanged;
      // 
      // ButtonFarbenStandard
      // 
      ButtonFarbenStandard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ButtonFarbenStandard.FlatStyle = FlatStyle.Flat;
      ButtonFarbenStandard.Location = new Point(191, 298);
      ButtonFarbenStandard.Name = "ButtonFarbenStandard";
      ButtonFarbenStandard.Size = new Size(147, 28);
      ButtonFarbenStandard.TabIndex = 36;
      ButtonFarbenStandard.Text = "Standardfarben";
      ButtonFarbenStandard.UseVisualStyleBackColor = true;
      ButtonFarbenStandard.Click += ButtonFarbenStandard_Click;
      // 
      // LabelFarben
      // 
      LabelFarben.AutoSize = true;
      LabelFarben.Location = new Point(15, 251);
      LabelFarben.Name = "LabelFarben";
      LabelFarben.Size = new Size(46, 15);
      LabelFarben.TabIndex = 13;
      LabelFarben.Text = "Farben:";
      // 
      // LabelErgebnisAutomatischLeerenSekunden
      // 
      LabelErgebnisAutomatischLeerenSekunden.AutoSize = true;
      LabelErgebnisAutomatischLeerenSekunden.Location = new Point(241, 206);
      LabelErgebnisAutomatischLeerenSekunden.Name = "LabelErgebnisAutomatischLeerenSekunden";
      LabelErgebnisAutomatischLeerenSekunden.Size = new Size(67, 15);
      LabelErgebnisAutomatischLeerenSekunden.TabIndex = 11;
      LabelErgebnisAutomatischLeerenSekunden.Text = "Sekunde(n)";
      // 
      // LabelErgebnisAutomatischLeeren
      // 
      LabelErgebnisAutomatischLeeren.AutoSize = true;
      LabelErgebnisAutomatischLeeren.Location = new Point(15, 202);
      LabelErgebnisAutomatischLeeren.Name = "LabelErgebnisAutomatischLeeren";
      LabelErgebnisAutomatischLeeren.Size = new Size(119, 15);
      LabelErgebnisAutomatischLeeren.TabIndex = 9;
      LabelErgebnisAutomatischLeeren.Text = "Ergebnis leeren nach:";
      // 
      // CheckBoxHideStreamLiveStatus
      // 
      CheckBoxHideStreamLiveStatus.AutoSize = true;
      CheckBoxHideStreamLiveStatus.Location = new Point(15, 105);
      CheckBoxHideStreamLiveStatus.Name = "CheckBoxHideStreamLiveStatus";
      CheckBoxHideStreamLiveStatus.Size = new Size(188, 19);
      CheckBoxHideStreamLiveStatus.TabIndex = 5;
      CheckBoxHideStreamLiveStatus.Text = "Stream Live-Status ausblenden";
      CheckBoxHideStreamLiveStatus.UseVisualStyleBackColor = true;
      CheckBoxHideStreamLiveStatus.CheckedChanged += CheckBoxHideStreamLiveStatus_CheckedChanged;
      // 
      // CheckBoxFensterAusblenden
      // 
      CheckBoxFensterAusblenden.AutoSize = true;
      CheckBoxFensterAusblenden.Location = new Point(191, 229);
      CheckBoxFensterAusblenden.Name = "CheckBoxFensterAusblenden";
      CheckBoxFensterAusblenden.Size = new Size(128, 19);
      CheckBoxFensterAusblenden.TabIndex = 12;
      CheckBoxFensterAusblenden.Text = "Fenster ausblenden";
      CheckBoxFensterAusblenden.UseVisualStyleBackColor = true;
      CheckBoxFensterAusblenden.CheckedChanged += CheckBoxFensterAusblenden_CheckedChanged;
      // 
      // CheckBoxDpiUnaware
      // 
      CheckBoxDpiUnaware.AutoSize = true;
      CheckBoxDpiUnaware.Location = new Point(15, 155);
      CheckBoxDpiUnaware.Name = "CheckBoxDpiUnaware";
      CheckBoxDpiUnaware.Size = new Size(234, 19);
      CheckBoxDpiUnaware.TabIndex = 7;
      CheckBoxDpiUnaware.Text = "Alternative DPI-Berechnung verwenden";
      CheckBoxDpiUnaware.UseVisualStyleBackColor = true;
      CheckBoxDpiUnaware.CheckedChanged += CheckBoxDpiUnaware_CheckedChanged;
      // 
      // CheckBoxAutoCheckForUpdate
      // 
      CheckBoxAutoCheckForUpdate.AutoSize = true;
      CheckBoxAutoCheckForUpdate.Location = new Point(15, 130);
      CheckBoxAutoCheckForUpdate.Name = "CheckBoxAutoCheckForUpdate";
      CheckBoxAutoCheckForUpdate.Size = new Size(236, 19);
      CheckBoxAutoCheckForUpdate.TabIndex = 6;
      CheckBoxAutoCheckForUpdate.Text = "Bei Programmstart nach Update suchen";
      CheckBoxAutoCheckForUpdate.UseVisualStyleBackColor = true;
      CheckBoxAutoCheckForUpdate.CheckedChanged += CheckBoxAutoCheckForUpdate_CheckedChanged;
      // 
      // NumericUpDownErgebnisAutomatischLeeren
      // 
      NumericUpDownErgebnisAutomatischLeeren.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownErgebnisAutomatischLeeren.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownErgebnisAutomatischLeeren.Location = new Point(191, 200);
      NumericUpDownErgebnisAutomatischLeeren.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
      NumericUpDownErgebnisAutomatischLeeren.Name = "NumericUpDownErgebnisAutomatischLeeren";
      NumericUpDownErgebnisAutomatischLeeren.Size = new Size(44, 23);
      NumericUpDownErgebnisAutomatischLeeren.TabIndex = 10;
      NumericUpDownErgebnisAutomatischLeeren.ValueChanged += NumericUpDownErgebnisAutomatischLeeren_ValueChanged;
      // 
      // NumericUpDownAffiliationenMaximum
      // 
      NumericUpDownAffiliationenMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownAffiliationenMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownAffiliationenMaximum.Location = new Point(191, 51);
      NumericUpDownAffiliationenMaximum.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
      NumericUpDownAffiliationenMaximum.Name = "NumericUpDownAffiliationenMaximum";
      NumericUpDownAffiliationenMaximum.Size = new Size(44, 23);
      NumericUpDownAffiliationenMaximum.TabIndex = 3;
      NumericUpDownAffiliationenMaximum.Value = new decimal(new int[] { 3, 0, 0, 0 });
      NumericUpDownAffiliationenMaximum.ValueChanged += NumericUpDownAffiliationenMaximum_ValueChanged;
      // 
      // ButtonSplitterColor
      // 
      ButtonSplitterColor.Cursor = Cursors.Hand;
      ButtonSplitterColor.FlatStyle = FlatStyle.Flat;
      ButtonSplitterColor.Location = new Point(93, 269);
      ButtonSplitterColor.Name = "ButtonSplitterColor";
      ButtonSplitterColor.Size = new Size(20, 20);
      ButtonSplitterColor.TabIndex = 18;
      ButtonSplitterColor.UseVisualStyleBackColor = true;
      ButtonSplitterColor.BackColorChanged += ButtonSplitterColor_BackColorChanged;
      ButtonSplitterColor.Click += ButtonSplitterColor_Click;
      // 
      // ButtonBackColor
      // 
      ButtonBackColor.Cursor = Cursors.Hand;
      ButtonBackColor.FlatStyle = FlatStyle.Flat;
      ButtonBackColor.Location = new Point(67, 269);
      ButtonBackColor.Name = "ButtonBackColor";
      ButtonBackColor.Size = new Size(20, 20);
      ButtonBackColor.TabIndex = 17;
      ButtonBackColor.UseVisualStyleBackColor = true;
      ButtonBackColor.BackColorChanged += ButtonBackColor_BackColorChanged;
      ButtonBackColor.Click += ButtonBackColor_Click;
      // 
      // ButtonForeColorInactive
      // 
      ButtonForeColorInactive.Cursor = Cursors.Hand;
      ButtonForeColorInactive.FlatStyle = FlatStyle.Flat;
      ButtonForeColorInactive.Location = new Point(41, 269);
      ButtonForeColorInactive.Name = "ButtonForeColorInactive";
      ButtonForeColorInactive.Size = new Size(20, 20);
      ButtonForeColorInactive.TabIndex = 16;
      ButtonForeColorInactive.UseVisualStyleBackColor = true;
      ButtonForeColorInactive.BackColorChanged += ButtonForeColorInactive_BackColorChanged;
      ButtonForeColorInactive.Click += ButtonForeColorInactive_Click;
      // 
      // ButtonForeColor
      // 
      ButtonForeColor.Cursor = Cursors.Hand;
      ButtonForeColor.FlatStyle = FlatStyle.Flat;
      ButtonForeColor.Location = new Point(15, 269);
      ButtonForeColor.Name = "ButtonForeColor";
      ButtonForeColor.Size = new Size(20, 20);
      ButtonForeColor.TabIndex = 15;
      ButtonForeColor.UseVisualStyleBackColor = true;
      ButtonForeColor.BackColorChanged += ButtonForeColor_BackColorChanged;
      ButtonForeColor.Click += ButtonForeColor_Click;
      // 
      // LabelMaxAffiliationen
      // 
      LabelMaxAffiliationen.AutoSize = true;
      LabelMaxAffiliationen.Location = new Point(15, 53);
      LabelMaxAffiliationen.Name = "LabelMaxAffiliationen";
      LabelMaxAffiliationen.Size = new Size(132, 15);
      LabelMaxAffiliationen.TabIndex = 2;
      LabelMaxAffiliationen.Text = "Affiliationen Maximum:";
      // 
      // CheckBoxUnkenntlicheAffiliationenAusblenden
      // 
      CheckBoxUnkenntlicheAffiliationenAusblenden.AutoSize = true;
      CheckBoxUnkenntlicheAffiliationenAusblenden.Location = new Point(15, 80);
      CheckBoxUnkenntlicheAffiliationenAusblenden.Name = "CheckBoxUnkenntlicheAffiliationenAusblenden";
      CheckBoxUnkenntlicheAffiliationenAusblenden.Size = new Size(228, 19);
      CheckBoxUnkenntlicheAffiliationenAusblenden.TabIndex = 4;
      CheckBoxUnkenntlicheAffiliationenAusblenden.Text = "Unkenntliche Affiliationen ausblenden";
      CheckBoxUnkenntlicheAffiliationenAusblenden.UseVisualStyleBackColor = true;
      CheckBoxUnkenntlicheAffiliationenAusblenden.CheckedChanged += CheckBoxUnkenntlicheAffiliationenAusblenden_CheckedChanged;
      // 
      // ToolTipSettings
      // 
      ToolTipSettings.BackColor = Color.FromArgb(19, 26, 33);
      ToolTipSettings.ForeColor = Color.FromArgb(57, 206, 216);
      ToolTipSettings.OwnerDraw = true;
      ToolTipSettings.ShowAlways = true;
      ToolTipSettings.Draw += ToolTipHandleQuery_Draw;
      // 
      // FormSettings
      // 
      AcceptButton = ButtonSpeichern;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      CancelButton = ButtonSchliessen;
      ClientSize = new Size(761, 410);
      Controls.Add(GroupBoxAnzeige);
      Controls.Add(GroupBoxLokalerCache);
      Controls.Add(GroupBoxFenster);
      Controls.Add(ButtonStandard);
      Controls.Add(ButtonSchliessen);
      Controls.Add(ButtonSpeichern);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(777, 449);
      Name = "FormSettings";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Star Citizen Handle Query Einstellungen";
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLokalerCacheAlter).EndInit();
      GroupBoxFenster.ResumeLayout(false);
      GroupBoxFenster.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownFensterDeckkraft).EndInit();
      GroupBoxLokalerCache.ResumeLayout(false);
      GroupBoxLokalerCache.PerformLayout();
      GroupBoxAnzeige.ResumeLayout(false);
      GroupBoxAnzeige.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownErgebnisAutomatischLeeren).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownAffiliationenMaximum).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private CheckBox CheckBoxFensterMauseingabenIgnorieren;
    private Label LabelLokalerCacheAlter;
    private NumericUpDown NumericUpDownLokalerCacheAlter;
    private Button ButtonSpeichern;
    private Button ButtonSchliessen;
    private Label LabelFensterDeckkraftProzent;
    private Label LabelLokalerCacheAlterTage;
    private GroupBox GroupBoxFenster;
    private ComboBox ComboBoxTaste;
    private Label LabelTastenkombination;
    private CheckBox CheckBoxUmschalt;
    private CheckBox CheckBoxAlt;
    private CheckBox CheckBoxStrg;
    private GroupBox GroupBoxLokalerCache;
    private Button ButtonStandard;
    private CheckBox CheckBoxAltTabEnabled;
    private Label LabelSprache;
    private ComboBox ComboBoxSprache;
    private GroupBox GroupBoxAnzeige;
    private NumericUpDown NumericUpDownAffiliationenMaximum;
    private Label LabelMaxAffiliationen;
    private CheckBox CheckBoxUnkenntlicheAffiliationenAusblenden;
    private CheckBox CheckBoxPositionMerken;
    private CheckBox CheckBoxAutoCheckForUpdate;
    private CheckBox CheckBoxHideStreamLiveStatus;
    private NumericUpDown NumericUpDownFensterDeckkraft;
    private Label LabelFensterDeckkraft;
    private CheckBox CheckBoxEscAusblenden;
    private CheckBox CheckBoxDpiUnaware;
    private Label LabelErgebnisAutomatischLeeren;
    private NumericUpDown NumericUpDownErgebnisAutomatischLeeren;
    private Label LabelErgebnisAutomatischLeerenSekunden;
    private Label LabelFarben;
    private Button ButtonForeColor;
    private Button ButtonForeColorInactive;
    private Button ButtonSplitterColor;
    private Button ButtonBackColor;
    private CheckBox CheckBoxFensterAusblenden;
    private Button ButtonFarbenStandard;
    private ComboBox ComboBoxColorThemes;
    private ToolTip ToolTipSettings;
    private CheckBox CheckBoxCompactMode;
  }
}