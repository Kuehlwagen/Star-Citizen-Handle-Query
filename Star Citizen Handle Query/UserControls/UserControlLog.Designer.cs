namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlLog {
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
      this.LabelText = new System.Windows.Forms.Label();
      this.LabelTime = new System.Windows.Forms.Label();
      this.PictureBoxRight = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRight)).BeginInit();
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
      // LabelText
      // 
      this.LabelText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelText.Location = new System.Drawing.Point(58, 2);
      this.LabelText.Name = "LabelText";
      this.LabelText.Size = new System.Drawing.Size(156, 21);
      this.LabelText.TabIndex = 1;
      this.LabelText.Text = "Text";
      this.LabelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // LabelTime
      // 
      this.LabelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(157)))), ((int)(((byte)(158)))));
      this.LabelTime.Location = new System.Drawing.Point(23, 2);
      this.LabelTime.Name = "LabelTime";
      this.LabelTime.Size = new System.Drawing.Size(37, 21);
      this.LabelTime.TabIndex = 0;
      this.LabelTime.Text = "00:00";
      this.LabelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // PictureBoxRight
      // 
      this.PictureBoxRight.Location = new System.Drawing.Point(214, 2);
      this.PictureBoxRight.Name = "PictureBoxRight";
      this.PictureBoxRight.Size = new System.Drawing.Size(21, 21);
      this.PictureBoxRight.TabIndex = 0;
      this.PictureBoxRight.TabStop = false;
      // 
      // UserControlLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelTime);
      this.Controls.Add(this.LabelText);
      this.Controls.Add(this.PictureBoxRight);
      this.Controls.Add(this.PictureBoxLeft);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlLog";
      this.Size = new System.Drawing.Size(238, 25);
      this.Load += new System.EventHandler(this.UserControlLog_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRight)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private PictureBox PictureBoxLeft;
        private Label LabelText;
        private Label LabelTime;
        private PictureBox PictureBoxRight;
    }
}
