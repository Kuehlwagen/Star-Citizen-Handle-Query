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
      CheckBoxHideStreamLiveStatus = new CheckBox();
      CheckBoxAutoCheckForUpdate = new CheckBox();
      NumericUpDownAffiliationenMaximum = new NumericUpDown();
      LabelMaxAffiliationen = new Label();
      CheckBoxUnkenntlicheAffiliationenAusblenden = new CheckBox();
      GroupBoxLocation = new GroupBox();
      TextBoxRMB_URL = new TextBox();
      TextBoxMMB_URL = new TextBox();
      TextBoxLMB_URL = new TextBox();
      LabelRMB_URL = new Label();
      LabelMMB_URL = new Label();
      LabelLMB_URL = new Label();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLokalerCacheAlter).BeginInit();
      GroupBoxFenster.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownFensterDeckkraft).BeginInit();
      GroupBoxLokalerCache.SuspendLayout();
      GroupBoxAnzeige.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownRelationsEntriesMaximum).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintragAnzeigedauer).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintraegeMaximum).BeginInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownAffiliationenMaximum).BeginInit();
      GroupBoxLocation.SuspendLayout();
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
      LabelLokalerCacheAlter.Size = new Size(95, 15);
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
      ButtonSpeichern.FlatStyle = FlatStyle.Flat;
      ButtonSpeichern.Location = new Point(12, 394);
      ButtonSpeichern.Name = "ButtonSpeichern";
      ButtonSpeichern.Size = new Size(75, 28);
      ButtonSpeichern.TabIndex = 4;
      ButtonSpeichern.Text = "Speichern";
      ButtonSpeichern.UseVisualStyleBackColor = true;
      ButtonSpeichern.Click += ButtonSpeichern_Click;
      // 
      // ButtonSchliessen
      // 
      ButtonSchliessen.FlatStyle = FlatStyle.Flat;
      ButtonSchliessen.Location = new Point(93, 394);
      ButtonSchliessen.Name = "ButtonSchliessen";
      ButtonSchliessen.Size = new Size(75, 28);
      ButtonSchliessen.TabIndex = 5;
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
      LabelLokalerCacheAlterTage.Size = new Size(39, 15);
      LabelLokalerCacheAlterTage.TabIndex = 2;
      LabelLokalerCacheAlterTage.Text = "Tag(e)";
      // 
      // GroupBoxFenster
      // 
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
      GroupBoxFenster.Location = new Point(370, 12);
      GroupBoxFenster.Name = "GroupBoxFenster";
      GroupBoxFenster.Size = new Size(416, 187);
      GroupBoxFenster.TabIndex = 1;
      GroupBoxFenster.TabStop = false;
      GroupBoxFenster.Text = "Fenster";
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
      CheckBoxAltTabEnabled.Size = new Size(166, 19);
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
      LabelTastenkombination.Size = new Size(79, 15);
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
      GroupBoxLokalerCache.Location = new Point(370, 326);
      GroupBoxLokalerCache.Name = "GroupBoxLokalerCache";
      GroupBoxLokalerCache.Size = new Size(416, 62);
      GroupBoxLokalerCache.TabIndex = 3;
      GroupBoxLokalerCache.TabStop = false;
      GroupBoxLokalerCache.Text = "Lokaler Cache";
      // 
      // ButtonStandard
      // 
      ButtonStandard.FlatStyle = FlatStyle.Flat;
      ButtonStandard.Location = new Point(711, 394);
      ButtonStandard.Name = "ButtonStandard";
      ButtonStandard.Size = new Size(75, 28);
      ButtonStandard.TabIndex = 6;
      ButtonStandard.Text = "Standard";
      ButtonStandard.UseVisualStyleBackColor = true;
      ButtonStandard.Click += ButtonStandard_Click;
      // 
      // GroupBoxAnzeige
      // 
      GroupBoxAnzeige.Controls.Add(NumericUpDownRelationsEntriesMaximum);
      GroupBoxAnzeige.Controls.Add(LabelRelationsEntriesMaximum);
      GroupBoxAnzeige.Controls.Add(CheckBoxSortRelationsAlphabetically);
      GroupBoxAnzeige.Controls.Add(CheckBoxShowRelations);
      GroupBoxAnzeige.Controls.Add(LabelLogEintragAnzeigedauerMinuten);
      GroupBoxAnzeige.Controls.Add(LabelLogEintragAnzeigeDauer);
      GroupBoxAnzeige.Controls.Add(NumericUpDownLogEintragAnzeigedauer);
      GroupBoxAnzeige.Controls.Add(NumericUpDownLogEintraegeMaximum);
      GroupBoxAnzeige.Controls.Add(LabelLogEintraegeMaximum);
      GroupBoxAnzeige.Controls.Add(CheckBoxLogMonitorFilterLoadingScreenDuration);
      GroupBoxAnzeige.Controls.Add(CheckBoxLogMonitorFilterCorpse);
      GroupBoxAnzeige.Controls.Add(CheckBoxShowLog);
      GroupBoxAnzeige.Controls.Add(CheckBoxHideStreamLiveStatus);
      GroupBoxAnzeige.Controls.Add(CheckBoxAutoCheckForUpdate);
      GroupBoxAnzeige.Controls.Add(LabelSprache);
      GroupBoxAnzeige.Controls.Add(NumericUpDownAffiliationenMaximum);
      GroupBoxAnzeige.Controls.Add(LabelMaxAffiliationen);
      GroupBoxAnzeige.Controls.Add(CheckBoxUnkenntlicheAffiliationenAusblenden);
      GroupBoxAnzeige.Controls.Add(ComboBoxSprache);
      GroupBoxAnzeige.FlatStyle = FlatStyle.Flat;
      GroupBoxAnzeige.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxAnzeige.Location = new Point(12, 12);
      GroupBoxAnzeige.Name = "GroupBoxAnzeige";
      GroupBoxAnzeige.Size = new Size(352, 376);
      GroupBoxAnzeige.TabIndex = 0;
      GroupBoxAnzeige.TabStop = false;
      GroupBoxAnzeige.Text = "Anzeige";
      // 
      // NumericUpDownRelationsEntriesMaximum
      // 
      NumericUpDownRelationsEntriesMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownRelationsEntriesMaximum.Enabled = false;
      NumericUpDownRelationsEntriesMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownRelationsEntriesMaximum.Location = new Point(190, 337);
      NumericUpDownRelationsEntriesMaximum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.Name = "NumericUpDownRelationsEntriesMaximum";
      NumericUpDownRelationsEntriesMaximum.Size = new Size(44, 23);
      NumericUpDownRelationsEntriesMaximum.TabIndex = 18;
      NumericUpDownRelationsEntriesMaximum.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownRelationsEntriesMaximum.ValueChanged += NumericUpDownRelationsEntriesMaximum_ValueChanged;
      // 
      // LabelRelationsEntriesMaximum
      // 
      LabelRelationsEntriesMaximum.AutoSize = true;
      LabelRelationsEntriesMaximum.Location = new Point(34, 339);
      LabelRelationsEntriesMaximum.Name = "LabelRelationsEntriesMaximum";
      LabelRelationsEntriesMaximum.Size = new Size(111, 15);
      LabelRelationsEntriesMaximum.TabIndex = 17;
      LabelRelationsEntriesMaximum.Text = "Einträge Maximum:";
      // 
      // CheckBoxSortRelationsAlphabetically
      // 
      CheckBoxSortRelationsAlphabetically.AutoSize = true;
      CheckBoxSortRelationsAlphabetically.Enabled = false;
      CheckBoxSortRelationsAlphabetically.Location = new Point(34, 315);
      CheckBoxSortRelationsAlphabetically.Name = "CheckBoxSortRelationsAlphabetically";
      CheckBoxSortRelationsAlphabetically.Size = new Size(144, 19);
      CheckBoxSortRelationsAlphabetically.TabIndex = 16;
      CheckBoxSortRelationsAlphabetically.Text = "Alphabetisch sortieren";
      CheckBoxSortRelationsAlphabetically.UseVisualStyleBackColor = true;
      CheckBoxSortRelationsAlphabetically.CheckedChanged += CheckBoxSortRelationsAlphabetically_CheckedChanged;
      // 
      // CheckBoxShowRelations
      // 
      CheckBoxShowRelations.AutoSize = true;
      CheckBoxShowRelations.Location = new Point(15, 288);
      CheckBoxShowRelations.Name = "CheckBoxShowRelations";
      CheckBoxShowRelations.Size = new Size(144, 19);
      CheckBoxShowRelations.TabIndex = 15;
      CheckBoxShowRelations.Text = "Beziehungen anzeigen";
      CheckBoxShowRelations.UseVisualStyleBackColor = true;
      CheckBoxShowRelations.CheckedChanged += CheckBoxShowRelations_CheckedChanged;
      // 
      // LabelLogEintragAnzeigedauerMinuten
      // 
      LabelLogEintragAnzeigedauerMinuten.AutoSize = true;
      LabelLogEintragAnzeigedauerMinuten.Location = new Point(240, 211);
      LabelLogEintragAnzeigedauerMinuten.Name = "LabelLogEintragAnzeigedauerMinuten";
      LabelLogEintragAnzeigedauerMinuten.Size = new Size(60, 15);
      LabelLogEintragAnzeigedauerMinuten.TabIndex = 12;
      LabelLogEintragAnzeigedauerMinuten.Text = "Minute(n)";
      // 
      // LabelLogEintragAnzeigeDauer
      // 
      LabelLogEintragAnzeigeDauer.AutoSize = true;
      LabelLogEintragAnzeigeDauer.Location = new Point(32, 211);
      LabelLogEintragAnzeigeDauer.Name = "LabelLogEintragAnzeigeDauer";
      LabelLogEintragAnzeigeDauer.Size = new Size(122, 15);
      LabelLogEintragAnzeigeDauer.TabIndex = 10;
      LabelLogEintragAnzeigeDauer.Text = "Eintrag Anzeigedauer:";
      // 
      // NumericUpDownLogEintragAnzeigedauer
      // 
      NumericUpDownLogEintragAnzeigedauer.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownLogEintragAnzeigedauer.Enabled = false;
      NumericUpDownLogEintragAnzeigedauer.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownLogEintragAnzeigedauer.Location = new Point(190, 209);
      NumericUpDownLogEintragAnzeigedauer.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
      NumericUpDownLogEintragAnzeigedauer.Name = "NumericUpDownLogEintragAnzeigedauer";
      NumericUpDownLogEintragAnzeigedauer.Size = new Size(44, 23);
      NumericUpDownLogEintragAnzeigedauer.TabIndex = 11;
      NumericUpDownLogEintragAnzeigedauer.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownLogEintragAnzeigedauer.ValueChanged += NumericUpDownLogEintragAnzeigedauer_ValueChanged;
      // 
      // NumericUpDownLogEintraegeMaximum
      // 
      NumericUpDownLogEintraegeMaximum.BackColor = Color.FromArgb(19, 26, 33);
      NumericUpDownLogEintraegeMaximum.Enabled = false;
      NumericUpDownLogEintraegeMaximum.ForeColor = Color.FromArgb(57, 206, 216);
      NumericUpDownLogEintraegeMaximum.Location = new Point(190, 180);
      NumericUpDownLogEintraegeMaximum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.Name = "NumericUpDownLogEintraegeMaximum";
      NumericUpDownLogEintraegeMaximum.Size = new Size(44, 23);
      NumericUpDownLogEintraegeMaximum.TabIndex = 9;
      NumericUpDownLogEintraegeMaximum.Value = new decimal(new int[] { 10, 0, 0, 0 });
      NumericUpDownLogEintraegeMaximum.ValueChanged += NumericUpDownLogEintraegeMaximum_ValueChanged;
      // 
      // LabelLogEintraegeMaximum
      // 
      LabelLogEintraegeMaximum.AutoSize = true;
      LabelLogEintraegeMaximum.Location = new Point(32, 182);
      LabelLogEintraegeMaximum.Name = "LabelLogEintraegeMaximum";
      LabelLogEintraegeMaximum.Size = new Size(111, 15);
      LabelLogEintraegeMaximum.TabIndex = 8;
      LabelLogEintraegeMaximum.Text = "Einträge Maximum:";
      // 
      // CheckBoxLogMonitorFilterLoadingScreenDuration
      // 
      CheckBoxLogMonitorFilterLoadingScreenDuration.AutoSize = true;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Enabled = false;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Location = new Point(34, 263);
      CheckBoxLogMonitorFilterLoadingScreenDuration.Name = "CheckBoxLogMonitorFilterLoadingScreenDuration";
      CheckBoxLogMonitorFilterLoadingScreenDuration.Size = new Size(193, 19);
      CheckBoxLogMonitorFilterLoadingScreenDuration.TabIndex = 14;
      CheckBoxLogMonitorFilterLoadingScreenDuration.Text = "Ladebildschirm-Dauer anzeigen";
      CheckBoxLogMonitorFilterLoadingScreenDuration.UseVisualStyleBackColor = true;
      CheckBoxLogMonitorFilterLoadingScreenDuration.CheckedChanged += CheckBoxLogMonitorFilterLoadingScreenDuration_CheckedChanged;
      // 
      // CheckBoxLogMonitorFilterCorpse
      // 
      CheckBoxLogMonitorFilterCorpse.AutoSize = true;
      CheckBoxLogMonitorFilterCorpse.Enabled = false;
      CheckBoxLogMonitorFilterCorpse.Location = new Point(34, 238);
      CheckBoxLogMonitorFilterCorpse.Name = "CheckBoxLogMonitorFilterCorpse";
      CheckBoxLogMonitorFilterCorpse.Size = new Size(135, 19);
      CheckBoxLogMonitorFilterCorpse.TabIndex = 13;
      CheckBoxLogMonitorFilterCorpse.Text = "Spielertode anzeigen";
      CheckBoxLogMonitorFilterCorpse.UseVisualStyleBackColor = true;
      CheckBoxLogMonitorFilterCorpse.CheckedChanged += CheckBoxLogMonitorFilterCorpse_CheckedChanged;
      // 
      // CheckBoxShowLog
      // 
      CheckBoxShowLog.AutoSize = true;
      CheckBoxShowLog.Location = new Point(15, 155);
      CheckBoxShowLog.Name = "CheckBoxShowLog";
      CheckBoxShowLog.Size = new Size(144, 19);
      CheckBoxShowLog.TabIndex = 7;
      CheckBoxShowLog.Text = "Log-Monitor anzeigen";
      CheckBoxShowLog.UseVisualStyleBackColor = true;
      CheckBoxShowLog.CheckedChanged += CheckBoxShowLog_CheckedChanged;
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
      // LabelMaxAffiliationen
      // 
      LabelMaxAffiliationen.AutoSize = true;
      LabelMaxAffiliationen.Location = new Point(15, 53);
      LabelMaxAffiliationen.Name = "LabelMaxAffiliationen";
      LabelMaxAffiliationen.Size = new Size(133, 15);
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
      // GroupBoxLocation
      // 
      GroupBoxLocation.Controls.Add(TextBoxRMB_URL);
      GroupBoxLocation.Controls.Add(TextBoxMMB_URL);
      GroupBoxLocation.Controls.Add(TextBoxLMB_URL);
      GroupBoxLocation.Controls.Add(LabelRMB_URL);
      GroupBoxLocation.Controls.Add(LabelMMB_URL);
      GroupBoxLocation.Controls.Add(LabelLMB_URL);
      GroupBoxLocation.FlatStyle = FlatStyle.Flat;
      GroupBoxLocation.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxLocation.Location = new Point(370, 205);
      GroupBoxLocation.Name = "GroupBoxLocation";
      GroupBoxLocation.Size = new Size(416, 115);
      GroupBoxLocation.TabIndex = 2;
      GroupBoxLocation.TabStop = false;
      GroupBoxLocation.Text = "Orte (Alt + Eingabe)";
      // 
      // TextBoxRMB_URL
      // 
      TextBoxRMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxRMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxRMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxRMB_URL.Location = new Point(173, 79);
      TextBoxRMB_URL.Name = "TextBoxRMB_URL";
      TextBoxRMB_URL.Size = new Size(230, 23);
      TextBoxRMB_URL.TabIndex = 5;
      TextBoxRMB_URL.TextChanged += TextBoxRMB_URL_TextChanged;
      // 
      // TextBoxMMB_URL
      // 
      TextBoxMMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxMMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxMMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxMMB_URL.Location = new Point(173, 50);
      TextBoxMMB_URL.Name = "TextBoxMMB_URL";
      TextBoxMMB_URL.Size = new Size(230, 23);
      TextBoxMMB_URL.TabIndex = 3;
      TextBoxMMB_URL.Text = "https://starcitizen.tools/{Name}";
      TextBoxMMB_URL.TextChanged += TextBoxMMB_URL_TextChanged;
      // 
      // TextBoxLMB_URL
      // 
      TextBoxLMB_URL.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxLMB_URL.BorderStyle = BorderStyle.FixedSingle;
      TextBoxLMB_URL.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxLMB_URL.Location = new Point(173, 21);
      TextBoxLMB_URL.Name = "TextBoxLMB_URL";
      TextBoxLMB_URL.Size = new Size(230, 23);
      TextBoxLMB_URL.TabIndex = 1;
      TextBoxLMB_URL.Text = "https://dydrmr.github.io/VerseTime/#{Name}";
      TextBoxLMB_URL.TextChanged += TextBoxLMB_URL_TextChanged;
      // 
      // LabelRMB_URL
      // 
      LabelRMB_URL.AutoSize = true;
      LabelRMB_URL.Location = new Point(15, 82);
      LabelRMB_URL.Name = "LabelRMB_URL";
      LabelRMB_URL.Size = new Size(103, 15);
      LabelRMB_URL.TabIndex = 4;
      LabelRMB_URL.Text = "Rechte Maustaste:";
      // 
      // LabelMMB_URL
      // 
      LabelMMB_URL.AutoSize = true;
      LabelMMB_URL.Location = new Point(15, 53);
      LabelMMB_URL.Name = "LabelMMB_URL";
      LabelMMB_URL.Size = new Size(108, 15);
      LabelMMB_URL.TabIndex = 2;
      LabelMMB_URL.Text = "Mittlere Maustaste:";
      // 
      // LabelLMB_URL
      // 
      LabelLMB_URL.AutoSize = true;
      LabelLMB_URL.Location = new Point(15, 24);
      LabelLMB_URL.Name = "LabelLMB_URL";
      LabelLMB_URL.Size = new Size(95, 15);
      LabelLMB_URL.TabIndex = 1;
      LabelLMB_URL.Text = "Linke Maustaste:";
      // 
      // FormSettings
      // 
      AcceptButton = ButtonSpeichern;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      CancelButton = ButtonSchliessen;
      ClientSize = new Size(798, 438);
      Controls.Add(GroupBoxAnzeige);
      Controls.Add(GroupBoxLocation);
      Controls.Add(GroupBoxLokalerCache);
      Controls.Add(GroupBoxFenster);
      Controls.Add(ButtonStandard);
      Controls.Add(ButtonSchliessen);
      Controls.Add(ButtonSpeichern);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(814, 477);
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
      ((System.ComponentModel.ISupportInitialize)NumericUpDownRelationsEntriesMaximum).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintragAnzeigedauer).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownLogEintraegeMaximum).EndInit();
      ((System.ComponentModel.ISupportInitialize)NumericUpDownAffiliationenMaximum).EndInit();
      GroupBoxLocation.ResumeLayout(false);
      GroupBoxLocation.PerformLayout();
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
  }
}