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
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFensterDeckkraft)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLokalerCacheAlter)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelFensterDeckkraft
      // 
      this.LabelFensterDeckkraft.AutoSize = true;
      this.LabelFensterDeckkraft.Location = new System.Drawing.Point(122, 14);
      this.LabelFensterDeckkraft.Name = "LabelFensterDeckkraft";
      this.LabelFensterDeckkraft.Size = new System.Drawing.Size(103, 15);
      this.LabelFensterDeckkraft.TabIndex = 0;
      this.LabelFensterDeckkraft.Text = "Fenster-Deckkraft:";
      // 
      // NumericUpDownFensterDeckkraft
      // 
      this.NumericUpDownFensterDeckkraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.NumericUpDownFensterDeckkraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.NumericUpDownFensterDeckkraft.Location = new System.Drawing.Point(231, 12);
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
      this.CheckBoxFensterMauseingabenIgnorieren.Location = new System.Drawing.Point(231, 41);
      this.CheckBoxFensterMauseingabenIgnorieren.Name = "CheckBoxFensterMauseingabenIgnorieren";
      this.CheckBoxFensterMauseingabenIgnorieren.Size = new System.Drawing.Size(204, 19);
      this.CheckBoxFensterMauseingabenIgnorieren.TabIndex = 3;
      this.CheckBoxFensterMauseingabenIgnorieren.Text = "Fenster-Mauseingaben ignorieren";
      this.CheckBoxFensterMauseingabenIgnorieren.UseVisualStyleBackColor = true;
      this.CheckBoxFensterMauseingabenIgnorieren.CheckedChanged += new System.EventHandler(this.CheckBoxFensterMauseingabenIgnorieren_CheckedChanged);
      // 
      // LabelLokalerCacheAlter
      // 
      this.LabelLokalerCacheAlter.AutoSize = true;
      this.LabelLokalerCacheAlter.Location = new System.Drawing.Point(12, 68);
      this.LabelLokalerCacheAlter.Name = "LabelLokalerCacheAlter";
      this.LabelLokalerCacheAlter.Size = new System.Drawing.Size(213, 15);
      this.LabelLokalerCacheAlter.TabIndex = 4;
      this.LabelLokalerCacheAlter.Text = "Maximales Alter für den lokalen Cache:";
      // 
      // NumericUpDownLokalerCacheAlter
      // 
      this.NumericUpDownLokalerCacheAlter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.NumericUpDownLokalerCacheAlter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.NumericUpDownLokalerCacheAlter.Location = new System.Drawing.Point(231, 66);
      this.NumericUpDownLokalerCacheAlter.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.NumericUpDownLokalerCacheAlter.Name = "NumericUpDownLokalerCacheAlter";
      this.NumericUpDownLokalerCacheAlter.Size = new System.Drawing.Size(44, 23);
      this.NumericUpDownLokalerCacheAlter.TabIndex = 5;
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
      this.LabelApiKey.Location = new System.Drawing.Point(173, 98);
      this.LabelApiKey.Name = "LabelApiKey";
      this.LabelApiKey.Size = new System.Drawing.Size(52, 15);
      this.LabelApiKey.TabIndex = 7;
      this.LabelApiKey.Text = "API-Key:";
      // 
      // TextBoxApiKey
      // 
      this.TextBoxApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.TextBoxApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.TextBoxApiKey.Location = new System.Drawing.Point(231, 95);
      this.TextBoxApiKey.MaxLength = 32;
      this.TextBoxApiKey.Name = "TextBoxApiKey";
      this.TextBoxApiKey.PlaceholderText = "32-stelligen API-Code eingeben...";
      this.TextBoxApiKey.Size = new System.Drawing.Size(227, 23);
      this.TextBoxApiKey.TabIndex = 8;
      this.TextBoxApiKey.TextChanged += new System.EventHandler(this.TextBoxApiKey_TextChanged);
      // 
      // ButtonSpeichern
      // 
      this.ButtonSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonSpeichern.Location = new System.Drawing.Point(231, 124);
      this.ButtonSpeichern.Name = "ButtonSpeichern";
      this.ButtonSpeichern.Size = new System.Drawing.Size(75, 28);
      this.ButtonSpeichern.TabIndex = 9;
      this.ButtonSpeichern.Text = "Speichern";
      this.ButtonSpeichern.UseVisualStyleBackColor = true;
      this.ButtonSpeichern.Click += new System.EventHandler(this.ButtonSpeichern_Click);
      // 
      // ButtonSchliessen
      // 
      this.ButtonSchliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonSchliessen.Location = new System.Drawing.Point(312, 124);
      this.ButtonSchliessen.Name = "ButtonSchliessen";
      this.ButtonSchliessen.Size = new System.Drawing.Size(75, 28);
      this.ButtonSchliessen.TabIndex = 10;
      this.ButtonSchliessen.Text = "Schließen";
      this.ButtonSchliessen.UseVisualStyleBackColor = true;
      this.ButtonSchliessen.Click += new System.EventHandler(this.ButtonSchliessen_Click);
      // 
      // LabelFensterDeckkraftProzent
      // 
      this.LabelFensterDeckkraftProzent.AutoSize = true;
      this.LabelFensterDeckkraftProzent.Location = new System.Drawing.Point(281, 14);
      this.LabelFensterDeckkraftProzent.Name = "LabelFensterDeckkraftProzent";
      this.LabelFensterDeckkraftProzent.Size = new System.Drawing.Size(17, 15);
      this.LabelFensterDeckkraftProzent.TabIndex = 2;
      this.LabelFensterDeckkraftProzent.Text = "%";
      // 
      // LabelLokalerCacheAlterTage
      // 
      this.LabelLokalerCacheAlterTage.AutoSize = true;
      this.LabelLokalerCacheAlterTage.Location = new System.Drawing.Point(281, 68);
      this.LabelLokalerCacheAlterTage.Name = "LabelLokalerCacheAlterTage";
      this.LabelLokalerCacheAlterTage.Size = new System.Drawing.Size(39, 15);
      this.LabelLokalerCacheAlterTage.TabIndex = 6;
      this.LabelLokalerCacheAlterTage.Text = "Tag(e)";
      // 
      // FormSettings
      // 
      this.AcceptButton = this.ButtonSpeichern;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.CancelButton = this.ButtonSchliessen;
      this.ClientSize = new System.Drawing.Size(470, 165);
      this.Controls.Add(this.ButtonSchliessen);
      this.Controls.Add(this.ButtonSpeichern);
      this.Controls.Add(this.TextBoxApiKey);
      this.Controls.Add(this.LabelApiKey);
      this.Controls.Add(this.LabelLokalerCacheAlterTage);
      this.Controls.Add(this.LabelLokalerCacheAlter);
      this.Controls.Add(this.CheckBoxFensterMauseingabenIgnorieren);
      this.Controls.Add(this.NumericUpDownLokalerCacheAlter);
      this.Controls.Add(this.NumericUpDownFensterDeckkraft);
      this.Controls.Add(this.LabelFensterDeckkraftProzent);
      this.Controls.Add(this.LabelFensterDeckkraft);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.MinimumSize = new System.Drawing.Size(486, 204);
      this.Name = "FormSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Star Citizen Handle Query Einstellungen";
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFensterDeckkraft)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLokalerCacheAlter)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

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
  }
}