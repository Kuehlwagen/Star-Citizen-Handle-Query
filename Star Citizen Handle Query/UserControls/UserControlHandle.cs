using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlHandle : UserControl {

    private readonly HandleInfo HandleInfo;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;

    public UserControlHandle(HandleInfo handleInfo, Settings programSettings, Translation programTranslation) {
      InitializeComponent();
      HandleInfo = handleInfo;
      ProgramSettings = programSettings;
      ProgramTranslation = programTranslation;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      CreateDirectory(CacheDirectoryType.Handle);
      CreateDirectory(CacheDirectoryType.HandleAvatar);
      CreateDirectory(CacheDirectoryType.HandleDisplayTitle);
      CreateDirectory(CacheDirectoryType.OrganizationAvatar);

      if (HandleInfo?.success == 1 && HandleInfo?.data?.profile != null) {
        string handle = GetString(HandleInfo?.data?.profile?.handle);
        CreateHandleJSON(handle);
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.image)) {
          PictureBoxHandleAvatar.Image = await GetImage(CacheDirectoryType.HandleAvatar, HandleInfo.data.profile.image, handle);
          PictureBoxHandleAvatar.Cursor = Cursors.Hand;
        }
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.badge_image)) {
          PictureBoxDisplayTitle.Image = await GetImage(CacheDirectoryType.HandleDisplayTitle, HandleInfo.data.profile.badge_image, HandleInfo?.data?.profile?.badge);
        }
        LabelHandle.Text = handle;
        LabelCommunityMoniker.Text = GetString(HandleInfo?.data?.profile?.display, "CM: ");
        LabelDisplayTitle.Text = GetString(HandleInfo?.data?.profile?.badge);
        LabelFluency.Text = HandleInfo?.data?.profile?.fluency?.Length > 0 ? $"Fluency: {string.Join(", ", HandleInfo.data.profile.fluency)}" : string.Empty;
      } else {
        LabelHandle.Text = HandleInfo?.success == 0 && !string.IsNullOrWhiteSpace(HandleInfo?.message) ? HandleInfo.message : ProgramTranslation.Window.Handle_Not_Found;
        LabelHandle.Location = new Point(3, LabelHandle.Location.Y);
        LabelHandle.BringToFront();
        Size = new Size(Size.Width, 25);
      }
    }

    private void CreateHandleJSON(string handle) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handle);
      if (!File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize(HandleInfo, new JsonSerializerOptions() { WriteIndented = true });
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
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
