using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlRelation : UserControl {

    internal readonly HandleInfo HandleInfoItem;

    public UserControlRelation(HandleInfo handleInfo) {
      InitializeComponent();
      HandleInfoItem = handleInfo;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelHandle.Text = HandleInfoItem.Profile.Handle;
      PictureBoxLeft.BackColor = FormHandleQuery.GetRelationColor(HandleInfoItem.Relation);
      AddMouseEvents();
    }

    private void AddMouseEvents() {
      PictureBoxLeft.MouseClick += Handle_MouseClick;
      PictureBoxLeft.Cursor = Cursors.Hand;
      LabelHandle.MouseClick += Handle_MouseClick;
      LabelHandle.Cursor = Cursors.Hand;
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormRelations).Owner as FormHandleQuery).SetAndQueryHandle(HandleInfoItem.Profile.Handle);
    }

  }

}
