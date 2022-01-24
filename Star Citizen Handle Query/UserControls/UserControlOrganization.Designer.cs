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
      this.LabelOrganizationName = new System.Windows.Forms.Label();
      this.PictureBoxOrganization = new System.Windows.Forms.PictureBox();
      this.LabelOrganizationSID = new System.Windows.Forms.Label();
      this.LabelOrganizationRank = new System.Windows.Forms.Label();
      this.PictureBoxOrganizationRank = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOrganization)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOrganizationRank)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelOrganizationName
      // 
      this.LabelOrganizationName.AutoSize = true;
      this.LabelOrganizationName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelOrganizationName.Location = new System.Drawing.Point(80, 1);
      this.LabelOrganizationName.Name = "LabelOrganizationName";
      this.LabelOrganizationName.Size = new System.Drawing.Size(0, 21);
      this.LabelOrganizationName.TabIndex = 5;
      // 
      // PictureBoxOrganization
      // 
      this.PictureBoxOrganization.Location = new System.Drawing.Point(3, 3);
      this.PictureBoxOrganization.Name = "PictureBoxOrganization";
      this.PictureBoxOrganization.Size = new System.Drawing.Size(70, 70);
      this.PictureBoxOrganization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PictureBoxOrganization.TabIndex = 6;
      this.PictureBoxOrganization.TabStop = false;
      this.PictureBoxOrganization.WaitOnLoad = true;
      this.PictureBoxOrganization.Click += new System.EventHandler(this.PictureBoxOrganization_Click);
      // 
      // LabelOrganizationSID
      // 
      this.LabelOrganizationSID.AutoSize = true;
      this.LabelOrganizationSID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelOrganizationSID.Location = new System.Drawing.Point(81, 22);
      this.LabelOrganizationSID.Name = "LabelOrganizationSID";
      this.LabelOrganizationSID.Size = new System.Drawing.Size(0, 15);
      this.LabelOrganizationSID.TabIndex = 7;
      // 
      // LabelOrganizationRank
      // 
      this.LabelOrganizationRank.AutoSize = true;
      this.LabelOrganizationRank.Location = new System.Drawing.Point(81, 37);
      this.LabelOrganizationRank.Name = "LabelOrganizationRank";
      this.LabelOrganizationRank.Size = new System.Drawing.Size(0, 15);
      this.LabelOrganizationRank.TabIndex = 8;
      // 
      // PictureBoxOrganizationRank
      // 
      this.PictureBoxOrganizationRank.Location = new System.Drawing.Point(85, 53);
      this.PictureBoxOrganizationRank.Name = "PictureBoxOrganizationRank";
      this.PictureBoxOrganizationRank.Size = new System.Drawing.Size(104, 20);
      this.PictureBoxOrganizationRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PictureBoxOrganizationRank.TabIndex = 3;
      this.PictureBoxOrganizationRank.TabStop = false;
      this.PictureBoxOrganizationRank.WaitOnLoad = true;
      // 
      // UserControlOrganization
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelOrganizationRank);
      this.Controls.Add(this.LabelOrganizationSID);
      this.Controls.Add(this.PictureBoxOrganization);
      this.Controls.Add(this.LabelOrganizationName);
      this.Controls.Add(this.PictureBoxOrganizationRank);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlOrganization";
      this.Size = new System.Drawing.Size(370, 76);
      this.Load += new System.EventHandler(this.UserControlHandle_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOrganization)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOrganizationRank)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Label LabelOrganizationName;
    private Label LabelOrganizationSID;
    private Label LabelOrganizationRank;
    internal PictureBox PictureBoxOrganization;
    internal PictureBox PictureBoxOrganizationRank;
  }
}
