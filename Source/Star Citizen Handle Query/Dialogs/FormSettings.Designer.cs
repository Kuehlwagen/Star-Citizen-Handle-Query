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
      NumericUpDownRelationsEntriesMaximum = new NumericUpDown();
      LabelRelationsEntriesMaximum = new Label();
      CheckBoxSortRelationsAlphabetically = new CheckBox();
      CheckBoxShowRelations = new CheckBox();
      LabelLogEintragAnzeigedauerMinuten = new Label();
      LabelLogEintragAnzeigeDauer = new Label();
      NumericUpDownLogEintragAnzeigedauer = new NumericUpDown();
      NumericUpDownLogEintraegeMaximum = new NumericUpDown();
      LabelLogEintraegeMaximum = new Label();
      CheckBoxLogMonitorFilterLoadingScreenDuration = new CheckBox();
      CheckBoxLogMonitorFilterCorpse = new CheckBox();
      CheckBoxShowLog = new CheckBox();
      GroupBoxLocation = new GroupBox();
      NumericUpDownOrteEintraegeMaximum = new NumericUpDown();
      LabelOrteEintraegeMaximum = new Label();
      CheckBoxShowLocations = new CheckBox();
      TextBoxRMB_URL = new TextBox();
      TextBoxMMB_URL = new TextBox();
      TextBoxLMB_URL = new TextBox();
      LabelRMB_URL = new Label();
      LabelMMB_URL = new Label();
      LabelLMB_URL = new Label();
      GroupBoxLogMonitor = new GroupBox();
      TextBoxLogMonitorHandleFilter = new TextBox();
      LabelLogMonitorHandleFilter = new Label();
      CheckBoxCheckCompleteFile = new CheckBox();
      GroupBoxBeziehungen = new GroupBox();
      ButtonEditPrcChannels = new Button();
      LabelGRPCKanalPasswort = new Label();
      CheckBoxRPCSyncOnStartup = new CheckBox();
      TextBoxGRPCChannelPassword = new TextBox();
      TextBoxGRPCChannel = new TextBox();
      TextBoxGRPCURL = new TextBox();
      LabelGRPCURL = new Label();
      LabelGRPCChannel = new Label();
      ButtonFarbenStandard = new Button();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLokalerCacheAlter).BeginInit();
      GroupBoxFenster.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownFensterDeckkraft).BeginInit();
      GroupBoxLokalerCache.SuspendLayout();
      GroupBoxAnzeige.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownErgebnisAutomatischLeeren).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownAffiliationenMaximum).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownRelationsEntriesMaximum).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintragAnzeigedauer).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintraegeMaximum).BeginInit();
      GroupBoxLocation.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownOrteEintraegeMaximum).BeginInit();
      GroupBoxLogMonitor.SuspendLayout();
      GroupBoxBeziehungen.SuspendLayout();
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
      ButtonSpeichern.Location = new Point(12, 621);
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
      ButtonSchliessen.Location = new Point(93, 621);
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
      GroupBoxFenster.Location = new Point(12, 316);
      GroupBoxFenster.Name = "GroupBoxFenster";
      GroupBoxFenster.Size = new Size(352, 221);
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
      GroupBoxLokalerCache.Controls.Add(LabelLokalerCacheAlterTage);
      GroupBoxLokalerCache.Controls.Add(NumericUpDownLokalerCacheAlter);
      GroupBoxLokalerCache.Controls.Add(LabelLokalerCacheAlter);
      GroupBoxLokalerCache.FlatStyle = FlatStyle.Flat;
      GroupBoxLokalerCache.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxLokalerCache.Location = new Point(12, 543);
      GroupBoxLokalerCache.Name = "GroupBoxLokalerCache";
      GroupBoxLokalerCache.Size = new Size(352, 67);
      GroupBoxLokalerCache.TabIndex = 2;
      GroupBoxLokalerCache.TabStop = false;
      GroupBoxLokalerCache.Text = "Lokaler Cache";
      // 
      // ButtonStandard
      // 
      ButtonStandard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ButtonStandard.FlatStyle = FlatStyle.Flat;
      ButtonStandard.Location = new Point(711, 621);
      ButtonStandard.Name = "ButtonStandard";
      ButtonStandard.Size = new Size(75, 28);
      ButtonStandard.TabIndex = 8;
      ButtonStandard.Text = "Standard";
      ButtonStandard.UseVisualStyleBackColor = true;
      ButtonStandard.Click += ButtonStandard_Click;
      // 
      // GroupBoxAnzeige
      // 
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
      GroupBoxAnzeige.Size = new Size(352, 298);
      GroupBoxAnzeige.TabIndex = 0;
      GroupBoxAnzeige.TabStop = false;
      GroupBoxAnzeige.Text = "Anzeige";
      // 
      // LabelFarben
      // 
      LabelFarben.AutoSize = true;
      LabelFarben.Location = new Point(15, 231);
      LabelFarben.Name = "LabelFarben";
      LabelFarben.Size = new Size(46, 15);
      LabelFarben.TabIndex = 11;
      LabelFarben.Text = "Farben:";
      // 
      // LabelErgebnisAutomatischLeerenSekunden
      // 
      LabelErgebnisAutomatischLeerenSekunden.AutoSize = true;
      LabelErgebnisAutomatischLeerenSekunden.Location = new Point(241, 182);
      LabelErgebnisAutomatischLeerenSekunden.Name = "LabelErgebnisAutomatischLeerenSekunden";
      LabelErgebnisAutomatischLeerenSekunden.Size = new Size(67, 15);
      LabelErgebnisAutomatischLeerenSekunden.TabIndex = 9;
      LabelErgebnisAutomatischLeerenSekunden.Text = "Sekunde(n)";
      // 
      // LabelErgebnisAutomatischLeeren
      // 
      LabelErgebnisAutomatischLeeren.AutoSize = true;
      LabelErgebnisAutomatischLeeren.Location = new Point(15, 182);
      LabelErgebnisAutomatischLeeren.Name = "LabelErgebnisAutomatischLeeren";
      LabelErgebnisAutomatischLeeren.Size = new Size(119, 15);
      LabelErgebnisAutomatischLeeren.TabIndex = 7;
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
      CheckBoxFensterAusblenden.Location = new Point(191, 209);
      CheckBoxFensterAusblenden.Name = "CheckBoxFensterAusblenden";
      CheckBoxFensterAusblenden.Size = new Size(128, 19);
      CheckBoxFensterAusblenden.TabIndex = 10;
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
      CheckBoxDpiUnaware.TabIndex = 6;
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
      NumericUpDownErgebnisAutomatischLeeren.Location = new Point(191, 180);
      NumericUpDownErgebnisAutomatischLeeren.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
      NumericUpDownErgebnisAutomatischLeeren.Name = "NumericUpDownErgebnisAutomatischLeeren";
      NumericUpDownErgebnisAutomatischLeeren.Size = new Size(44, 23);
      NumericUpDownErgebnisAutomatischLeeren.TabIndex = 8;
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
      ButtonSplitterColor.Location = new Point(117, 249);
      ButtonSplitterColor.Name = "ButtonSplitterColor";
      ButtonSplitterColor.Size = new Size(28, 28);
      ButtonSplitterColor.TabIndex = 15;
      ButtonSplitterColor.UseVisualStyleBackColor = true;
      ButtonSplitterColor.BackColorChanged += ButtonSplitterColor_BackColorChanged;
      ButtonSplitterColor.Click += ButtonSplitterColor_Click;
      // 
      // ButtonBackColor
      // 
      ButtonBackColor.Cursor = Cursors.Hand;
      ButtonBackColor.FlatStyle = FlatStyle.Flat;
      ButtonBackColor.Location = new Point(83, 249);
      ButtonBackColor.Name = "ButtonBackColor";
      ButtonBackColor.Size = new Size(28, 28);
      ButtonBackColor.TabIndex = 14;
      ButtonBackColor.UseVisualStyleBackColor = true;
      ButtonBackColor.BackColorChanged += ButtonBackColor_BackColorChanged;
      ButtonBackColor.Click += ButtonBackColor_Click;
      // 
      // ButtonForeColorInactive
      // 
      ButtonForeColorInactive.Cursor = Cursors.Hand;
      ButtonForeColorInactive.FlatStyle = FlatStyle.Flat;
      ButtonForeColorInactive.Location = new Point(49, 249);
      ButtonForeColorInactive.Name = "ButtonForeColorInactive";
      ButtonForeColorInactive.Size = new Size(28, 28);
      ButtonForeColorInactive.TabIndex = 13;
      ButtonForeColorInactive.UseVisualStyleBackColor = true;
      ButtonForeColorInactive.BackColorChanged += ButtonForeColorInactive_BackColorChanged;
      ButtonForeColorInactive.Click += ButtonForeColorInactive_Click;
      // 
      // ButtonForeColor
      // 
      ButtonForeColor.Cursor = Cursors.Hand;
      ButtonForeColor.FlatStyle = FlatStyle.Flat;
      ButtonForeColor.Location = new Point(15, 249);
      ButtonForeColor.Name = "ButtonForeColor";
      ButtonForeColor.Size = new Size(28, 28);
      ButtonForeColor.TabIndex = 12;
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
      // NumericUpDownRelationsEntriesMaximum
      // 
      NumericUpDownRelationsEntriesMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownRelationsEntriesMaximum.Enabled = false;
      NumericUpDownRelationsEntriesMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownRelationsEntriesMaximum.Location = new Point(190, 76);
      NumericUpDownRelationsEntriesMaximum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.Name = "NumericUpDownRelationsEntriesMaximum";
      NumericUpDownRelationsEntriesMaximum.Size = new Size(44, 23);
      NumericUpDownRelationsEntriesMaximum.TabIndex = 3;
      NumericUpDownRelationsEntriesMaximum.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.ValueChanged += NumericUpDownRelationsEntriesMaximum_ValueChanged;
      // 
      // LabelRelationsEntriesMaximum
      // 
      LabelRelationsEntriesMaximum.AutoSize = true;
      LabelRelationsEntriesMaximum.Location = new Point(34, 78);
      LabelRelationsEntriesMaximum.Name = "LabelRelationsEntriesMaximum";
      LabelRelationsEntriesMaximum.Size = new Size(110, 15);
      LabelRelationsEntriesMaximum.TabIndex = 2;
      LabelRelationsEntriesMaximum.Text = "Einträge Maximum:";
      // 
      // CheckBoxSortRelationsAlphabetically
      // 
      CheckBoxSortRelationsAlphabetically.AutoSize = true;
      CheckBoxSortRelationsAlphabetically.Enabled = false;
      CheckBoxSortRelationsAlphabetically.Location = new Point(34, 54);
      CheckBoxSortRelationsAlphabetically.Name = "CheckBoxSortRelationsAlphabetically";
      CheckBoxSortRelationsAlphabetically.Size = new Size(144, 19);
      CheckBoxSortRelationsAlphabetically.TabIndex = 1;
      CheckBoxSortRelationsAlphabetically.Text = "Alphabetisch sortieren";
      CheckBoxSortRelationsAlphabetically.UseVisualStyleBackColor = true;
      CheckBoxSortRelationsAlphabetically.CheckedChanged += CheckBoxSortRelationsAlphabetically_CheckedChanged;
      // 
      // CheckBoxShowRelations
      // 
      CheckBoxShowRelations.AutoSize = true;
      CheckBoxShowRelations.Location = new Point(15, 27);
      CheckBoxShowRelations.Name = "CheckBoxShowRelations";
      CheckBoxShowRelations.Size = new Size(144, 19);
      CheckBoxShowRelations.TabIndex = 0;
      CheckBoxShowRelations.Text = "Beziehungen anzeigen";
      CheckBoxShowRelations.UseVisualStyleBackColor = true;
      CheckBoxShowRelations.CheckedChanged += CheckBoxShowRelations_CheckedChanged;
      // 
      // LabelLogEintragAnzeigedauerMinuten
      // 
      LabelLogEintragAnzeigedauerMinuten.AutoSize = true;
      LabelLogEintragAnzeigedauerMinuten.Location = new Point(240, 83);
      LabelLogEintragAnzeigedauerMinuten.Name = "LabelLogEintragAnzeigedauerMinuten";
      LabelLogEintragAnzeigedauerMinuten.Size = new Size(60, 15);
      LabelLogEintragAnzeigedauerMinuten.TabIndex = 5;
      LabelLogEintragAnzeigedauerMinuten.Text = "Minute(n)";
      // 
      // LabelLogEintragAnzeigeDauer
      // 
      LabelLogEintragAnzeigeDauer.AutoSize = true;
      LabelLogEintragAnzeigeDauer.Location = new Point(32, 83);
      LabelLogEintragAnzeigeDauer.Name = "LabelLogEintragAnzeigeDauer";
      LabelLogEintragAnzeigeDauer.Size = new Size(122, 15);
      LabelLogEintragAnzeigeDauer.TabIndex = 0;
      LabelLogEintragAnzeigeDauer.Text = "Eintrag Anzeigedauer:";
      // 
      // NumericUpDownLogEintragAnzeigedauer
      // 
      NumericUpDownLogEintragAnzeigedauer.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownLogEintragAnzeigedauer.Enabled = false;
      NumericUpDownLogEintragAnzeigedauer.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownLogEintragAnzeigedauer.Location = new Point(190, 81);
      NumericUpDownLogEintragAnzeigedauer.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
      NumericUpDownLogEintragAnzeigedauer.Name = "NumericUpDownLogEintragAnzeigedauer";
      NumericUpDownLogEintragAnzeigedauer.Size = new Size(44, 23);
      NumericUpDownLogEintragAnzeigedauer.TabIndex = 4;
      NumericUpDownLogEintragAnzeigedauer.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownLogEintragAnzeigedauer.ValueChanged += NumericUpDownLogEintragAnzeigedauer_ValueChanged;
      // 
      // NumericUpDownLogEintraegeMaximum
      // 
      NumericUpDownLogEintraegeMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownLogEintraegeMaximum.Enabled = false;
      NumericUpDownLogEintraegeMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownLogEintraegeMaximum.Location = new Point(190, 52);
      NumericUpDownLogEintraegeMaximum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.Name = "NumericUpDownLogEintraegeMaximum";
      NumericUpDownLogEintraegeMaximum.Size = new Size(44, 23);
      NumericUpDownLogEintraegeMaximum.TabIndex = 2;
      NumericUpDownLogEintraegeMaximum.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.ValueChanged += NumericUpDownLogEintraegeMaximum_ValueChanged;
      // 
      // LabelLogEintraegeMaximum
      // 
      LabelLogEintraegeMaximum.AutoSize = true;
      LabelLogEintraegeMaximum.Location = new Point(32, 54);
      LabelLogEintraegeMaximum.Name = "LabelLogEintraegeMaximum";
      LabelLogEintraegeMaximum.Size = new Size(110, 15);
      LabelLogEintraegeMaximum.TabIndex = 1;
      LabelLogEintraegeMaximum.Text = "Einträge Maximum:";
      // 
      // CheckBoxLogMonitorFilterLoadingScreenDuration
      // 
      CheckBoxLogMonitorFilterLoadingScreenDuration.AutoSize = true;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Enabled = false;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Location = new Point(190, 110);
      CheckBoxLogMonitorFilterLoadingScreenDuration.Name = "CheckBoxLogMonitorFilterLoadingScreenDuration";
      CheckBoxLogMonitorFilterLoadingScreenDuration.Size = new Size(193, 19);
      CheckBoxLogMonitorFilterLoadingScreenDuration.TabIndex = 7;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Text = "Ladebildschirm-Dauer anzeigen";
      CheckBoxLogMonitorFilterLoadingScreenDuration.UseVisualStyleBackColor = true;
      CheckBoxLogMonitorFilterLoadingScreenDuration.CheckedChanged += CheckBoxLogMonitorFilterLoadingScreenDuration_CheckedChanged;
      // 
      // CheckBoxLogMonitorFilterCorpse
      // 
      CheckBoxLogMonitorFilterCorpse.AutoSize = true;
      CheckBoxLogMonitorFilterCorpse.Enabled = false;
      CheckBoxLogMonitorFilterCorpse.Location = new Point(34, 110);
      CheckBoxLogMonitorFilterCorpse.Name = "CheckBoxLogMonitorFilterCorpse";
      CheckBoxLogMonitorFilterCorpse.Size = new Size(135, 19);
      CheckBoxLogMonitorFilterCorpse.TabIndex = 6;
      CheckBoxLogMonitorFilterCorpse.Text = "Spielertode anzeigen";
      CheckBoxLogMonitorFilterCorpse.UseVisualStyleBackColor = true;
      CheckBoxLogMonitorFilterCorpse.CheckedChanged += CheckBoxLogMonitorFilterCorpse_CheckedChanged;
      // 
      // CheckBoxShowLog
      // 
      CheckBoxShowLog.AutoSize = true;
      CheckBoxShowLog.Location = new Point(15, 27);
      CheckBoxShowLog.Name = "CheckBoxShowLog";
      CheckBoxShowLog.Size = new Size(144, 19);
      CheckBoxShowLog.TabIndex = 0;
      CheckBoxShowLog.Text = "Log-Monitor anzeigen";
      CheckBoxShowLog.UseVisualStyleBackColor = true;
      CheckBoxShowLog.CheckedChanged += CheckBoxShowLog_CheckedChanged;
      // 
      // GroupBoxLocation
      // 
      GroupBoxLocation.Controls.Add(NumericUpDownOrteEintraegeMaximum);
      GroupBoxLocation.Controls.Add(LabelOrteEintraegeMaximum);
      GroupBoxLocation.Controls.Add(CheckBoxShowLocations);
      GroupBoxLocation.Controls.Add(TextBoxRMB_URL);
      GroupBoxLocation.Controls.Add(TextBoxMMB_URL);
      GroupBoxLocation.Controls.Add(TextBoxLMB_URL);
      GroupBoxLocation.Controls.Add(LabelRMB_URL);
      GroupBoxLocation.Controls.Add(LabelMMB_URL);
      GroupBoxLocation.Controls.Add(LabelLMB_URL);
      GroupBoxLocation.FlatStyle = FlatStyle.Flat;
      GroupBoxLocation.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxLocation.Location = new Point(370, 12);
      GroupBoxLocation.Name = "GroupBoxLocation";
      GroupBoxLocation.Size = new Size(416, 170);
      GroupBoxLocation.TabIndex = 3;
      GroupBoxLocation.TabStop = false;
      GroupBoxLocation.Text = "Orte (Alt + Eingabe)";
      // 
      // NumericUpDownOrteEintraegeMaximum
      // 
      NumericUpDownOrteEintraegeMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownOrteEintraegeMaximum.Enabled = false;
      NumericUpDownOrteEintraegeMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownOrteEintraegeMaximum.Location = new Point(190, 48);
      NumericUpDownOrteEintraegeMaximum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownOrteEintraegeMaximum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      NumericUpDownOrteEintraegeMaximum.Name = "NumericUpDownOrteEintraegeMaximum";
      NumericUpDownOrteEintraegeMaximum.Size = new Size(44, 23);
      NumericUpDownOrteEintraegeMaximum.TabIndex = 2;
      NumericUpDownOrteEintraegeMaximum.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownOrteEintraegeMaximum.ValueChanged += NumericUpDownOrteEintraegeMaximum_ValueChanged;
      // 
      // LabelOrteEintraegeMaximum
      // 
      LabelOrteEintraegeMaximum.AutoSize = true;
      LabelOrteEintraegeMaximum.Location = new Point(32, 50);
      LabelOrteEintraegeMaximum.Name = "LabelOrteEintraegeMaximum";
      LabelOrteEintraegeMaximum.Size = new Size(110, 15);
      LabelOrteEintraegeMaximum.TabIndex = 1;
      LabelOrteEintraegeMaximum.Text = "Einträge Maximum:";
      // 
      // CheckBoxShowLocations
      // 
      CheckBoxShowLocations.AutoSize = true;
      CheckBoxShowLocations.Location = new Point(15, 26);
      CheckBoxShowLocations.Name = "CheckBoxShowLocations";
      CheckBoxShowLocations.Size = new Size(99, 19);
      CheckBoxShowLocations.TabIndex = 0;
      CheckBoxShowLocations.Text = "Orte anzeigen";
      CheckBoxShowLocations.UseVisualStyleBackColor = true;
      CheckBoxShowLocations.CheckedChanged += CheckBoxShowLocations_CheckedChanged;
      // 
      // TextBoxRMB_URL
      // 
      TextBoxRMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxRMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxRMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxRMB_URL.Location = new Point(190, 135);
      TextBoxRMB_URL.Name = "TextBoxRMB_URL";
      TextBoxRMB_URL.Size = new Size(213, 23);
      TextBoxRMB_URL.TabIndex = 8;
      TextBoxRMB_URL.TextChanged += TextBoxRMB_URL_TextChanged;
      // 
      // TextBoxMMB_URL
      // 
      TextBoxMMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxMMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxMMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxMMB_URL.Location = new Point(190, 106);
      TextBoxMMB_URL.Name = "TextBoxMMB_URL";
      TextBoxMMB_URL.Size = new Size(213, 23);
      TextBoxMMB_URL.TabIndex = 6;
      TextBoxMMB_URL.Text = "{WikiLink}|https://starcitizen.tools/{Name}";
      TextBoxMMB_URL.TextChanged += TextBoxMMB_URL_TextChanged;
      // 
      // TextBoxLMB_URL
      // 
      TextBoxLMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxLMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxLMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxLMB_URL.Location = new Point(190, 77);
      TextBoxLMB_URL.Name = "TextBoxLMB_URL";
      TextBoxLMB_URL.Size = new Size(213, 23);
      TextBoxLMB_URL.TabIndex = 4;
      TextBoxLMB_URL.Text = "https://dydrmr.github.io/VerseTime/#{Name}";
      TextBoxLMB_URL.TextChanged += TextBoxLMB_URL_TextChanged;
      // 
      // LabelRMB_URL
      // 
      LabelRMB_URL.AutoSize = true;
      LabelRMB_URL.Location = new Point(32, 137);
      LabelRMB_URL.Name = "LabelRMB_URL";
      LabelRMB_URL.Size = new Size(103, 15);
      LabelRMB_URL.TabIndex = 7;
      LabelRMB_URL.Text = "Rechte Maustaste:";
      // 
      // LabelMMB_URL
      // 
      LabelMMB_URL.AutoSize = true;
      LabelMMB_URL.Location = new Point(32, 108);
      LabelMMB_URL.Name = "LabelMMB_URL";
      LabelMMB_URL.Size = new Size(108, 15);
      LabelMMB_URL.TabIndex = 5;
      LabelMMB_URL.Text = "Mittlere Maustaste:";
      // 
      // LabelLMB_URL
      // 
      LabelLMB_URL.AutoSize = true;
      LabelLMB_URL.Location = new Point(32, 79);
      LabelLMB_URL.Name = "LabelLMB_URL";
      LabelLMB_URL.Size = new Size(95, 15);
      LabelLMB_URL.TabIndex = 3;
      LabelLMB_URL.Text = "Linke Maustaste:";
      // 
      // GroupBoxLogMonitor
      // 
      GroupBoxLogMonitor.Controls.Add(TextBoxLogMonitorHandleFilter);
      GroupBoxLogMonitor.Controls.Add(LabelLogMonitorHandleFilter);
      GroupBoxLogMonitor.Controls.Add(LabelLogEintragAnzeigedauerMinuten);
      GroupBoxLogMonitor.Controls.Add(CheckBoxShowLog);
      GroupBoxLogMonitor.Controls.Add(CheckBoxLogMonitorFilterCorpse);
      GroupBoxLogMonitor.Controls.Add(CheckBoxCheckCompleteFile);
      GroupBoxLogMonitor.Controls.Add(CheckBoxLogMonitorFilterLoadingScreenDuration);
      GroupBoxLogMonitor.Controls.Add(LabelLogEintraegeMaximum);
      GroupBoxLogMonitor.Controls.Add(NumericUpDownLogEintraegeMaximum);
      GroupBoxLogMonitor.Controls.Add(LabelLogEintragAnzeigeDauer);
      GroupBoxLogMonitor.Controls.Add(NumericUpDownLogEintragAnzeigedauer);
      GroupBoxLogMonitor.FlatStyle = FlatStyle.Flat;
      GroupBoxLogMonitor.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxLogMonitor.Location = new Point(370, 415);
      GroupBoxLogMonitor.Name = "GroupBoxLogMonitor";
      GroupBoxLogMonitor.Size = new Size(416, 195);
      GroupBoxLogMonitor.TabIndex = 5;
      GroupBoxLogMonitor.TabStop = false;
      GroupBoxLogMonitor.Text = "Log-Monitor";
      // 
      // TextBoxLogMonitorHandleFilter
      // 
      TextBoxLogMonitorHandleFilter.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxLogMonitorHandleFilter.BorderStyle = BorderStyle.FixedSingle;
      TextBoxLogMonitorHandleFilter.Enabled = false;
      TextBoxLogMonitorHandleFilter.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxLogMonitorHandleFilter.Location = new Point(190, 154);
      TextBoxLogMonitorHandleFilter.Name = "TextBoxLogMonitorHandleFilter";
      TextBoxLogMonitorHandleFilter.Size = new Size(213, 23);
      TextBoxLogMonitorHandleFilter.TabIndex = 10;
      TextBoxLogMonitorHandleFilter.TextChanged += TextBoxLogMonitorHandleFilter_TextChanged;
      // 
      // LabelLogMonitorHandleFilter
      // 
      LabelLogMonitorHandleFilter.AutoSize = true;
      LabelLogMonitorHandleFilter.Location = new Point(32, 157);
      LabelLogMonitorHandleFilter.Name = "LabelLogMonitorHandleFilter";
      LabelLogMonitorHandleFilter.Size = new Size(79, 15);
      LabelLogMonitorHandleFilter.TabIndex = 9;
      LabelLogMonitorHandleFilter.Text = "Handle-Filter:";
      // 
      // CheckBoxCheckCompleteFile
      // 
      CheckBoxCheckCompleteFile.AutoSize = true;
      CheckBoxCheckCompleteFile.Enabled = false;
      CheckBoxCheckCompleteFile.Location = new Point(34, 135);
      CheckBoxCheckCompleteFile.Name = "CheckBoxCheckCompleteFile";
      CheckBoxCheckCompleteFile.Size = new Size(168, 19);
      CheckBoxCheckCompleteFile.TabIndex = 8;
      CheckBoxCheckCompleteFile.Text = "Komplette Datei auswerten";
      CheckBoxCheckCompleteFile.UseVisualStyleBackColor = true;
      CheckBoxCheckCompleteFile.CheckedChanged += CheckBoxCheckCompleteFile_CheckedChanged;
      // 
      // GroupBoxBeziehungen
      // 
      GroupBoxBeziehungen.Controls.Add(ButtonEditPrcChannels);
      GroupBoxBeziehungen.Controls.Add(LabelGRPCKanalPasswort);
      GroupBoxBeziehungen.Controls.Add(CheckBoxRPCSyncOnStartup);
      GroupBoxBeziehungen.Controls.Add(NumericUpDownRelationsEntriesMaximum);
      GroupBoxBeziehungen.Controls.Add(CheckBoxShowRelations);
      GroupBoxBeziehungen.Controls.Add(LabelRelationsEntriesMaximum);
      GroupBoxBeziehungen.Controls.Add(CheckBoxSortRelationsAlphabetically);
      GroupBoxBeziehungen.Controls.Add(TextBoxGRPCChannelPassword);
      GroupBoxBeziehungen.Controls.Add(TextBoxGRPCChannel);
      GroupBoxBeziehungen.Controls.Add(TextBoxGRPCURL);
      GroupBoxBeziehungen.Controls.Add(LabelGRPCURL);
      GroupBoxBeziehungen.Controls.Add(LabelGRPCChannel);
      GroupBoxBeziehungen.FlatStyle = FlatStyle.Flat;
      GroupBoxBeziehungen.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxBeziehungen.Location = new Point(370, 188);
      GroupBoxBeziehungen.Name = "GroupBoxBeziehungen";
      GroupBoxBeziehungen.Size = new Size(416, 221);
      GroupBoxBeziehungen.TabIndex = 4;
      GroupBoxBeziehungen.TabStop = false;
      GroupBoxBeziehungen.Text = "Beziehungen";
      // 
      // ButtonEditPrcChannels
      // 
      ButtonEditPrcChannels.BackgroundImageLayout = ImageLayout.Center;
      ButtonEditPrcChannels.FlatStyle = FlatStyle.Flat;
      ButtonEditPrcChannels.Location = new Point(380, 134);
      ButtonEditPrcChannels.Name = "ButtonEditPrcChannels";
      ButtonEditPrcChannels.Size = new Size(23, 23);
      ButtonEditPrcChannels.TabIndex = 8;
      ButtonEditPrcChannels.UseVisualStyleBackColor = true;
      ButtonEditPrcChannels.Click += ButtonEditPrcChannels_Click;
      ButtonEditPrcChannels.Paint += ButtonEditPrcChannels_Paint;
      // 
      // LabelGRPCKanalPasswort
      // 
      LabelGRPCKanalPasswort.AutoSize = true;
      LabelGRPCKanalPasswort.Location = new Point(32, 165);
      LabelGRPCKanalPasswort.Name = "LabelGRPCKanalPasswort";
      LabelGRPCKanalPasswort.Size = new Size(123, 15);
      LabelGRPCKanalPasswort.TabIndex = 9;
      LabelGRPCKanalPasswort.Text = "gRPC Kanal-Passwort:";
      // 
      // CheckBoxRPCSyncOnStartup
      // 
      CheckBoxRPCSyncOnStartup.AutoSize = true;
      CheckBoxRPCSyncOnStartup.Location = new Point(34, 192);
      CheckBoxRPCSyncOnStartup.Name = "CheckBoxRPCSyncOnStartup";
      CheckBoxRPCSyncOnStartup.Size = new Size(254, 19);
      CheckBoxRPCSyncOnStartup.TabIndex = 11;
      CheckBoxRPCSyncOnStartup.Text = "gRPC-Synchronisierung bei Programmstart";
      CheckBoxRPCSyncOnStartup.UseVisualStyleBackColor = true;
      CheckBoxRPCSyncOnStartup.CheckedChanged += CheckBoxRPCSyncOnStartup_CheckedChanged;
      // 
      // TextBoxGRPCChannelPassword
      // 
      TextBoxGRPCChannelPassword.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxGRPCChannelPassword.BorderStyle = BorderStyle.FixedSingle;
      TextBoxGRPCChannelPassword.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxGRPCChannelPassword.Location = new Point(190, 163);
      TextBoxGRPCChannelPassword.Name = "TextBoxGRPCChannelPassword";
      TextBoxGRPCChannelPassword.PasswordChar = '*';
      TextBoxGRPCChannelPassword.Size = new Size(213, 23);
      TextBoxGRPCChannelPassword.TabIndex = 10;
      TextBoxGRPCChannelPassword.TextChanged += MaskedTextBoxGRPCKanalPasswort_TextChanged;
      // 
      // TextBoxGRPCChannel
      // 
      TextBoxGRPCChannel.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxGRPCChannel.BorderStyle = BorderStyle.FixedSingle;
      TextBoxGRPCChannel.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxGRPCChannel.Location = new Point(190, 134);
      TextBoxGRPCChannel.Name = "TextBoxGRPCChannel";
      TextBoxGRPCChannel.Size = new Size(188, 23);
      TextBoxGRPCChannel.TabIndex = 7;
      TextBoxGRPCChannel.TextChanged += TextBoxGRPCChannel_TextChanged;
      // 
      // TextBoxGRPCURL
      // 
      TextBoxGRPCURL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxGRPCURL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxGRPCURL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxGRPCURL.Location = new Point(190, 105);
      TextBoxGRPCURL.Name = "TextBoxGRPCURL";
      TextBoxGRPCURL.Size = new Size(213, 23);
      TextBoxGRPCURL.TabIndex = 5;
      TextBoxGRPCURL.TextChanged += TextBoxGRPCURL_TextChanged;
      // 
      // LabelGRPCURL
      // 
      LabelGRPCURL.AutoSize = true;
      LabelGRPCURL.Location = new Point(32, 107);
      LabelGRPCURL.Name = "LabelGRPCURL";
      LabelGRPCURL.Size = new Size(100, 15);
      LabelGRPCURL.TabIndex = 4;
      LabelGRPCURL.Text = "gRPC Server-URL:";
      // 
      // LabelGRPCChannel
      // 
      LabelGRPCChannel.AutoSize = true;
      LabelGRPCChannel.Location = new Point(32, 136);
      LabelGRPCChannel.Name = "LabelGRPCChannel";
      LabelGRPCChannel.Size = new Size(71, 15);
      LabelGRPCChannel.TabIndex = 6;
      LabelGRPCChannel.Text = "gRPC Kanal:";
      // 
      // ButtonFarbenStandard
      // 
      ButtonFarbenStandard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ButtonFarbenStandard.FlatStyle = FlatStyle.Flat;
      ButtonFarbenStandard.Location = new Point(151, 249);
      ButtonFarbenStandard.Name = "ButtonFarbenStandard";
      ButtonFarbenStandard.Size = new Size(75, 28);
      ButtonFarbenStandard.TabIndex = 16;
      ButtonFarbenStandard.Text = "Standard";
      ButtonFarbenStandard.UseVisualStyleBackColor = true;
      ButtonFarbenStandard.Click += ButtonFarbenStandard_Click;
      // 
      // FormSettings
      // 
      AcceptButton = ButtonSpeichern;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      CancelButton = ButtonSchliessen;
      ClientSize = new Size(798, 663);
      Controls.Add(GroupBoxAnzeige);
      Controls.Add(GroupBoxLocation);
      Controls.Add(GroupBoxLogMonitor);
      Controls.Add(GroupBoxBeziehungen);
      Controls.Add(GroupBoxLokalerCache);
      Controls.Add(GroupBoxFenster);
      Controls.Add(ButtonStandard);
      Controls.Add(ButtonSchliessen);
      Controls.Add(ButtonSpeichern);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(814, 702);
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
      ((System.ComponentModel.ISupportInitialize)NumericUpDownRelationsEntriesMaximum).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintragAnzeigedauer).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintraegeMaximum).EndInit();
      GroupBoxLocation.ResumeLayout(false);
      GroupBoxLocation.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownOrteEintraegeMaximum).EndInit();
      GroupBoxLogMonitor.ResumeLayout(false);
      GroupBoxLogMonitor.PerformLayout();
      GroupBoxBeziehungen.ResumeLayout(false);
      GroupBoxBeziehungen.PerformLayout();
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
    private CheckBox CheckBoxShowLog;
    private NumericUpDown NumericUpDownFensterDeckkraft;
    private Label LabelFensterDeckkraft;
    private NumericUpDown NumericUpDownLogEintraegeMaximum;
    private Label LabelLogEintraegeMaximum;
    private Label LabelLogEintragAnzeigeDauer;
    private NumericUpDown NumericUpDownLogEintragAnzeigedauer;
    private Label LabelLogEintragAnzeigedauerMinuten;
    private NumericUpDown NumericUpDownRelationsEntriesMaximum;
    private Label LabelRelationsEntriesMaximum;
    private CheckBox CheckBoxShowRelations;
    private CheckBox CheckBoxSortRelationsAlphabetically;
    private CheckBox CheckBoxLogMonitorFilterLoadingScreenDuration;
    private CheckBox CheckBoxLogMonitorFilterCorpse;
    private GroupBox GroupBoxLocation;
    private TextBox TextBoxLMB_URL;
    private Label LabelRMB_URL;
    private Label LabelMMB_URL;
    private Label LabelLMB_URL;
    private TextBox TextBoxRMB_URL;
    private TextBox TextBoxMMB_URL;
    private NumericUpDown NumericUpDownOrteEintraegeMaximum;
    private Label LabelOrteEintraegeMaximum;
    private CheckBox CheckBoxShowLocations;
    private GroupBox GroupBoxLogMonitor;
    private GroupBox GroupBoxBeziehungen;
    private TextBox TextBoxGRPCChannel;
    private TextBox TextBoxGRPCURL;
    private Label LabelGRPCURL;
    private Label LabelGRPCChannel;
    private CheckBox CheckBoxRPCSyncOnStartup;
    private Label LabelGRPCKanalPasswort;
    private TextBox TextBoxGRPCChannelPassword;
    private Button ButtonEditPrcChannels;
    private CheckBox CheckBoxCheckCompleteFile;
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
    private TextBox TextBoxLogMonitorHandleFilter;
    private Label LabelLogMonitorHandleFilter;
    private Button ButtonFarbenStandard;
  }
}