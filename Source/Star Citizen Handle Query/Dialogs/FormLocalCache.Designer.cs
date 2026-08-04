namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormLocalCache {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLocalCache));
      DataGridViewLokalerCache = new DataGridView();
      ButtonCacheLeeren = new Button();
      ButtonSchliessen = new Button();
      ButtonOrdnerOeffnen = new Button();
      PanelInfo = new FlowLayoutPanel();
      ColumnCacheDatum = new DataGridViewTextBoxColumn();
      ColumnHandle = new DataGridViewLinkColumn();
      ColumnCommunityMoniker = new DataGridViewTextBoxColumn();
      ColumnEnlisted = new DataGridViewTextBoxColumn();
      ColumnUEECitizenRecord = new DataGridViewTextBoxColumn();
      ColumnOrganisation = new DataGridViewLinkColumn();
      ColumnOrganisationRang = new DataGridViewTextBoxColumn();
      ColumnAnzahlAffiliationen = new DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)DataGridViewLokalerCache).BeginInit();
      SuspendLayout();
      // 
      // DataGridViewLokalerCache
      // 
      DataGridViewLokalerCache.AllowUserToAddRows = false;
      DataGridViewLokalerCache.AllowUserToDeleteRows = false;
      DataGridViewLokalerCache.AllowUserToResizeColumns = false;
      DataGridViewLokalerCache.AllowUserToResizeRows = false;
      DataGridViewLokalerCache.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      DataGridViewLokalerCache.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      DataGridViewLokalerCache.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      DataGridViewLokalerCache.BackgroundColor = Color.FromArgb(19, 26, 33);
      DataGridViewLokalerCache.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      DataGridViewLokalerCache.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      dataGridViewCellStyle1.ForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
      DataGridViewLokalerCache.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      DataGridViewLokalerCache.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      DataGridViewLokalerCache.Columns.AddRange(new DataGridViewColumn[] { ColumnCacheDatum, ColumnHandle, ColumnCommunityMoniker, ColumnEnlisted, ColumnUEECitizenRecord, ColumnOrganisation, ColumnOrganisationRang, ColumnAnzahlAffiliationen });
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
      dataGridViewCellStyle2.ForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      DataGridViewLokalerCache.DefaultCellStyle = dataGridViewCellStyle2;
      DataGridViewLokalerCache.EnableHeadersVisualStyles = false;
      DataGridViewLokalerCache.Location = new Point(12, 12);
      DataGridViewLokalerCache.Name = "DataGridViewLokalerCache";
      DataGridViewLokalerCache.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      DataGridViewLokalerCache.RowHeadersVisible = false;
      DataGridViewLokalerCache.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      DataGridViewLokalerCache.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      DataGridViewLokalerCache.ShowEditingIcon = false;
      DataGridViewLokalerCache.Size = new Size(905, 293);
      DataGridViewLokalerCache.TabIndex = 0;
      DataGridViewLokalerCache.CellContentClick += DataGridViewExport_CellContentClick;
      DataGridViewLokalerCache.SelectionChanged += DataGridViewExport_SelectionChanged;
      // 
      // ButtonCacheLeeren
      // 
      ButtonCacheLeeren.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ButtonCacheLeeren.BackColor = Color.FromArgb(19, 26, 33);
      ButtonCacheLeeren.FlatStyle = FlatStyle.Flat;
      ButtonCacheLeeren.Location = new Point(12, 397);
      ButtonCacheLeeren.Name = "ButtonCacheLeeren";
      ButtonCacheLeeren.Size = new Size(91, 28);
      ButtonCacheLeeren.TabIndex = 1;
      ButtonCacheLeeren.Text = "Cache leeren";
      ButtonCacheLeeren.UseVisualStyleBackColor = false;
      ButtonCacheLeeren.Click += ButtonCacheLeeren_Click;
      // 
      // ButtonSchliessen
      // 
      ButtonSchliessen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ButtonSchliessen.BackColor = Color.FromArgb(19, 26, 33);
      ButtonSchliessen.FlatStyle = FlatStyle.Flat;
      ButtonSchliessen.Location = new Point(216, 397);
      ButtonSchliessen.Name = "ButtonSchliessen";
      ButtonSchliessen.Size = new Size(74, 28);
      ButtonSchliessen.TabIndex = 3;
      ButtonSchliessen.Text = "Schließen";
      ButtonSchliessen.UseVisualStyleBackColor = false;
      ButtonSchliessen.Click += ButtonSchliessen_Click;
      // 
      // ButtonOrdnerOeffnen
      // 
      ButtonOrdnerOeffnen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ButtonOrdnerOeffnen.BackColor = Color.FromArgb(19, 26, 33);
      ButtonOrdnerOeffnen.FlatStyle = FlatStyle.Flat;
      ButtonOrdnerOeffnen.Location = new Point(109, 397);
      ButtonOrdnerOeffnen.Name = "ButtonOrdnerOeffnen";
      ButtonOrdnerOeffnen.Size = new Size(101, 28);
      ButtonOrdnerOeffnen.TabIndex = 2;
      ButtonOrdnerOeffnen.Text = "Ordner öffnen";
      ButtonOrdnerOeffnen.UseVisualStyleBackColor = false;
      ButtonOrdnerOeffnen.Click += ButtonOrdnerOeffnen_Click;
      // 
      // PanelInfo
      // 
      PanelInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      PanelInfo.BackColor = Color.FromArgb(19, 26, 33);
      PanelInfo.Location = new Point(12, 308);
      PanelInfo.Margin = new Padding(0);
      PanelInfo.Name = "PanelInfo";
      PanelInfo.Size = new Size(905, 85);
      PanelInfo.TabIndex = 4;
      // 
      // ColumnCacheDatum
      // 
      ColumnCacheDatum.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnCacheDatum.Frozen = true;
      ColumnCacheDatum.HeaderText = "Cache Datum";
      ColumnCacheDatum.MinimumWidth = 74;
      ColumnCacheDatum.Name = "ColumnCacheDatum";
      ColumnCacheDatum.ReadOnly = true;
      ColumnCacheDatum.Width = 105;
      // 
      // ColumnHandle
      // 
      ColumnHandle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnHandle.Frozen = true;
      ColumnHandle.HeaderText = "Handle";
      ColumnHandle.LinkColor = Color.SteelBlue;
      ColumnHandle.MinimumWidth = 74;
      ColumnHandle.Name = "ColumnHandle";
      ColumnHandle.ReadOnly = true;
      ColumnHandle.Resizable = DataGridViewTriState.True;
      ColumnHandle.SortMode = DataGridViewColumnSortMode.Automatic;
      ColumnHandle.TrackVisitedState = false;
      ColumnHandle.Width = 74;
      // 
      // ColumnCommunityMoniker
      // 
      ColumnCommunityMoniker.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnCommunityMoniker.HeaderText = "CM";
      ColumnCommunityMoniker.Name = "ColumnCommunityMoniker";
      ColumnCommunityMoniker.ReadOnly = true;
      ColumnCommunityMoniker.Width = 49;
      // 
      // ColumnEnlisted
      // 
      ColumnEnlisted.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnEnlisted.HeaderText = "Angeworben";
      ColumnEnlisted.Name = "ColumnEnlisted";
      ColumnEnlisted.ReadOnly = true;
      ColumnEnlisted.Width = 103;
      // 
      // ColumnUEECitizenRecord
      // 
      ColumnUEECitizenRecord.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnUEECitizenRecord.HeaderText = "UEE CR";
      ColumnUEECitizenRecord.Name = "ColumnUEECitizenRecord";
      ColumnUEECitizenRecord.ReadOnly = true;
      ColumnUEECitizenRecord.Width = 70;
      // 
      // ColumnOrganisation
      // 
      ColumnOrganisation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnOrganisation.HeaderText = "Organisation";
      ColumnOrganisation.LinkColor = Color.SteelBlue;
      ColumnOrganisation.MinimumWidth = 99;
      ColumnOrganisation.Name = "ColumnOrganisation";
      ColumnOrganisation.ReadOnly = true;
      ColumnOrganisation.Resizable = DataGridViewTriState.True;
      ColumnOrganisation.SortMode = DataGridViewColumnSortMode.Automatic;
      ColumnOrganisation.TrackVisitedState = false;
      ColumnOrganisation.Width = 101;
      // 
      // ColumnOrganisationRang
      // 
      ColumnOrganisationRang.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnOrganisationRang.HeaderText = "Org. Rang";
      ColumnOrganisationRang.Name = "ColumnOrganisationRang";
      ColumnOrganisationRang.ReadOnly = true;
      ColumnOrganisationRang.Width = 86;
      // 
      // ColumnAnzahlAffiliationen
      // 
      ColumnAnzahlAffiliationen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      ColumnAnzahlAffiliationen.HeaderText = "Anz. Aff.";
      ColumnAnzahlAffiliationen.Name = "ColumnAnzahlAffiliationen";
      ColumnAnzahlAffiliationen.ReadOnly = true;
      // 
      // FormLocalCache
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      CancelButton = ButtonSchliessen;
      ClientSize = new Size(929, 436);
      Controls.Add(PanelInfo);
      Controls.Add(ButtonOrdnerOeffnen);
      Controls.Add(ButtonSchliessen);
      Controls.Add(ButtonCacheLeeren);
      Controls.Add(DataGridViewLokalerCache);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(945, 475);
      Name = "FormLocalCache";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Star Citizen Handle Query - Lokaler Cache";
      FormClosing += FormLocalCache_FormClosing;
      Load += FormExport_Load;
      ((System.ComponentModel.ISupportInitialize)DataGridViewLokalerCache).EndInit();
      ResumeLayout(false);

    }

    #endregion

    private DataGridView DataGridViewLokalerCache;
    private Button ButtonCacheLeeren;
    private Button ButtonSchliessen;
    private Button ButtonOrdnerOeffnen;
    private FlowLayoutPanel PanelInfo;
    private DataGridViewTextBoxColumn ColumnCacheDatum;
    private DataGridViewLinkColumn ColumnHandle;
    private DataGridViewTextBoxColumn ColumnCommunityMoniker;
    private DataGridViewTextBoxColumn ColumnEnlisted;
    private DataGridViewTextBoxColumn ColumnUEECitizenRecord;
    private DataGridViewLinkColumn ColumnOrganisation;
    private DataGridViewTextBoxColumn ColumnOrganisationRang;
    private DataGridViewTextBoxColumn ColumnAnzahlAffiliationen;
  }
}