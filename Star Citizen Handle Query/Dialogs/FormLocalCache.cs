using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLocalCache : Form {

    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;

    public FormLocalCache(Settings settings, Translation translation) {
      InitializeComponent();
      ProgramSettings = settings;
      ProgramTranslation = translation;
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
          if (info[2]?.ToString() == String.Empty) {
            row.Cells[2] = new DataGridViewTextBoxCell();
            row.Cells[2].Value = "REDACTED";
            row.Cells[2].Style.ForeColor = Color.FromArgb(255, 57, 57);
            row.Cells[2].Style.SelectionForeColor = Color.FromArgb(255, 57, 57);
          }
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
            if (dgvc is DataGridViewLinkCell) {
              Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{(dgvr.Tag as HandleInfo).data.organization.sid}");
            }
            break;
        }
      }
    }

    private void UpdateLocalization() {

      Text = $"Star Citizen Handle Query - {ProgramTranslation.Local_Cache.Title}";

      ColumnCacheDatum.HeaderText = ProgramTranslation.Local_Cache.Columns.Cache_Date;
      ColumnHandle.HeaderText = ProgramTranslation.Local_Cache.Columns.Handle;
      ColumnOrganisation.HeaderText = ProgramTranslation.Local_Cache.Columns.Organization;

      ButtonCacheLeeren.Text = ProgramTranslation.Local_Cache.Buttons.Clear_Cache;
      ButtonOrdnerOeffnen.Text = ProgramTranslation.Local_Cache.Buttons.Open_Folder;
      ButtonSchliessen.Text = ProgramTranslation.Local_Cache.Buttons.Close;

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

    private void DataGridViewExport_SelectionChanged(object sender, EventArgs e) {
      DataGridView dgv = sender as DataGridView;
      DisposeUserControlHandle();
      if (dgv.SelectedRows.Count > 0) {
        if (dgv.SelectedRows[0].Tag is HandleInfo handleInfo) {
          PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, false));
        }
      }
    }

    private void DisposeUserControlHandle() {
      if (PanelInfo.Controls.Count > 0) {
        if (PanelInfo.Controls[0] is UserControlHandle userControlHandle) {
          userControlHandle.PictureBoxHandleAvatar.Image?.Dispose();
          userControlHandle.PictureBoxHandleAvatar.Image = null;
          userControlHandle.PictureBoxDisplayTitle.Image?.Dispose();
          userControlHandle.PictureBoxDisplayTitle.Image = null;
          userControlHandle.Dispose();
        }
        PanelInfo.Controls.Clear();
      }
    }

    private void FormLocalCache_FormClosing(object sender, FormClosingEventArgs e) {
      DisposeUserControlHandle();
    }
  }

}
