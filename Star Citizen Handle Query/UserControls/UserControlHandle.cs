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
    private readonly bool ForceLive;

    public UserControlHandle(HandleInfo handleInfo, Settings programSettings, Translation programTranslation, bool forceLive) {
      InitializeComponent();
      HandleInfo = handleInfo;
      ProgramSettings = programSettings;
      ProgramTranslation = programTranslation;
      ForceLive = forceLive;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      if (HandleInfo?.success == 1 && HandleInfo?.data?.profile != null) {
        string handle = GetString(HandleInfo?.data?.profile?.handle);
        CreateHandleJSON(handle);
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.image)) {
          PictureBoxHandleAvatar.Image = await GetImage(CacheDirectoryType.HandleAvatar, HandleInfo.data.profile.image, handle, ProgramSettings.LocalCacheMaxAge, ForceLive);
          PictureBoxHandleAvatar.Cursor = Cursors.Hand;
        }
        if (!string.IsNullOrWhiteSpace(HandleInfo?.data?.profile?.badge_image)) {
          PictureBoxDisplayTitle.Image = await GetImage(CacheDirectoryType.HandleDisplayTitle, HandleInfo.data.profile.badge_image, HandleInfo?.data?.profile?.badge, ProgramSettings.LocalCacheMaxAge);
        }
        LabelHandle.Text = handle;
        LabelCommunityMoniker.Text = GetString(HandleInfo?.data?.profile?.display, "CM: ");
        LabelDisplayTitle.Text = GetString(HandleInfo?.data?.profile?.badge);
        LabelFluency.Text = HandleInfo?.data?.profile?.fluency?.Length > 0 ? $"Fluency: {string.Join(", ", HandleInfo.data.profile.fluency)}" : string.Empty;
        LabelUEECitizenRecord.Text = GetString(HandleInfo?.data?.profile?.id);
        LabelEnlistedDate.Text = HandleInfo?.data?.profile?.enlisted.ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture);
      } else {
        LabelCommunityMoniker.Text = HandleInfo?.success == 0 && !string.IsNullOrWhiteSpace(HandleInfo?.message) ? HandleInfo.message : ProgramTranslation.Window.Handle_Not_Found;
        LabelCommunityMoniker.Location = new Point(3, LabelHandle.Location.Y + 4);
        LabelCommunityMoniker.BringToFront();
        Size = new Size(Size.Width, 25);
      }
    }

    private void CreateHandleJSON(string handle) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handle);
      if (ForceLive || !File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize(HandleInfo, new JsonSerializerOptions() { WriteIndented = true });
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
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
