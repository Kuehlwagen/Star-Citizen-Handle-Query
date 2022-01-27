using Star_Citizen_Handle_Query.Serialization;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLocalCache : Form {

    private readonly Translation Translation;

    public FormLocalCache(Translation translation) {
      InitializeComponent();
      Translation = translation;
    }

    private void FormExport_Load(object sender, EventArgs e) {

      UpdateLocalization();

      typeof(DataGridView).InvokeMember(
        "DoubleBuffered",
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        null,
        DataGridViewExport,
        new object[] { true });
      ColumnCacheDatum.DefaultCellStyle.Format = "G";

      DataGridViewExport.PerformLayout();
      List<DataGridViewRow> rows = new();
      FormHandleQuery.CreateDirectory(FormHandleQuery.CacheDirectoryType.Handle);
      foreach (string handleJsonPath in Directory.GetFiles(FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Handle), "*.json").OrderByDescending(x => new FileInfo(x).LastWriteTime)) {
        HandleInfo handleInfo = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
        if (handleInfo != null) {
          DataGridViewRow row = new();
          HandleInfoDataOrganization org = handleInfo?.data?.organization;
          List<object> info = new() {
            new FileInfo(handleJsonPath).LastWriteTime,
            handleInfo.data.profile.handle,
            org?.name
          };
          row.Tag = handleInfo;
          row.CreateCells(DataGridViewExport, info.ToArray());
          rows.Add(row);
        }
      }
      if (rows.Count > 0) {
        DataGridViewExport.Rows.AddRange(rows.ToArray());
        DataGridViewExport.Sort(ColumnCacheDatum, ListSortDirection.Descending);
        DataGridViewExport.ClearSelection();
        DataGridViewExport.Rows[0].Selected = true;
      }
      DataGridViewExport.ResumeLayout();
    }

    private void DataGridViewExport_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      DataGridView dgv = sender as DataGridView;
      if (e.RowIndex > -1 && e.ColumnIndex > -1) {
        DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
        DataGridViewCell dgvc = dgvr.Cells[e.ColumnIndex];
        switch (e.ColumnIndex) {
          case 1: // Handle
            Process.Start("explorer", $"https://robertsspaceindustries.com/citizens/{dgvc.Value}");
            break;
          case 2: // Org Name
            Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{(dgvr.Tag as HandleInfo).data.organization.sid}");
            break;
        }
      }
    }

    private void UpdateLocalization() {

      Text = $"Star Citizen Handle Query - {Translation.Local_Cache.Title}";

      ColumnCacheDatum.HeaderText = Translation.Local_Cache.Columns.Cache_Date;
      ColumnHandle.HeaderText = Translation.Local_Cache.Columns.Handle;
      ColumnOrganisation.HeaderText = Translation.Local_Cache.Columns.Organization;

      ButtonCacheLeeren.Text = Translation.Local_Cache.Buttons.Clear_Cache;
      ButtonOrdnerOeffnen.Text = Translation.Local_Cache.Buttons.Open_Folder;
      ButtonSchliessen.Text = Translation.Local_Cache.Buttons.Close;

    }

    private void ButtonCacheLeeren_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Yes;
      Close();
    }

    private void ButtonOrdnerOeffnen_Click(object sender, EventArgs e) {
      Process.Start("explorer", FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Root));
    }

    private void ButtonSchliessen_Click(object sender, EventArgs e) {
      Close();
    }

  }

}
