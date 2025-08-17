using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
    private CommunityHubLiveState LiveState = CommunityHubLiveState.Initializing;

    public string HandleName { get { return Info.Profile.Handle; } }
    public RelationValue HandleRelation { get { return Info.Relation; } }

    public UserControlHandle(HandleInfo handleInfo, Settings programSettings, Translation programTranslation, bool forceLive, bool displayOnly = false) {
      InitializeComponent();

      // Farben setzen
      if (programSettings.Colors != null) {
        BackColor = programSettings.Colors.AppBackColor;
        ForeColor = programSettings.Colors.AppForeColor;
        LabelAdditionalInformation.ForeColor = programSettings.Colors.AppForeColor;
        TextBoxAdditionalInformation.BackColor = programSettings.Colors.AppBackColor;
        TextBoxAdditionalInformation.ForeColor = programSettings.Colors.AppForeColor;
      }

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
        SetToolTip(LabelHandle);
        LabelCommunityMoniker.Text = GetString(Info?.Profile?.CommunityMonicker, "CM: ");
        SetToolTip(LabelCommunityMoniker);
        LabelDisplayTitle.Text = GetString(Info?.Profile?.DisplayTitle);
        SetToolTip(PictureBoxDisplayTitle, LabelDisplayTitle.Text);
        SetToolTip(LabelDisplayTitle);
        if (!string.IsNullOrWhiteSpace(Info?.Profile?.Country)) {
          LabelLocationFluency.Text = $"{Info.Profile.Country} ({string.Join(", ", Info.Profile.Fluency)})";
          SetToolTip(LabelLocationFluency, $"{Info.Profile.Country}{(!string.IsNullOrWhiteSpace(Info.Profile.Region) ? $", {Info.Profile.Region}" : string.Empty)} ({string.Join(", ", Info.Profile.Fluency)})");
        } else {
          string fluency = string.Join(", ", Info.Profile.Fluency);
          LabelLocationFluency.Text = $"Fluency: {fluency}";
          SetToolTip(LabelLocationFluency);
        }
        LabelUEECitizenRecord.Text = GetString(Info?.Profile?.UeeCitizenRecord);
        LabelEnlistedDate.Text = Info?.Profile?.Enlisted.ToString("MMM d, yyyy", System.Globalization.CultureInfo.InvariantCulture);
        LabelAdditionalInformation.Text = GetString(Info?.Comment);
        SetToolTip(LabelAdditionalInformation);
        if (Info?.Relation > RelationValue.NotAssigned) {
          LabelRelation.BackColor = GetRelationColor(ProgramSettings, Info.Relation);
          SetToolTip(LabelRelation, FormLocalCache.GetTranslatedRelationText(ProgramTranslation, Info.Relation));
          LabelRelation.Visible = true;
        }
        if (DisplayOnly) {
          LabelAdditionalInformation.Cursor = Cursors.Default;
          LabelRelation.Cursor = Cursors.Default;
          LabelRelation.MouseClick -= LabelRelation_MouseClick;
          PictureBoxLive.Visible = false;
        } else if (!ProgramSettings.HideStreamLiveStatus) {
          PictureBoxLive.Invalidate();
          LiveState = await CheckCommunityHubIsLive(handle);
          PictureBoxLive.Invalidate();
        }
      } else {
        LabelCommunityMoniker.Text = Info?.HttpResponse?.StatusCode == HttpStatusCode.NotFound ? ProgramTranslation.Window.Handle_Not_Found : Info?.HttpResponse?.ErrorText;
        LabelCommunityMoniker.Location = new Point(3, LabelHandle.Location.Y + 4);
        LabelCommunityMoniker.BringToFront();
        SetToolTip(LabelCommunityMoniker);
        Size = new Size(Size.Width, LogicalToDeviceUnits(25));
      }
    }

    private readonly static JsonSerializerOptions JsonSerOptions = new() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    internal static void CreateHandleJSON(HandleInfo handleInfo, Settings programSettings, bool forceLive = false, bool forceExport = false) {
      string jsonPath = GetCachePath(CacheDirectoryType.Handle, handleInfo?.Profile?.Handle);
      if (forceExport || forceLive || !File.Exists(jsonPath) || new FileInfo(jsonPath).LastWriteTime < DateTime.Now.AddDays(programSettings.LocalCacheMaxAge * -1)) {
        string handleJson = JsonSerializer.Serialize(handleInfo, JsonSerOptions);
        if (!string.IsNullOrWhiteSpace(handleJson)) {
          File.WriteAllText(jsonPath, handleJson, Encoding.UTF8);
        }
      }
    }

    internal static async Task<CommunityHubLiveState> CheckCommunityHubIsLive(string handle) {
      CommunityHubLiveState rtnVal = CommunityHubLiveState.Offline;

      HttpInfo httpInfo = await GetRSISource($"{handle}_CommunityHub", $"https://robertsspaceindustries.com/community-hub/user/{handle}", CancelToken, true);
      switch (httpInfo.StatusCode) {
        case HttpStatusCode.OK:
          if (httpInfo.Source.Contains("\"live\":true")) {
            rtnVal = CommunityHubLiveState.Live;
          }
          break;
        case HttpStatusCode.BadGateway:
          rtnVal = CommunityHubLiveState.Error;
          break;
      }

      return rtnVal;
    }

    private void PictureBoxHandleAvatar_MouseClick(object sender, MouseEventArgs e) {
      OpenProfile(e);
    }

    private void LabelRelation_MouseClick(object sender, MouseEventArgs e) {
      OpenProfile(e);
    }

    private void OpenProfile(MouseEventArgs e) {
      if (e.Button == MouseButtons.Left && Info?.Profile.Url?.Length > 0) {
        Process.Start("explorer", Info.Profile.Url);
      }
    }

    private void TextBoxAdditionalInformation_KeyDown(object sender, KeyEventArgs e) {
      TextBox textBox = sender as TextBox;
      switch (e.KeyCode) {
        case Keys.Enter:
          e.SuppressKeyPress = true;
          Info.Comment = TextBoxAdditionalInformation.Text;
          textBox.Tag = Info.Comment;
          LabelAdditionalInformation.Text = Info.Comment;
          SetToolTip(LabelAdditionalInformation);
          CreateHandleJSON(Info, ProgramSettings, forceExport: true);
          textBox.Visible = false;
          GetMainForm().ChangeComment(HandleName, Info.Comment);
          ActivateTextBoxHandle();
          break;
        case Keys.Escape:
          e.SuppressKeyPress = true;
          textBox.Text = textBox.Tag as string;
          textBox.Visible = false;
          ActivateTextBoxHandle();
          break;
      }
    }

    private void TextBoxAdditionalInformation_Leave(object sender, EventArgs e) {
      TextBox textBox = sender as TextBox;
      textBox.Text = textBox.Tag as string;
      textBox.Visible = false;
      ActivateTextBoxHandle();
    }

    private void ActivateTextBoxHandle() {
      TextBox textBoxHandle = GetMainForm().Controls[1].Controls[0] as TextBox;
      textBoxHandle.SelectAll();
      textBoxHandle.Focus();
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

    public void ChangeRelation(Keys keyCode) {
      RelationValue relation = RelationValue.NotAssigned;
      switch (keyCode) {
        case Keys.D1:
        case Keys.NumPad1:
          relation = RelationValue.Friendly;
          break;
        case Keys.D2:
        case Keys.NumPad2:
          relation = RelationValue.Neutral;
          break;
        case Keys.D3:
        case Keys.NumPad3:
          relation = RelationValue.Bogey;
          break;
        case Keys.D4:
        case Keys.NumPad4:
          relation = RelationValue.Bandit;
          break;
      }
      Info.Relation = relation;
      CreateHandleJSON(Info, ProgramSettings, forceExport: true);
      LabelRelation.Visible = relation > RelationValue.NotAssigned;
      LabelRelation.BackColor = GetRelationColor(ProgramSettings, Info.Relation);
      SetToolTip(LabelRelation, FormLocalCache.GetTranslatedRelationText(ProgramTranslation, Info.Relation));
      ActivateTextBoxHandle();
    }

    private void PictureBoxLive_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/community-hub/user/{Info.Profile.Handle}");
      }
    }

    private FormHandleQuery GetMainForm() {
      return Parent?.Parent as FormHandleQuery;
    }

    private void SetToolTip(Control control, string text = null) {
      GetMainForm()?.SetToolTip(control, text ?? control.Text);
    }

    private void LabelRelation_Paint(object sender, PaintEventArgs e) {
      ControlPaint.DrawBorder(e.Graphics, LabelRelation.ClientRectangle, BackColor, ButtonBorderStyle.Solid);
    }

    private void PictureBoxLive_Paint(object sender, PaintEventArgs e) {
      DrawLiveState(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive, ProgramSettings.Colors.AppBackColor);
    }

    private void DrawLiveState(Graphics g, Color foreColor, Color foreColorInactive, Color backColor) {
      // Size: 32; 16
      if (!ProgramSettings.HideStreamLiveStatus) {
        using var fgiPen = new Pen(foreColorInactive, 2.0F);
        using var fgPen = new Pen(foreColor, 1.0F);
        using var bgPen = new Pen(backColor, 1.0F);

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawRectangle(fgiPen, 0, 0, 30, 14);
        g.FillRectangle(fgPen.Brush, 0, 0, 30, 14);
        switch (LiveState) {
          case CommunityHubLiveState.Initializing:
            g.FillEllipse(fgiPen.Brush, 6, 5, 4, 4);
            g.FillEllipse(bgPen.Brush, 6, 5, 4, 4);
            g.FillEllipse(fgiPen.Brush, 13, 5, 4, 4);
            g.FillEllipse(bgPen.Brush, 13, 5, 4, 4);
            g.FillEllipse(fgiPen.Brush, 20, 5, 4, 4);
            g.FillEllipse(bgPen.Brush, 20, 5, 4, 4);
            break;
          case CommunityHubLiveState.Offline:
            g.DrawString("OFF", new Font("Consolas", 8, FontStyle.Bold), bgPen.Brush, new PointF(5, 2));
            break;
          case CommunityHubLiveState.Live:
            g.DrawString("LIVE", new Font("Consolas", 7, FontStyle.Bold), bgPen.Brush, new PointF(4, 2));
            break;
          case CommunityHubLiveState.Error:
            g.DrawString("ERR", new Font("Consolas", 8, FontStyle.Bold), bgPen.Brush, new PointF(5, 2));
            break;
        }
      }
    }

  }

}
