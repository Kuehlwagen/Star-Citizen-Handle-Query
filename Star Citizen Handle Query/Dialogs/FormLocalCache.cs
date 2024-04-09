using SCHQ_Shared.Protos;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
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
        [true]);
      ColumnCacheDatum.DefaultCellStyle.Format = "G";
      ColumnEnlisted.DefaultCellStyle.Format = "d";

      DataGridViewLokalerCache.PerformLayout();
      List<DataGridViewRow> rows = [];
      FormHandleQuery.CreateDirectory(FormHandleQuery.CacheDirectoryType.Handle);
      foreach (string handleJsonPath in Directory.GetFiles(FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Handle), "*.json").OrderByDescending(x => new FileInfo(x).LastWriteTime)) {
        HandleInfo handleInfo = JsonSerializer.Deserialize<HandleInfo>(File.ReadAllText(handleJsonPath, Encoding.UTF8));
        if (handleInfo != null) {
          handleInfo.HttpResponse = new() {
            StatusCode = HttpStatusCode.OK
          };
          DataGridViewRow row = new();
          OrganizationInfo org = handleInfo?.Organizations.MainOrganization;
          List<object> info = [
            new FileInfo(handleJsonPath).LastWriteTime,
            handleInfo.Profile.Handle,
            handleInfo.Profile.CommunityMonicker,
            handleInfo.Profile.Enlisted,
            handleInfo.Profile.UeeCitizenRecord,
            org?.Name,
            org?.RankStars,
            handleInfo.Organizations.Affiliations?.Count ?? 0,
            $"{(int)handleInfo.Relation}-{handleInfo.Relation}",
            handleInfo?.Comment ?? string.Empty
          ];
          row.Tag = handleInfo;
          row.CreateCells(DataGridViewLokalerCache, [.. info]);
          if (handleInfo.Organizations.MainOrganization?.Redacted == true) {
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
        DataGridViewLokalerCache.Rows.AddRange([.. rows]);
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
          case 9: // Kommentar
            DataGridViewRow dgvr = (sender as DataGridView).Rows[e.RowIndex];
            HandleInfo handleInfo = (dgvr.Tag as HandleInfo);
            string cellValue = $"{dgvr.Cells[e.ColumnIndex].Value}";
            handleInfo.Comment = !string.IsNullOrWhiteSpace(cellValue) ? cellValue : null;
            UserControlHandle.CreateHandleJSON(handleInfo, ProgramSettings, forceExport: true);
            break;
        }
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
              Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{(dgvr.Tag as HandleInfo).Organizations.MainOrganization.Sid}");
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
      ColumnRelation.HeaderText = ProgramTranslation.Local_Cache.Columns.Relation;
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
      DisposeUserControls();
      if (dgv.SelectedRows.Count > 0) {
        if (dgv.SelectedRows[0].Tag is HandleInfo handleInfo) {
          PanelInfo.Controls.Add(new UserControlHandle(handleInfo, ProgramSettings, ProgramTranslation, false, true));
          PanelInfo.Controls[0].Margin = new Padding(0, 0, 50, 0);
          if (handleInfo?.Organizations?.MainOrganization != null) {
            PanelInfo.Controls.Add(new UserControlOrganization(handleInfo.Organizations.MainOrganization, ProgramSettings, true, false, true));
          }
        }
      }
    }

    private void DisposeUserControls() {
      if (PanelInfo.Controls.Count > 0) {
        for (int i = PanelInfo.Controls.Count - 1; i >= 0; i--) {
          Control control = PanelInfo.Controls[i];
          if (control is UserControlHandle ctrlHandle) {
            ctrlHandle.PictureBoxHandleAvatar.Image?.Dispose();
            ctrlHandle.PictureBoxHandleAvatar.Image = null;
            ctrlHandle.PictureBoxDisplayTitle.Image?.Dispose();
            ctrlHandle.PictureBoxDisplayTitle.Image = null;
            ctrlHandle.Dispose();
          } else if (control is UserControlOrganization ctrlOrganization) {
            ctrlOrganization.PictureBoxOrganization.Image?.Dispose();
            ctrlOrganization.PictureBoxOrganization.Image = null;
            ctrlOrganization.PictureBoxOrganizationRank.Image?.Dispose();
            ctrlOrganization.PictureBoxOrganizationRank.Image = null;
            ctrlOrganization.Dispose();
          }
        }
        PanelInfo.Controls.Clear();
      }
    }

    private void FormLocalCache_FormClosing(object sender, FormClosingEventArgs e) {
      DisposeUserControls();
    }

    private void DataGridViewLokalerCache_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (e.RowIndex > -1 && e.ColumnIndex == 8) {
        string[] values = $"{e.Value}".Split("-");
        if (values?.Length == 2 && Enum.TryParse(values[0], out RelationValue value)) {
          e.CellStyle.BackColor = FormHandleQuery.GetRelationColor(value);
          e.CellStyle.ForeColor = value > 0 ? Color.FromArgb(19, 26, 33) : ForeColor;
          e.Value = GetTranslatedRelationText(ProgramTranslation, value);
          e.FormattingApplied = true;
        }
      }
    }

    public static string GetTranslatedRelationText(Translation translation, RelationValue relation) {
      string translationText = $"{relation}";

      switch (relation) {
        case RelationValue.NotAssigned:
          translationText = translation.Local_Cache.Relation.Not_Assigned;
          break;
        case RelationValue.Friendly:
          translationText = translation.Local_Cache.Relation.Friendly;
          break;
        case RelationValue.Neutral:
          translationText = translation.Local_Cache.Relation.Neutral;
          break;
        case RelationValue.Bogey:
          translationText = translation.Local_Cache.Relation.Bogey;
          break;
        case RelationValue.Bandit:
          translationText = translation.Local_Cache.Relation.Bandit;
          break;
      }

      return translationText;
    }

  }

}
