namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlOrganization {
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
      LabelOrganizationName = new Label();
      PictureBoxOrganization = new PictureBox();
      LabelOrganizationSID = new Label();
      LabelOrganizationRank = new Label();
      PictureBoxOrganizationRank = new PictureBox();
      LabelMainOrganizationAffiliate = new Label();
      LabelFocusPrimary = new Label();
      LabelFocusSecondary = new Label();
      LabelRelation = new Label();
      ((System.ComponentModel.ISupportInitialize)PictureBoxOrganization).BeginInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxOrganizationRank).BeginInit();
      SuspendLayout();
      // 
      // LabelOrganizationName
      // 
      LabelOrganizationName.AutoSize = true;
      LabelOrganizationName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
      LabelOrganizationName.Location = new Point(76, 1);
      LabelOrganizationName.Name = "LabelOrganizationName";
      LabelOrganizationName.Size = new Size(0, 21);
      LabelOrganizationName.TabIndex = 5;
      // 
      // PictureBoxOrganization
      // 
      PictureBoxOrganization.Location = new Point(3, 3);
      PictureBoxOrganization.Name = "PictureBoxOrganization";
      PictureBoxOrganization.Size = new Size(70, 70);
      PictureBoxOrganization.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxOrganization.TabIndex = 6;
      PictureBoxOrganization.TabStop = false;
      PictureBoxOrganization.WaitOnLoad = true;
      PictureBoxOrganization.MouseClick += PictureBoxOrganization_MouseClick;
      // 
      // LabelOrganizationSID
      // 
      LabelOrganizationSID.AutoSize = true;
      LabelOrganizationSID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelOrganizationSID.Location = new Point(77, 22);
      LabelOrganizationSID.Name = "LabelOrganizationSID";
      LabelOrganizationSID.Size = new Size(0, 15);
      LabelOrganizationSID.TabIndex = 7;
      // 
      // LabelOrganizationRank
      // 
      LabelOrganizationRank.AutoSize = true;
      LabelOrganizationRank.Location = new Point(77, 38);
      LabelOrganizationRank.Name = "LabelOrganizationRank";
      LabelOrganizationRank.Size = new Size(0, 15);
      LabelOrganizationRank.TabIndex = 8;
      // 
      // PictureBoxOrganizationRank
      // 
      PictureBoxOrganizationRank.Location = new Point(81, 54);
      PictureBoxOrganizationRank.Name = "PictureBoxOrganizationRank";
      PictureBoxOrganizationRank.Size = new Size(104, 20);
      PictureBoxOrganizationRank.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxOrganizationRank.TabIndex = 3;
      PictureBoxOrganizationRank.TabStop = false;
      PictureBoxOrganizationRank.WaitOnLoad = true;
      // 
      // LabelMainOrganizationAffiliate
      // 
      LabelMainOrganizationAffiliate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      LabelMainOrganizationAffiliate.ForeColor = Color.FromArgb(46, 157, 158);
      LabelMainOrganizationAffiliate.Location = new Point(188, 59);
      LabelMainOrganizationAffiliate.Name = "LabelMainOrganizationAffiliate";
      LabelMainOrganizationAffiliate.Size = new Size(184, 15);
      LabelMainOrganizationAffiliate.TabIndex = 8;
      LabelMainOrganizationAffiliate.TextAlign = ContentAlignment.MiddleRight;
      // 
      // LabelFocusPrimary
      // 
      LabelFocusPrimary.Location = new Point(252, 23);
      LabelFocusPrimary.Name = "LabelFocusPrimary";
      LabelFocusPrimary.RightToLeft = RightToLeft.Yes;
      LabelFocusPrimary.Size = new Size(120, 18);
      LabelFocusPrimary.TabIndex = 10;
      // 
      // LabelFocusSecondary
      // 
      LabelFocusSecondary.Location = new Point(252, 41);
      LabelFocusSecondary.Name = "LabelFocusSecondary";
      LabelFocusSecondary.RightToLeft = RightToLeft.Yes;
      LabelFocusSecondary.Size = new Size(120, 18);
      LabelFocusSecondary.TabIndex = 10;
      // 
      // LabelRelation
      // 
      LabelRelation.Cursor = Cursors.Hand;
      LabelRelation.Location = new Point(68, 2);
      LabelRelation.Margin = new Padding(0);
      LabelRelation.Name = "LabelRelation";
      LabelRelation.Size = new Size(6, 72);
      LabelRelation.TabIndex = 15;
      LabelRelation.Visible = false;
      LabelRelation.Paint += LabelRelation_Paint;
      // 
      // UserControlOrganization
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelRelation);
      Controls.Add(LabelFocusSecondary);
      Controls.Add(LabelFocusPrimary);
      Controls.Add(LabelMainOrganizationAffiliate);
      Controls.Add(LabelOrganizationRank);
      Controls.Add(LabelOrganizationSID);
      Controls.Add(PictureBoxOrganization);
      Controls.Add(LabelOrganizationName);
      Controls.Add(PictureBoxOrganizationRank);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlOrganization";
      Size = new Size(375, 76);
      Load += UserControlOrganization_Load;
      ((System.ComponentModel.ISupportInitialize)PictureBoxOrganization).EndInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxOrganizationRank).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Label LabelOrganizationName;
    private Label LabelOrganizationSID;
    private Label LabelOrganizationRank;
    internal PictureBox PictureBoxOrganization;
    internal PictureBox PictureBoxOrganizationRank;
    private Label LabelMainOrganizationAffiliate;
    public Label LabelFocusPrimary;
    public Label LabelFocusSecondary;
    private Label LabelRelation;
  }
}
