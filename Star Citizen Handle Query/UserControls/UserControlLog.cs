﻿using Star_Citizen_Handle_Query.Dialogs;
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

      switch (LogInfoItem.LogType) {
        case LogType.Corpse:
          LabelText.Text = LogInfoItem.Handle;
          Image img;
          if (LogInfoItem.IsCriminalArrest) {
            img = Properties.Resources.BountyHunting;
          } else if (LogInfoItem.IsCorpseEnabled) {
            img = Properties.Resources.Medical;
          } else {
            img = Properties.Resources.Dead;
          }
          PictureBoxLeft.Image = img;
          if (LogInfoItem.IsLocalInventoryAvailable) {
            PictureBoxRight.Image = Properties.Resources.Resource;
          }
          AddMouseEvents();
          break;
      }

    }

    private void AddMouseEvents() {
      PictureBoxLeft.MouseClick += Handle_MouseClick;
      PictureBoxLeft.Cursor = Cursors.Hand;
      LabelTime.MouseClick += Handle_MouseClick;
      LabelTime.Cursor = Cursors.Hand;
      LabelText.MouseClick += Handle_MouseClick;
      LabelText.Cursor = Cursors.Hand;
      PictureBoxRight.MouseClick += Handle_MouseClick;
      PictureBoxRight.Cursor = Cursors.Hand;
    }

    private void Handle_MouseClick(object sender, MouseEventArgs e) {
      ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(LogInfoItem.Handle);
    }

  }

}
