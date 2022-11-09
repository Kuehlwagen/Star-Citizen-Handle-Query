using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlSAR : UserControl {

    private readonly SARMonitorInfo SARInfoItem;

    public UserControlSAR(SARMonitorInfo sarInfo) {
      InitializeComponent();
      SARInfoItem = sarInfo;
    }

    private void UserControlSAR_Load(object sender, EventArgs e) {
      LabelTime.Text = SARInfoItem.Date.ToString("HH:mm");
      LabelHandle.Text = SARInfoItem.Handle;

      Image img;
      if (SARInfoItem.IsCriminalArrest) {
        img = Properties.Resources.BountyHunting;
      } else if (SARInfoItem.CorpseEnabled) {
        img = Properties.Resources.Medical;
      } else {
        img = Properties.Resources.Dead;
      }
      PictureBoxEvent.Image = img;

      if (SARInfoItem.IsLocalInventory) {
        PictureBoxLocalInventory.Image = Properties.Resources.Resource;
      }
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormSARMonitor).Owner as FormHandleQuery).SetAndQueryHandle(SARInfoItem.Handle);
    }
  }

}
