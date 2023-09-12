using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLogMonitor : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private bool Cancel = false;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;

    private readonly Regex RgxCorpse = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)>.+<Corpse> Player '(?<Handle>[\w_\-]+)'.+IsCorpseEnabled: (?<Corpse>\w{2,3})[,\.] ?(?<Info>[\w\s]*)\.?$",
     RegexOptions.Compiled);
    private readonly Regex RgxLoadingScreenDuration = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)>\sLoading screen for.+closed after (?<Seconds>\d+\.\d+) seconds$",
      RegexOptions.Compiled);
    private readonly Regex RgxCompile = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)>\s*Compile\s*(?<Type>\w+)@\w+\((?<Type2>\w+)\)",
      RegexOptions.Compiled);
    private readonly Regex RgxQT = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)>\s--\sEntity Trying To QT:\s(?<Handle>.+)$",
      RegexOptions.Compiled);

    public FormLogMonitor(Settings programSettings, Translation translation) {
      InitializeComponent();
      ProgramSettings = programSettings;
      ProgramTranslation = translation;

      // Pr�fen, ob die Programm-Einstellungen valide sind
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLong(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLong(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }
      }

      // �bersetzung laden
      SetTranslation();
    }

    private void SetTranslation() {
      // Pr�fen, ob die �bersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        SetTitle();
      }
    }

    protected override CreateParams CreateParams {
      // Fenster von Alt + Tab verbergen
      get {
        CreateParams cp = base.CreateParams;
        // turn on WS_EX_TOOLWINDOW style bit
        cp.ExStyle |= 0x80;
        return cp;
      }
    }

    public void MoveWindowToDefaultLocation() {
      CenterToScreen();
      Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, 125);
    }

    private void LabelTitle_MouseDown(object sender, MouseEventArgs e) {
      if (!WindowLocked) {
        switch (e.Button) {
          case MouseButtons.Left:
            _ = User32Wrappers.ReleaseCapture();
            _ = User32Wrappers.SendMessage(Handle, User32Wrappers.WM_NCLBUTTONDOWN, User32Wrappers.HT_CAPTION, 0);
            break;
          case MouseButtons.Middle:
            MoveWindowToDefaultLocation();
            break;
        }
      }
    }

    private void LabelTitle_MouseCaptureChanged(object sender, EventArgs e) {
      SetTitleLableCursor();
    }

    private void LabelTitle_MouseMove(object sender, MouseEventArgs e) {
      SetTitleLableCursor();
    }

    private void SetTitleLableCursor() {
      LabelTitle.Cursor = !WindowLocked ? Cursors.SizeAll : Cursors.Default;
    }

    public void LockUnlockWindow(bool locked) {
      WindowLocked = locked;
    }

    private void FormLogMonitor_Shown(object sender, EventArgs e) {
      Height = 31;
      StartMonitor();
    }

    private void StartMonitor() {
      Task.Run(() => {
        while (!Cancel) {

          try {

            Invoke(new Action(() => ChangeStatus(Status.Inactive)));

            string processName = "StarCitizen_Launcher";
            Process[] processes = Process.GetProcessesByName(processName);
            Process processSC = null;
            if (processes?.Length > 0) {
              processSC = Process.GetProcessesByName(processName)[0];
            }

#if DEBUG
            if (processSC == null) {
              Invoke(new Action(() => ClearLogInfos()));
            }
#endif

            if (processSC != null) {

              Invoke(new Action(() => ClearLogInfos()));
              Invoke(new Action(() => ChangeStatus(Status.Initializing)));

              string scLogPath = Path.Combine(Path.GetDirectoryName(processSC.Modules[0].FileName), $@"Game.log");
              if (File.Exists(scLogPath)) {

                Encoding encoding = Encoding.UTF8;
                StreamReader logReader = new(new FileStream(scLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), encoding);
                long currentPosition = logReader.BaseStream.Length;
                long lastMaxOffset = currentPosition;

                while (!Cancel && processSC != null && !processSC.HasExited) {

                  Application.DoEvents();
                  Thread.Sleep(100);

                  string livePtuFolder = Path.GetFileName(Path.GetDirectoryName(scLogPath));
                  Invoke(new Action(() => SetTitle(livePtuFolder)));

                  Invoke(new Action(() => ChangeStatus(Status.Monitoring)));

                  logReader.Close();
                  logReader = new(new FileStream(scLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), encoding);

                  currentPosition = logReader.BaseStream.Length;

                  if (currentPosition == lastMaxOffset) {
                    continue;
                  } else if (currentPosition < lastMaxOffset) {
                    lastMaxOffset = currentPosition;
                    continue;
                  }

                  logReader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);
                  Invoke(new Action(() => AddLogInfo(CheckRegEx(logReader.ReadToEnd()))));

                  currentPosition = logReader.BaseStream.Position;
                  lastMaxOffset = currentPosition;

                }

                SetTitle();

              }

            }

          } catch { }

          Application.DoEvents();
          Thread.Sleep(TimeSpan.FromSeconds(1));
        }
      });
    }

    private void AddLogInfo(List<LogMonitorInfo> logInfos) {
      foreach (LogMonitorInfo logInfo in logInfos) {
        if (logInfo.IsValid) {
          if (logInfo.LogType == LogType.Compile) {
            if (PanelLogInfo.Controls.Count > 0 && PanelLogInfo.Controls[0] is UserControlLog ucl && ucl.LogInfoItem.LogType == LogType.Compile) {
              ucl.SetText($"Compile {logInfo.Info}", true);
            } else {
              UserControlLog uc = new(logInfo, ProgramSettings);
              if (PanelLogInfo.Controls.Count == ProgramSettings.LogMonitor.EntriesMax) {
                RemoveControl(PanelLogInfo.Controls[1] as UserControlLog);
              }
              PanelLogInfo.Controls.Add(uc);
              PanelLogInfo.Controls.SetChildIndex(uc, 0);
            }
          } else if (PanelLogInfo.Controls.Count == 0 ||
            (PanelLogInfo.Controls[PanelLogInfo.Controls.Count - 1] is UserControlLog ucl) && !logInfo.Equals(ucl.LogInfoItem)) {
            UserControlLog uc = new(logInfo, ProgramSettings);
            if (PanelLogInfo.Controls.Count == ProgramSettings.LogMonitor.EntriesMax) {
              int removeIndex = PanelLogInfo.Controls[0] is UserControlLog ucl2 && ucl2.LogInfoItem.LogType != LogType.Compile ? 0 : 1;
              RemoveControl(PanelLogInfo.Controls[removeIndex] as UserControlLog);
            }
            PanelLogInfo.Controls.Add(uc);
          }

        }
      }
    }

    private void ClearLogInfos() {
#if DEBUG
      if (PanelLogInfo.Controls.Count == 0) {
        AddLogInfo(new List<LogMonitorInfo>() {
          new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "there is a local inventory", "Yes"),
          new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "DudeCrocker", additionalInfo: "Yes"),
          new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "LanceFlair"),
          new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Gentle81", "criminal arrest"),
          new(LogType.HandleAction, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "LanceFlair", "LanceFlair", icon: Properties.Resources.Ship),
          new(LogType.Compile, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), info: "Compile Test"),
          new(LogType.LoadingScreenDuration, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), info: "15")
        });
      }
#else
      SetTitle();
      if (PanelLogInfo.Controls.Count > 0) {
        List<UserControlLog> ctrls = new(PanelLogInfo.Controls.OfType<UserControlLog>());
        PanelLogInfo.Controls.Clear();
        foreach (UserControlLog c in ctrls) {
          c.StopTimer();
          c.Dispose();
        }
      }
#endif
    }

    private void ChangeStatus(Status status) {
      Image imgStatus = Properties.Resources.StatusRed;

      switch (status) {
        case Status.Initializing:
          imgStatus = Properties.Resources.StatusOrange;
          break;
        case Status.Monitoring:
          imgStatus = Properties.Resources.StatusGreen;
          break;
      }

      if (PictureBoxStatus.Image != imgStatus) {
        PictureBoxStatus.Image = imgStatus;
      }
    }

    private List<LogMonitorInfo> CheckRegEx(string input) {
      List<LogMonitorInfo> rtnVal = input != null ? new() : null;

      if (rtnVal != null) {
        try {
          Match match = null;
          foreach (string line in input.Split(Environment.NewLine)) {
            if (ProgramSettings.LogMonitor.Filter.Corpse) {
              match = RgxCorpse.Match(line);
              if (match != null && match.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.Corpse,
                  match.Groups["Date"].Value,
                  match.Groups["Handle"].Value,
                  match.Groups["Info"].Value,
                  match.Groups["Corpse"].Value));
                continue;
              }
            }
            if (ProgramSettings.LogMonitor.Filter.LoadingScreenDuration) {
              match = RgxLoadingScreenDuration.Match(line);
              if (match != null && match.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.LoadingScreenDuration,
                  match.Groups["Date"].Value,
                  info: match.Groups["Seconds"].Value));
                continue;
              }
            }
            if (ProgramSettings.LogMonitor.Filter.QT) {
              match = RgxQT.Match(line);
              if (match != null && match.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.HandleAction,
                  match.Groups["Date"].Value,
                  match.Groups["Handle"].Value,
                  match.Groups["Handle"].Value));
                continue;
              }
            }
            if (ProgramSettings.LogMonitor.Filter.Compile) {
              match = RgxCompile.Match(line);
              if (match != null && match.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.Compile,
                  match.Groups["Date"].Value,
                  info: $"{match.Groups["Type"].Value} {match.Groups["Type2"].Value}"));
                continue;
              }
            }
          }
        } catch { }
      }

      return rtnVal;
    }

    private void FormLogMonitor_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
      } else {
        Cancel = true;
      }
    }

    public enum Status {
      Monitoring,
      Initializing,
      Inactive
    }

    private void PictureBoxClearAll_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        ClearLogInfos();
      }
    }

    private void SetTitle(string livePtu = null) {
      LabelTitle.Text = $"{ProgramTranslation.Log_Monitor.Title}{(livePtu != null ? $" - {livePtu}" : string.Empty)}";
    }

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      FormHandleQuery.CheckSnap(this, Location);
    }

    private void PanelLogInfo_ControlAdded(object sender, ControlEventArgs e) {
      if (PanelLogInfo.Controls.Count == 1) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll;
        PictureBoxClearAll.Cursor = Cursors.Hand;
      }
      if (PanelLogInfo.Controls.Count <= ProgramSettings.LogMonitor.EntriesMax) {
        Height += e.Control.Height + 2;
      }
    }

    private void PanelLogInfo_ControlRemoved(object sender, ControlEventArgs e) {
      Height -= e.Control.Height + 2;
      if (PanelLogInfo.Controls.Count == 0) {
        PictureBoxClearAll.MouseClick -= PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
    }

    public void RemoveControl(UserControlLog uc) {
      uc.StopTimer();
      PanelLogInfo.Controls.Remove(uc);
      uc.Dispose();
    }

  }

}
