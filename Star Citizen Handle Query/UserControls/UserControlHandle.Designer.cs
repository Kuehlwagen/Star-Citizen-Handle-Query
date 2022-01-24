namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlHandle {
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
      this.LabelCommunityMoniker = new System.Windows.Forms.Label();
      this.PictureBoxHandleAvatar = new System.Windows.Forms.PictureBox();
      this.PictureBoxDisplayTitle = new System.Windows.Forms.PictureBox();
      this.LabelDisplayTitle = new System.Windows.Forms.Label();
      this.LabelFluency = new System.Windows.Forms.Label();
      this.LabelUEECitizenRecord = new System.Windows.Forms.Label();
      this.LabelEnlistedDate = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxHandleAvatar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDisplayTitle)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelHandle
      // 
      this.LabelHandle.AutoSize = true;
      this.LabelHandle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelHandle.Location = new System.Drawing.Point(75, 1);
      this.LabelHandle.Name = "LabelHandle";
      this.LabelHandle.Size = new System.Drawing.Size(0, 21);
      this.LabelHandle.TabIndex = 0;
      // 
      // LabelCommunityMoniker
      // 
      this.LabelCommunityMoniker.AutoSize = true;
      this.LabelCommunityMoniker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelCommunityMoniker.Location = new System.Drawing.Point(76, 22);
      this.LabelCommunityMoniker.Name = "LabelCommunityMoniker";
      this.LabelCommunityMoniker.Size = new System.Drawing.Size(0, 15);
      this.LabelCommunityMoniker.TabIndex = 1;
      // 
      // PictureBoxHandleAvatar
      // 
      this.PictureBoxHandleAvatar.Location = new System.Drawing.Point(3, 3);
      this.PictureBoxHandleAvatar.Name = "PictureBoxHandleAvatar";
      this.PictureBoxHandleAvatar.Size = new System.Drawing.Size(70, 70);
      this.PictureBoxHandleAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PictureBoxHandleAvatar.TabIndex = 2;
      this.PictureBoxHandleAvatar.TabStop = false;
      this.PictureBoxHandleAvatar.WaitOnLoad = true;
      this.PictureBoxHandleAvatar.Click += new System.EventHandler(this.PictureBoxHandleAvatar_Click);
      // 
      // PictureBoxDisplayTitle
      // 
      this.PictureBoxDisplayTitle.Location = new System.Drawing.Point(79, 40);
      this.PictureBoxDisplayTitle.Name = "PictureBoxDisplayTitle";
      this.PictureBoxDisplayTitle.Size = new System.Drawing.Size(16, 16);
      this.PictureBoxDisplayTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PictureBoxDisplayTitle.TabIndex = 3;
      this.PictureBoxDisplayTitle.TabStop = false;
      this.PictureBoxDisplayTitle.WaitOnLoad = true;
      // 
      // LabelDisplayTitle
      // 
      this.LabelDisplayTitle.AutoSize = true;
      this.LabelDisplayTitle.Location = new System.Drawing.Point(97, 40);
      this.LabelDisplayTitle.Name = "LabelDisplayTitle";
      this.LabelDisplayTitle.Size = new System.Drawing.Size(0, 15);
      this.LabelDisplayTitle.TabIndex = 4;
      // 
      // LabelFluency
      // 
      this.LabelFluency.AutoSize = true;
      this.LabelFluency.Location = new System.Drawing.Point(77, 59);
      this.LabelFluency.Name = "LabelFluency";
      this.LabelFluency.Size = new System.Drawing.Size(0, 15);
      this.LabelFluency.TabIndex = 9;
      // 
      // LabelUEECitizenRecord
      // 
      this.LabelUEECitizenRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.LabelUEECitizenRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelUEECitizenRecord.Location = new System.Drawing.Point(281, 1);
      this.LabelUEECitizenRecord.Name = "LabelUEECitizenRecord";
      this.LabelUEECitizenRecord.Size = new System.Drawing.Size(91, 19);
      this.LabelUEECitizenRecord.TabIndex = 10;
      this.LabelUEECitizenRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // LabelEnlistedDate
      // 
      this.LabelEnlistedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelEnlistedDate.Location = new System.Drawing.Point(281, 22);
      this.LabelEnlistedDate.Name = "LabelEnlistedDate";
      this.LabelEnlistedDate.Size = new System.Drawing.Size(91, 19);
      this.LabelEnlistedDate.TabIndex = 1;
      this.LabelEnlistedDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // UserControlHandle
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelUEECitizenRecord);
      this.Controls.Add(this.LabelFluency);
      this.Controls.Add(this.LabelDisplayTitle);
      this.Controls.Add(this.PictureBoxDisplayTitle);
      this.Controls.Add(this.PictureBoxHandleAvatar);
      this.Controls.Add(this.LabelEnlistedDate);
      this.Controls.Add(this.LabelCommunityMoniker);
      this.Controls.Add(this.LabelHandle);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlHandle";
      this.Size = new System.Drawing.Size(375, 76);
      this.Load += new System.EventHandler(this.UserControlHandle_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxHandleAvatar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDisplayTitle)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label LabelHandle;
    private Label LabelCommunityMoniker;
    private Label LabelDisplayTitle;
    private Label LabelFluency;
    internal PictureBox PictureBoxHandleAvatar;
    internal PictureBox PictureBoxDisplayTitle;
    private Label LabelUEECitizenRecord;
    private Label LabelEnlistedDate;
  }
}
