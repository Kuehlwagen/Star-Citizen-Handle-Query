using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlOrganization : UserControl {

    private readonly HandleInfoDataOrganization OrganizationInfo;
    private readonly Settings ProgramSettings;
    private readonly bool IsMainOrg;
    private string SID;
    private readonly bool ForceLive;
    private readonly bool DisplayOnly;

    public UserControlOrganization(HandleInfoDataOrganization organizationInfo, Settings programSettings, bool isMainOrg, bool forceLive, bool displayOnly = false) {
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

    private void PictureBoxOrganization_Click(object sender, EventArgs e) {
      if (!string.IsNullOrWhiteSpace(SID)) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{SID}");
      }
    }

  }

}
