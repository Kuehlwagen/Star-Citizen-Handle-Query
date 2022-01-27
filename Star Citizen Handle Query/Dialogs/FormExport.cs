using Star_Citizen_Handle_Query.Serialization;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormExport : Form {

    public FormExport() {
      InitializeComponent();
    }

    private void FormExport_Load(object sender, EventArgs e) {

      typeof(DataGridView).InvokeMember(
        "DoubleBuffered",
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        null,
        DataGridViewExport,
        new object[] { true });
      ColumnCachedLocal.DefaultCellStyle.Format = "G";
      ColumnEnlisted.DefaultCellStyle.Format = "d";

      DataGridViewExport.PerformLayout();
      foreach (string handleJsonPath in Directory.GetFiles(FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Handle), "*.json")) {
        HandleInfo handleInfo = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
        if (handleInfo != null) {
          HandleInfoDataOrganization org = handleInfo?.data?.organization;
          List<object> info = new() {
            new FileInfo(handleJsonPath).LastWriteTime,
            handleInfo.data.profile.handle,
            handleInfo.data.profile.display,
            handleInfo.data.profile.badge,
            string.Join(", ", handleInfo.data.profile.fluency),
            handleInfo.data.profile.id,
            handleInfo.data.profile.enlisted,
            handleInfo.data.profile.enlisted
          };
          if (!string.IsNullOrWhiteSpace(org?.sid)) {
            info.Add(org.sid);
            info.Add(org.name);
            info.Add(org.rank);
            info.Add(org.stars);
          }
          DataGridViewExport.Rows.Add(info.ToArray());
        }
      }
      if (DataGridViewExport.Rows.Count > 0) {
        DataGridViewExport.Sort(ColumnCachedLocal, ListSortDirection.Descending);
        DataGridViewExport.ClearSelection();
        DataGridViewExport.Rows[0].Selected = true;
      }
      DataGridViewExport.ResumeLayout();
    }
  }

}
