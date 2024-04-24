using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlOrganization : UserControl {

    private readonly OrganizationInfo Info;
    private readonly Settings ProgramSettings;
    private readonly bool IsMainOrg;
    internal string SID;
    internal RelationValue Relation;
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
        SetToolTip(LabelOrganizationName);
        LabelOrganizationSID.Text = GetString(organizationSid, "SID: ");
        LabelOrganizationRank.Text = GetString(Info?.RankName);
        SetToolTip(LabelOrganizationRank);
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
            PictureBoxOrganization.MouseClick -= PictureBoxOrganization_MouseClick;
          }
        }
        if (Info?.Sid != null && Info?.RankStars >= 0 && Info.RankStars <= 5) {
          PictureBoxOrganizationRank.Image = Properties.Resources.ResourceManager.GetObject($"OrganizationRank{Info.RankStars}") as Image;
        }
        if (!DisplayOnly) {
          Relation = GetMainForm().GetOrganizationRelation(Info.Sid);
          if (Relation > RelationValue.NotAssigned) {
            LabelRelation.BackColor = GetRelationColor(Relation);
            LabelRelation.Visible = true;
          }
        }
      } else {
        BackColor = Color.FromArgb(33, 26, 19);
        PictureBoxOrganization.Size = new Size(PictureBoxOrganization.Width, LogicalToDeviceUnits(19));
        PictureBoxOrganization.Image = Properties.Resources.Redacted_Small;
        LabelOrganizationName.ForeColor = Color.FromArgb(255, 57, 57);
        LabelOrganizationName.Text = "REDACTED";
        LabelMainOrganizationAffiliate.ForeColor = Color.FromArgb(173, 39, 39);
        PictureBoxOrganization.MouseClick -= PictureBoxOrganization_MouseClick;
        LabelMainOrganizationAffiliate.Location = new Point(LabelMainOrganizationAffiliate.Left, LabelMainOrganizationAffiliate.Top - 3);
        Size = new Size(Size.Width, LogicalToDeviceUnits(25));
      }
    }

    private void PictureBoxOrganization_MouseClick(object sender, MouseEventArgs e) {
      OpenProfile(e);
    }

    private void OpenProfile(MouseEventArgs e) {
      if (e.Button == MouseButtons.Left && !string.IsNullOrWhiteSpace(SID)) {
        Process.Start("explorer", $"https://robertsspaceindustries.com/orgs/{SID}");
      }
    }

    private FormHandleQuery GetMainForm() {
      return Parent.Parent as FormHandleQuery;
    }

    private void SetToolTip(Control control, string text = null) {
      GetMainForm()?.SetToolTip(control, text ?? control.Text);
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
      Relation = relation;
      LabelRelation.Visible = relation > RelationValue.NotAssigned;
      LabelRelation.BackColor = GetRelationColor(Relation);
    }

    private void LabelRelation_Paint(object sender, PaintEventArgs e) {
      ControlPaint.DrawBorder(e.Graphics, LabelRelation.ClientRectangle, BackColor, ButtonBorderStyle.Solid);
    }

  }

}
