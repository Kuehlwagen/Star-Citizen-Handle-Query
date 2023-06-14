﻿using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlHandleRelation : UserControl {

    private readonly Translation ProgramTranslation;

    public UserControlHandleRelation(Translation programTranslations) {
      InitializeComponent();
      ProgramTranslation = programTranslations;
    }

    private void UserControlOrganization_Load(object sender, EventArgs e) {
      LabelFriendly.BackColor = FormHandleQuery.GetRelationInactiveColor(Relation.Friendly);
      LabelFriendly.ForeColor = FormHandleQuery.GetRelationColor(Relation.Friendly);
      LabelFriendly.Text = ProgramTranslation.Local_Cache.Relation.Friendly;
      LabelNeutral.BackColor = FormHandleQuery.GetRelationInactiveColor(Relation.Neutral);
      LabelNeutral.ForeColor = FormHandleQuery.GetRelationColor(Relation.Neutral);
      LabelNeutral.Text = ProgramTranslation.Local_Cache.Relation.Neutral;
      LabelBogey.BackColor = FormHandleQuery.GetRelationInactiveColor(Relation.Bogey);
      LabelBogey.ForeColor = FormHandleQuery.GetRelationColor(Relation.Bogey);
      LabelBogey.Text = ProgramTranslation.Local_Cache.Relation.Bogey;
      LabelBandit.BackColor = FormHandleQuery.GetRelationInactiveColor(Relation.Bandit);
      LabelBandit.ForeColor = FormHandleQuery.GetRelationColor(Relation.Bandit);
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
