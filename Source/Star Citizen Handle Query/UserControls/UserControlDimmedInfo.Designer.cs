namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlDimmedInfo {
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
      LabelInfo = new Label();
      SuspendLayout();
      // 
      // LabelInfo
      // 
      LabelInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      LabelInfo.ForeColor = Color.FromArgb(46, 157, 158);
      LabelInfo.Location = new Point(6, 2);
      LabelInfo.Name = "LabelInfo";
      LabelInfo.Size = new Size(320, 21);
      LabelInfo.TabIndex = 1;
      LabelInfo.Text = "Info";
      LabelInfo.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // UserControlDimmedInfo
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelInfo);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlDimmedInfo";
      Size = new Size(329, 25);
      ResumeLayout(false);
    }

    #endregion
    private Label LabelInfo;
  }
}
