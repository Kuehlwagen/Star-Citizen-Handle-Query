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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHandleQuery));
      this.PanelHandleQuery = new System.Windows.Forms.Panel();
      this.LabelCacheType = new System.Windows.Forms.Label();
      this.TextBoxHandle = new System.Windows.Forms.TextBox();
      this.LabelHandle = new System.Windows.Forms.Label();
      this.PanelInfo = new System.Windows.Forms.FlowLayoutPanel();
      this.NotifyIconHandleQuery = new System.Windows.Forms.NotifyIcon(this.components);
      this.ContextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.AnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.EinstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.LokalerCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AufUpdatePruefenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.UeberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.BeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelHandleQuery.SuspendLayout();
      this.ContextMenuStripNotifyIcon.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelHandleQuery
      // 
      this.PanelHandleQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelHandleQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.PanelHandleQuery.Controls.Add(this.LabelCacheType);
      this.PanelHandleQuery.Controls.Add(this.TextBoxHandle);
      this.PanelHandleQuery.Controls.Add(this.LabelHandle);
      this.PanelHandleQuery.Location = new System.Drawing.Point(1, 1);
      this.PanelHandleQuery.Name = "PanelHandleQuery";
      this.PanelHandleQuery.Size = new System.Drawing.Size(373, 29);
      this.PanelHandleQuery.TabIndex = 0;
      // 
      // LabelCacheType
      // 
      this.LabelCacheType.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.LabelCacheType.Image = global::Star_Citizen_Handle_Query.Properties.Resources.Info_Background;
      this.LabelCacheType.Location = new System.Drawing.Point(310, 4);
      this.LabelCacheType.Name = "LabelCacheType";
      this.LabelCacheType.Size = new System.Drawing.Size(60, 21);
      this.LabelCacheType.TabIndex = 3;
      this.LabelCacheType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.LabelCacheType.Visible = false;
      // 
      // TextBoxHandle
      // 
      this.TextBoxHandle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TextBoxHandle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
      this.TextBoxHandle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.TextBoxHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.TextBoxHandle.Location = new System.Drawing.Point(55, 3);
      this.TextBoxHandle.MaxLength = 60;
      this.TextBoxHandle.Name = "TextBoxHandle";
      this.TextBoxHandle.PlaceholderText = "Handle eingeben...";
      this.TextBoxHandle.Size = new System.Drawing.Size(315, 23);
      this.TextBoxHandle.TabIndex = 1;
      this.TextBoxHandle.TextChanged += new System.EventHandler(this.TextBoxHandle_TextChanged);
      this.TextBoxHandle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxHandle_KeyDown);
      // 
      // LabelHandle
      // 
      this.LabelHandle.AutoSize = true;
      this.LabelHandle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelHandle.Location = new System.Drawing.Point(0, 6);
      this.LabelHandle.Name = "LabelHandle";
      this.LabelHandle.Size = new System.Drawing.Size(49, 15);
      this.LabelHandle.TabIndex = 0;
      this.LabelHandle.Text = "Handle:";
      this.LabelHandle.MouseCaptureChanged += new System.EventHandler(this.LabelHandle_MouseCaptureChanged);
      this.LabelHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelHandle_MouseDown);
      this.LabelHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelHandle_MouseMove);
      // 
      // PanelInfo
      // 
      this.PanelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelInfo.BackColor = System.Drawing.Color.Lime;
      this.PanelInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.PanelInfo.Location = new System.Drawing.Point(1, 30);
      this.PanelInfo.Margin = new System.Windows.Forms.Padding(0);
      this.PanelInfo.Name = "PanelInfo";
      this.PanelInfo.Size = new System.Drawing.Size(373, 85);
      this.PanelInfo.TabIndex = 1;
      // 
      // NotifyIconHandleQuery
      // 
      this.NotifyIconHandleQuery.ContextMenuStrip = this.ContextMenuStripNotifyIcon;
      this.NotifyIconHandleQuery.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconHandleQuery.Icon")));
      this.NotifyIconHandleQuery.Text = "Star Citizen Handle Query";
      this.NotifyIconHandleQuery.Visible = true;
      this.NotifyIconHandleQuery.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconHandleQuery_MouseClick);
      // 
      // ContextMenuStripNotifyIcon
      // 
      this.ContextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnzeigenToolStripMenuItem,
            this.EinstellungenToolStripMenuItem,
            this.LokalerCacheToolStripMenuItem,
            this.AufUpdatePruefenToolStripMenuItem,
            this.UeberToolStripMenuItem,
            this.ToolStripSeparator1,
            this.BeendenToolStripMenuItem});
      this.ContextMenuStripNotifyIcon.Name = "ContextMenuStripNotifyIcon";
      this.ContextMenuStripNotifyIcon.Size = new System.Drawing.Size(173, 142);
      // 
      // AnzeigenToolStripMenuItem
      // 
      this.AnzeigenToolStripMenuItem.Enabled = false;
      this.AnzeigenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AnzeigenToolStripMenuItem.Name = "AnzeigenToolStripMenuItem";
      this.AnzeigenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.AnzeigenToolStripMenuItem.Text = "&Anzeigen";
      this.AnzeigenToolStripMenuItem.Click += new System.EventHandler(this.AnzeigenToolStripMenuItem_Click);
      // 
      // EinstellungenToolStripMenuItem
      // 
      this.EinstellungenToolStripMenuItem.Enabled = false;
      this.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem";
      this.EinstellungenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.EinstellungenToolStripMenuItem.Text = "&Einstellungen";
      this.EinstellungenToolStripMenuItem.Click += new System.EventHandler(this.EinstellungenToolStripMenuItem_Click);
      // 
      // LokalerCacheToolStripMenuItem
      // 
      this.LokalerCacheToolStripMenuItem.Enabled = false;
      this.LokalerCacheToolStripMenuItem.Name = "LokalerCacheToolStripMenuItem";
      this.LokalerCacheToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.LokalerCacheToolStripMenuItem.Text = "&Lokaler Cache";
      this.LokalerCacheToolStripMenuItem.Click += new System.EventHandler(this.LokalerCacheToolStripMenuItem_Click);
      // 
      // AufUpdatePruefenToolStripMenuItem
      // 
      this.AufUpdatePruefenToolStripMenuItem.Enabled = false;
      this.AufUpdatePruefenToolStripMenuItem.Name = "AufUpdatePruefenToolStripMenuItem";
      this.AufUpdatePruefenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.AufUpdatePruefenToolStripMenuItem.Text = "Auf Update prüfen";
      this.AufUpdatePruefenToolStripMenuItem.Click += new System.EventHandler(this.AufUpdatePruefenToolStripMenuItem_Click);
      // 
      // UeberToolStripMenuItem
      // 
      this.UeberToolStripMenuItem.Enabled = false;
      this.UeberToolStripMenuItem.Name = "UeberToolStripMenuItem";
      this.UeberToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.UeberToolStripMenuItem.Text = "&Über";
      this.UeberToolStripMenuItem.Click += new System.EventHandler(this.UeberToolStripMenuItem_Click);
      // 
      // ToolStripSeparator1
      // 
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new System.Drawing.Size(169, 6);
      // 
      // BeendenToolStripMenuItem
      // 
      this.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem";
      this.BeendenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.BeendenToolStripMenuItem.Text = "&Beenden";
      this.BeendenToolStripMenuItem.Click += new System.EventHandler(this.BeendenToolStripMenuItem_Click);
      // 
      // FormHandleQuery
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Lime;
      this.ClientSize = new System.Drawing.Size(375, 116);
      this.Controls.Add(this.PanelInfo);
      this.Controls.Add(this.PanelHandleQuery);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormHandleQuery";
      this.ShowInTaskbar = false;
      this.Text = "Star Citizen Handle Query";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.Color.Lime;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHandleQuery_FormClosing);
      this.Shown += new System.EventHandler(this.FormHandleQuery_Shown);
      this.PanelHandleQuery.ResumeLayout(false);
      this.PanelHandleQuery.PerformLayout();
      this.ContextMenuStripNotifyIcon.ResumeLayout(false);
      this.ResumeLayout(false);

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
    private Label LabelCacheType;
    private ToolStripMenuItem UeberToolStripMenuItem;
    private ToolStripMenuItem AufUpdatePruefenToolStripMenuItem;
  }
}