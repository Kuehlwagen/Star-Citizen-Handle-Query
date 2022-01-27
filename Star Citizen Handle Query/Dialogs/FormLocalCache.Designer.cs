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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLocalCache));
      this.DataGridViewExport = new System.Windows.Forms.DataGridView();
      this.ColumnCacheDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnHandle = new System.Windows.Forms.DataGridViewLinkColumn();
      this.ColumnOrganisation = new System.Windows.Forms.DataGridViewLinkColumn();
      this.ButtonCacheLeeren = new System.Windows.Forms.Button();
      this.ButtonSchliessen = new System.Windows.Forms.Button();
      this.ButtonOrdnerOeffnen = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewExport)).BeginInit();
      this.SuspendLayout();
      // 
      // DataGridViewExport
      // 
      this.DataGridViewExport.AllowUserToAddRows = false;
      this.DataGridViewExport.AllowUserToDeleteRows = false;
      this.DataGridViewExport.AllowUserToResizeColumns = false;
      this.DataGridViewExport.AllowUserToResizeRows = false;
      this.DataGridViewExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DataGridViewExport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.DataGridViewExport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridViewExport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.DataGridViewExport.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.DataGridViewExport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.DataGridViewExport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.DataGridViewExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridViewExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCacheDatum,
            this.ColumnHandle,
            this.ColumnOrganisation});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.DataGridViewExport.DefaultCellStyle = dataGridViewCellStyle2;
      this.DataGridViewExport.EnableHeadersVisualStyles = false;
      this.DataGridViewExport.Location = new System.Drawing.Point(12, 12);
      this.DataGridViewExport.Name = "DataGridViewExport";
      this.DataGridViewExport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      this.DataGridViewExport.RowHeadersVisible = false;
      this.DataGridViewExport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.DataGridViewExport.RowTemplate.Height = 25;
      this.DataGridViewExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridViewExport.ShowEditingIcon = false;
      this.DataGridViewExport.Size = new System.Drawing.Size(410, 283);
      this.DataGridViewExport.TabIndex = 0;
      this.DataGridViewExport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewExport_CellContentClick);
      // 
      // ColumnCacheDatum
      // 
      this.ColumnCacheDatum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.ColumnCacheDatum.Frozen = true;
      this.ColumnCacheDatum.HeaderText = "Cache Datum";
      this.ColumnCacheDatum.MinimumWidth = 74;
      this.ColumnCacheDatum.Name = "ColumnCacheDatum";
      this.ColumnCacheDatum.ReadOnly = true;
      this.ColumnCacheDatum.Width = 105;
      // 
      // ColumnHandle
      // 
      this.ColumnHandle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.ColumnHandle.Frozen = true;
      this.ColumnHandle.HeaderText = "Handle";
      this.ColumnHandle.LinkColor = System.Drawing.Color.SteelBlue;
      this.ColumnHandle.MinimumWidth = 74;
      this.ColumnHandle.Name = "ColumnHandle";
      this.ColumnHandle.ReadOnly = true;
      this.ColumnHandle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ColumnHandle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.ColumnHandle.TrackVisitedState = false;
      this.ColumnHandle.Width = 74;
      // 
      // ColumnOrganisation
      // 
      this.ColumnOrganisation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ColumnOrganisation.HeaderText = "Organisation";
      this.ColumnOrganisation.LinkColor = System.Drawing.Color.SteelBlue;
      this.ColumnOrganisation.MinimumWidth = 99;
      this.ColumnOrganisation.Name = "ColumnOrganisation";
      this.ColumnOrganisation.ReadOnly = true;
      this.ColumnOrganisation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ColumnOrganisation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.ColumnOrganisation.TrackVisitedState = false;
      // 
      // ButtonCacheLeeren
      // 
      this.ButtonCacheLeeren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ButtonCacheLeeren.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ButtonCacheLeeren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonCacheLeeren.Location = new System.Drawing.Point(12, 301);
      this.ButtonCacheLeeren.Name = "ButtonCacheLeeren";
      this.ButtonCacheLeeren.Size = new System.Drawing.Size(91, 28);
      this.ButtonCacheLeeren.TabIndex = 1;
      this.ButtonCacheLeeren.Text = "Cache leeren";
      this.ButtonCacheLeeren.UseVisualStyleBackColor = false;
      this.ButtonCacheLeeren.Click += new System.EventHandler(this.ButtonCacheLeeren_Click);
      // 
      // ButtonSchliessen
      // 
      this.ButtonSchliessen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ButtonSchliessen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ButtonSchliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonSchliessen.Location = new System.Drawing.Point(216, 301);
      this.ButtonSchliessen.Name = "ButtonSchliessen";
      this.ButtonSchliessen.Size = new System.Drawing.Size(74, 28);
      this.ButtonSchliessen.TabIndex = 3;
      this.ButtonSchliessen.Text = "Schließen";
      this.ButtonSchliessen.UseVisualStyleBackColor = false;
      this.ButtonSchliessen.Click += new System.EventHandler(this.ButtonSchliessen_Click);
      // 
      // ButtonOrdnerOeffnen
      // 
      this.ButtonOrdnerOeffnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ButtonOrdnerOeffnen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.ButtonOrdnerOeffnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ButtonOrdnerOeffnen.Location = new System.Drawing.Point(109, 301);
      this.ButtonOrdnerOeffnen.Name = "ButtonOrdnerOeffnen";
      this.ButtonOrdnerOeffnen.Size = new System.Drawing.Size(101, 28);
      this.ButtonOrdnerOeffnen.TabIndex = 2;
      this.ButtonOrdnerOeffnen.Text = "Ordner öffnen";
      this.ButtonOrdnerOeffnen.UseVisualStyleBackColor = false;
      this.ButtonOrdnerOeffnen.Click += new System.EventHandler(this.ButtonOrdnerOeffnen_Click);
      // 
      // FormLocalCache
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.CancelButton = this.ButtonSchliessen;
      this.ClientSize = new System.Drawing.Size(434, 341);
      this.Controls.Add(this.ButtonOrdnerOeffnen);
      this.Controls.Add(this.ButtonSchliessen);
      this.Controls.Add(this.ButtonCacheLeeren);
      this.Controls.Add(this.DataGridViewExport);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(450, 380);
      this.Name = "FormLocalCache";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Star Citizen Handle Query - Lokaler Cache";
      this.Load += new System.EventHandler(this.FormExport_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewExport)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DataGridView DataGridViewExport;
    private Button ButtonCacheLeeren;
    private DataGridViewTextBoxColumn ColumnCacheDatum;
    private DataGridViewLinkColumn ColumnHandle;
    private DataGridViewLinkColumn ColumnOrganisation;
    private Button ButtonSchliessen;
    private Button ButtonOrdnerOeffnen;
  }
}