using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLog : UserControl {

    private readonly LogMonitorInfo LogInfoItem;

    public UserControlLog(LogMonitorInfo logInfo) {
      InitializeComponent();
      LogInfoItem = logInfo;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelTime.Text = LogInfoItem.Date.ToString("HH:mm");
      LabelHandle.Text = LogInfoItem.Handle;

      Image img;
      if (LogInfoItem.IsCriminalArrest) {
        img = Properties.Resources.BountyHunting;
      } else if (LogInfoItem.IsCorpseEnabled) {
        img = Properties.Resources.Medical;
      } else {
        img = Properties.Resources.Dead;
      }
      PictureBoxEvent.Image = img;

      if (LogInfoItem.IsLocalInventoryAvailable) {
        PictureBoxLocalInventory.Image = Properties.Resources.Resource;
      }
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(LogInfoItem.Handle);
    }
  }

}
