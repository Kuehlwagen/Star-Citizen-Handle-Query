﻿using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlRelation : UserControl {

    internal readonly RelationType Type;
    internal readonly string RelationName;
    internal Relation Relation;

    public UserControlRelation(string handle, RelationType relationType, Relation relation) {
      InitializeComponent();
      RelationName = handle;
      Relation = relation;
      Type = relationType;
      LabelOrganization.Visible = relationType == RelationType.Organization;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelHandle.Text = RelationName;
      UpdateRelation(Relation);
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

    public void UpdateRelation(Relation relation) {
      Relation = relation;
      LabelRelation.BackColor = FormHandleQuery.GetRelationColor(relation);
    }

  }

}
