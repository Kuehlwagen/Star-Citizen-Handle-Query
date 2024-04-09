using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.gRPC;
using Star_Citizen_Handle_Query.Serialization;
using System.Reflection;

namespace Star_Citizen_Handle_Query.Dialogs;
public partial class FormEditRpcChannels : Form {

  private readonly Settings ProgramSettings;
  private readonly Translation ProgramTranslation;

  public string SelectedChannel { get; set; } = string.Empty;
  public string SelectedPassword { get; set; } = string.Empty;

  public FormEditRpcChannels(Settings settings, Translation translation) {
    InitializeComponent();
    ProgramSettings = settings;
    ProgramTranslation = translation;
  }

  private void FormEditRpcChannels_Load(object sender, EventArgs e) {
    RPC_Wrapper.SetURL(ProgramSettings.Relations.RPC_URL);

    UpdateLocalization();

    typeof(DataGridView).InvokeMember(
      "DoubleBuffered",
      BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
      null,
      DataGridViewChannels,
      [true]);

    ComboBoxNewChannelPermissions.SelectedIndex = 0;
  }

  private void FormEditRpcChannels_Shown(object sender, EventArgs e) {
    LoadChannels();
  }

  private void UpdateLocalization() {
    PerformLayout();

    Text = $"SCHQ_Server {ProgramTranslation.Settings.Relations.RPC_Channels.Title} - {ProgramSettings.Relations.RPC_URL}";
    ButtonLoadChannels.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_Load_Channels;
    ButtonClose.Text = ProgramTranslation.Settings.Buttons.Close;
    ColumnChannelName.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Name;
    ColumnHasPassword.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Secured;
    ColumnPermissions.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Permissions;
    ColumnPasswort.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Password;
    ColumnDeleteChannel.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Delete;
    ColumnDeleteChannel.DefaultCellStyle.NullValue = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Delete;
    ButtonOK.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_OK;
    GroupBoxCreateChannel.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_Create_Channel;
    TextBoxNewChannelName.PlaceholderText = ProgramTranslation.Settings.Relations.RPC_Channels.New_Channel_Name_Placeholder;
    TextBoxNewChannelPassword.PlaceholderText = ProgramTranslation.Settings.Relations.RPC_Channels.New_Channel_Password_Placeholder;
    ButtonCreateChannel.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_Create_Channel;
    LabelNewChannelPermissions.Text = $"{ProgramTranslation.Settings.Relations.RPC_Channels.Permissions}:";
    ComboBoxNewChannelPermissions.Items.AddRange([ProgramTranslation.Settings.Relations.RPC_Channels.Permission_None, ProgramTranslation.Settings.Relations.RPC_Channels.Permission_Read,
      ProgramTranslation.Settings.Relations.RPC_Channels.Permission_Write]);

    ResumeLayout();
  }

  private void ButtonLoadChannels_Click(object sender, EventArgs e) {
    LoadChannels(true);
  }

  private void LoadChannels(bool withMessageBox = false) {
    EnableControls(false);
    DataGridViewChannels.PerformLayout();
    DataGridViewChannels.Rows.Clear();
    var channelInfos = Task.Run(RPC_Wrapper.GetChannels).Result;
    if (channelInfos?.Count > 0) {
      foreach (ChannelInfo channelInfo in channelInfos) {
        DataGridViewChannels.Rows.Add(channelInfo.Name, channelInfo.HasPassword ? CheckState.Checked : CheckState.Unchecked,
          $"{ComboBoxNewChannelPermissions.Items[(int)channelInfo.Permissions]}", string.Empty, null);
      }
    } else if (withMessageBox) {
      MessageBox.Show(ProgramTranslation.Settings.Relations.RPC_Channels.No_Channels_Found, Text);
    }
    DataGridViewChannels.ResumeLayout();
    EnableControls();
  }

  private void DataGridViewChannels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
    if (e.RowIndex > -1 && e.ColumnIndex == 3 && e.Value?.ToString().Length > 0) {
      e.Value = string.Empty.PadLeft(e.Value.ToString().Length, '*');
      e.FormattingApplied = true;
    }
  }

  private void DataGridViewChannels_CellContentClick(object sender, DataGridViewCellEventArgs e) {
    var grid = (DataGridView)sender;
    if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1) {
      string channel = grid.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
      string password = grid.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;
      EnableControls(false);
      var deleted = Task.Run(() => RPC_Wrapper.DeleteChannel(channel, password)).Result;
      if (deleted) {
        DataGridViewChannels.Rows.RemoveAt(e.RowIndex);
      } else {
        MessageBox.Show(ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Not_Deleted, Text);
      }
      EnableControls();
    }
  }

  private void DataGridViewChannels_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex > -1 && e.ColumnIndex == 0) {
      DialogResult = DialogResult.OK;
    }
  }

  private void EnableControls(bool enable = true) {
    ButtonLoadChannels.Enabled = enable;
    DataGridViewChannels.Enabled = enable;
    ButtonCreateChannel.Enabled = enable && !string.IsNullOrWhiteSpace(TextBoxNewChannelName.Text);
    ButtonOK.Enabled = enable && DataGridViewChannels.SelectedRows?.Count > 0;
    ButtonClose.Enabled = enable;
    if (enable && DataGridViewChannels.SelectedRows?.Count > 0) {
      ButtonOK.Focus();
      ButtonOK.Select();
    } else {
      ButtonLoadChannels.Focus();
      ButtonLoadChannels.Select();
    }
  }

  private void DataGridViewChannels_SelectionChanged(object sender, EventArgs e) {
    DataGridView dgv = (DataGridView)sender;
    if (dgv.SelectedRows.Count > 0) {
      SelectedChannel = dgv.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
      SelectedPassword = dgv.SelectedRows[0].Cells[3].Value?.ToString() ?? string.Empty;
    }
  }

  private void DataGridViewChannels_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex > -1 && e.ColumnIndex == 3) {
      SelectedPassword = DataGridViewChannels.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? string.Empty;
    }
  }

  private void TextBoxNewChannelName_TextChanged(object sender, EventArgs e) {
    ButtonCreateChannel.Enabled = !string.IsNullOrWhiteSpace(TextBoxNewChannelName.Text);
  }

  private void ButtonCreateChannel_Click(object sender, EventArgs e) {
    EnableControls(false);
    var created = Task.Run(() => RPC_Wrapper.CreateChannel(TextBoxNewChannelName.Text, TextBoxNewChannelPassword.Text, (ChannelPermissions)ComboBoxNewChannelPermissions.SelectedIndex)).Result;
    if (created) {
      DataGridViewChannels.PerformLayout();
      int index = DataGridViewChannels.Rows.Add(TextBoxNewChannelName.Text, !string.IsNullOrWhiteSpace(TextBoxNewChannelPassword.Text) ? CheckState.Checked : CheckState.Unchecked,
        $"{ComboBoxNewChannelPermissions.Text}", TextBoxNewChannelPassword.Text, null);
      TextBoxNewChannelName.Clear();
      TextBoxNewChannelPassword.Clear();
      DataGridViewChannels.Rows[index].Selected = true;
      DataGridViewChannels.FirstDisplayedScrollingRowIndex = index;
      DataGridViewChannels.ResumeLayout();
    } else {
      MessageBox.Show(ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Not_Created);
    }
    EnableControls();
  }

  private void ButtonOK_Click(object sender, EventArgs e) {
    DialogResult = DialogResult.OK;
  }

  private void ButtonClose_Click(object sender, EventArgs e) {
    Close();
  }

}
