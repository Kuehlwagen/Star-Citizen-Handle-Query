using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
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
        CreateHandleJSON(handle);
        if (!string.IsNullOrWhiteSpace(Info.Profile?.AvatarUrl)) {
          PictureBoxHandleAvatar.Image = await GetImage(CacheDirectoryType.HandleAvatar, Info.Profile.AvatarUrl, handle, ProgramSettings.LocalCacheMaxAge, ForceLive);
          if (!DisplayOnly) {
            PictureBoxHandleAvatar.Cursor = Cursors.Hand;
          } else {
            PictureBoxHandleAvatar.Click -= PictureBoxHandleAvatar_Click;
          }
        }
        if (!string.IsNullOrWhiteSpace(Info?.Profile?.DisplayTitleAvatarUrl)) {
          PictureBoxDisplayTitle.Image = await GetImage(CacheDirectoryType.HandleDisplayTitle, Info.Profile.DisplayTitleAvatarUrl, Info?.Profile?.DisplayTitle, ProgramSettings.LocalCacheMaxAge);
        }
        LabelHandle.Text = handle;
        LabelCommunityMoniker.Text = GetString(Info?.Profile?.CommunityMonicker, "CM: ");
        LabelDisplayTitle.Text = GetString(Info?.Profile?.DisplayTitle);
        LabelFluency.Text = Info?.Profile?.Fluency?.Count > 0 ? $"Fluency: {string.Join(", ", Info.Profile.Fluency)}" : string.Empty;
        LabelUEECitizenRecord.Text = GetString(Info?.Profile?.UeeCitizenRecord);
        LabelEnlistedDate.Text = Info?.Profile?.Enlisted.ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture);
        if (DisplayOnly) {
          LabelAdditionalInformation.Cursor = Cursors.Default;
        }
        string additionalInfoPath = FormHandleQuery.GetCachePath(CacheDirectoryType.HandleAdditional, handle);
        if (File.Exists(additionalInfoPath)) {
          HandleAdditionalInfo handleAdditionalInfo = JsonSerializer.Deserialize<HandleAdditionalInfo>(File.ReadAllText(additionalInfoPath, Encoding.UTF8));
          if (!string.IsNullOrWhiteSpace(handleAdditionalInfo?.Comment)) {
            LabelAdditionalInformation.Text = handleAdditionalInfo.Comment;
            TextBoxAdditionalInformation.Text = handleAdditionalInfo.Comment;
            TextBoxAdditionalInformation.Tag = TextBoxAdditionalInformation.Text;
          }
        }
      } else {
        LabelCommunityMoniker.Text = Info?.HttpResponse?.StatusCode == HttpStatusCode.NotFound ? ProgramTranslation.Window.Handle_Not_Found : Info?.HttpResponse?.ErrorText;
        LabelCommunityMoniker.Location = new Point(3, LabelHandle.Location.Y + 4);
        LabelCommunityMoniker.BringToFront();
        Size = new Size(Size.Width, 25);
      }
    }

    private void CreateHandleJSON(string handle) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handle);
      if (ForceLive || !File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(ProgramSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize(Info, new JsonSerializerOptions() { WriteIndented = true });
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
      }
    }

    private void PictureBoxHandleAvatar_Click(object sender, EventArgs e) {
      if (Info?.Profile.Url?.Length > 0) {
        Process.Start("explorer", Info.Profile.Url);
      }
    }

    private void TextBoxAdditionalInformation_KeyDown(object sender, KeyEventArgs e) {
      TextBox textBox = sender as TextBox;
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          textBox.Tag = textBox.Text;
          LabelAdditionalInformation.Text = textBox.Text;
          FormLocalCache.WriteHandleAdditionalInformation(Info.Profile.Handle, textBox.Text);
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

  }

}
