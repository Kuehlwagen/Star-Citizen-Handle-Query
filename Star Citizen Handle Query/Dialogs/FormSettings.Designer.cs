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
      this.LabelFensterDeckkraft = new System.Windows.Forms.Label();
      this.NumericUpDownFensterDeckkraft = new System.Windows.Forms.NumericUpDown();
      this.CheckBoxFensterMauseingabenIgnorieren = new System.Windows.Forms.CheckBox();
      this.LabelLokalerCacheAlter = new System.Windows.Forms.Label();
      this.NumericUpDownLokalerCacheAlter = new System.Windows.Forms.NumericUpDown();
      this.LabelApiKey = new System.Windows.Forms.Label();
      this.TextBoxApiKey = new System.Windows.Forms.TextBox();
      this.ButtonSpeichern = new System.Windows.Forms.Button();
      this.ButtonSchliessen = new System.Windows.Forms.Button();
      this.LabelFensterDeckkraftProzent = new System.Windows.Forms.Label();
      this.LabelLokalerCacheAlterTage = new System.Windows.Forms.Label();
      this.GroupBoxFenster = new System.Windows.Forms.GroupBox();
      this.CheckBoxAltTabEnabled = new System.Windows.Forms.CheckBox();
      this.CheckBoxUmschalt = new System.Windows.Forms.CheckBox();
      this.CheckBoxAlt = new System.Windows.Forms.CheckBox();
      this.CheckBoxStrg = new System.Windows.Forms.CheckBox();
      this.ComboBoxTaste = new System.Windows.Forms.ComboBox();
      this.LabelTastenkombination = new System.Windows.Forms.Label();
      this.CheckBoxShowCacheType = new System.Windows.Forms.CheckBox();
      this.LabelSprache = new System.Windows.Forms.Label();
      this.ComboBoxSprache = new System.Windows.Forms.ComboBox();
      this.GroupBoxAPI = new System.Windows.Forms.GroupBox();
      this.LabelApiTestStatus = new System.Windows.Forms.Label();
      this.LabelModusBeschreibung = new System.Windows.Forms.Label();
      this.ComboBoxApiModus = new System.Windows.Forms.ComboBox();
      this.LabelApiMode = new System.Windows.Forms.Label();
      this.ButtonApiTest = new System.Windows.Forms.Button();
      this.GroupBoxLokalerCache = new System.Windows.Forms.GroupBox();
      this.ButtonStandard = new System.Windows.Forms.Button();
      this.GroupBoxAnzeige = new System.Windows.Forms.GroupBox();
      this.CheckBoxMainOrgShowAdditionalInformation = new System.Windows.Forms.CheckBox();
      this.NumericUpDownAffiliationenMaximum = new System.Windows.Forms.NumericUpDown();
      this.LabelMaxAffiliationen = new System.Windows.Forms.Label();
      this.CheckBoxUnkenntlicheAffiliationenAusblenden = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFensterDeckkraft)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLokalerCacheAlter)).BeginInit();
      this.GroupBoxFenster.SuspendLayout();
      this.GroupBoxAPI.SuspendLayout();
      this.GroupBoxLokalerCache.SuspendLayout();
      this.GroupBoxAnzeige.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAffiliationenMaximum)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelFensterDeckkraft
      // 
      this.LabelFensterDeckkraft.AutoSize = true;
      this.LabelFensterDeckkraft.Location = new System.Drawing.Point(15, 24);
      this.LabelFensterDeckkraft.Name = "LabelFensterDeckkraft";
      this.LabelFensterDeckkraft.Size = new System.Drawing.Size(60, 15);
      this.LabelFensterDeckkraft.TabIndex = 0;
      this.LabelFensterDeckkraft.Text = "Deckkraft:";
      // 
      // NumericUpDownFensterDeckkraft
      // 
      this.NumericUpDownFensterDeckkraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.NumericUpDownFensterDeckkraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.NumericUpDownFensterDeckkraft.Location = new System.Drawing.Point(154, 22);
      this.NumericUpDownFensterDeckkraft.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.NumericUpDownFensterDeckkraft.Name = "NumericUpDownFensterDeckkraft";
      this.NumericUpDownFensterDeckkraft.Size = new System.Drawing.Size(44, 23);
      this.NumericUpDownFensterDeckkraft.TabIndex = 1;
      this.NumericUpDownFensterDeckkraft.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
      this.NumericUpDownFensterDeckkraft.ValueChanged += new System.EventHandler(this.NumericUpDownFensterDeckkraft_ValueChanged);
      // 
      // CheckBoxFensterMauseingabenIgnorieren
      // 
      this.CheckBoxFensterMauseingabenIgnorieren.AutoSize = true;
      this.CheckBoxFensterMauseingabenIgnorieren.Location = new System.Drawing.Point(15, 105);
      this.CheckBoxFensterMauseingabenIgnorieren.Name = "CheckBoxFensterMauseingabenIgnorieren";
      this.CheckBoxFensterMauseingabenIgnorieren.Size = new System.Drawing.Size(161, 19);
      this.CheckBoxFensterMauseingabenIgnorieren.TabIndex = 8;
      this.CheckBoxFensterMauseingabenIgnorieren.Text = "Mauseingaben ignorieren";
      this.CheckBoxFensterMauseingabenIgnorieren.UseVisualStyleBackColor = true;
      this.CheckBoxFensterMauseingabenIgnorieren.CheckedChanged += new System.EventHandler(this.CheckBoxFensterMauseingabenIgnorieren_CheckedChanged);
      // 
      // LabelLokalerCacheAlter
      // 
      this.LabelLokalerCacheAlter.AutoSize = true;
      this.LabelLokalerCacheAlter.Location = new System.Drawing.Point(15, 24);
      this.LabelLokalerCacheAlter.Name = "LabelLokalerCacheAlter";
      this.LabelLokalerCacheAlter.Size = new System.Drawing.Size(95, 15);
      this.LabelLokalerCacheAlter.TabIndex = 0;
      this.LabelLokalerCacheAlter.Text = "Maximales Alter:";
      // 
      // NumericUpDownLokalerCacheAlter
      // 
      this.NumericUpDownLokalerCacheAlter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.NumericUpDownLokalerCacheAlter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.NumericUpDownLokalerCacheAlter.Location = new System.Drawing.Point(154, 22);
      this.NumericUpDownLokalerCacheAlter.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
      this.NumericUpDownLokalerCacheAlter.Name = "NumericUpDownLokalerCacheAlter";
      this.NumericUpDownLokalerCacheAlter.Size = new System.Drawing.Size(44, 23);
      this.NumericUpDownLokalerCacheAlter.TabIndex = 1;
      this.NumericUpDownLokalerCacheAlter.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      this.NumericUpDownLokalerCacheAlter.ValueChanged += new System.EventHandler(this.NumericUpDownLokalerCacheAlter_ValueChanged);
      // 
      // LabelApiKey
      // 
      this.LabelApiKey.AutoSize = true;
      this.LabelApiKey.Location = new System.Drawing.Point(15, 25);
      this.LabelApiKey.Name = "LabelApiKey";
      this.LabelApiKey.Size = new System.Drawing.Size(58, 15);
      this.LabelApiKey.TabIndex = 0;
      this.LabelApiKey.Text = "Schlüssel:";
      // 
      // TextBoxApiKey
      // 
      this.TextBoxApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.TextBoxApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.TextBoxApiKey.Location = new System.Drawing.Point(154, 22);
      this.TextBoxApiKey.MaxLength = 32;
      this.TextBoxApiKey.Name = "TextBoxApiKey";
      this.TextBoxApiKey.PlaceholderText = "32-stelligen API-Schlüssel eingeben...";
      this.TextBoxApiKey.Size = new System.Drawing.Size(243, 23);
      this.TextBoxApiKey.TabIndex = 1;
      this.TextBoxApiKey.TextChanged += new System.EventHandler(this.TextBoxApiKey_TextChanged);
      // 
      // ButtonSpeichern
      // 
      this.ButtonSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonSpeichern.Location = new System.Drawing.Point(12, 536);
      this.ButtonSpeichern.Name = "ButtonSpeichern";
      this.ButtonSpeichern.Size = new System.Drawing.Size(75, 28);
      this.ButtonSpeichern.TabIndex = 4;
      this.ButtonSpeichern.Text = "Speichern";
      this.ButtonSpeichern.UseVisualStyleBackColor = true;
      this.ButtonSpeichern.Click += new System.EventHandler(this.ButtonSpeichern_Click);
      // 
      // ButtonSchliessen
      // 
      this.ButtonSchliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonSchliessen.Location = new System.Drawing.Point(93, 536);
      this.ButtonSchliessen.Name = "ButtonSchliessen";
      this.ButtonSchliessen.Size = new System.Drawing.Size(75, 28);
      this.ButtonSchliessen.TabIndex = 5;
      this.ButtonSchliessen.Text = "Schließen";
      this.ButtonSchliessen.UseVisualStyleBackColor = true;
      this.ButtonSchliessen.Click += new System.EventHandler(this.ButtonSchliessen_Click);
      // 
      // LabelFensterDeckkraftProzent
      // 
      this.LabelFensterDeckkraftProzent.AutoSize = true;
      this.LabelFensterDeckkraftProzent.Location = new System.Drawing.Point(197, 24);
      this.LabelFensterDeckkraftProzent.Name = "LabelFensterDeckkraftProzent";
      this.LabelFensterDeckkraftProzent.Size = new System.Drawing.Size(17, 15);
      this.LabelFensterDeckkraftProzent.TabIndex = 2;
      this.LabelFensterDeckkraftProzent.Text = "%";
      // 
      // LabelLokalerCacheAlterTage
      // 
      this.LabelLokalerCacheAlterTage.AutoSize = true;
      this.LabelLokalerCacheAlterTage.Location = new System.Drawing.Point(204, 24);
      this.LabelLokalerCacheAlterTage.Name = "LabelLokalerCacheAlterTage";
      this.LabelLokalerCacheAlterTage.Size = new System.Drawing.Size(39, 15);
      this.LabelLokalerCacheAlterTage.TabIndex = 2;
      this.LabelLokalerCacheAlterTage.Text = "Tag(e)";
      // 
      // GroupBoxFenster
      // 
      this.GroupBoxFenster.Controls.Add(this.CheckBoxAltTabEnabled);
      this.GroupBoxFenster.Controls.Add(this.CheckBoxUmschalt);
      this.GroupBoxFenster.Controls.Add(this.CheckBoxAlt);
      this.GroupBoxFenster.Controls.Add(this.CheckBoxStrg);
      this.GroupBoxFenster.Controls.Add(this.ComboBoxTaste);
      this.GroupBoxFenster.Controls.Add(this.LabelTastenkombination);
      this.GroupBoxFenster.Controls.Add(this.NumericUpDownFensterDeckkraft);
      this.GroupBoxFenster.Controls.Add(this.LabelFensterDeckkraft);
      this.GroupBoxFenster.Controls.Add(this.CheckBoxFensterMauseingabenIgnorieren);
      this.GroupBoxFenster.Controls.Add(this.LabelFensterDeckkraftProzent);
      this.GroupBoxFenster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GroupBoxFenster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.GroupBoxFenster.Location = new System.Drawing.Point(12, 304);
      this.GroupBoxFenster.Name = "GroupBoxFenster";
      this.GroupBoxFenster.Size = new System.Drawing.Size(416, 159);
      this.GroupBoxFenster.TabIndex = 2;
      this.GroupBoxFenster.TabStop = false;
      this.GroupBoxFenster.Text = "Fenster";
      // 
      // CheckBoxAltTabEnabled
      // 
      this.CheckBoxAltTabEnabled.AutoSize = true;
      this.CheckBoxAltTabEnabled.Location = new System.Drawing.Point(15, 130);
      this.CheckBoxAltTabEnabled.Name = "CheckBoxAltTabEnabled";
      this.CheckBoxAltTabEnabled.Size = new System.Drawing.Size(166, 19);
      this.CheckBoxAltTabEnabled.TabIndex = 9;
      this.CheckBoxAltTabEnabled.Text = "Erreichbarkeit via Alt + Tab";
      this.CheckBoxAltTabEnabled.UseVisualStyleBackColor = true;
      this.CheckBoxAltTabEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxAltTabEnabled_CheckedChanged);
      // 
      // CheckBoxUmschalt
      // 
      this.CheckBoxUmschalt.AutoSize = true;
      this.CheckBoxUmschalt.Location = new System.Drawing.Point(254, 80);
      this.CheckBoxUmschalt.Name = "CheckBoxUmschalt";
      this.CheckBoxUmschalt.Size = new System.Drawing.Size(76, 19);
      this.CheckBoxUmschalt.TabIndex = 7;
      this.CheckBoxUmschalt.Text = "Umschalt";
      this.CheckBoxUmschalt.UseVisualStyleBackColor = true;
      this.CheckBoxUmschalt.CheckedChanged += new System.EventHandler(this.CheckBoxUmschalt_CheckedChanged);
      // 
      // CheckBoxAlt
      // 
      this.CheckBoxAlt.AutoSize = true;
      this.CheckBoxAlt.Location = new System.Drawing.Point(207, 80);
      this.CheckBoxAlt.Name = "CheckBoxAlt";
      this.CheckBoxAlt.Size = new System.Drawing.Size(41, 19);
      this.CheckBoxAlt.TabIndex = 6;
      this.CheckBoxAlt.Text = "Alt";
      this.CheckBoxAlt.UseVisualStyleBackColor = true;
      this.CheckBoxAlt.CheckedChanged += new System.EventHandler(this.CheckBoxAlt_CheckedChanged);
      // 
      // CheckBoxStrg
      // 
      this.CheckBoxStrg.AutoSize = true;
      this.CheckBoxStrg.Location = new System.Drawing.Point(154, 80);
      this.CheckBoxStrg.Name = "CheckBoxStrg";
      this.CheckBoxStrg.Size = new System.Drawing.Size(47, 19);
      this.CheckBoxStrg.TabIndex = 5;
      this.CheckBoxStrg.Text = "Strg";
      this.CheckBoxStrg.UseVisualStyleBackColor = true;
      this.CheckBoxStrg.CheckedChanged += new System.EventHandler(this.CheckBoxStrg_CheckedChanged);
      // 
      // ComboBoxTaste
      // 
      this.ComboBoxTaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ComboBoxTaste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxTaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ComboBoxTaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.ComboBoxTaste.FormattingEnabled = true;
      this.ComboBoxTaste.Location = new System.Drawing.Point(154, 51);
      this.ComboBoxTaste.MaxDropDownItems = 5;
      this.ComboBoxTaste.Name = "ComboBoxTaste";
      this.ComboBoxTaste.Size = new System.Drawing.Size(78, 23);
      this.ComboBoxTaste.TabIndex = 4;
      this.ComboBoxTaste.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTaste_SelectedIndexChanged);
      // 
      // LabelTastenkombination
      // 
      this.LabelTastenkombination.AutoSize = true;
      this.LabelTastenkombination.Location = new System.Drawing.Point(15, 54);
      this.LabelTastenkombination.Name = "LabelTastenkombination";
      this.LabelTastenkombination.Size = new System.Drawing.Size(79, 15);
      this.LabelTastenkombination.TabIndex = 3;
      this.LabelTastenkombination.Text = "Globale Taste:";
      // 
      // CheckBoxShowCacheType
      // 
      this.CheckBoxShowCacheType.AutoSize = true;
      this.CheckBoxShowCacheType.Location = new System.Drawing.Point(15, 130);
      this.CheckBoxShowCacheType.Name = "CheckBoxShowCacheType";
      this.CheckBoxShowCacheType.Size = new System.Drawing.Size(203, 19);
      this.CheckBoxShowCacheType.TabIndex = 6;
      this.CheckBoxShowCacheType.Text = "Verwendeten Cache-Typ anzeigen";
      this.CheckBoxShowCacheType.UseVisualStyleBackColor = true;
      this.CheckBoxShowCacheType.CheckedChanged += new System.EventHandler(this.CheckBoxShowCacheType_CheckedChanged);
      // 
      // LabelSprache
      // 
      this.LabelSprache.AutoSize = true;
      this.LabelSprache.Location = new System.Drawing.Point(15, 25);
      this.LabelSprache.Name = "LabelSprache";
      this.LabelSprache.Size = new System.Drawing.Size(52, 15);
      this.LabelSprache.TabIndex = 0;
      this.LabelSprache.Text = "Sprache:";
      // 
      // ComboBoxSprache
      // 
      this.ComboBoxSprache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ComboBoxSprache.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxSprache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ComboBoxSprache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.ComboBoxSprache.FormattingEnabled = true;
      this.ComboBoxSprache.Location = new System.Drawing.Point(154, 22);
      this.ComboBoxSprache.MaxDropDownItems = 5;
      this.ComboBoxSprache.Name = "ComboBoxSprache";
      this.ComboBoxSprache.Size = new System.Drawing.Size(147, 23);
      this.ComboBoxSprache.TabIndex = 1;
      this.ComboBoxSprache.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSprache_SelectedIndexChanged);
      // 
      // GroupBoxAPI
      // 
      this.GroupBoxAPI.Controls.Add(this.LabelApiTestStatus);
      this.GroupBoxAPI.Controls.Add(this.LabelModusBeschreibung);
      this.GroupBoxAPI.Controls.Add(this.ComboBoxApiModus);
      this.GroupBoxAPI.Controls.Add(this.LabelApiMode);
      this.GroupBoxAPI.Controls.Add(this.TextBoxApiKey);
      this.GroupBoxAPI.Controls.Add(this.LabelApiKey);
      this.GroupBoxAPI.Controls.Add(this.ButtonApiTest);
      this.GroupBoxAPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.GroupBoxAPI.Location = new System.Drawing.Point(12, 12);
      this.GroupBoxAPI.Name = "GroupBoxAPI";
      this.GroupBoxAPI.Size = new System.Drawing.Size(416, 121);
      this.GroupBoxAPI.TabIndex = 0;
      this.GroupBoxAPI.TabStop = false;
      this.GroupBoxAPI.Text = "API (starcitizen-api.com)";
      // 
      // LabelApiTestStatus
      // 
      this.LabelApiTestStatus.AutoSize = true;
      this.LabelApiTestStatus.Location = new System.Drawing.Point(235, 87);
      this.LabelApiTestStatus.Name = "LabelApiTestStatus";
      this.LabelApiTestStatus.Size = new System.Drawing.Size(0, 15);
      this.LabelApiTestStatus.TabIndex = 5;
      // 
      // LabelModusBeschreibung
      // 
      this.LabelModusBeschreibung.AutoSize = true;
      this.LabelModusBeschreibung.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelModusBeschreibung.Location = new System.Drawing.Point(249, 54);
      this.LabelModusBeschreibung.Name = "LabelModusBeschreibung";
      this.LabelModusBeschreibung.Size = new System.Drawing.Size(0, 15);
      this.LabelModusBeschreibung.TabIndex = 11;
      // 
      // ComboBoxApiModus
      // 
      this.ComboBoxApiModus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ComboBoxApiModus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxApiModus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ComboBoxApiModus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.ComboBoxApiModus.FormattingEnabled = true;
      this.ComboBoxApiModus.Location = new System.Drawing.Point(154, 51);
      this.ComboBoxApiModus.MaxDropDownItems = 5;
      this.ComboBoxApiModus.Name = "ComboBoxApiModus";
      this.ComboBoxApiModus.Size = new System.Drawing.Size(89, 23);
      this.ComboBoxApiModus.TabIndex = 3;
      this.ComboBoxApiModus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxApiModus_SelectedIndexChanged);
      // 
      // LabelApiMode
      // 
      this.LabelApiMode.AutoSize = true;
      this.LabelApiMode.Location = new System.Drawing.Point(15, 54);
      this.LabelApiMode.Name = "LabelApiMode";
      this.LabelApiMode.Size = new System.Drawing.Size(47, 15);
      this.LabelApiMode.TabIndex = 2;
      this.LabelApiMode.Text = "Modus:";
      // 
      // ButtonApiTest
      // 
      this.ButtonApiTest.Enabled = false;
      this.ButtonApiTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonApiTest.Location = new System.Drawing.Point(154, 80);
      this.ButtonApiTest.Name = "ButtonApiTest";
      this.ButtonApiTest.Size = new System.Drawing.Size(75, 28);
      this.ButtonApiTest.TabIndex = 4;
      this.ButtonApiTest.Text = "API-Test";
      this.ButtonApiTest.UseVisualStyleBackColor = true;
      this.ButtonApiTest.Click += new System.EventHandler(this.ButtonApiTest_Click);
      // 
      // GroupBoxLokalerCache
      // 
      this.GroupBoxLokalerCache.Controls.Add(this.LabelLokalerCacheAlterTage);
      this.GroupBoxLokalerCache.Controls.Add(this.NumericUpDownLokalerCacheAlter);
      this.GroupBoxLokalerCache.Controls.Add(this.LabelLokalerCacheAlter);
      this.GroupBoxLokalerCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GroupBoxLokalerCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.GroupBoxLokalerCache.Location = new System.Drawing.Point(12, 469);
      this.GroupBoxLokalerCache.Name = "GroupBoxLokalerCache";
      this.GroupBoxLokalerCache.Size = new System.Drawing.Size(416, 61);
      this.GroupBoxLokalerCache.TabIndex = 3;
      this.GroupBoxLokalerCache.TabStop = false;
      this.GroupBoxLokalerCache.Text = "Lokaler Cache";
      // 
      // ButtonStandard
      // 
      this.ButtonStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonStandard.Location = new System.Drawing.Point(353, 536);
      this.ButtonStandard.Name = "ButtonStandard";
      this.ButtonStandard.Size = new System.Drawing.Size(75, 28);
      this.ButtonStandard.TabIndex = 6;
      this.ButtonStandard.Text = "Standard";
      this.ButtonStandard.UseVisualStyleBackColor = true;
      this.ButtonStandard.Click += new System.EventHandler(this.ButtonStandard_Click);
      // 
      // GroupBoxAnzeige
      // 
      this.GroupBoxAnzeige.Controls.Add(this.CheckBoxMainOrgShowAdditionalInformation);
      this.GroupBoxAnzeige.Controls.Add(this.CheckBoxShowCacheType);
      this.GroupBoxAnzeige.Controls.Add(this.LabelSprache);
      this.GroupBoxAnzeige.Controls.Add(this.NumericUpDownAffiliationenMaximum);
      this.GroupBoxAnzeige.Controls.Add(this.LabelMaxAffiliationen);
      this.GroupBoxAnzeige.Controls.Add(this.CheckBoxUnkenntlicheAffiliationenAusblenden);
      this.GroupBoxAnzeige.Controls.Add(this.ComboBoxSprache);
      this.GroupBoxAnzeige.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GroupBoxAnzeige.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.GroupBoxAnzeige.Location = new System.Drawing.Point(12, 139);
      this.GroupBoxAnzeige.Name = "GroupBoxAnzeige";
      this.GroupBoxAnzeige.Size = new System.Drawing.Size(416, 159);
      this.GroupBoxAnzeige.TabIndex = 1;
      this.GroupBoxAnzeige.TabStop = false;
      this.GroupBoxAnzeige.Text = "Anzeige";
      // 
      // CheckBoxMainOrgShowAdditionalInformation
      // 
      this.CheckBoxMainOrgShowAdditionalInformation.AutoSize = true;
      this.CheckBoxMainOrgShowAdditionalInformation.Location = new System.Drawing.Point(15, 105);
      this.CheckBoxMainOrgShowAdditionalInformation.Name = "CheckBoxMainOrgShowAdditionalInformation";
      this.CheckBoxMainOrgShowAdditionalInformation.Size = new System.Drawing.Size(335, 19);
      this.CheckBoxMainOrgShowAdditionalInformation.TabIndex = 5;
      this.CheckBoxMainOrgShowAdditionalInformation.Text = "Zusätzliche Informationen zur Hauptorganisation anzeigen";
      this.CheckBoxMainOrgShowAdditionalInformation.UseVisualStyleBackColor = true;
      this.CheckBoxMainOrgShowAdditionalInformation.CheckedChanged += new System.EventHandler(this.CheckBoxMainOrgShowAdditionalInformation_CheckedChanged);
      // 
      // NumericUpDownAffiliationenMaximum
      // 
      this.NumericUpDownAffiliationenMaximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.NumericUpDownAffiliationenMaximum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.NumericUpDownAffiliationenMaximum.Location = new System.Drawing.Point(154, 51);
      this.NumericUpDownAffiliationenMaximum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
      this.NumericUpDownAffiliationenMaximum.Name = "NumericUpDownAffiliationenMaximum";
      this.NumericUpDownAffiliationenMaximum.Size = new System.Drawing.Size(44, 23);
      this.NumericUpDownAffiliationenMaximum.TabIndex = 3;
      this.NumericUpDownAffiliationenMaximum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      this.NumericUpDownAffiliationenMaximum.ValueChanged += new System.EventHandler(this.NumericUpDownAffiliationenMaximum_ValueChanged);
      // 
      // LabelMaxAffiliationen
      // 
      this.LabelMaxAffiliationen.AutoSize = true;
      this.LabelMaxAffiliationen.Location = new System.Drawing.Point(15, 53);
      this.LabelMaxAffiliationen.Name = "LabelMaxAffiliationen";
      this.LabelMaxAffiliationen.Size = new System.Drawing.Size(133, 15);
      this.LabelMaxAffiliationen.TabIndex = 2;
      this.LabelMaxAffiliationen.Text = "Affiliationen Maximum:";
      // 
      // CheckBoxUnkenntlicheAffiliationenAusblenden
      // 
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.AutoSize = true;
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.Location = new System.Drawing.Point(15, 80);
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.Name = "CheckBoxUnkenntlicheAffiliationenAusblenden";
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.Size = new System.Drawing.Size(228, 19);
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.TabIndex = 4;
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.Text = "Unkenntliche Affiliationen ausblenden";
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.UseVisualStyleBackColor = true;
      this.CheckBoxUnkenntlicheAffiliationenAusblenden.CheckedChanged += new System.EventHandler(this.CheckBoxUnkenntlicheAffiliationenAusblenden_CheckedChanged);
      // 
      // FormSettings
      // 
      this.AcceptButton = this.ButtonSpeichern;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.CancelButton = this.ButtonSchliessen;
      this.ClientSize = new System.Drawing.Size(440, 575);
      this.Controls.Add(this.GroupBoxAnzeige);
      this.Controls.Add(this.GroupBoxAPI);
      this.Controls.Add(this.GroupBoxLokalerCache);
      this.Controls.Add(this.GroupBoxFenster);
      this.Controls.Add(this.ButtonStandard);
      this.Controls.Add(this.ButtonSchliessen);
      this.Controls.Add(this.ButtonSpeichern);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(456, 614);
      this.Name = "FormSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Star Citizen Handle Query Einstellungen";
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFensterDeckkraft)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLokalerCacheAlter)).EndInit();
      this.GroupBoxFenster.ResumeLayout(false);
      this.GroupBoxFenster.PerformLayout();
      this.GroupBoxAPI.ResumeLayout(false);
      this.GroupBoxAPI.PerformLayout();
      this.GroupBoxLokalerCache.ResumeLayout(false);
      this.GroupBoxLokalerCache.PerformLayout();
      this.GroupBoxAnzeige.ResumeLayout(false);
      this.GroupBoxAnzeige.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAffiliationenMaximum)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Label LabelFensterDeckkraft;
    private NumericUpDown NumericUpDownFensterDeckkraft;
    private CheckBox CheckBoxFensterMauseingabenIgnorieren;
    private Label LabelLokalerCacheAlter;
    private NumericUpDown NumericUpDownLokalerCacheAlter;
    private Label LabelApiKey;
    private TextBox TextBoxApiKey;
    private Button ButtonSpeichern;
    private Button ButtonSchliessen;
    private Label LabelFensterDeckkraftProzent;
    private Label LabelLokalerCacheAlterTage;
    private GroupBox GroupBoxFenster;
    private GroupBox GroupBoxAPI;
    private Label LabelApiMode;
    private ComboBox ComboBoxApiModus;
    private ComboBox ComboBoxTaste;
    private Label LabelTastenkombination;
    private CheckBox CheckBoxUmschalt;
    private CheckBox CheckBoxAlt;
    private CheckBox CheckBoxStrg;
    private GroupBox GroupBoxLokalerCache;
    private Label LabelModusBeschreibung;
    private Button ButtonStandard;
    private Button ButtonApiTest;
    private Label LabelApiTestStatus;
    private CheckBox CheckBoxAltTabEnabled;
    private Label LabelSprache;
    private ComboBox ComboBoxSprache;
    private GroupBox GroupBoxAnzeige;
    private NumericUpDown NumericUpDownAffiliationenMaximum;
    private Label LabelMaxAffiliationen;
    private CheckBox CheckBoxUnkenntlicheAffiliationenAusblenden;
    private CheckBox CheckBoxShowCacheType;
    private CheckBox CheckBoxMainOrgShowAdditionalInformation;
  }
}