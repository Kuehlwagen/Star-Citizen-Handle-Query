using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLogMonitor : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private bool Cancel = false;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;

    private readonly Regex RegexCorpse = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})\.\d{3}Z>.+<Corpse> Player '(?<Handle>[\w_\-]+)'.+IsCorpseEnabled: (?<Corpse>\w{2,3})[,\.] ?(?<Info>[\w\s]*)\.?$",
     RegexOptions.Compiled);

    public FormLogMonitor(Settings programSettings, Translation translation) {
      InitializeComponent();
      ProgramSettings = programSettings;
      ProgramTranslation = translation;

      // Prüfen, ob die Programm-Einstellungen valide sind
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLong(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLong(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }
      }

      // Übersetzung laden
      SetTranslation();
    }

    private void SetTranslation() {
      // Prüfen, ob die Übersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        LabelTitle.Text = ProgramTranslation.Log_Monitor.Title;
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
      Size = new Size(Width, 31);
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

              }

            }

          } catch { }

          Application.DoEvents();
          Thread.Sleep(TimeSpan.FromSeconds(1));
        }
      });
    }

    private void AddLogInfo(List<CorpseMonitorInfo> lines) {
      foreach (CorpseMonitorInfo line in lines) {
        if (line.IsValid) {
          UserControlCorpse uc = new(line);
          if (PanelLogInfo.Controls.Count == ProgramSettings.LogMonitor.EntriesMax) {
            PanelLogInfo.Controls.RemoveAt(0);
          } else {
            Size = new Size(Width, Height + uc.Height + 2);
          }
          PanelLogInfo.Controls.Add(uc);
          if (PanelLogInfo.Controls.Count == 1) {
            PictureBoxClearAll.Click += PictureBoxClearAll_Click;
            PictureBoxClearAll.Image = Properties.Resources.ClearAll;
            PictureBoxClearAll.Cursor = Cursors.Hand;
          }
        }
      }
    }

    private void ClearLogInfos() {
      if (PanelLogInfo.Controls.Count > 0) {
        PanelLogInfo.Controls.Clear();
        Size = new Size(Width, 60);
        PictureBoxClearAll.Click -= PictureBoxClearAll_Click;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
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

    private List<CorpseMonitorInfo> CheckRegEx(string input) {
      List<CorpseMonitorInfo> rtnVal = input != null ? new() : null;

      if (rtnVal != null) {
        try {
          foreach (string line in input.Split(Environment.NewLine)) {
            Match match = RegexCorpse.Match(line);
            if (match != null && match.Success) {
              rtnVal.Add(new CorpseMonitorInfo() {
                Date = DateTime.Parse(match.Groups["Date"].Value, CultureInfo.InvariantCulture).ToLocalTime(),
                Handle = match.Groups["Handle"].Value,
                CorpseEnabled = match.Groups["Corpse"].Value == "Yes",
                Info = match.Groups["Info"].Value
              });
            }
          }
        } catch { }
      }

      return rtnVal;
    }

    private void FormLogMonitor_FormClosing(object sender, FormClosingEventArgs e) {
      Cancel = true;
    }

    public enum Status {
      Monitoring,
      Initializing,
      Inactive
    }

    private void PictureBoxClearAll_Click(object sender, EventArgs e) {
      ClearLogInfos();
    }

  }

}
