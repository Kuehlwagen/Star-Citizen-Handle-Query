using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.gRPC;
using Star_Citizen_Handle_Query.Serialization;
using System.Reflection;

namespace Star_Citizen_Handle_Query.Dialogs;
public partial class FormEditRpcChannels : Form {

  private readonly Settings ProgramSettings;
  private readonly Translation ProgramTranslation;

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

  private void UpdateLocalization() {
    PerformLayout();

    Text = $"SCHQ_Server {ProgramTranslation.Settings.Relations.RPC_Channels.Title} - {ProgramSettings.Relations.RPC_URL}";
    ButtonLoadChannels.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Load_Channels;
    ButtonClose.Text = ProgramTranslation.Settings.Buttons.Close;
    ColumnChannelName.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Name;
    ColumnHasPassword.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Secured;
    ColumnPasswort.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Password;
    ColumnDeleteChannel.HeaderText = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Delete;
    ColumnDeleteChannel.DefaultCellStyle.NullValue = ProgramTranslation.Settings.Relations.RPC_Channels.Channel_Delete;
    ButtonOK.Text = ProgramTranslation.Settings.Relations.RPC_Channels.Button_OK;

    ResumeLayout();
  }

  private void ButtonLoadChannels_Click(object sender, EventArgs e) {
    EnableControls(false);
    DataGridViewChannels.PerformLayout();
    DataGridViewChannels.Rows.Clear();
    var channelInfos = Task.Run(RPC_Wrapper.GetChannels).Result;
    if (channelInfos?.Count > 0) {
      foreach (ChannelInfo channelInfo in channelInfos) {
        DataGridViewChannels.Rows.Add(channelInfo.Name, channelInfo.HasPassword ? CheckState.Checked : CheckState.Unchecked, string.Empty, null);
      }
    }
    DataGridViewChannels.ResumeLayout();
    EnableControls();
  }

  private void DataGridViewChannels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
    if (e.RowIndex > -1 && e.ColumnIndex == 2 && e.Value?.ToString().Length > 0) {
      e.Value = string.Empty.PadLeft(e.Value.ToString().Length, '*');
      e.FormattingApplied = true;
    }
  }

  private void DataGridViewChannels_CellContentClick(object sender, DataGridViewCellEventArgs e) {
    var grid = (DataGridView)sender;
    if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1) {
      string channel = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
      string password = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
      EnableControls(false);
      var deleted = Task.Run(() => RPC_Wrapper.DeleteChannel(channel, password)).Result;
      if (deleted) {
        DataGridViewChannels.Rows.RemoveAt(e.RowIndex);
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
    ButtonOK.Enabled = enable && DataGridViewChannels.SelectedRows?.Count > 0;
    ButtonClose.Enabled = enable;
  }

  private void DataGridViewChannels_SelectionChanged(object sender, EventArgs e) {
    DataGridView dgv = (DataGridView)sender;
    if (dgv.SelectedRows.Count > 0) {
      SelectedChannel = dgv.SelectedRows[0].Cells[0].Value.ToString();
    }
  }

  private void ButtonOK_Click(object sender, EventArgs e) {
    DialogResult = DialogResult.OK;
  }

  private void ButtonClose_Click(object sender, EventArgs e) {
    Close();
  }

}
