namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormLogMonitor {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogMonitor));
      PanelHeader = new Panel();
      PictureBoxClearAll = new PictureBox();
      PictureBoxStatus = new PictureBox();
      LabelTitle = new Label();
      PanelLogInfo = new FlowLayoutPanel();
      PanelHeader.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)PictureBoxClearAll).BeginInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxStatus).BeginInit();
      SuspendLayout();
      // 
      // PanelHeader
      // 
      PanelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      PanelHeader.BackColor = Color.FromArgb(19, 26, 33);
      PanelHeader.Controls.Add(PictureBoxClearAll);
      PanelHeader.Controls.Add(PictureBoxStatus);
      PanelHeader.Controls.Add(LabelTitle);
      PanelHeader.Location = new Point(1, 2);
      PanelHeader.Margin = new Padding(4, 5, 4, 5);
      PanelHeader.Name = "PanelHeader";
      PanelHeader.Size = new Size(340, 48);
      PanelHeader.TabIndex = 0;
      // 
      // PictureBoxClearAll
      // 
      PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
      PictureBoxClearAll.Location = new Point(313, 12);
      PictureBoxClearAll.Margin = new Padding(4, 5, 4, 5);
      PictureBoxClearAll.Name = "PictureBoxClearAll";
      PictureBoxClearAll.Size = new Size(17, 25);
      PictureBoxClearAll.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxClearAll.TabIndex = 2;
      PictureBoxClearAll.TabStop = false;
      // 
      // PictureBoxStatus
      // 
      PictureBoxStatus.Image = Properties.Resources.StatusRed;
      PictureBoxStatus.Location = new Point(6, 12);
      PictureBoxStatus.Margin = new Padding(4, 5, 4, 5);
      PictureBoxStatus.Name = "PictureBoxStatus";
      PictureBoxStatus.Size = new Size(21, 25);
      PictureBoxStatus.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxStatus.TabIndex = 2;
      PictureBoxStatus.TabStop = false;
      // 
      // LabelTitle
      // 
      LabelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelTitle.Location = new Point(33, 12);
      LabelTitle.Margin = new Padding(4, 0, 4, 0);
      LabelTitle.Name = "LabelTitle";
      LabelTitle.Size = new Size(277, 25);
      LabelTitle.TabIndex = 0;
      LabelTitle.Text = "Log-Monitor";
      LabelTitle.TextAlign = ContentAlignment.MiddleLeft;
      LabelTitle.MouseCaptureChanged += LabelTitle_MouseCaptureChanged;
      LabelTitle.MouseDown += LabelTitle_MouseDown;
      LabelTitle.MouseMove += LabelTitle_MouseMove;
      // 
      // PanelLogInfo
      // 
      PanelLogInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      PanelLogInfo.BackColor = Color.Lime;
      PanelLogInfo.FlowDirection = FlowDirection.TopDown;
      PanelLogInfo.Location = new Point(1, 50);
      PanelLogInfo.Margin = new Padding(0);
      PanelLogInfo.Name = "PanelLogInfo";
      PanelLogInfo.Size = new Size(340, 48);
      PanelLogInfo.TabIndex = 1;
      PanelLogInfo.ControlAdded += PanelLogInfo_ControlAdded;
      PanelLogInfo.ControlRemoved += PanelLogInfo_ControlRemoved;
      // 
      // FormLogMonitor
      // 
      AutoScaleDimensions = new SizeF(10F, 25F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Lime;
      ClientSize = new Size(343, 100);
      Controls.Add(PanelLogInfo);
      Controls.Add(PanelHeader);
      ForeColor = Color.FromArgb(57, 206, 216);
      FormBorderStyle = FormBorderStyle.None;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Margin = new Padding(4, 5, 4, 5);
      Name = "FormLogMonitor";
      ShowInTaskbar = false;
      Text = "Star Citizen Handle Query";
      TopMost = true;
      TransparencyKey = Color.Lime;
      FormClosing += FormLogMonitor_FormClosing;
      Shown += FormLogMonitor_Shown;
      PanelHeader.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)PictureBoxClearAll).EndInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxStatus).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel PanelHeader;
    private Label LabelTitle;
    private FlowLayoutPanel PanelLogInfo;
        private PictureBox PictureBoxStatus;
        private PictureBox PictureBoxClearAll;
    }
}