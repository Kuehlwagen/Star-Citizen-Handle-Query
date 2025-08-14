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
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogMonitor));
      PanelHeader = new Panel();
      PictureBoxClearAll = new PictureBox();
      PictureBoxStatus = new PictureBox();
      LabelTitle = new Label();
      PanelLogInfo = new FlowLayoutPanel();
      ToolTipLogMonitor = new ToolTip(components);
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
      PanelHeader.Location = new Point(1, 1);
      PanelHeader.Name = "PanelHeader";
      PanelHeader.Size = new Size(238, 29);
      PanelHeader.TabIndex = 0;
      // 
      // PictureBoxClearAll
      // 
      PictureBoxClearAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      PictureBoxClearAll.Location = new Point(215, 5);
      PictureBoxClearAll.Name = "PictureBoxClearAll";
      PictureBoxClearAll.Size = new Size(20, 20);
      PictureBoxClearAll.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxClearAll.TabIndex = 2;
      PictureBoxClearAll.TabStop = false;
      PictureBoxClearAll.Paint += PictureBoxClearAll_Paint;
      // 
      // PictureBoxStatus
      // 
      PictureBoxStatus.Location = new Point(1, 5);
      PictureBoxStatus.Name = "PictureBoxStatus";
      PictureBoxStatus.Size = new Size(20, 20);
      PictureBoxStatus.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxStatus.TabIndex = 2;
      PictureBoxStatus.TabStop = false;
      PictureBoxStatus.Paint += PictureBoxStatus_Paint;
      // 
      // LabelTitle
      // 
      LabelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      LabelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelTitle.Location = new Point(23, 7);
      LabelTitle.Name = "LabelTitle";
      LabelTitle.Size = new Size(191, 15);
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
      PanelLogInfo.Location = new Point(1, 30);
      PanelLogInfo.Margin = new Padding(0);
      PanelLogInfo.Name = "PanelLogInfo";
      PanelLogInfo.Size = new Size(238, 29);
      PanelLogInfo.TabIndex = 1;
      PanelLogInfo.SizeChanged += PanelLogInfo_SizeChanged;
      PanelLogInfo.ControlAdded += PanelLogInfo_ControlAdded;
      PanelLogInfo.ControlRemoved += PanelLogInfo_ControlRemoved;
      // 
      // ToolTipLogMonitor
      // 
      ToolTipLogMonitor.BackColor = Color.FromArgb(19, 26, 33);
      ToolTipLogMonitor.ForeColor = Color.FromArgb(57, 206, 216);
      ToolTipLogMonitor.OwnerDraw = true;
      ToolTipLogMonitor.ShowAlways = true;
      ToolTipLogMonitor.Draw += ToolTipLogMonitor_Draw;
      // 
      // FormLogMonitor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Lime;
      ClientSize = new Size(240, 60);
      ControlBox = false;
      Controls.Add(PanelLogInfo);
      Controls.Add(PanelHeader);
      ForeColor = Color.FromArgb(57, 206, 216);
      FormBorderStyle = FormBorderStyle.None;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(240, 60);
      Name = "FormLogMonitor";
      ShowInTaskbar = false;
      Text = "Star Citizen Handle Query - Log-Monitor";
      TopMost = true;
      TransparencyKey = Color.Lime;
      Activated += FormLogMonitor_Activated;
      Deactivate += FormLogMonitor_Deactivate;
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
    private ToolTip ToolTipLogMonitor;
  }
}