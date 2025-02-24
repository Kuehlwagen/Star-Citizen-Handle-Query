namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormHandleQuery {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHandleQuery));
      PanelHandleQuery = new Panel();
      TextBoxHandle = new TextBox();
      LabelSettings = new Label();
      LabelQuery = new Label();
      LabelLockUnlock = new Label();
      LabelHandle = new Label();
      PanelInfo = new FlowLayoutPanel();
      NotifyIconHandleQuery = new NotifyIcon(components);
      ContextMenuStripNotifyIcon = new ContextMenuStrip(components);
      AnzeigenToolStripMenuItem = new ToolStripMenuItem();
      EinstellungenToolStripMenuItem = new ToolStripMenuItem();
      LokalerCacheToolStripMenuItem = new ToolStripMenuItem();
      AufUpdatePruefenToolStripMenuItem = new ToolStripMenuItem();
      UeberToolStripMenuItem = new ToolStripMenuItem();
      ToolStripSeparator1 = new ToolStripSeparator();
      BeziehungenBereitstellenToolStripMenuItem = new ToolStripMenuItem();
      BeziehungenUebernehmenToolStripMenuItem = new ToolStripMenuItem();
      toolStripSeparator2 = new ToolStripSeparator();
      BeendenToolStripMenuItem = new ToolStripMenuItem();
      ToolTipHandleQuery = new ToolTip(components);
      PanelHandleQuery.SuspendLayout();
      ContextMenuStripNotifyIcon.SuspendLayout();
      SuspendLayout();
      // 
      // PanelHandleQuery
      // 
      PanelHandleQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      PanelHandleQuery.BackColor = Color.FromArgb(19, 26, 33);
      PanelHandleQuery.Controls.Add(TextBoxHandle);
      PanelHandleQuery.Controls.Add(LabelSettings);
      PanelHandleQuery.Controls.Add(LabelQuery);
      PanelHandleQuery.Controls.Add(LabelLockUnlock);
      PanelHandleQuery.Controls.Add(LabelHandle);
      PanelHandleQuery.Location = new Point(1, 1);
      PanelHandleQuery.Name = "PanelHandleQuery";
      PanelHandleQuery.Size = new Size(373, 29);
      PanelHandleQuery.TabIndex = 0;
      // 
      // TextBoxHandle
      // 
      TextBoxHandle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      TextBoxHandle.AutoCompleteMode = AutoCompleteMode.Append;
      TextBoxHandle.AutoCompleteSource = AutoCompleteSource.CustomSource;
      TextBoxHandle.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxHandle.Location = new Point(69, 3);
      TextBoxHandle.MaxLength = 60;
      TextBoxHandle.Name = "TextBoxHandle";
      TextBoxHandle.PlaceholderText = "Handle eingeben...";
      TextBoxHandle.Size = new Size(253, 23);
      TextBoxHandle.TabIndex = 2;
      TextBoxHandle.TextChanged += TextBoxHandle_TextChanged;
      TextBoxHandle.KeyDown += TextBoxHandle_KeyDown;
      // 
      // LabelSettings
      // 
      LabelSettings.Cursor = Cursors.Hand;
      LabelSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelSettings.Image = Properties.Resources.Settings;
      LabelSettings.Location = new Point(350, 4);
      LabelSettings.Name = "LabelSettings";
      LabelSettings.Size = new Size(20, 20);
      LabelSettings.TabIndex = 3;
      LabelSettings.MouseClick += LabelSettings_MouseClick;
      // 
      // LabelQuery
      // 
      LabelQuery.Cursor = Cursors.Hand;
      LabelQuery.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelQuery.Image = Properties.Resources.Search;
      LabelQuery.Location = new Point(328, 4);
      LabelQuery.Name = "LabelQuery";
      LabelQuery.Size = new Size(20, 20);
      LabelQuery.TabIndex = 3;
      LabelQuery.MouseClick += LabelQuery_MouseClick;
      // 
      // LabelLockUnlock
      // 
      LabelLockUnlock.Cursor = Cursors.Hand;
      LabelLockUnlock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelLockUnlock.Image = Properties.Resources.WindowLocked;
      LabelLockUnlock.Location = new Point(3, 7);
      LabelLockUnlock.Name = "LabelLockUnlock";
      LabelLockUnlock.Size = new Size(12, 12);
      LabelLockUnlock.TabIndex = 0;
      LabelLockUnlock.MouseClick += LabelLockUnlock_MouseClick;
      // 
      // LabelHandle
      // 
      LabelHandle.AutoSize = true;
      LabelHandle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      LabelHandle.Location = new Point(14, 6);
      LabelHandle.Name = "LabelHandle";
      LabelHandle.Size = new Size(49, 15);
      LabelHandle.TabIndex = 1;
      LabelHandle.Text = "Handle:";
      LabelHandle.MouseCaptureChanged += LabelHandle_MouseCaptureChanged;
      LabelHandle.MouseDown += LabelHandle_MouseDown;
      LabelHandle.MouseMove += LabelHandle_MouseMove;
      // 
      // PanelInfo
      // 
      PanelInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      PanelInfo.BackColor = Color.Lime;
      PanelInfo.FlowDirection = FlowDirection.TopDown;
      PanelInfo.Location = new Point(1, 30);
      PanelInfo.Margin = new Padding(0);
      PanelInfo.Name = "PanelInfo";
      PanelInfo.Size = new Size(373, 85);
      PanelInfo.TabIndex = 1;
      // 
      // NotifyIconHandleQuery
      // 
      NotifyIconHandleQuery.ContextMenuStrip = ContextMenuStripNotifyIcon;
      NotifyIconHandleQuery.Icon = (Icon)resources.GetObject("NotifyIconHandleQuery.Icon");
      NotifyIconHandleQuery.Text = "Star Citizen Handle Query";
      NotifyIconHandleQuery.Visible = true;
      NotifyIconHandleQuery.MouseClick += NotifyIconHandleQuery_MouseClick;
      // 
      // ContextMenuStripNotifyIcon
      // 
      ContextMenuStripNotifyIcon.Items.AddRange(new ToolStripItem[] { AnzeigenToolStripMenuItem, EinstellungenToolStripMenuItem, LokalerCacheToolStripMenuItem, AufUpdatePruefenToolStripMenuItem, UeberToolStripMenuItem, ToolStripSeparator1, BeziehungenBereitstellenToolStripMenuItem, BeziehungenUebernehmenToolStripMenuItem, toolStripSeparator2, BeendenToolStripMenuItem });
      ContextMenuStripNotifyIcon.Name = "ContextMenuStripNotifyIcon";
      ContextMenuStripNotifyIcon.Size = new Size(214, 192);
      // 
      // AnzeigenToolStripMenuItem
      // 
      AnzeigenToolStripMenuItem.Enabled = false;
      AnzeigenToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      AnzeigenToolStripMenuItem.Name = "AnzeigenToolStripMenuItem";
      AnzeigenToolStripMenuItem.Size = new Size(213, 22);
      AnzeigenToolStripMenuItem.Text = "&Anzeigen";
      AnzeigenToolStripMenuItem.Click += AnzeigenToolStripMenuItem_Click;
      // 
      // EinstellungenToolStripMenuItem
      // 
      EinstellungenToolStripMenuItem.Enabled = false;
      EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem";
      EinstellungenToolStripMenuItem.Size = new Size(213, 22);
      EinstellungenToolStripMenuItem.Text = "&Einstellungen";
      EinstellungenToolStripMenuItem.Click += EinstellungenToolStripMenuItem_Click;
      // 
      // LokalerCacheToolStripMenuItem
      // 
      LokalerCacheToolStripMenuItem.Enabled = false;
      LokalerCacheToolStripMenuItem.Name = "LokalerCacheToolStripMenuItem";
      LokalerCacheToolStripMenuItem.Size = new Size(213, 22);
      LokalerCacheToolStripMenuItem.Text = "&Lokaler Cache";
      LokalerCacheToolStripMenuItem.Click += LokalerCacheToolStripMenuItem_Click;
      // 
      // AufUpdatePruefenToolStripMenuItem
      // 
      AufUpdatePruefenToolStripMenuItem.Enabled = false;
      AufUpdatePruefenToolStripMenuItem.Name = "AufUpdatePruefenToolStripMenuItem";
      AufUpdatePruefenToolStripMenuItem.Size = new Size(213, 22);
      AufUpdatePruefenToolStripMenuItem.Text = "Auf Update prüfen";
      AufUpdatePruefenToolStripMenuItem.Click += AufUpdatePruefenToolStripMenuItem_Click;
      // 
      // UeberToolStripMenuItem
      // 
      UeberToolStripMenuItem.Enabled = false;
      UeberToolStripMenuItem.Name = "UeberToolStripMenuItem";
      UeberToolStripMenuItem.Size = new Size(213, 22);
      UeberToolStripMenuItem.Text = "&Über";
      UeberToolStripMenuItem.Click += UeberToolStripMenuItem_Click;
      // 
      // ToolStripSeparator1
      // 
      ToolStripSeparator1.Name = "ToolStripSeparator1";
      ToolStripSeparator1.Size = new Size(210, 6);
      ToolStripSeparator1.Visible = false;
      // 
      // BeziehungenBereitstellenToolStripMenuItem
      // 
      BeziehungenBereitstellenToolStripMenuItem.Name = "BeziehungenBereitstellenToolStripMenuItem";
      BeziehungenBereitstellenToolStripMenuItem.Size = new Size(213, 22);
      BeziehungenBereitstellenToolStripMenuItem.Text = "Beziehungen bereitstellen";
      BeziehungenBereitstellenToolStripMenuItem.Visible = false;
      BeziehungenBereitstellenToolStripMenuItem.Click += BeziehungenBereitstellenToolStripMenuItem_Click;
      // 
      // BeziehungenUebernehmenToolStripMenuItem
      // 
      BeziehungenUebernehmenToolStripMenuItem.Name = "BeziehungenUebernehmenToolStripMenuItem";
      BeziehungenUebernehmenToolStripMenuItem.Size = new Size(213, 22);
      BeziehungenUebernehmenToolStripMenuItem.Text = "Beziehungen übernehmen";
      BeziehungenUebernehmenToolStripMenuItem.Visible = false;
      BeziehungenUebernehmenToolStripMenuItem.Click += BeziehungenUebernehmenToolStripMenuItem_Click;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(210, 6);
      // 
      // BeendenToolStripMenuItem
      // 
      BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem";
      BeendenToolStripMenuItem.Size = new Size(213, 22);
      BeendenToolStripMenuItem.Text = "&Beenden";
      BeendenToolStripMenuItem.Click += BeendenToolStripMenuItem_Click;
      // 
      // ToolTipHandleQuery
      // 
      ToolTipHandleQuery.BackColor = Color.FromArgb(19, 26, 33);
      ToolTipHandleQuery.ForeColor = Color.FromArgb(57, 206, 216);
      ToolTipHandleQuery.OwnerDraw = true;
      ToolTipHandleQuery.ShowAlways = true;
      ToolTipHandleQuery.Draw += ToolTipHandleQuery_Draw;
      // 
      // FormHandleQuery
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Lime;
      ClientSize = new Size(375, 116);
      Controls.Add(PanelInfo);
      Controls.Add(PanelHandleQuery);
      ForeColor = Color.FromArgb(57, 206, 216);
      FormBorderStyle = FormBorderStyle.None;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "FormHandleQuery";
      ShowInTaskbar = false;
      Text = "Star Citizen Handle Query";
      TopMost = true;
      TransparencyKey = Color.Lime;
      Activated += FormHandleQuery_Activated;
      Deactivate += FormHandleQuery_Deactivate;
      FormClosing += FormHandleQuery_FormClosing;
      Shown += FormHandleQuery_Shown;
      PanelHandleQuery.ResumeLayout(false);
      PanelHandleQuery.PerformLayout();
      ContextMenuStripNotifyIcon.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel PanelHandleQuery;
    private TextBox TextBoxHandle;
    private Label LabelHandle;
    private FlowLayoutPanel PanelInfo;
    private NotifyIcon NotifyIconHandleQuery;
    private ContextMenuStrip ContextMenuStripNotifyIcon;
    private ToolStripMenuItem BeendenToolStripMenuItem;
    private ToolStripMenuItem AnzeigenToolStripMenuItem;
    private ToolStripSeparator ToolStripSeparator1;
    private ToolStripMenuItem EinstellungenToolStripMenuItem;
    private ToolStripMenuItem LokalerCacheToolStripMenuItem;
    private ToolStripMenuItem UeberToolStripMenuItem;
    private ToolStripMenuItem AufUpdatePruefenToolStripMenuItem;
    private Label LabelLockUnlock;
    private Label LabelQuery;
    private Label LabelSettings;
    private ToolTip ToolTipHandleQuery;
    private ToolStripMenuItem BeziehungenBereitstellenToolStripMenuItem;
    private ToolStripMenuItem BeziehungenUebernehmenToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
  }
}