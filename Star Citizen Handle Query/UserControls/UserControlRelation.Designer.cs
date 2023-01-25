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
      this.PictureBoxLeft = new System.Windows.Forms.PictureBox();
      this.LabelHandle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).BeginInit();
      this.SuspendLayout();
      // 
      // PictureBoxLeft
      // 
      this.PictureBoxLeft.Location = new System.Drawing.Point(1, 2);
      this.PictureBoxLeft.Name = "PictureBoxLeft";
      this.PictureBoxLeft.Size = new System.Drawing.Size(21, 21);
      this.PictureBoxLeft.TabIndex = 0;
      this.PictureBoxLeft.TabStop = false;
      // 
      // LabelHandle
      // 
      this.LabelHandle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelHandle.Location = new System.Drawing.Point(28, 2);
      this.LabelHandle.Name = "LabelHandle";
      this.LabelHandle.Size = new System.Drawing.Size(186, 21);
      this.LabelHandle.TabIndex = 1;
      this.LabelHandle.Text = "Handle";
      this.LabelHandle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // UserControlRelation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelHandle);
      this.Controls.Add(this.PictureBoxLeft);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlRelation";
      this.Size = new System.Drawing.Size(238, 25);
      this.Load += new System.EventHandler(this.UserControlLog_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private PictureBox PictureBoxLeft;
        private Label LabelHandle;
    }
}
