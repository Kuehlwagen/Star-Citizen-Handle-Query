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
        DataGridViewLokalerCache,
        new object[] { true });
      ColumnCacheDatum.DefaultCellStyle.Format = "G";
      ColumnEnlisted.DefaultCellStyle.Format = "d";

      DataGridViewLokalerCache.PerformLayout();
      List<DataGridViewRow> rows = new();
      FormHandleQuery.CreateDirectory(FormHandleQuery.CacheDirectoryType.Handle);
      FormHandleQuery.CreateDirectory(FormHandleQuery.CacheDirectoryType.HandleAdditional);
      foreach (string handleJsonPath in Directory.GetFiles(FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Handle), "*.json").OrderByDescending(x => new FileInfo(x).LastWriteTime)) {
        HandleInfo handleInfo = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
        if (handleInfo?.data != null) {
          HandleAdditionalInfo handleAdditionalInfo = null;
          string additionalInfoPath = FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.HandleAdditional, handleInfo.data.profile.handle);
          if (File.Exists(additionalInfoPath)) {
            handleAdditionalInfo = JsonSerializer.Deserialize<HandleAdditionalInfo>(File.ReadAllText(FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.HandleAdditional, handleInfo.data.profile.handle), Encoding.UTF8));
          }
          DataGridViewRow row = new();
          HandleInfoDataOrganization org = handleInfo?.data?.organization;
          List<object> info = new() {
            new FileInfo(handleJsonPath).LastWriteTime,
            handleInfo.data.profile.handle,
            handleInfo.data.profile.display,
            handleInfo.data.profile.enlisted,
            handleInfo.data.profile.id,
            org?.name,
            org?.stars,
            handleInfo?.data?.affiliation?.Length,
            handleAdditionalInfo?.Comment ?? string.Empty
          };
          row.Tag = handleInfo;
          row.CreateCells(DataGridViewLokalerCache, info.ToArray());
          if (info[5]?.ToString() == string.Empty) {
#pragma warning disable IDE0017 // Initialisierung von Objekten vereinfachen
            row.Cells[5] = new DataGridViewTextBoxCell();
#pragma warning restore IDE0017 // Initialisierung von Objekten vereinfachen
            row.Cells[5].Value = "REDACTED";
            row.Cells[5].Style.ForeColor = Color.FromArgb(255, 57, 57);
            row.Cells[5].Style.SelectionForeColor = Color.FromArgb(255, 57, 57);
          }
          rows.Add(row);
        }
      }
      if (rows.Count > 0) {
        DataGridViewLokalerCache.Rows.AddRange(rows.ToArray());
        DataGridViewLokalerCache.Sort(ColumnCacheDatum, ListSortDirection.Descending);
        DataGridViewLokalerCache.ClearSelection();
        DataGridViewLokalerCache.Rows[0].Selected = true;
      }
      DataGridViewLokalerCache.CellValueChanged += DataGridViewExport_CellValueChanged;
      DataGridViewLokalerCache.ResumeLayout();
    }

    private void DataGridViewExport_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex > -1 && e.ColumnIndex > -1) {
        switch (e.ColumnIndex) {
          case 8: // Kommentar
            DataGridViewRow dgvr = (sender as DataGridView).Rows[e.RowIndex];
            WriteHandleAdditionalInformation((dgvr.Tag as HandleInfo).data.profile.handle, $"{dgvr.Cells[e.ColumnIndex].Value}");
            break;
        }
      }
    }

    public static void WriteHandleAdditionalInformation(string handle, string additionalInfo) {
      string additionalPath = FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.HandleAdditional, handle);
      if (!string.IsNullOrWhiteSpace(additionalInfo)) {
        File.WriteAllText(additionalPath, JsonSerializer.Serialize(new HandleAdditionalInfo() { Comment = $"{additionalInfo}" },
          new JsonSerializerOptions() { WriteIndented = true }), Encoding.UTF8);
      } else if (File.Exists(additionalPath)) {
        File.Delete(additionalPath);
      }
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
          case 5: // Org Name
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
      ColumnCommunityMoniker.HeaderText = ProgramTranslation.Local_Cache.Columns.Community_Moniker;
      ColumnEnlisted.HeaderText = ProgramTranslation.Local_Cache.Columns.Enlisted;
      ColumnUEECitizenRecord.HeaderText = ProgramTranslation.Local_Cache.Columns.UEE_Citizen_Record;
      ColumnOrganisation.HeaderText = ProgramTranslation.Local_Cache.Columns.Organization;
      ColumnOrganisationRang.HeaderText = ProgramTranslation.Local_Cache.Columns.Organization_Rank;
      ColumnAnzahlAffiliationen.HeaderText = ProgramTranslation.Local_Cache.Columns.Affiliation_Count;
      ColumnKommentar.HeaderText = ProgramTranslation.Local_Cache.Columns.Comment;

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
          PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, false, true));
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
