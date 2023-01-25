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
      this.LabelHandle = new System.Windows.Forms.Label();
      this.LabelRelation = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // LabelHandle
      // 
      this.LabelHandle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelHandle.Location = new System.Drawing.Point(18, 2);
      this.LabelHandle.Name = "LabelHandle";
      this.LabelHandle.Size = new System.Drawing.Size(217, 21);
      this.LabelHandle.TabIndex = 1;
      this.LabelHandle.Text = "Handle";
      this.LabelHandle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // LabelRelation
      // 
      this.LabelRelation.Location = new System.Drawing.Point(8, 2);
      this.LabelRelation.Name = "LabelRelation";
      this.LabelRelation.Size = new System.Drawing.Size(4, 21);
      this.LabelRelation.TabIndex = 2;
      // 
      // UserControlRelation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelRelation);
      this.Controls.Add(this.LabelHandle);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlRelation";
      this.Size = new System.Drawing.Size(238, 25);
      this.Load += new System.EventHandler(this.UserControlLog_Load);
      this.ResumeLayout(false);

    }

        #endregion
        private Label LabelHandle;
    private Label LabelRelation;
  }
}
