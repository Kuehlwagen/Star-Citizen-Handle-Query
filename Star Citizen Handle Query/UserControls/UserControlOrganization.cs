using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlOrganization : UserControl {

    private readonly ApiHandleInfoDataOrganization OrganizationInfo;
    private readonly Settings ProgramSettings;
    private readonly bool IsMainOrg;
    private string SID;
    private readonly bool ForceLive;
    private readonly bool DisplayOnly;

    public UserControlOrganization(ApiHandleInfoDataOrganization organizationInfo, Settings programSettings, bool isMainOrg, bool forceLive, bool displayOnly = false) {
      InitializeComponent();
      OrganizationInfo = organizationInfo;
      ProgramSettings = programSettings;
      IsMainOrg = isMainOrg;
      ForceLive = forceLive;
      DisplayOnly = displayOnly;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      LabelMainOrganizationAffiliate.Text = IsMainOrg ? "Main Organization" : "Affiliation";
      string organizationSid = GetString(OrganizationInfo?.sid);
      SID = organizationSid;
      if ((IsMainOrg &&  OrganizationInfo?.name != string.Empty) || (!IsMainOrg && !string.IsNullOrWhiteSpace(organizationSid))) {
        LabelOrganizationName.Text = GetString(OrganizationInfo?.name);
        LabelOrganizationSID.Text = GetString(organizationSid, "SID: ");
        LabelOrganizationRank.Text = GetString(OrganizationInfo?.rank);
        if (!string.IsNullOrWhiteSpace(OrganizationInfo?.image)) {
          PictureBoxOrganization.Image = await GetImage(CacheDirectoryType.OrganizationAvatar, OrganizationInfo.image, organizationSid, ProgramSettings.LocalCacheMaxAge, ForceLive);
          if (!DisplayOnly) {
            PictureBoxOrganization.Cursor = Cursors.Hand;
          } else {
            PictureBoxOrganization.Click -= PictureBoxOrganization_Click;
          }
        }
        if (OrganizationInfo?.sid != null && OrganizationInfo?.stars >= 0 && OrganizationInfo.stars <= 5) {
          PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{OrganizationInfo.stars}") as Image;
        }
        if (IsMainOrg) {
          ApiOrganizationInfo orgInfo = await GetApiInfo<ApiOrganizationInfo>(ForceLive, SID, ProgramSettings, CacheDirectoryType.Organization);
          if (orgInfo?.success == 1) {
            CreateOrganizationJSON(organizationSid, orgInfo);
            LabelMainOrganizationAffiliate.Text = $"{orgInfo.data.commitment} / {orgInfo.data.members:n0}";
            LabelFocusPrimary.Text = GetString(orgInfo.data.focus.primary.name);
            LabelFocusSecondary.Text = GetString(orgInfo.data.focus.secondary.name);
            if (!string.IsNullOrWhiteSpace(orgInfo.data.focus?.primary?.image)) {
              PictureBoxFocus1.Image = await GetImage(CacheDirectoryType.OrganizationFocus, orgInfo.data.focus.primary.image, orgInfo.data.focus.primary.name, ProgramSettings.LocalCacheMaxAge);
            }
            if (!string.IsNullOrWhiteSpace(orgInfo.data.focus?.secondary?.image)) {
              PictureBoxFocus2.Image = await GetImage(CacheDirectoryType.OrganizationFocus, orgInfo.data.focus.secondary.image, orgInfo.data.focus.secondary.name, ProgramSettings.LocalCacheMaxAge);
            }
          }
        }
      } else {
        BackColor = Color.FromArgb(33, 26, 19);
        PictureBoxOrganization.Size = new Size(PictureBoxOrganization.Width, 19);
        PictureBoxOrganization.Image = Properties.Resources.Redacted_Small;
        LabelOrganizationName.ForeColor = Color.FromArgb(255, 57, 57);
        LabelOrganizationName.Text = "REDACTED";
        LabelMainOrganizationAffiliate.ForeColor = Color.FromArgb(173, 39, 39);
        PictureBoxOrganization.Click -= PictureBoxOrganization_Click;
        Size = new Size(Size.Width, 25);
      }
    }

    private void CreateOrganizationJSON(string organizationSid, ApiOrganizationInfo orgInfo) {
      string jsonPath = GetCachePath(CacheDirectoryType.Organization, organizationSid);
      if (ForceLive || !File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        string organizationJson = JsonSerializer.Serialize(orgInfo, new JsonSerializerOptions() { WriteIndented = true });
        if (!string.IsNullOrWhiteSpace(organizationJson)) {
          File.WriteAllText(jsonPath, organizationJson, Encoding.UTF8);
        }
      }
    }

    private void PictureBoxOrganization_Click(object sender, EventArgs e) {
      if (!string.IsNullOrWhiteSpace(SID)) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{SID}");
      }
    }

  }

}
