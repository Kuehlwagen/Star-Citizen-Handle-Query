using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormSARMonitor : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private bool Cancel = false;
    private StreamReader LogReader;
    private long LastMaxOffset = 0;
    private readonly Settings ProgramSettings;

    private readonly Regex RegexSAR = new(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})\.\d{3}Z>.+<Corpse> Player '(?<Handle>[\w_\-]+)'.+IsCorpseEnabled: (?<Corpse>\w{2,3})[,\.] ?(?<Info>[\w\s]*)\.?$",
      RegexOptions.Compiled);

    public FormSARMonitor(Settings programSettings = null) {
      InitializeComponent();
      ProgramSettings = programSettings;

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

    private void FormSARMonitor_Shown(object sender, EventArgs e) {
      Size = new Size(Width, 31);

      Task.Run(() => {
        while (!Cancel) {

          Invoke(new Action(() => ChangeStatus(Status.Inactive)));

          Process[] processes = Process.GetProcessesByName("StarCitizen_Launcher");
          Process processSC = null;
          if (processes?.Length > 0) {
            processSC = Process.GetProcessesByName("StarCitizen_Launcher")[0];
          }

          if (processSC != null) {

            Invoke(new Action(() => ChangeStatus(Status.Initializing)));

            string scLogPath = Path.Combine(Path.GetDirectoryName(processSC.Modules[0].FileName), $@"Game.log");
            if (File.Exists(scLogPath)) {

              LogReader = new StreamReader(new FileStream(scLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.UTF8);
              LastMaxOffset = LogReader.BaseStream.Length;

              while (!Cancel && processSC != null && !processSC.HasExited) {

                Application.DoEvents();
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Invoke(new Action(() => ChangeStatus(Status.Monitoring)));

                if (LogReader.BaseStream.Length == LastMaxOffset) {
                  continue;
                }

                LogReader.BaseStream.Seek(LastMaxOffset < LogReader.BaseStream.Length ? LastMaxOffset : 0, SeekOrigin.Begin);

                SARMonitorInfo logInfo;
                while ((logInfo = CheckRegEx(LogReader.ReadLine())) != null && logInfo.IsValid) {
                  Invoke(new Action(() => AddSARInfo(logInfo)));
                }

                LastMaxOffset = LogReader.BaseStream.Position;

              }

            }

          }

          Application.DoEvents();
          Thread.Sleep(TimeSpan.FromSeconds(1));
        }
      });
    }

    private void AddSARInfo(SARMonitorInfo line) {
      if (PanelSARInfo.Controls.Count == ProgramSettings.SARMonitor.EntriesMax) {
        PanelSARInfo.Controls.RemoveAt(0);
      }
      UserControlSAR uc = new(line);
      Size = new Size(Width, Height + uc.Height + 2);
      PanelSARInfo.Controls.Add(uc);
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

    private SARMonitorInfo CheckRegEx(string input) {
      SARMonitorInfo rtnVal = input != null ? new SARMonitorInfo() : null;

      try {
        Match match = RegexSAR.Match(input);
        if (match.Success) {
          if (match.Groups.Count == 5 &&
            match.Groups.ContainsKey("Date") &&
            match.Groups.ContainsKey("Handle") &&
            match.Groups.ContainsKey("Corpse") &&
            match.Groups.ContainsKey("Info")) {

            rtnVal = new SARMonitorInfo() {
              Date = DateTime.Parse(match.Groups["Date"].Value, CultureInfo.InvariantCulture).ToLocalTime(),
              Handle = match.Groups["Handle"].Value,
              CorpseEnabled = match.Groups["Corpse"].Value == "Yes",
              Info = match.Groups["Info"].Value
            };
          }
        }
      } catch { }

      return rtnVal;
    }

    private void FormSARMonitor_FormClosing(object sender, FormClosingEventArgs e) {
      Cancel = true;
    }

    public enum Status {
      Monitoring,
      Initializing,
      Inactive
    }

  }

}
