namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlLocation {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent() {
      LabelLocationName = new Label();
      LabelType = new Label();
      LabelDescription = new Label();
      PictureBoxLocation = new PictureBox();
      ((System.ComponentModel.ISupportInitialize)PictureBoxLocation).BeginInit();
      SuspendLayout();
      // 
      // LabelLocationName
      // 
      LabelLocationName.Cursor = Cursors.Hand;
      LabelLocationName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelLocationName.Location = new Point(6, 2);
      LabelLocationName.Name = "LabelLocationName";
      LabelLocationName.Size = new Size(215, 21);
      LabelLocationName.TabIndex = 1;
      LabelLocationName.Text = "Name";
      LabelLocationName.TextAlign = ContentAlignment.MiddleLeft;
      LabelLocationName.MouseClick += LabelLocationName_MouseClick;
      // 
      // LabelType
      // 
      LabelType.Cursor = Cursors.Hand;
      LabelType.ForeColor = Color.FromArgb(46, 157, 158);
      LabelType.Location = new Point(6, 20);
      LabelType.Name = "LabelType";
      LabelType.Size = new Size(215, 21);
      LabelType.TabIndex = 1;
      LabelType.Text = "Typ";
      LabelType.TextAlign = ContentAlignment.MiddleLeft;
      LabelType.MouseClick += LabelLocationName_MouseClick;
      // 
      // LabelDescription
      // 
      LabelDescription.Cursor = Cursors.Hand;
      LabelDescription.ForeColor = Color.FromArgb(46, 157, 158);
      LabelDescription.Location = new Point(6, 38);
      LabelDescription.Name = "LabelDescription";
      LabelDescription.Size = new Size(215, 21);
      LabelDescription.TabIndex = 1;
      LabelDescription.Text = "Beschreibung";
      LabelDescription.TextAlign = ContentAlignment.MiddleLeft;
      LabelDescription.MouseClick += LabelLocationName_MouseClick;
      // 
      // PictureBoxLocation
      // 
      PictureBoxLocation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      PictureBoxLocation.Cursor = Cursors.Hand;
      PictureBoxLocation.Location = new Point(223, 2);
      PictureBoxLocation.Name = "PictureBoxLocation";
      PictureBoxLocation.Size = new Size(97, 57);
      PictureBoxLocation.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxLocation.TabIndex = 3;
      PictureBoxLocation.TabStop = false;
      PictureBoxLocation.WaitOnLoad = true;
      PictureBoxLocation.MouseClick += LabelLocationName_MouseClick;
      // 
      // UserControlLocation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(PictureBoxLocation);
      Controls.Add(LabelDescription);
      Controls.Add(LabelType);
      Controls.Add(LabelLocationName);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlLocation";
      Size = new Size(329, 63);
      Load += UserControlLog_Load;
      ((System.ComponentModel.ISupportInitialize)PictureBoxLocation).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private Label LabelLocationName;
    private Label LabelType;
    private Label LabelDescription;
    internal PictureBox PictureBoxLocation;
  }
}
