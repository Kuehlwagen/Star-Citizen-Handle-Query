using SCHQ_Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using System.Drawing.Drawing2D;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLog : UserControl {

    internal LogMonitorInfo LogInfoItem;
    private readonly System.Windows.Forms.Timer TimerRemoveControl = new();
    private string ToolTipText = string.Empty;
    private readonly Settings ProgramSettings;

    public UserControlLog(LogMonitorInfo logInfo, Settings programSettings) {
      InitializeComponent();

      ProgramSettings = programSettings;

      // Farben setzen
      if (ProgramSettings.Colors != null) {
        BackColor = ProgramSettings.Colors.AppBackColor;
        ForeColor = ProgramSettings.Colors.AppForeColor;
        LabelTime.BackColor = ProgramSettings.Colors.AppBackColor;
        LabelTime.ForeColor = ProgramSettings.Colors.AppForeColorInactive;
      }

      LogInfoItem = logInfo;
      if (ProgramSettings.LogMonitor.EntryDisplayDurationInMinutes > 0) {
        TimerRemoveControl.Interval = ProgramSettings.LogMonitor.EntryDisplayDurationInMinutes * 60000;
        TimerRemoveControl.Tick += TimerRemoveControl_Tick;
        TimerRemoveControl.Start();
      }
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelTime.Text = LogInfoItem.Date.ToString("HH:mm");

      switch (LogInfoItem.LogType) {
        case LogType.Corpse:
          LabelText.Text = LogInfoItem.Handle;
          PictureBoxLeft.Invalidate();
          if (LogInfoItem.RelationValue > RelationValue.NotAssigned) {
            LabelRelation.Visible = LogInfoItem.RelationValue > RelationValue.NotAssigned;
            LabelRelation.BackColor = FormHandleQuery.GetRelationColor(ProgramSettings, LogInfoItem.RelationValue);
          }
          if (LogInfoItem.IsLocationInfo) {
            SetToolTip(LogInfoItem.Value);
          }
          AddMouseEvents();
          break;
        case LogType.LoadingScreenDuration:
          LabelText.Text = $"Loading screen: {LogInfoItem.Value}s";
          break;    
        case LogType.OwnHandleInfo:
          InitLogItemLayout();
          LabelText.Text = $"Own handle is: {Environment.NewLine}{LogInfoItem.Handle}";
          break;
        case LogType.ActorDeath:
          InitLogItemLayout();
          SetAndQueryHandle(LogInfoItem.Handle);
          break;
        case LogType.HostilityEvent:
          InitLogItemLayout();
          // Handle-Suche direkt durchführen
          // hostility events handles nur suchen, wenn man selbst betroffen ist; da diese events auch von anderen spielern geloggt werden
          if (ProgramSettings.LogMonitor.Filter.OwnHandle.Equals(LogInfoItem.Handle)) {
              SetAndQueryHandle(LogInfoItem.Key);
          } else if (ProgramSettings.LogMonitor.Filter.OwnHandle.Equals(LogInfoItem.Key)) {
              SetAndQueryHandle(LogInfoItem.Handle);
          }
          break;
      }

      TimerRemoveControl.Enabled = true;
    }

    private void InitLogItemLayout() {
      LabelText.Text = $"{LogInfoItem.Handle}{Environment.NewLine}{LogInfoItem.Key}";
      Height += LabelText.Height;
      LabelRelation.Height += LabelText.Height;
      LabelText.Height *= 2;
      LabelTime.Text += $"{Environment.NewLine}❌";
      LabelTime.Height *= 2;
      SetToolTip(LogInfoItem.Value);
      if (LogInfoItem.RelationValue > RelationValue.NotAssigned) {
        LabelRelation.Visible = LogInfoItem.RelationValue > RelationValue.NotAssigned;
        LabelRelation.BackColor = FormHandleQuery.GetRelationColor(ProgramSettings, LogInfoItem.RelationValue);
      }
      AddMouseEvents();
    }

    public void UpdateInfo(LogMonitorInfo info) {
      if (info != null && info.IsValid) {
        switch (info.LogType) {
          case LogType.Corpse:
            LogInfoItem = info;
            PictureBoxLeft.Invalidate();
            if (info.RelationValue > RelationValue.NotAssigned) {
              LabelRelation.Visible = info.RelationValue > RelationValue.NotAssigned;
              LabelRelation.BackColor = FormHandleQuery.GetRelationColor(ProgramSettings, info.RelationValue);
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
          SetAndQueryHandle(LogInfoItem.Handle);
          break;
        case MouseButtons.Right:
          SetAndQueryHandle(LogInfoItem.LogType == LogType.ActorDeath || LogInfoItem.LogType == LogType.HostilityEvent ? LogInfoItem.Key : LogInfoItem.Handle);
          break;
      }
    }

    private void SetAndQueryHandle(string handle) {
      ((Parent.Parent as FormLogMonitor).Owner as FormHandleQuery).SetAndQueryHandle(handle);
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

    private void PictureBoxLeft_Paint(object sender, PaintEventArgs e) {
      PaintLeftIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive);
    }

    private void PaintLeftIcon(Graphics g, Color foreColor, Color foreColorInactive) {
      using var bgPen = new Pen(foreColorInactive, 2.0F);
      using var fgPen = new Pen(foreColor, 1.0F);

      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.DrawEllipse(bgPen, 2, 2, 16, 16);
      g.DrawEllipse(fgPen, 2, 2, 16, 16);

      switch (LogInfoItem.LogType) {
        case LogType.Corpse:
          if (LogInfoItem.IsCorpseEnabled) {
            g.DrawLine(bgPen, 10.25F, 6, 10.25F, 14);
            g.DrawLine(fgPen, 10.25F, 6, 10.25F, 14);
            g.DrawLine(bgPen, 6, 10.25F, 14, 10.25F);
            g.DrawLine(fgPen, 6, 10.25F, 14, 10.25F);
          } else if (LogInfoItem.IsCriminalArrest) {
            g.DrawLine(bgPen, 10.25F, 3, 10.25F, 6);
            g.DrawLine(fgPen, 10.25F, 3, 10.25F, 6);
            g.DrawLine(bgPen, 10.25F, 14, 10.25F, 17);
            g.DrawLine(fgPen, 10.25F, 14, 10.25F, 17);
            g.DrawLine(bgPen, 2, 10.25F, 5, 10.25F);
            g.DrawLine(fgPen, 2, 10.25F, 5, 10.25F);
            g.DrawLine(bgPen, 14, 10.25F, 17, 10.25F);
            g.DrawLine(fgPen, 14, 10.25F, 17, 10.25F);
            g.DrawEllipse(bgPen, 8.25F, 8.25F, 3.5F, 3.5F);
            g.DrawEllipse(fgPen, 8.25F, 8.25F, 3.5F, 3.5F);
          } else {
            DrawDeathIcon(g, fgPen, bgPen);
          }
          break;
        case LogType.ActorDeath:
          DrawDeathIcon(g, fgPen, bgPen);
          break;
        case LogType.LoadingScreenDuration:
          g.FillEllipse(bgPen.Brush, 9, 5, 2.25F, 2.25F);
          g.FillEllipse(fgPen.Brush, 9, 5, 2.25F, 2.25F);
          g.DrawLine(bgPen, 10.25F, 9.25F, 10.25F, 15);
          g.DrawLine(fgPen, 10.25F, 9.25F, 10.25F, 15);
          break;
        case LogType.HostilityEvent:
          g.DrawEllipse(bgPen, 5, 6.5F, 10, 7);
          g.DrawEllipse(fgPen, 5, 6.5F, 10, 7);
          g.DrawEllipse(bgPen, 8, 8, 4, 4);
          g.DrawEllipse(fgPen, 8, 8, 4, 4);
          break;
      }
    }

    private static void DrawDeathIcon(Graphics g, Pen fgPen, Pen bgPen) {
      g.DrawLine(bgPen, 6.5F, 6.5F, 9, 9);
      g.DrawLine(fgPen, 6.5F, 6.5F, 9, 9);
      g.DrawLine(bgPen, 6.5F, 9, 9, 6.5F);
      g.DrawLine(fgPen, 6.5F, 9, 9, 6.5F);
      g.DrawLine(bgPen, 11.5F, 6.5F, 14, 9);
      g.DrawLine(fgPen, 11.5F, 6.5F, 14, 9);
      g.DrawLine(bgPen, 11.5F, 9, 14, 6.5F);
      g.DrawLine(fgPen, 11.5F, 9, 14, 6.5F);
      g.DrawEllipse(bgPen, 8.25F, 11, 3.5F, 3.5F);
      g.DrawEllipse(fgPen, 8.25F, 11, 3.5F, 3.5F);
    }

    private void PictureBoxRight_Paint(object sender, PaintEventArgs e) {
      PaintRightIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive);
    }

    private void PaintRightIcon(Graphics g, Color foreColor, Color foreColorInactive) {
      if (LogInfoItem.IsLocalInventoryAvailable) {
        using var bgPen = new Pen(foreColorInactive, 2.0F);
        using var fgPen = new Pen(foreColor, 1.0F);

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawRectangle(bgPen, 2, 8, 10, 10);
        g.DrawLine(bgPen, 12, 8, 16, 3);
        g.DrawLines(bgPen, [
          new PointF(2, 8),
          new PointF(6, 3),
          new PointF(16, 3),
          new PointF(16, 13),
          new PointF(12, 18)
        ]);
        g.DrawRectangle(fgPen, 2, 8, 10, 10);
        g.DrawLines(fgPen, [
          new PointF(2, 8),
          new PointF(6, 3),
          new PointF(16, 3),
          new PointF(16, 13),
          new PointF(12, 18)
        ]);
        g.DrawLine(fgPen, 12, 8, 16, 3);
      }
    }

  }

}
