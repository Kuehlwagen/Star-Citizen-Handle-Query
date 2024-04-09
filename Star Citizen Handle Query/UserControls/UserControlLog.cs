using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLog : UserControl {

    internal readonly LogMonitorInfo LogInfoItem;
    private readonly System.Windows.Forms.Timer TimerRemoveControl = new();

    public UserControlLog(LogMonitorInfo logInfo, Settings programSettings) {
      InitializeComponent();
      LogInfoItem = logInfo;
      if (programSettings.LogMonitor.EntryDisplayDurationInMinutes > 0) {
        TimerRemoveControl.Interval = programSettings.LogMonitor.EntryDisplayDurationInMinutes * 60000;
        TimerRemoveControl.Tick += TimerRemoveControl_Tick;
        TimerRemoveControl.Start();
      }
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
          if (LogInfoItem.RelationValue > RelationValue.NotAssigned) {
            LabelRelation.Visible = LogInfoItem.RelationValue > RelationValue.NotAssigned;
            LabelRelation.BackColor = FormHandleQuery.GetRelationColor(LogInfoItem.RelationValue);
          }
          if (LogInfoItem.IsLocalInventoryAvailable) {
            PictureBoxRight.Image = Properties.Resources.Resource;
          }
          AddMouseEvents();
          break;
        case LogType.LoadingScreenDuration:
          PictureBoxLeft.Image = Properties.Resources.Info;
          LabelText.Text = $"Loading screen: {LogInfoItem.Info}s";
          break;
      }

      TimerRemoveControl.Enabled = true;
    }

    private void AddMouseEvents() {
      PictureBoxLeft.MouseClick += Handle_MouseClick;
      PictureBoxLeft.Cursor = Cursors.Hand;
      LabelRelation.MouseClick += Handle_MouseClick;
      LabelRelation.Cursor = Cursors.Hand;
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

    private void TimerRemoveControl_Tick(object sender, EventArgs e) {
      StopTimer();
      (Parent.Parent as FormLogMonitor).RemoveControl(this);
    }

    public void StopTimer() {
      TimerRemoveControl.Stop();
    }

    public void ResetTimer() {
      TimerRemoveControl.Stop();
      TimerRemoveControl.Start();
    }

    public void SetText(string info, bool resetTimer = false) {
      LabelText.Text = info;
      if (resetTimer) {
        LabelTime.Text = DateTime.Now.ToString("HH:mm");
        ResetTimer();
      }
    }

  }

}
