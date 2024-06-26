﻿using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlRelation : UserControl {

    internal readonly RelationType Type;
    internal readonly string RelationName;
    internal RelationValue Relation;
    internal string Comment;

    public UserControlRelation(string handle, RelationType relationType, RelationValue relation, string comment = null) {
      InitializeComponent();
      RelationName = handle;
      Relation = relation;
      Type = relationType;
      LabelOrganization.Visible = relationType == RelationType.Organization;
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

  }

}
