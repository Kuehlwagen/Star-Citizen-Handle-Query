using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlOrganization : UserControl {

    private readonly OrganizationInfo Info;
    private readonly Settings ProgramSettings;
    private readonly bool IsMainOrg;
    private string SID;
    private readonly bool ForceLive;
    private readonly bool DisplayOnly;

    public UserControlOrganization(OrganizationInfo organizationInfo, Settings programSettings, bool isMainOrg, bool forceLive, bool displayOnly = false) {
      InitializeComponent();
      Info = organizationInfo;
      ProgramSettings = programSettings;
      IsMainOrg = isMainOrg;
      ForceLive = forceLive;
      DisplayOnly = displayOnly;
    }

    private async void UserControlOrganization_Load(object sender, EventArgs e) {
      LabelMainOrganizationAffiliate.Text = IsMainOrg ? "Main Organization" : "Affiliation";
      string organizationSid = GetString(Info?.Sid);
      SID = organizationSid;
      if (Info?.Redacted == false) {
        LabelOrganizationName.Text = GetString(Info?.Name);
        LabelOrganizationSID.Text = GetString(organizationSid, "SID: ");
        LabelOrganizationRank.Text = GetString(Info?.RankName);
        LabelFocusPrimary.Text = GetString(Info?.PrimaryActivity);
        LabelFocusSecondary.Text = GetString(Info?.SecondaryActivity);
        if (!string.IsNullOrWhiteSpace(Info?.Commitment)) {
          LabelMainOrganizationAffiliate.Text = $"{Info.Commitment} / {Info.Members:n0} Member{(Info.Members > 0 ? "s" : string.Empty)}";
        } else {
          LabelMainOrganizationAffiliate.Text += $" / {Info.Members:n0} Member{(Info.Members > 0 ? "s" : string.Empty)}";
        }
        if (!string.IsNullOrWhiteSpace(Info?.AvatarUrl)) {
          PictureBoxOrganization.Image = await GetImage(CacheDirectoryType.OrganizationAvatar, Info.AvatarUrl, organizationSid, ProgramSettings.LocalCacheMaxAge, ForceLive);
          if (!DisplayOnly) {
            PictureBoxOrganization.Cursor = Cursors.Hand;
          } else {
            PictureBoxOrganization.Click -= PictureBoxOrganization_Click;
          }
        }
        if (Info?.Sid != null && Info?.RankStars >= 0 && Info.RankStars <= 5) {
          PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{Info.RankStars}") as Image;
        }
      } else {
        BackColor = Color.FromArgb(33, 26, 19);
        PictureBoxOrganization.Size = new Size(PictureBoxOrganization.Width, 19);
        PictureBoxOrganization.Image = Properties.Resources.Redacted_Small;
        LabelOrganizationName.ForeColor = Color.FromArgb(255, 57, 57);
        LabelOrganizationName.Text = "REDACTED";
        LabelMainOrganizationAffiliate.ForeColor = Color.FromArgb(173, 39, 39);
        PictureBoxOrganization.Click -= PictureBoxOrganization_Click;
        LabelMainOrganizationAffiliate.Location = new Point(LabelMainOrganizationAffiliate.Left, LabelMainOrganizationAffiliate.Top - 3);
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
