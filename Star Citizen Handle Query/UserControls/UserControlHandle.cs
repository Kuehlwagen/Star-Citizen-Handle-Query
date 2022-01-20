using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlHandle : UserControl {

    private readonly HandleInfo HandleInfo;
    private readonly Settings ProgramSettings;

    public UserControlHandle(HandleInfo handleInfo, Settings programSettings) {
      InitializeComponent();
      HandleInfo = handleInfo;
      ProgramSettings = programSettings;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      CreateDirectory(CacheDirectoryType.Handle);
      CreateDirectory(CacheDirectoryType.HandleAvatar);
      CreateDirectory(CacheDirectoryType.HandleDisplayTitle);
      CreateDirectory(CacheDirectoryType.OrganizationAvatar);

      if (HandleInfo?.success == 1 && HandleInfo?.data?.profile != null) {
        string handle = GetString(HandleInfo?.data?.profile?.handle);
        CreateHandleJSON(handle);
        string organizationSid = GetString(HandleInfo?.data?.organization?.sid);
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.image)) {
          PictureBoxHandleAvatar.Image = await GetImage(CacheDirectoryType.HandleAvatar, HandleInfo.data.profile.image, handle);
          PictureBoxHandleAvatar.Cursor = Cursors.Hand;
        }
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.badge_image)) {
          PictureBoxDisplayTitle.Image = await GetImage(CacheDirectoryType.HandleDisplayTitle, HandleInfo.data.profile.badge_image, HandleInfo?.data?.profile?.badge);
        }
        if (!string.IsNullOrWhiteSpace(HandleInfo.data?.organization?.image)) {
          PictureBoxOrganization.Image = await GetImage(CacheDirectoryType.OrganizationAvatar, HandleInfo.data.organization.image, organizationSid);
          PictureBoxOrganization.Cursor = Cursors.Hand;
        }
        LabelHandle.Text = handle;
        LabelCommunityMoniker.Text = GetString(HandleInfo?.data?.profile?.display, "CM: ");
        LabelDisplayTitle.Text = GetString(HandleInfo?.data?.profile?.badge);
        LabelFluency.Text = HandleInfo?.data?.profile?.fluency?.Length > 0 ? $"Fluency: {string.Join(", ", HandleInfo.data.profile.fluency)}" : string.Empty;
        if (organizationSid.Length > 0) {
          LabelOrganizationName.Text = GetString(HandleInfo?.data?.organization?.name);
          LabelOrganizationSID.Text = GetString(organizationSid, "SID: ");
          LabelOrganizationRank.Text = GetString(HandleInfo?.data?.organization?.rank);
          if (HandleInfo?.data?.organization.sid != null && HandleInfo?.data?.organization?.stars >= 0 && HandleInfo.data.organization.stars <= 5) {
            PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{HandleInfo.data.organization.stars}") as Image;
          }
        } else {
          Size = new Size(Size.Width, 76);
        }
      } else {
        LabelHandle.Text = HandleInfo?.success == 0 && !string.IsNullOrWhiteSpace(HandleInfo?.message) ? HandleInfo.message : "Handle nicht gefunden...";
        LabelHandle.Location = new Point(3, LabelHandle.Location.Y);
        LabelHandle.BringToFront();
        Size = new Size(Size.Width, 25);
      }
    }

    private void CreateHandleJSON(string handle) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handle);
      if (!File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize<HandleInfo>(HandleInfo, new JsonSerializerOptions() { WriteIndented = true });
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
      }
    }

    private static string GetString(string value, string preValue = "") {
      return !string.IsNullOrWhiteSpace(value) ? $"{(!string.IsNullOrWhiteSpace(preValue) ? preValue : string.Empty)}{value}" : string.Empty;
    }

    private async Task<Image> GetImage(CacheDirectoryType imageType, string url, string name) {
      string filePath = GetImagePath(imageType, url, name);
      if (!File.Exists(filePath) || new FileInfo(filePath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        using Stream urlStream = await GetImageFromUrl(url);
        using FileStream fileStream = new(filePath, FileMode.OpenOrCreate);
        urlStream.CopyTo(fileStream);
      }
      return Image.FromFile(filePath);
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
      using HttpClient client = new();
      return await client.GetStreamAsync(url);
    }

    private static void CreateDirectory(CacheDirectoryType imageType) {
      string directoryPath = Path.Combine(Application.StartupPath, GetCachePath(imageType));
      if (!Directory.Exists(directoryPath)) {
        Directory.CreateDirectory(Path.Combine(Application.StartupPath, directoryPath));
      }
    }

    private void PictureBoxHandleAvatar_Click(object sender, EventArgs e) {
      if (HandleInfo?.data?.profile?.page?.url?.Length > 0) {
        Process.Start("explorer", HandleInfo.data.profile.page.url);
      }
    }

    private void PictureBoxOrganization_Click(object sender, EventArgs e) {
      if (HandleInfo?.data?.organization?.sid?.Length > 0) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{HandleInfo.data.organization.sid}");
      }
    }

  }

}
