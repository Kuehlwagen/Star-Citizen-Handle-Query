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

      string organizationSid = GetString(org?.sid);
      if (!string.IsNullOrWhiteSpace(organizationSid)) {
        LabelOrganizationName.Text = GetString(org?.name);
        LabelOrganizationSID.Text = GetString(organizationSid, "SID: ");
        LabelOrganizationRank.Text = GetString(org?.rank);
        if (!string.IsNullOrWhiteSpace(org?.image)) {
          PictureBoxOrganization.Image = await GetImage(CacheDirectoryType.OrganizationAvatar, org.image, organizationSid);
          PictureBoxOrganization.Cursor = Cursors.Hand;
        }
        if (org?.sid != null && org?.stars >= 0 && org.stars <= 5) {
          PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{org.stars}") as Image;
        }
      } else {
        BackColor = Color.FromArgb(33, 26, 19);
        PictureBoxOrganization.Image = Properties.Resources.Redacted;
        LabelOrganizationName.ForeColor = Color.FromArgb(255, 57, 57);
        LabelOrganizationName.Text = "REDACTED";
        PictureBoxOrganization.Click -= PictureBoxOrganization_Click;
      }
    }

    private static string GetString(string value, string preValue = "") {
      return !string.IsNullOrWhiteSpace(value) ? $"{(!string.IsNullOrWhiteSpace(preValue) ? preValue : string.Empty)}{value}" : string.Empty;
    }

    private async Task<Image> GetImage(CacheDirectoryType imageType, string url, string name) {
      Image rtnVal = null;

      string filePath = GetImagePath(imageType, url, name);
      if (!File.Exists(filePath) || new FileInfo(filePath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        using Stream urlStream = await GetImageFromUrl(url);
        if (urlStream != null) {
          using FileStream fileStream = new(filePath, FileMode.OpenOrCreate);
          urlStream.CopyTo(fileStream);
        }
      }
      if (File.Exists(filePath)) {
        rtnVal = Image.FromFile(filePath);
      }

      return rtnVal;
    }

    private static string GetImagePath(CacheDirectoryType imageType, string url, string name) {
      string rtnVal = string.Empty;

      switch (imageType) {
        case CacheDirectoryType.HandleAvatar:
        case CacheDirectoryType.OrganizationAvatar:
          rtnVal = Path.Combine(GetCachePath(imageType), GetCorrectFileName($"{name}_{url[(url.LastIndexOf("/") + 1)..]}"));
          break;
        case CacheDirectoryType.HandleDisplayTitle:
          rtnVal = Path.Combine(GetCachePath(imageType), GetCorrectFileName($"{name}{url[url.LastIndexOf(".")..]}"));
          break;
      }

      return rtnVal;
    }

    private static string GetCorrectFileName(string name) {
      string rtnVal = name;
      foreach (Char c in Path.GetInvalidFileNameChars()) {
        rtnVal = rtnVal.Replace(c, '-');
      }
      return rtnVal;
    }

    private static async Task<Stream> GetImageFromUrl(string url) {
      Stream rtnVal = null;

      using HttpClient client = new();
      try {
        rtnVal = await client.GetStreamAsync(url);
      } catch { }

      return rtnVal;
    }

    private void PictureBoxOrganization_Click(object sender, EventArgs e) {
      if (!string.IsNullOrWhiteSpace(SID)) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{SID}");
      }
    }

  }

}
