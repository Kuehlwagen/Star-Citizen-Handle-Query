using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlCorpse : UserControl {

    private readonly CorpseMonitorInfo CorpseInfoItem;

    public UserControlCorpse(CorpseMonitorInfo corpseInfo) {
      InitializeComponent();
      CorpseInfoItem = corpseInfo;
    }

    private void UserControlCorpse_Load(object sender, EventArgs e) {
      LabelTime.Text = CorpseInfoItem.Date.ToString("HH:mm");
      LabelHandle.Text = CorpseInfoItem.Handle;

      Image img;
      if (CorpseInfoItem.IsCriminalArrest) {
        img = Properties.Resources.BountyHunting;
      } else if (CorpseInfoItem.CorpseEnabled) {
        img = Properties.Resources.Medical;
      } else {
        img = Properties.Resources.Dead;
      }
      PictureBoxEvent.Image = img;

      if (CorpseInfoItem.IsLocalInventory) {
        PictureBoxLocalInventory.Image = Properties.Resources.Resource;
      }
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(CorpseInfoItem.Handle);
    }
  }

}
