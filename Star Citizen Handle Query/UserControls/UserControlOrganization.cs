using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlOrganization : UserControl {

    private readonly HandleInfo HandleInfo;
    private readonly Settings ProgramSettings;
    private readonly int OrganizationIndex;
    private string SID;

    public UserControlOrganization(HandleInfo handleInfo, Settings programSettings, int organizationIndex) {
      InitializeComponent();
      HandleInfo = handleInfo;
      ProgramSettings = programSettings;
      OrganizationIndex = organizationIndex;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      dynamic org = HandleInfo?.data?.organization;

      if (OrganizationIndex > -1) {
        // Affiliate
        org = HandleInfo?.data?.affiliation[OrganizationIndex];
        SID = HandleInfo?.data?.affiliation[OrganizationIndex].sid;
      } else {
        SID = HandleInfo?.data?.organization?.sid;
      }

      LabelMainOrganizationAffiliate.Text = OrganizationIndex == -1 ? "Main Organization" : "Affiliation";
      string organizationSid = UserControlHandle.GetString(org?.sid);
      if ((OrganizationIndex == -1 &&  org?.name != string.Empty) || (OrganizationIndex > -1 && !string.IsNullOrWhiteSpace(organizationSid))) {
        LabelOrganizationName.Text = UserControlHandle.GetString(org?.name);
        LabelOrganizationSID.Text = UserControlHandle.GetString(organizationSid, "SID: ");
        LabelOrganizationRank.Text = UserControlHandle.GetString(org?.rank);
        if (!string.IsNullOrWhiteSpace(org?.image)) {
          PictureBoxOrganization.Image = await UserControlHandle.GetImage(CacheDirectoryType.OrganizationAvatar, org.image, organizationSid, ProgramSettings.LocalCacheMaxAge);
          PictureBoxOrganization.Cursor = Cursors.Hand;
        }
        if (org?.sid != null && org?.stars >= 0 && org.stars <= 5) {
          PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{org.stars}") as Image;
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
