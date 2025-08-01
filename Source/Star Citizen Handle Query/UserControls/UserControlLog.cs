using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLog : UserControl {

    internal readonly LogMonitorInfo LogInfoItem;
    private readonly System.Windows.Forms.Timer TimerRemoveControl = new();
    private string ToolTipText = string.Empty;

    public UserControlLog(LogMonitorInfo logInfo, Settings programSettings) {
      InitializeComponent();

      // Farben setzen
      if (programSettings.Colors != null) {
        BackColor = programSettings.Colors.AppBackColor;
        ForeColor = programSettings.Colors.AppForeColor;
        LabelTime.ForeColor = programSettings.Colors.AppForeColorInactive;
      }

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
          if (LogInfoItem.IsLocationInfo) {
            SetToolTip(LogInfoItem.Value);
          }
          AddMouseEvents();
          break;
        case LogType.LoadingScreenDuration:
          PictureBoxLeft.Image = Properties.Resources.Info;
          LabelText.Text = $"Loading screen: {LogInfoItem.Value}s";
          break;
        case LogType.ActorDeath:
          PictureBoxLeft.Image = Properties.Resources.Dead;
          LabelText.Text = LogInfoItem.Handle;
          SetToolTip(LogInfoItem.Value);
          if (LogInfoItem.RelationValue > RelationValue.NotAssigned) {
            LabelRelation.Visible = LogInfoItem.RelationValue > RelationValue.NotAssigned;
            LabelRelation.BackColor = FormHandleQuery.GetRelationColor(LogInfoItem.RelationValue);
          }
          AddMouseEvents();
          break;
      }

      TimerRemoveControl.Enabled = true;
    }

    public void UpdateInfo(LogMonitorInfo info) {
      if (info != null && info.IsValid) {
        switch (info.LogType) {
          case LogType.Corpse:
            Image img;
            if (info.IsCriminalArrest) {
              img = Properties.Resources.BountyHunting;
            } else if (info.IsCorpseEnabled) {
              img = Properties.Resources.Medical;
            } else {
              img = Properties.Resources.Dead;
            }
            PictureBoxLeft.Image = img;
            if (info.RelationValue > RelationValue.NotAssigned) {
              LabelRelation.Visible = info.RelationValue > RelationValue.NotAssigned;
              LabelRelation.BackColor = FormHandleQuery.GetRelationColor(info.RelationValue);
            }
            if (info.IsLocalInventoryAvailable) {
              PictureBoxRight.Image = Properties.Resources.Resource;
            }
            if (info.IsLocationInfo) {
              SetToolTip(info.Value);
            }
            break;
          case LogType.ActorDeath:
            SetToolTip(info.Value);
            break;
        }
      }
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
      switch (e.Button) {
        case MouseButtons.Left:
          ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(LogInfoItem.Handle);
          break;
        case MouseButtons.Right:
          ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(LogInfoItem.LogType == LogType.ActorDeath ? LogInfoItem.Key : LogInfoItem.Handle);
          break;
      }
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

    public void SetToolTip(string tooltip) {
      if (!LabelText.Text.StartsWith('⭐')) {
        LabelText.Text = $"⭐ {LabelText.Text}";
      }
      ToolTipText = $"{ToolTipText}{Environment.NewLine}{tooltip}".Trim();
      (Parent.Parent as FormLogMonitor).SetTooltip(PictureBoxLeft, ToolTipText);
      (Parent.Parent as FormLogMonitor).SetTooltip(LabelTime, ToolTipText);
      (Parent.Parent as FormLogMonitor).SetTooltip(LabelRelation, ToolTipText);
      (Parent.Parent as FormLogMonitor).SetTooltip(LabelText, ToolTipText);
      (Parent.Parent as FormLogMonitor).SetTooltip(PictureBoxRight, ToolTipText);
    }

  }

}
