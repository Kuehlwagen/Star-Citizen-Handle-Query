using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlHandle : UserControl {

    private readonly HandleInfo Info;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;
    private readonly bool ForceLive;
    private readonly bool DisplayOnly;

    public UserControlHandle(HandleInfo handleInfo, Settings programSettings, Translation programTranslation, bool forceLive, bool displayOnly = false) {
      InitializeComponent();
      Info = handleInfo;
      ProgramSettings = programSettings;
      ProgramTranslation = programTranslation;
      ForceLive = forceLive;
      DisplayOnly = displayOnly;
    }

    private async void UserControlHandle_Load(object sender, EventArgs e) {
      if (Info?.HttpResponse?.StatusCode == HttpStatusCode.OK && Info?.Profile != null) {
        string handle = GetString(Info?.Profile?.Handle);
        CreateHandleJSON(Info, forceLive: ForceLive, programSettings: ProgramSettings);
        PictureBoxHandleAvatar.Image = await GetImage(CacheDirectoryType.HandleAvatar, Info.Profile?.AvatarUrl, handle, ProgramSettings.LocalCacheMaxAge, ForceLive);
        if (!DisplayOnly) {
          PictureBoxHandleAvatar.Cursor = Cursors.Hand;
        } else {
          PictureBoxHandleAvatar.MouseClick -= PictureBoxHandleAvatar_MouseClick;
        }
        if (!string.IsNullOrWhiteSpace(Info?.Profile?.DisplayTitleAvatarUrl)) {
          PictureBoxDisplayTitle.Image = await GetImage(CacheDirectoryType.HandleDisplayTitle, Info.Profile.DisplayTitleAvatarUrl, Info?.Profile?.DisplayTitle, ProgramSettings.LocalCacheMaxAge);
        }
        LabelHandle.Text = handle;
        LabelCommunityMoniker.Text = GetString(Info?.Profile?.CommunityMonicker, "CM: ");
        LabelDisplayTitle.Text = GetString(Info?.Profile?.DisplayTitle);
        LabelFluency.Text = Info?.Profile?.Fluency?.Count > 0 ? $"Fluency: {string.Join(", ", Info.Profile.Fluency)}" : string.Empty;
        LabelUEECitizenRecord.Text = GetString(Info?.Profile?.UeeCitizenRecord);
        LabelEnlistedDate.Text = Info?.Profile?.Enlisted.ToString("MMM d, yyyy", System.Globalization.CultureInfo.InvariantCulture);
        LabelAdditionalInformation.Text = GetString(Info?.Comment);
        if (DisplayOnly) {
          LabelAdditionalInformation.Cursor = Cursors.Default;
        } else {
          bool isLive = await CheckCommunityHubIsLive(handle);
          if (isLive) {
            PictureBoxLive.Visible = true;
          }
        }
      } else {
        LabelCommunityMoniker.Text = Info?.HttpResponse?.StatusCode == HttpStatusCode.NotFound ? ProgramTranslation.Window.Handle_Not_Found : Info?.HttpResponse?.ErrorText;
        LabelCommunityMoniker.Location = new Point(3, LabelHandle.Location.Y + 4);
        LabelCommunityMoniker.BringToFront();
        Size = new Size(Size.Width, 25);
      }
    }

    internal static void CreateHandleJSON(HandleInfo handleInfo, Settings programSettings, bool forceLive = false, bool forceExport = false) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handleInfo?.Profile?.Handle);
      if (forceExport || forceLive || !File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(programSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize(handleInfo, new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
      }
    }

    internal static async Task<bool> CheckCommunityHubIsLive(string handle) {
      bool rtnVal = false;

      HttpInfo httpInfo = await GetSource($"{handle}_CommunityHub", $"https://robertsspaceindustries.com/community-hub/user/{handle}", true);
      if (httpInfo?.StatusCode == HttpStatusCode.OK) {
        if (httpInfo.Source.Contains("\"live\":true")) {
          rtnVal = true;
        }
      }

      return rtnVal;
    }

    private void PictureBoxHandleAvatar_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left && Info?.Profile.Url?.Length > 0) {
        Process.Start("explorer", Info.Profile.Url);
      }
    }

    private void TextBoxAdditionalInformation_KeyDown(object sender, KeyEventArgs e) {
      TextBox textBox = sender as TextBox;
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          Info.Comment = !string.IsNullOrWhiteSpace(textBox.Text) ? textBox.Text : null;
          textBox.Tag = Info.Comment;
          LabelAdditionalInformation.Text = Info.Comment;
          CreateHandleJSON(Info, ProgramSettings, forceExport: true);
          textBox.Visible = false;
          break;
        case Keys.Escape:
          e.SuppressKeyPress = true;
          textBox.Text = textBox.Tag as string;
          textBox.Visible = false;
          break;
      }
    }

    private void TextBoxAdditionalInformation_Leave(object sender, EventArgs e) {
      TextBox textBox = sender as TextBox;
      textBox.Text = textBox.Tag as string;
      textBox.Visible = false;
    }

    private void LabelAdditionalInformation_Click(object sender, EventArgs e) {
      ActivateComment();
    }

    public void ActivateComment() {
      if (!DisplayOnly) {
        TextBoxAdditionalInformation.Visible = true;
        TextBoxAdditionalInformation.SelectAll();
        TextBoxAdditionalInformation.Focus();
      }
    }

    private void PictureBoxLive_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/community-hub/user/{Info.Profile.Handle}");
      }
    }
  }

}
