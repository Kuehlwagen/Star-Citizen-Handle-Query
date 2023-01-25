using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlRelation : UserControl {

    internal readonly string HandleName;
    internal readonly Relation HandleRelation;

    public UserControlRelation(string handle, Relation relation) {
      InitializeComponent();
      HandleName = handle;
      HandleRelation = relation;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelHandle.Text = HandleName;
      UpdateRelation(HandleRelation);
      AddMouseEvents();
    }

    private void AddMouseEvents() {
      LabelRelation.MouseClick += Handle_MouseClick;
      LabelRelation.Cursor = Cursors.Hand;
      LabelHandle.MouseClick += Handle_MouseClick;
      LabelHandle.Cursor = Cursors.Hand;
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormRelations).Owner as FormHandleQuery).SetAndQueryHandle(HandleName);
    }

    public void UpdateRelation(Relation relation) {
      LabelRelation.BackColor = FormHandleQuery.GetRelationColor(relation);
    }

  }

}
