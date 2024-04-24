using SCHQ_Protos;
using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Serialization;
using System.Reflection;

namespace Star_Citizen_Handle_Query.Dialogs;
public partial class FormEditRpcChannels : Form {

  private readonly Settings ProgramSettings;
  private readonly Translation ProgramTranslation;
  private readonly List<string> ChannelPermissions = [];

  public string SelectedChannel { get; set; } = string.Empty;

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
    ButtonOK.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_OK;
    ChannelPermissions.AddRange([ProgramTranslation.Settings.Relations.RPC_Channels.Permission_None, ProgramTranslation.Settings.Relations.RPC_Channels.Permission_Read,
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
          ChannelPermissions[(int)channelInfo.Permissions], string.Empty, null);
      }
    } else if (withMessageBox) {
      MessageBox.Show(ProgramTranslation.Settings.Relations.RPC_Channels.No_Channels_Found, Text);
    }
    DataGridViewChannels.ResumeLayout();
    EnableControls();
  }

  private void DataGridViewChannels_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex > -1) {
      DialogResult = DialogResult.OK;
    }
  }

  private void EnableControls(bool enable = true) {
    ButtonLoadChannels.Enabled = enable;
    DataGridViewChannels.Enabled = enable;
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
    }
  }

  private void ButtonOK_Click(object sender, EventArgs e) {
    DialogResult = DialogResult.OK;
  }

  private void ButtonClose_Click(object sender, EventArgs e) {
    Close();
  }

}
