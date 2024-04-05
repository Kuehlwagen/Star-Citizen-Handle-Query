namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormEditRpcChannels {
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
      DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditRpcChannels));
      ButtonLoadChannels = new Button();
      ButtonClose = new Button();
      DataGridViewChannels = new DataGridView();
      ColumnChannelName = new DataGridViewTextBoxColumn();
      ColumnHasPassword = new DataGridViewCheckBoxColumn();
      ColumnPasswort = new DataGridViewTextBoxColumn();
      ColumnDeleteChannel = new DataGridViewButtonColumn();
      ButtonOK = new Button();
      TextBoxNewChannelName = new TextBox();
      TextBoxNewChannelPassword = new TextBox();
      ButtonCreateChannel = new Button();
      GroupBoxCreateChannel = new GroupBox();
      ((System.ComponentModel.ISupportInitialize)DataGridViewChannels).BeginInit();
      GroupBoxCreateChannel.SuspendLayout();
      SuspendLayout();
      // 
      // ButtonLoadChannels
      // 
      ButtonLoadChannels.FlatStyle = FlatStyle.Flat;
      ButtonLoadChannels.Location = new Point(12, 12);
      ButtonLoadChannels.Name = "ButtonLoadChannels";
      ButtonLoadChannels.Size = new Size(115, 28);
      ButtonLoadChannels.TabIndex = 0;
      ButtonLoadChannels.Text = "Kanäle laden";
      ButtonLoadChannels.UseVisualStyleBackColor = true;
      ButtonLoadChannels.Click += ButtonLoadChannels_Click;
      // 
      // ButtonClose
      // 
      ButtonClose.FlatStyle = FlatStyle.Flat;
      ButtonClose.Location = new Point(93, 444);
      ButtonClose.Name = "ButtonClose";
      ButtonClose.Size = new Size(75, 28);
      ButtonClose.TabIndex = 4;
      ButtonClose.Text = "Schließen";
      ButtonClose.UseVisualStyleBackColor = true;
      ButtonClose.Click += ButtonClose_Click;
      // 
      // DataGridViewChannels
      // 
      DataGridViewChannels.AllowUserToAddRows = false;
      DataGridViewChannels.AllowUserToDeleteRows = false;
      DataGridViewChannels.AllowUserToResizeColumns = false;
      DataGridViewChannels.AllowUserToResizeRows = false;
      DataGridViewChannels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      DataGridViewChannels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      DataGridViewChannels.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      DataGridViewChannels.BackgroundColor = Color.FromArgb(19, 26, 33);
      DataGridViewChannels.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      DataGridViewChannels.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      dataGridViewCellStyle1.ForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
      DataGridViewChannels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      DataGridViewChannels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      DataGridViewChannels.Columns.AddRange(new DataGridViewColumn[] { ColumnChannelName, ColumnHasPassword, ColumnPasswort, ColumnDeleteChannel });
      dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
      dataGridViewCellStyle4.ForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
      DataGridViewChannels.DefaultCellStyle = dataGridViewCellStyle4;
      DataGridViewChannels.EnableHeadersVisualStyles = false;
      DataGridViewChannels.Location = new Point(12, 46);
      DataGridViewChannels.MultiSelect = false;
      DataGridViewChannels.Name = "DataGridViewChannels";
      DataGridViewChannels.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      DataGridViewChannels.RowHeadersVisible = false;
      DataGridViewChannels.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      DataGridViewChannels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      DataGridViewChannels.ShowEditingIcon = false;
      DataGridViewChannels.Size = new Size(440, 315);
      DataGridViewChannels.TabIndex = 1;
      DataGridViewChannels.CellContentClick += DataGridViewChannels_CellContentClick;
      DataGridViewChannels.CellContentDoubleClick += DataGridViewChannels_CellContentDoubleClick;
      DataGridViewChannels.CellEndEdit += DataGridViewChannels_CellEndEdit;
      DataGridViewChannels.CellFormatting += DataGridViewChannels_CellFormatting;
      DataGridViewChannels.SelectionChanged += DataGridViewChannels_SelectionChanged;
      // 
      // ColumnChannelName
      // 
      ColumnChannelName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnChannelName.HeaderText = "Kanalname";
      ColumnChannelName.Name = "ColumnChannelName";
      ColumnChannelName.ReadOnly = true;
      ColumnChannelName.Width = 92;
      // 
      // ColumnHasPassword
      // 
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.ForeColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle2.NullValue = false;
      dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(19, 26, 33);
      ColumnHasPassword.DefaultCellStyle = dataGridViewCellStyle2;
      ColumnHasPassword.FlatStyle = FlatStyle.Popup;
      ColumnHasPassword.HeaderText = "Gesichert";
      ColumnHasPassword.Name = "ColumnHasPassword";
      ColumnHasPassword.ReadOnly = true;
      ColumnHasPassword.SortMode = DataGridViewColumnSortMode.Automatic;
      ColumnHasPassword.Width = 85;
      // 
      // ColumnPasswort
      // 
      ColumnPasswort.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      ColumnPasswort.HeaderText = "Passwort";
      ColumnPasswort.Name = "ColumnPasswort";
      ColumnPasswort.SortMode = DataGridViewColumnSortMode.NotSortable;
      ColumnPasswort.Width = 62;
      // 
      // ColumnDeleteChannel
      // 
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.BackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle3.ForeColor = Color.FromArgb(57, 206, 216);
      dataGridViewCellStyle3.NullValue = "Löschen";
      dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(19, 26, 33);
      dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(57, 206, 216);
      ColumnDeleteChannel.DefaultCellStyle = dataGridViewCellStyle3;
      ColumnDeleteChannel.FlatStyle = FlatStyle.Flat;
      ColumnDeleteChannel.HeaderText = "Löschen";
      ColumnDeleteChannel.Name = "ColumnDeleteChannel";
      ColumnDeleteChannel.UseColumnTextForButtonValue = true;
      ColumnDeleteChannel.Width = 57;
      // 
      // ButtonOK
      // 
      ButtonOK.Enabled = false;
      ButtonOK.FlatStyle = FlatStyle.Flat;
      ButtonOK.Location = new Point(12, 444);
      ButtonOK.Name = "ButtonOK";
      ButtonOK.Size = new Size(75, 28);
      ButtonOK.TabIndex = 3;
      ButtonOK.Text = "OK";
      ButtonOK.UseVisualStyleBackColor = true;
      ButtonOK.Click += ButtonOK_Click;
      // 
      // TextBoxNewChannelName
      // 
      TextBoxNewChannelName.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxNewChannelName.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxNewChannelName.Location = new Point(6, 26);
      TextBoxNewChannelName.Name = "TextBoxNewChannelName";
      TextBoxNewChannelName.PlaceholderText = "Kanal-Name";
      TextBoxNewChannelName.Size = new Size(160, 23);
      TextBoxNewChannelName.TabIndex = 0;
      TextBoxNewChannelName.TextChanged += TextBoxNewChannelName_TextChanged;
      // 
      // TextBoxNewChannelPassword
      // 
      TextBoxNewChannelPassword.BackColor = Color.FromArgb(57, 206, 216);
      TextBoxNewChannelPassword.ForeColor = Color.FromArgb(19, 26, 33);
      TextBoxNewChannelPassword.Location = new Point(172, 26);
      TextBoxNewChannelPassword.Name = "TextBoxNewChannelPassword";
      TextBoxNewChannelPassword.PasswordChar = '*';
      TextBoxNewChannelPassword.PlaceholderText = "Kanal-Passwort";
      TextBoxNewChannelPassword.Size = new Size(144, 23);
      TextBoxNewChannelPassword.TabIndex = 1;
      // 
      // ButtonCreateChannel
      // 
      ButtonCreateChannel.Enabled = false;
      ButtonCreateChannel.FlatStyle = FlatStyle.Flat;
      ButtonCreateChannel.Location = new Point(322, 22);
      ButtonCreateChannel.Name = "ButtonCreateChannel";
      ButtonCreateChannel.Size = new Size(111, 28);
      ButtonCreateChannel.TabIndex = 2;
      ButtonCreateChannel.Text = "Kanal erstellen";
      ButtonCreateChannel.UseVisualStyleBackColor = true;
      ButtonCreateChannel.Click += ButtonCreateChannel_Click;
      // 
      // GroupBoxCreateChannel
      // 
      GroupBoxCreateChannel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      GroupBoxCreateChannel.Controls.Add(TextBoxNewChannelName);
      GroupBoxCreateChannel.Controls.Add(TextBoxNewChannelPassword);
      GroupBoxCreateChannel.Controls.Add(ButtonCreateChannel);
      GroupBoxCreateChannel.FlatStyle = FlatStyle.Flat;
      GroupBoxCreateChannel.ForeColor = Color.FromArgb(57, 206, 216);
      GroupBoxCreateChannel.Location = new Point(13, 367);
      GroupBoxCreateChannel.Name = "GroupBoxCreateChannel";
      GroupBoxCreateChannel.Size = new Size(439, 67);
      GroupBoxCreateChannel.TabIndex = 2;
      GroupBoxCreateChannel.TabStop = false;
      GroupBoxCreateChannel.Text = "Kanal erstellen";
      // 
      // FormEditRpcChannels
      // 
      AcceptButton = ButtonOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      CancelButton = ButtonClose;
      ClientSize = new Size(464, 484);
      Controls.Add(GroupBoxCreateChannel);
      Controls.Add(DataGridViewChannels);
      Controls.Add(ButtonOK);
      Controls.Add(ButtonClose);
      Controls.Add(ButtonLoadChannels);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MinimumSize = new Size(480, 523);
      Name = "FormEditRpcChannels";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "SCHQ_Server gRPC Kanalverwaltung";
      Load += FormEditRpcChannels_Load;
      Shown += FormEditRpcChannels_Shown;
      ((System.ComponentModel.ISupportInitialize)DataGridViewChannels).EndInit();
      GroupBoxCreateChannel.ResumeLayout(false);
      GroupBoxCreateChannel.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Button ButtonLoadChannels;
    private Button ButtonClose;
    private DataGridView DataGridViewChannels;
    private Button ButtonOK;
    private TextBox TextBoxNewChannelName;
    private TextBox TextBoxNewChannelPassword;
    private Button ButtonCreateChannel;
    private GroupBox GroupBoxCreateChannel;
    private DataGridViewTextBoxColumn ColumnChannelName;
    private DataGridViewCheckBoxColumn ColumnHasPassword;
    private DataGridViewTextBoxColumn ColumnPasswort;
    private DataGridViewButtonColumn ColumnDeleteChannel;
  }
}