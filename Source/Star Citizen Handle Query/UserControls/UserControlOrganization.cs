using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata.Ecma335;
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

      // Farben setzen
      if (programSettings.Colors != null) {
        BackColor = programSettings.Colors.AppBackColor;
        ForeColor = programSettings.Colors.AppForeColor;
        LabelMainOrganizationAffiliate.ForeColor = programSettings.Colors.AppForeColorInactive;
      }

      Info = organizationInfo;
      ProgramSettings = programSettings;
      IsMainOrg = isMainOrg;
      ForceLive = forceLive;
      DisplayOnly = displayOnly;
    }

    private async void UserControlOrganization_Load(object sender, EventArgs e) {
      if (ProgramSettings.CompactMode) {
        PictureBoxOrganization.Size = new Size(LogicalToDeviceUnits(19), LogicalToDeviceUnits(19));
        LabelRelation.Location = new Point(PictureBoxOrganization.Location.X + PictureBoxOrganization.Size.Width, LabelRelation.Location.Y);
        LabelRelation.Height = LogicalToDeviceUnits(21);
        LabelOrganizationName.Location = new Point(LabelRelation.Location.X + LabelRelation.Size.Width, LabelOrganizationName.Location.Y);
        Size = new Size(Size.Width, LogicalToDeviceUnits(25));
        LabelMainOrganizationAffiliate.Visible = false;
        PictureBoxOrganizationRank.Location = new Point(Width - PictureBoxOrganizationRank.Width - LogicalToDeviceUnits(3), LogicalToDeviceUnits(3));
        SetToolTip(PictureBoxOrganizationRank, GetString(Info?.RankName));
        SetToolTip(LabelOrganizationName, GetString(Info?.Name));
      }
      LabelMainOrganizationAffiliate.Text = IsMainOrg ? "Main Organization" : "Affiliation";
      string organizationSid = GetString(Info?.Sid);
      SID = organizationSid;
      if (Info?.Redacted == false) {
        LabelOrganizationName.Text = GetString(!ProgramSettings.CompactMode ? Info?.Name : Info?.Sid);
        if (!ProgramSettings.CompactMode) {
          SetToolTip(LabelOrganizationName);
        }
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
        PictureBoxOrganizationRank.Invalidate();
        if (!DisplayOnly) {
          Relation = GetMainForm().GetOrganizationRelation(Info.Sid);
          if (Relation > RelationValue.NotAssigned) {
            LabelRelation.BackColor = GetRelationColor(ProgramSettings, Relation);
            LabelRelation.Visible = true;
          }
        }
      } else {
        PictureBoxOrganization.Size = new Size(PictureBoxOrganization.Width, LogicalToDeviceUnits(19));
        PictureBoxOrganization.Image = Properties.Resources.Redacted_Small;
        LabelOrganizationName.ForeColor = ProgramSettings.Colors.AppForeColorInactive;
        LabelOrganizationName.Text = "REDACTED";
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
      LabelRelation.BackColor = GetRelationColor(ProgramSettings, Relation);
    }

    private void LabelRelation_Paint(object sender, PaintEventArgs e) {
      ControlPaint.DrawBorder(e.Graphics, LabelRelation.ClientRectangle, BackColor, ButtonBorderStyle.Solid);
    }

    private void PictureBoxOrganizationRank_Paint(object sender, PaintEventArgs e) {
      PaintOrganizationRanksIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive);
    }

    internal void PaintOrganizationRanksIcon(Graphics g, Color foreColor, Color foreColorInactive) {
      if (Info.RankStars != null && Info.RankStars.Value >= 0 && Info.RankStars <= 5) {
        using var bgPen = new Pen(foreColorInactive, 2.0F);
        using var fgPen = new Pen(foreColor, 1.0F);

        g.SmoothingMode = SmoothingMode.AntiAlias;
        for (int i = 0; i < 5; i++) {
          g.DrawEllipse(bgPen, new Rectangle((i * 20) + 1, 1, 16, 16));
          if (Info.RankStars > i) {
            g.FillEllipse(fgPen.Brush, new Rectangle((i * 20) + 1, 1, 16, 16));
          }
        }
      }
    }

  }

}
