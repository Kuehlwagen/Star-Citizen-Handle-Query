using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Drawing.Drawing2D;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlRelation : UserControl {

    internal readonly RelationType Type;
    internal readonly string RelationName;
    internal RelationValue Relation;
    internal string Comment;
    private readonly Settings ProgramSettings;

    public UserControlRelation(Settings programSettings, string handle, RelationType relationType, RelationValue relation, string comment = null) {
      InitializeComponent();

      ProgramSettings = programSettings;

      // Farben setzen
      if (ProgramSettings.Colors != null) {
        BackColor = ProgramSettings.Colors.AppBackColor;
        ForeColor = ProgramSettings.Colors.AppForeColor;
      }

      RelationName = handle;
      Relation = relation;
      Type = relationType;
      LabelOrganization.Invalidate();
      Comment = comment;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelHandle.Text = RelationName;
      UpdateRelation(Relation);
      UpdateComment(Comment);
      AddMouseEvents();
    }

    private void AddMouseEvents() {
      if (Type == RelationType.Handle) {
        LabelRelation.MouseClick += Handle_MouseClick;
        LabelRelation.Cursor = Cursors.Hand;
        LabelHandle.MouseClick += Handle_MouseClick;
        LabelHandle.Cursor = Cursors.Hand;
      }
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      if (Type == RelationType.Handle) {
        ((Parent.Parent as FormRelations).Owner as FormHandleQuery).SetAndQueryHandle(RelationName);
      }
    }

    public void UpdateRelation(RelationValue relation) {
      Relation = relation;
      LabelRelation.BackColor = FormHandleQuery.GetRelationColor(relation);
    }

    public void UpdateComment(string comment) {
      Comment = comment;
      if (Parent != null) {
        LabelHandle.Text = string.IsNullOrWhiteSpace(comment) ? RelationName : $"⭐ {RelationName}";
        (Parent.Parent as FormRelations).SetToolTip(LabelHandle, comment ?? string.Empty);
      }
    }

    private void LabelOrganization_Paint(object sender, PaintEventArgs e) {
      if (Type == RelationType.Organization) {
        PaintOrgIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive);
      }
    }

    private static void PaintOrgIcon(Graphics g, Color foreColor, Color foreColorInactive) {
      using var bgPen = new Pen(foreColorInactive, 2.0F);
      using var fgPen = new Pen(foreColor, 1.0F);

      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.DrawEllipse(bgPen, 2, 2, 16, 16);
      g.DrawEllipse(fgPen, 2, 2, 16, 16);
      g.FillEllipse(bgPen.Brush, 6, 6, 8, 8);
      g.FillEllipse(fgPen.Brush, 6, 6, 8, 8);
    }

  }

}
