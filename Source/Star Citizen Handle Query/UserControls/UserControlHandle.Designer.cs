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
      LabelHandle = new Label();
      LabelCommunityMoniker = new Label();
      PictureBoxHandleAvatar = new PictureBox();
      PictureBoxDisplayTitle = new PictureBox();
      LabelDisplayTitle = new Label();
      LabelLocationFluency = new Label();
      LabelUEECitizenRecord = new Label();
      LabelEnlistedDate = new Label();
      TextBoxAdditionalInformation = new TextBox();
      LabelAdditionalInformation = new Label();
      PictureBoxLive = new PictureBox();
      LabelRelation = new Label();
      ((System.ComponentModel.ISupportInitialize)PictureBoxHandleAvatar).BeginInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxDisplayTitle).BeginInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxLive).BeginInit();
      SuspendLayout();
      // 
      // LabelHandle
      // 
      LabelHandle.AutoSize = true;
      LabelHandle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
      LabelHandle.Location = new Point(75, 1);
      LabelHandle.Name = "LabelHandle";
      LabelHandle.Size = new Size(0, 21);
      LabelHandle.TabIndex = 0;
      // 
      // LabelCommunityMoniker
      // 
      LabelCommunityMoniker.AutoSize = true;
      LabelCommunityMoniker.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelCommunityMoniker.Location = new Point(76, 22);
      LabelCommunityMoniker.Name = "LabelCommunityMoniker";
      LabelCommunityMoniker.Size = new Size(0, 15);
      LabelCommunityMoniker.TabIndex = 1;
      // 
      // PictureBoxHandleAvatar
      // 
      PictureBoxHandleAvatar.Location = new Point(3, 3);
      PictureBoxHandleAvatar.Name = "PictureBoxHandleAvatar";
      PictureBoxHandleAvatar.Size = new Size(70, 70);
      PictureBoxHandleAvatar.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxHandleAvatar.TabIndex = 2;
      PictureBoxHandleAvatar.TabStop = false;
      PictureBoxHandleAvatar.WaitOnLoad = true;
      PictureBoxHandleAvatar.MouseClick += PictureBoxHandleAvatar_MouseClick;
      // 
      // PictureBoxDisplayTitle
      // 
      PictureBoxDisplayTitle.Location = new Point(79, 40);
      PictureBoxDisplayTitle.Name = "PictureBoxDisplayTitle";
      PictureBoxDisplayTitle.Size = new Size(16, 16);
      PictureBoxDisplayTitle.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxDisplayTitle.TabIndex = 3;
      PictureBoxDisplayTitle.TabStop = false;
      PictureBoxDisplayTitle.WaitOnLoad = true;
      // 
      // LabelDisplayTitle
      // 
      LabelDisplayTitle.AutoSize = true;
      LabelDisplayTitle.Location = new Point(97, 40);
      LabelDisplayTitle.Name = "LabelDisplayTitle";
      LabelDisplayTitle.Size = new Size(0, 15);
      LabelDisplayTitle.TabIndex = 4;
      // 
      // LabelLocationFluency
      // 
      LabelLocationFluency.AutoSize = true;
      LabelLocationFluency.Location = new Point(77, 59);
      LabelLocationFluency.Name = "LabelLocationFluency";
      LabelLocationFluency.Size = new Size(0, 15);
      LabelLocationFluency.TabIndex = 9;
      // 
      // LabelUEECitizenRecord
      // 
      LabelUEECitizenRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      LabelUEECitizenRecord.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
      LabelUEECitizenRecord.Location = new Point(281, 1);
      LabelUEECitizenRecord.Name = "LabelUEECitizenRecord";
      LabelUEECitizenRecord.Size = new Size(91, 19);
      LabelUEECitizenRecord.TabIndex = 10;
      LabelUEECitizenRecord.TextAlign = ContentAlignment.TopRight;
      // 
      // LabelEnlistedDate
      // 
      LabelEnlistedDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      LabelEnlistedDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelEnlistedDate.Location = new Point(281, 22);
      LabelEnlistedDate.Name = "LabelEnlistedDate";
      LabelEnlistedDate.Size = new Size(91, 19);
      LabelEnlistedDate.TabIndex = 1;
      LabelEnlistedDate.TextAlign = ContentAlignment.TopRight;
      // 
      // TextBoxAdditionalInformation
      // 
      TextBoxAdditionalInformation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      TextBoxAdditionalInformation.BackColor = Color.FromArgb(19, 26, 33);
      TextBoxAdditionalInformation.BorderStyle = BorderStyle.None;
      TextBoxAdditionalInformation.ForeColor = Color.Khaki;
      TextBoxAdditionalInformation.Location = new Point(230, 40);
      TextBoxAdditionalInformation.MaxLength = 0;
      TextBoxAdditionalInformation.Name = "TextBoxAdditionalInformation";
      TextBoxAdditionalInformation.Size = new Size(138, 16);
      TextBoxAdditionalInformation.TabIndex = 12;
      TextBoxAdditionalInformation.TextAlign = HorizontalAlignment.Right;
      TextBoxAdditionalInformation.Visible = false;
      TextBoxAdditionalInformation.KeyDown += TextBoxAdditionalInformation_KeyDown;
      TextBoxAdditionalInformation.Leave += TextBoxAdditionalInformation_Leave;
      // 
      // LabelAdditionalInformation
      // 
      LabelAdditionalInformation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      LabelAdditionalInformation.Cursor = Cursors.IBeam;
      LabelAdditionalInformation.ForeColor = Color.Khaki;
      LabelAdditionalInformation.Location = new Point(230, 40);
      LabelAdditionalInformation.Name = "LabelAdditionalInformation";
      LabelAdditionalInformation.Size = new Size(142, 19);
      LabelAdditionalInformation.TabIndex = 1;
      LabelAdditionalInformation.TextAlign = ContentAlignment.TopRight;
      LabelAdditionalInformation.Click += LabelAdditionalInformation_Click;
      // 
      // PictureBoxLive
      // 
      PictureBoxLive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      PictureBoxLive.BackColor = Color.Transparent;
      PictureBoxLive.Cursor = Cursors.Hand;
      PictureBoxLive.InitialImage = null;
      PictureBoxLive.Location = new Point(336, 57);
      PictureBoxLive.Name = "PictureBoxLive";
      PictureBoxLive.Size = new Size(32, 16);
      PictureBoxLive.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxLive.TabIndex = 13;
      PictureBoxLive.TabStop = false;
      PictureBoxLive.Paint += PictureBoxLive_Paint;
      PictureBoxLive.MouseClick += PictureBoxLive_MouseClick;
      // 
      // LabelRelation
      // 
      LabelRelation.Cursor = Cursors.Hand;
      LabelRelation.Location = new Point(68, 2);
      LabelRelation.Margin = new Padding(0);
      LabelRelation.Name = "LabelRelation";
      LabelRelation.Size = new Size(6, 72);
      LabelRelation.TabIndex = 14;
      LabelRelation.Visible = false;
      LabelRelation.Paint += LabelRelation_Paint;
      LabelRelation.MouseClick += LabelRelation_MouseClick;
      // 
      // UserControlHandle
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelRelation);
      Controls.Add(PictureBoxLive);
      Controls.Add(TextBoxAdditionalInformation);
      Controls.Add(LabelAdditionalInformation);
      Controls.Add(LabelUEECitizenRecord);
      Controls.Add(LabelLocationFluency);
      Controls.Add(LabelDisplayTitle);
      Controls.Add(PictureBoxDisplayTitle);
      Controls.Add(PictureBoxHandleAvatar);
      Controls.Add(LabelEnlistedDate);
      Controls.Add(LabelCommunityMoniker);
      Controls.Add(LabelHandle);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlHandle";
      Size = new Size(375, 76);
      Load += UserControlHandle_Load;
      ((System.ComponentModel.ISupportInitialize)PictureBoxHandleAvatar).EndInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxDisplayTitle).EndInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxLive).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label LabelHandle;
    private Label LabelCommunityMoniker;
    private Label LabelDisplayTitle;
    private Label LabelLocationFluency;
    internal PictureBox PictureBoxHandleAvatar;
    internal PictureBox PictureBoxDisplayTitle;
    private Label LabelUEECitizenRecord;
    private Label LabelEnlistedDate;
    private TextBox TextBoxAdditionalInformation;
    private Label LabelAdditionalInformation;
        private PictureBox PictureBoxLive;
    private Label LabelRelation;
  }
}
