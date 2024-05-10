namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormRelations {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelations));
      PanelHeader = new Panel();
      CheckBoxFilterBandit = new CheckBox();
      CheckBoxFilterBogey = new CheckBox();
      CheckBoxFilterNeutral = new CheckBox();
      CheckBoxFilterOrganization = new CheckBox();
      CheckBoxFilterFriendly = new CheckBox();
      PictureBoxClearAll = new PictureBox();
      LabelTitle = new Label();
      PanelRelations = new FlowLayoutPanel();
      ToolTipRelations = new ToolTip(components);
      PanelHeader.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)PictureBoxClearAll).BeginInit();
      SuspendLayout();
      // 
      // PanelHeader
      // 
      PanelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      PanelHeader.BackColor = Color.FromArgb(19, 26, 33);
      PanelHeader.Controls.Add(CheckBoxFilterBandit);
      PanelHeader.Controls.Add(CheckBoxFilterBogey);
      PanelHeader.Controls.Add(CheckBoxFilterNeutral);
      PanelHeader.Controls.Add(CheckBoxFilterOrganization);
      PanelHeader.Controls.Add(CheckBoxFilterFriendly);
      PanelHeader.Controls.Add(PictureBoxClearAll);
      PanelHeader.Controls.Add(LabelTitle);
      PanelHeader.Location = new Point(1, 1);
      PanelHeader.Name = "PanelHeader";
      PanelHeader.Size = new Size(238, 29);
      PanelHeader.TabIndex = 0;
      // 
      // CheckBoxFilterBandit
      // 
      CheckBoxFilterBandit.Appearance = Appearance.Button;
      CheckBoxFilterBandit.BackColor = Color.Red;
      CheckBoxFilterBandit.BackgroundImageLayout = ImageLayout.Center;
      CheckBoxFilterBandit.Checked = true;
      CheckBoxFilterBandit.CheckState = CheckState.Checked;
      CheckBoxFilterBandit.Cursor = Cursors.Hand;
      CheckBoxFilterBandit.FlatAppearance.BorderColor = Color.FromArgb(127, 0, 0);
      CheckBoxFilterBandit.FlatAppearance.CheckedBackColor = Color.Red;
      CheckBoxFilterBandit.FlatStyle = FlatStyle.Flat;
      CheckBoxFilterBandit.ForeColor = Color.FromArgb(19, 26, 33);
      CheckBoxFilterBandit.Location = new Point(182, 7);
      CheckBoxFilterBandit.Name = "CheckBoxFilterBandit";
      CheckBoxFilterBandit.Size = new Size(15, 15);
      CheckBoxFilterBandit.TabIndex = 3;
      CheckBoxFilterBandit.UseVisualStyleBackColor = false;
      CheckBoxFilterBandit.CheckedChanged += CheckBoxFilterChanged;
      CheckBoxFilterBandit.Paint += CheckBoxFilter_Paint;
      // 
      // CheckBoxFilterBogey
      // 
      CheckBoxFilterBogey.Appearance = Appearance.Button;
      CheckBoxFilterBogey.BackColor = Color.Orange;
      CheckBoxFilterBogey.BackgroundImageLayout = ImageLayout.Center;
      CheckBoxFilterBogey.Checked = true;
      CheckBoxFilterBogey.CheckState = CheckState.Checked;
      CheckBoxFilterBogey.Cursor = Cursors.Hand;
      CheckBoxFilterBogey.FlatAppearance.BorderColor = Color.FromArgb(127, 82, 0);
      CheckBoxFilterBogey.FlatAppearance.CheckedBackColor = Color.Orange;
      CheckBoxFilterBogey.FlatStyle = FlatStyle.Flat;
      CheckBoxFilterBogey.ForeColor = Color.FromArgb(19, 26, 33);
      CheckBoxFilterBogey.Location = new Point(165, 7);
      CheckBoxFilterBogey.Name = "CheckBoxFilterBogey";
      CheckBoxFilterBogey.Size = new Size(15, 15);
      CheckBoxFilterBogey.TabIndex = 3;
      CheckBoxFilterBogey.UseVisualStyleBackColor = false;
      CheckBoxFilterBogey.CheckedChanged += CheckBoxFilterChanged;
      CheckBoxFilterBogey.Paint += CheckBoxFilter_Paint;
      // 
      // CheckBoxFilterNeutral
      // 
      CheckBoxFilterNeutral.Appearance = Appearance.Button;
      CheckBoxFilterNeutral.BackColor = Color.Gray;
      CheckBoxFilterNeutral.BackgroundImageLayout = ImageLayout.Center;
      CheckBoxFilterNeutral.Checked = true;
      CheckBoxFilterNeutral.CheckState = CheckState.Checked;
      CheckBoxFilterNeutral.Cursor = Cursors.Hand;
      CheckBoxFilterNeutral.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
      CheckBoxFilterNeutral.FlatAppearance.CheckedBackColor = Color.Gray;
      CheckBoxFilterNeutral.FlatStyle = FlatStyle.Flat;
      CheckBoxFilterNeutral.ForeColor = Color.FromArgb(19, 26, 33);
      CheckBoxFilterNeutral.Location = new Point(148, 7);
      CheckBoxFilterNeutral.Name = "CheckBoxFilterNeutral";
      CheckBoxFilterNeutral.Size = new Size(15, 15);
      CheckBoxFilterNeutral.TabIndex = 3;
      CheckBoxFilterNeutral.UseVisualStyleBackColor = false;
      CheckBoxFilterNeutral.CheckedChanged += CheckBoxFilterChanged;
      CheckBoxFilterNeutral.Paint += CheckBoxFilter_Paint;
      // 
      // CheckBoxFilterOrganization
      // 
      CheckBoxFilterOrganization.Appearance = Appearance.Button;
      CheckBoxFilterOrganization.BackColor = Color.FromArgb(57, 206, 216);
      CheckBoxFilterOrganization.Checked = true;
      CheckBoxFilterOrganization.CheckState = CheckState.Checked;
      CheckBoxFilterOrganization.Cursor = Cursors.Hand;
      CheckBoxFilterOrganization.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
      CheckBoxFilterOrganization.FlatAppearance.CheckedBackColor = Color.FromArgb(57, 206, 216);
      CheckBoxFilterOrganization.FlatStyle = FlatStyle.Flat;
      CheckBoxFilterOrganization.ForeColor = Color.FromArgb(19, 26, 33);
      CheckBoxFilterOrganization.Location = new Point(198, 7);
      CheckBoxFilterOrganization.Name = "CheckBoxFilterOrganization";
      CheckBoxFilterOrganization.Size = new Size(15, 15);
      CheckBoxFilterOrganization.TabIndex = 3;
      CheckBoxFilterOrganization.UseVisualStyleBackColor = false;
      CheckBoxFilterOrganization.CheckedChanged += CheckBoxFilterChanged;
      CheckBoxFilterOrganization.Paint += CheckBoxFilter_Paint;
      // 
      // CheckBoxFilterFriendly
      // 
      CheckBoxFilterFriendly.Appearance = Appearance.Button;
      CheckBoxFilterFriendly.BackColor = Color.Green;
      CheckBoxFilterFriendly.BackgroundImageLayout = ImageLayout.Center;
      CheckBoxFilterFriendly.Checked = true;
      CheckBoxFilterFriendly.CheckState = CheckState.Checked;
      CheckBoxFilterFriendly.Cursor = Cursors.Hand;
      CheckBoxFilterFriendly.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
      CheckBoxFilterFriendly.FlatAppearance.CheckedBackColor = Color.Green;
      CheckBoxFilterFriendly.FlatStyle = FlatStyle.Flat;
      CheckBoxFilterFriendly.ForeColor = Color.FromArgb(19, 26, 33);
      CheckBoxFilterFriendly.Location = new Point(131, 7);
      CheckBoxFilterFriendly.Name = "CheckBoxFilterFriendly";
      CheckBoxFilterFriendly.Size = new Size(15, 15);
      CheckBoxFilterFriendly.TabIndex = 3;
      CheckBoxFilterFriendly.UseVisualStyleBackColor = false;
      CheckBoxFilterFriendly.CheckedChanged += CheckBoxFilterChanged;
      CheckBoxFilterFriendly.Paint += CheckBoxFilter_Paint;
      // 
      // PictureBoxClearAll
      // 
      PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
      PictureBoxClearAll.Location = new Point(219, 7);
      PictureBoxClearAll.Name = "PictureBoxClearAll";
      PictureBoxClearAll.Size = new Size(12, 15);
      PictureBoxClearAll.SizeMode = PictureBoxSizeMode.Zoom;
      PictureBoxClearAll.TabIndex = 2;
      PictureBoxClearAll.TabStop = false;
      // 
      // LabelTitle
      // 
      LabelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelTitle.Location = new Point(4, 7);
      LabelTitle.Name = "LabelTitle";
      LabelTitle.Size = new Size(125, 15);
      LabelTitle.TabIndex = 0;
      LabelTitle.Text = "Beziehungen";
      LabelTitle.TextAlign = ContentAlignment.MiddleLeft;
      LabelTitle.MouseCaptureChanged += LabelTitle_MouseCaptureChanged;
      LabelTitle.MouseDown += LabelTitle_MouseDown;
      LabelTitle.MouseMove += LabelTitle_MouseMove;
      // 
      // PanelRelations
      // 
      PanelRelations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      PanelRelations.BackColor = Color.Lime;
      PanelRelations.FlowDirection = FlowDirection.TopDown;
      PanelRelations.Location = new Point(1, 30);
      PanelRelations.Margin = new Padding(0);
      PanelRelations.Name = "PanelRelations";
      PanelRelations.Size = new Size(238, 29);
      PanelRelations.TabIndex = 1;
      PanelRelations.ControlAdded += PanelRelations_ControlAdded;
      PanelRelations.ControlRemoved += PanelRelations_ControlRemoved;
      // 
      // ToolTipRelations
      // 
      ToolTipRelations.BackColor = Color.FromArgb(19, 26, 33);
      ToolTipRelations.ForeColor = Color.FromArgb(57, 206, 216);
      ToolTipRelations.OwnerDraw = true;
      ToolTipRelations.ShowAlways = true;
      ToolTipRelations.Draw += ToolTipHandleQuery_Draw;
      // 
      // FormRelations
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Lime;
      ClientSize = new Size(240, 60);
      Controls.Add(PanelRelations);
      Controls.Add(PanelHeader);
      ForeColor = Color.FromArgb(57, 206, 216);
      FormBorderStyle = FormBorderStyle.None;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "FormRelations";
      ShowInTaskbar = false;
      Text = "Star Citizen Handle Query";
      TopMost = true;
      TransparencyKey = Color.Lime;
      FormClosing += FormRelations_FormClosing;
      Shown += FormRelations_Shown;
      PanelHeader.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)PictureBoxClearAll).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel PanelHeader;
    private Label LabelTitle;
    private FlowLayoutPanel PanelRelations;
    private CheckBox CheckBoxFilterFriendly;
    private CheckBox CheckBoxFilterNeutral;
    private CheckBox CheckBoxFilterBogey;
    private CheckBox CheckBoxFilterBandit;
    private CheckBox CheckBoxFilterOrganization;
    internal PictureBox PictureBoxClearAll;
    private ToolTip ToolTipRelations;
  }
}