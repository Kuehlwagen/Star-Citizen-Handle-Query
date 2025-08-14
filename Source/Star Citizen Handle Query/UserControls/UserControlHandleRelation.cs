using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlHandleRelation : UserControl {

    private readonly Translation ProgramTranslation;
    private readonly Settings ProgramSettings;

    public UserControlHandleRelation(Settings programSettings, Translation programTranslations) {
      InitializeComponent();

      ProgramSettings = programSettings;
      // Farben setzen
      if (ProgramSettings.Colors != null) {
        BackColor = ProgramSettings.Colors.AppBackColor;
        ForeColor = ProgramSettings.Colors.AppForeColor;
      }

      ProgramTranslation = programTranslations;
    }

    private void UserControlOrganization_Load(object sender, EventArgs e) {
      LabelFriendly.BackColor = FormHandleQuery.GetRelationInactiveColor(ProgramSettings, RelationValue.Friendly);
      LabelFriendly.ForeColor = FormHandleQuery.GetRelationColor(ProgramSettings, RelationValue.Friendly);
      LabelFriendly.Text = ProgramTranslation.Local_Cache.Relation.Friendly;
      LabelNeutral.BackColor = FormHandleQuery.GetRelationInactiveColor(ProgramSettings, RelationValue.Neutral);
      LabelNeutral.ForeColor = FormHandleQuery.GetRelationColor(ProgramSettings, RelationValue.Neutral);
      LabelNeutral.Text = ProgramTranslation.Local_Cache.Relation.Neutral;
      LabelBogey.BackColor = FormHandleQuery.GetRelationInactiveColor(ProgramSettings, RelationValue.Bogey);
      LabelBogey.ForeColor = FormHandleQuery.GetRelationColor(ProgramSettings, RelationValue.Bogey);
      LabelBogey.Text = ProgramTranslation.Local_Cache.Relation.Bogey;
      LabelBandit.BackColor = FormHandleQuery.GetRelationInactiveColor(ProgramSettings, RelationValue.Bandit);
      LabelBandit.ForeColor = FormHandleQuery.GetRelationColor(ProgramSettings, RelationValue.Bandit);
      LabelBandit.Text = ProgramTranslation.Local_Cache.Relation.Bandit;
    }

    private FormHandleQuery GetMainForm() {
      return Parent.Parent as FormHandleQuery;
    }

    private void LabelFriendly_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        Keys key = Keys.None;
        switch ((sender as Label).Name) {
          case "LabelFriendly":
            key = Keys.NumPad1;
            break;
          case "LabelNeutral":
            key = Keys.NumPad2;
            break;
          case "LabelBogey":
            key = Keys.NumPad3;
            break;
          case "LabelBandit":
            key = Keys.NumPad4;
            break;
        }
        if (key != Keys.None) {
          GetMainForm().ChangeRelation(ModifierKeys == Keys.Shift ? RelationType.Organization : RelationType.Handle, key);
        }
      }
    }

    private void Label_Paint(object sender, PaintEventArgs e) {
      Label control = sender as Label;
      ControlPaint.DrawBorder(e.Graphics, control.DisplayRectangle, control.ForeColor, ButtonBorderStyle.Solid);
    }
  }

}
