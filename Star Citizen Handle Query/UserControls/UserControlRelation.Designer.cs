namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlRelation {
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
      LabelHandle = new Label();
      LabelRelation = new Label();
      LabelOrganization = new Label();
      SuspendLayout();
      // 
      // LabelHandle
      // 
      LabelHandle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelHandle.Location = new Point(14, 2);
      LabelHandle.Name = "LabelHandle";
      LabelHandle.Size = new Size(199, 21);
      LabelHandle.TabIndex = 1;
      LabelHandle.Text = "Handle";
      LabelHandle.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // LabelRelation
      // 
      LabelRelation.Location = new Point(8, 2);
      LabelRelation.Name = "LabelRelation";
      LabelRelation.Size = new Size(4, 21);
      LabelRelation.TabIndex = 2;
      // 
      // LabelOrganization
      // 
      LabelOrganization.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelOrganization.Image = Properties.Resources.Organization_Small;
      LabelOrganization.Location = new Point(215, 2);
      LabelOrganization.Name = "LabelOrganization";
      LabelOrganization.Size = new Size(20, 20);
      LabelOrganization.TabIndex = 4;
      LabelOrganization.Visible = false;
      // 
      // UserControlRelation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelOrganization);
      Controls.Add(LabelRelation);
      Controls.Add(LabelHandle);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlRelation";
      Size = new Size(238, 25);
      Load += UserControlLog_Load;
      ResumeLayout(false);
    }

    #endregion
    private Label LabelHandle;
    private Label LabelRelation;
    private Label LabelOrganization;
  }
}
