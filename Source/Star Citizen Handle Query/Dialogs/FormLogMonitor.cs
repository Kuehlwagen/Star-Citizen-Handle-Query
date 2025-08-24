using SCHQ_Protos;
using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLogMonitor : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private bool Cancel = false;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;
    private readonly string NL = Environment.NewLine;
    private Status LogStatus = Status.Inactive;
    private List<string> NPC_Filter = null;

    private readonly Regex RgxCorpse = RegexCorpse();
    [GeneratedRegex(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)> \[Notice\] <\[ActorState\] Corpse> \[ACTOR STATE\]\[SSCActorStateCVars::LogCorpse\] Player '(?<Handle>[\w_\-]+)' <\w+ client>: (?<Key>.+): (?<Value>.+) \[Team_ActorTech]\[Actor\]$", RegexOptions.Compiled)]
    private static partial Regex RegexCorpse();

    private readonly Regex RgxLoadingScreenDuration = RegexLoadingScreen();
    [GeneratedRegex(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)>\sLoading screen for pu : SC_Frontend closed after (?<Value>\d+\.\d+) seconds$", RegexOptions.Compiled)]
    private static partial Regex RegexLoadingScreen();

    private readonly Regex RgxActorDeath = RegexActorDeath();
    [GeneratedRegex(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)> \[Notice\] <Actor Death> CActor::Kill: '(?<Handle>[\w_\-]+)' \[\d+\] in zone '(?<Zone>.+)' killed by '(?<KilledBy>[\w_\-]+)' \[\d+\] using '(?<Using>.+)' \[(?<UsingClass>.+)\] with damage type '(?<DamageType>.+)'.+$", RegexOptions.Compiled)]
    private static partial Regex RegexActorDeath();

    private static readonly Regex RgxActorDeathInfo = RegexActorDeathInfo();
    [GeneratedRegex(@"Using: (?<Using>.+)\nZone: (?<Zone>.+)\nDamage Type: (?<Type>.+)", RegexOptions.Compiled)]
    private static partial Regex RegexActorDeathInfo();

    private readonly Regex RgxHostilityEvent = RegexHostilityEvent();
    [GeneratedRegex(@"^<(?<Date>\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z)> \[Notice\] <Debug Hostility Events> \[OnHandleHit\] Fake hit FROM (?<Handle_Attacker>[\w_\-]+) TO (?<Vehicle>[\w_\-]+). Being sent to child (?<Handle_Victim>[\w_\-]+) \[Team_MissionFeatures\]\[HitInfo\]$", RegexOptions.Compiled)]
    private static partial Regex RegexHostilityEvent();

    public FormLogMonitor(Settings programSettings, Translation translation) {
      InitializeComponent();
      ProgramSettings = programSettings;
      ProgramTranslation = translation;

      // Pr�fen, ob die Programm-Einstellungen valide sind
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        InitialWindowStyle = User32Wrappers.GetWindowLongA(Handle, User32Wrappers.GWL.ExStyle);

        // Farben setzen
        if (programSettings.Colors != null) {
          ForeColor = programSettings.Colors.AppForeColor;
          PanelHeader.BackColor = programSettings.Colors.AppBackColor;
          ToolTipLogMonitor.BackColor = programSettings.Colors.AppBackColor;
          ToolTipLogMonitor.ForeColor = programSettings.Colors.AppForeColor;
        }
      }

      // �bersetzung laden
      SetTranslation();
    }

    public void SetIgnoreMouseInput(bool ignoreMouseInput = true) {
      try {
        if (ignoreMouseInput) {
          _ = User32Wrappers.SetWindowLongA(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        } else {
          _ = User32Wrappers.SetWindowLongA(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered);
        }
      } catch { }
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
      Width = 240;
      CenterToScreen();
      Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, 125);
    }

    private void LabelTitle_MouseDown(object sender, MouseEventArgs e) {
      if (!WindowLocked) {
        switch (e.Button) {
          case MouseButtons.Left:
            _ = User32Wrappers.ReleaseCapture();
            _ = User32Wrappers.SendMessageA(Handle, User32Wrappers.WM_NCLBUTTONDOWN, User32Wrappers.HT_CAPTION, 0);
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
      if (UcResize != null) {
        UcResize.BackColor = locked ? Color.Transparent : ProgramSettings.Colors.AppSplitterColor;
        UcResize.Cursor = locked ? Cursors.Default : Cursors.SizeWE;
      }
    }

    private readonly int ResizeWidth = 2;
    private bool IsDragging = false;
    private Rectangle LastRectangle = new();
    private UserControl UcResize = null;
    private void FormLogMonitor_Shown(object sender, EventArgs e) {
      Height = LogicalToDeviceUnits(31);

      UcResize = new() {
        Dock = DockStyle.Right,
        Height = DisplayRectangle.Height - (ResizeWidth * 2),
        Width = ResizeWidth,
        Left = DisplayRectangle.Width - ResizeWidth,
        Top = ResizeWidth,
        BackColor = Color.Transparent,
        Cursor = Cursors.Default
      };
      UcResize.MouseDown += Form_MouseDown;
      UcResize.MouseUp += Form_MouseUp;
      UcResize.MouseMove += delegate (object sender, MouseEventArgs e) {
        if (IsDragging) {
          Size = new Size(e.X - LastRectangle.X + Width, LastRectangle.Height);
        }
      };
      UcResize.BringToFront();
      PanelHeader.Controls.Add(UcResize);

      StartMonitor();
    }

    private void Form_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left && !WindowLocked) {
        IsDragging = true;
        LastRectangle = new Rectangle(e.Location.X, e.Location.Y, Width, Height);
      }
    }

    private void Form_MouseMove(object sender, MouseEventArgs e) {
      if (IsDragging && !WindowLocked) {
        int x = (Location.X + (e.Location.X - LastRectangle.X));
        int y = (Location.Y + (e.Location.Y - LastRectangle.Y));

        Location = new Point(x, y);
      }
    }

    private void Form_MouseUp(object sender, MouseEventArgs e) {
      IsDragging = false;
    }

    private void StartMonitor() {
      Task.Run(() => {

#if DEBUG
        Invoke(new Action(() => ClearLogInfos()));
#endif

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

              string scLogPath = Path.Combine(Path.GetDirectoryName(processSC.Modules[0].FileName), "Game.log");
              if (File.Exists(scLogPath)) {

                Encoding encoding = Encoding.UTF8;
                StreamReader logReader = new(new FileStream(scLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), encoding);
                long currentPosition = ProgramSettings.LogMonitor.LoadCompleteFile ? 0 : logReader.BaseStream.Length;
                long lastMaxOffset = currentPosition;

                string livePtuFolder = Path.GetFileName(Path.GetDirectoryName(scLogPath));
                Invoke(new Action(() => SetTitle(livePtuFolder)));

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
          if (PanelLogInfo.Controls.Count == 0) {
            if (PanelLogInfo.Controls.Count == ProgramSettings.LogMonitor.EntriesMax) {
              RemoveControl(PanelLogInfo.Controls[0] as UserControlLog);
            }
            if (CheckAddLogInfo(logInfo)) {
              PanelLogInfo.Controls.Add(new UserControlLog(logInfo, ProgramSettings));
            }
          } else if (PanelLogInfo.Controls[PanelLogInfo.Controls.Count - 1] is UserControlLog ucl) {
            if (!logInfo.Equals(ucl.LogInfoItem)) {
              if (PanelLogInfo.Controls.Count == ProgramSettings.LogMonitor.EntriesMax) {
                RemoveControl(PanelLogInfo.Controls[0] as UserControlLog);
              }
              if (CheckAddLogInfo(logInfo)) {
                PanelLogInfo.Controls.Add(new UserControlLog(logInfo, ProgramSettings));
              }
            } else {
              ucl.UpdateInfo(logInfo);
            }
          }
        }
      }
    }

    private bool CheckAddLogInfo(LogMonitorInfo logInfo) {
      bool rtnVal = false;

      List<string> filter = ProgramSettings.LogMonitor.HandleFilter;
      if (logInfo != null && logInfo.IsValid) {
        rtnVal = logInfo.LogType switch {
          LogType.Corpse => filter == null || filter.Count == 0 || filter.Contains(logInfo.Handle, StringComparer.CurrentCultureIgnoreCase),
          LogType.ActorDeath => !FilterNPC(logInfo.Handle) && (filter == null || filter.Count == 0 || filter.Contains(logInfo.Handle, StringComparer.CurrentCultureIgnoreCase) || filter.Contains(logInfo.Key, StringComparer.CurrentCultureIgnoreCase)),
          LogType.HostilityEvent => !(FilterNPC(logInfo.Handle) || FilterNPC(logInfo.Key)),
          _ => true,
        };
      }

      if (rtnVal && (logInfo.LogType == LogType.ActorDeath || logInfo.LogType == LogType.HostilityEvent) && FormSettings.IsValidDiscordWebhookUrl(ProgramSettings.LogMonitor.WebhookURL)) {
        PushDiscordWebhook(logInfo, ProgramSettings.LogMonitor.WebhookURL, ProgramTranslation);
      }

      return rtnVal;
    }

    public static void PushDiscordWebhook(LogMonitorInfo logInfo, string url, Translation translation) {
      Thread thread = new(() => PushWebhook(logInfo, url, translation));
      thread.Start();
    }

    private static void PushWebhook(LogMonitorInfo logInfo, string url, Translation translation) {
      DiscordWebhook webhook = null;

      switch (logInfo.LogType) {
        case LogType.ActorDeath: {
            List<DiscordField> killerFields = [];
            Match m = RgxActorDeathInfo.Match(logInfo.Value);
            if (m != null && m.Success) {
              killerFields.AddRange([
                new() { name = translation.Log_Monitor.Webhook_Using, value = V(m, "Using")},
                new() { name = translation.Log_Monitor.Webhook_Damage_Type, value = V(m, "Type")},
                new() { name = translation.Log_Monitor.Webhook_Zone, value = V(m, "Zone")}
              ]);
            }
            webhook = new() {
              embeds = [
                new() {
                  title = translation.Log_Monitor.Webhook_Actor_Death,
                  description = $"**[{logInfo.Handle}](https://robertsspaceindustries.com/en/citizens/{logInfo.Handle})**",
                  color = GetWebhookRelationColor(logInfo.RelationValue)
                },
                new() {
                  title = translation.Log_Monitor.Webhook_Killer,
                  description = $"**[{logInfo.Key}](https://robertsspaceindustries.com/en/citizens/{logInfo.Key})**",
                  color = GetWebhookRelationColor(logInfo.RelationValue2),
                  fields = killerFields
                }
              ]
            };
          }
          break;
        case LogType.HostilityEvent: {
            webhook = new() {
              embeds = [
                new() {
                  title = translation.Log_Monitor.Webhook_Hostility_Event,
                  description = $"**[{logInfo.Handle}](https://robertsspaceindustries.com/en/citizens/{logInfo.Handle})**",
                  color = GetWebhookRelationColor(logInfo.RelationValue),
                  fields = [
                    new() {
                      name = translation.Log_Monitor.Webhook_Hostility_Event_Ship,
                      value = logInfo.Value
                    }
                  ]
                },
                new() {
                  title = translation.Log_Monitor.Webhook_Hostility_Event_Attacker,
                  description = $"**[{logInfo.Key}](https://robertsspaceindustries.com/en/citizens/{logInfo.Key})**",
                  color = GetWebhookRelationColor(logInfo.RelationValue2)
              }
              ]
            };
          }
          break;
      }
      try {
        using HttpClient client = new();
        _ = client.PostAsJsonAsync(url, webhook).Result;
      } catch { }
    }

    private static int? GetWebhookRelationColor(RelationValue relation) {
      return relation switch {
        RelationValue.Friendly => 5763719,
        RelationValue.Neutral => 9807270,
        RelationValue.Bogey => 15105570,
        RelationValue.Bandit => 15548997,
        _ => null
      };
    }

    private void ClearLogInfos() {
#if DEBUG
      if (PanelLogInfo.Controls.Count == 0) {
        string debugGameLogPath = Path.Combine(FormHandleQuery.GetSaveFilesRootPath(), @"..\Game.log");
        if (File.Exists(debugGameLogPath)) {
          Encoding encoding = Encoding.UTF8;
          using StreamReader logReader = new(new FileStream(debugGameLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), encoding);
          Invoke(new Action(() => SetTitle("DEBUG")));
          string line;
          while (!logReader.EndOfStream) {
            line = logReader.ReadLine();
            Invoke(new Action(() => AddLogInfo(CheckRegEx(line))));
          }
        } else {
          AddLogInfo([
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "DoesLocationContainHospital", "Searching landing zone location \"@ui_pregame_port_GrimHex_name\" for the closest hospital.", relation: RelationValue.Friendly),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "DoesLocationContainHospital", "Nearby hospital \"@Stanton2_Orison_Hospital\" IS NOT contained within landing zone \"@ui_pregame_port_GrimHex_name\".", relation: RelationValue.Friendly),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "IsCorpseEnabled", "Yes, there is a local inventory but no hospital.", relation: RelationValue.Friendly),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "DudeCrocker", "DoesLocationContainHospital", "Searching landing zone location \"@Stanton2_Transfer_Seraphim\" for the closest hospital."),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "DudeCrocker", "DoesLocationContainHospital", "Nearby hospital \"@RR_Clinic\" IS contained within landing zone \"@Stanton2_Transfer_Seraphim\"."),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "DudeCrocker", "IsCorpseEnabled", "Yes"),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "LanceFlair", relation: RelationValue.Bogey),
            new(LogType.Corpse, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Gentle81", "IsCorpseEnabled", "criminal arrest", relation: RelationValue.Bandit),
            new(LogType.LoadingScreenDuration, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), value: "15"),
            new(LogType.ActorDeath, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "Churchtrill", $"Killed by: Churchtrill{NL}Using: unknown (Class unknown){NL}Zone: TransitCarriage_RSI_Polaris_Rear_Elevator_1604048788858{NL}Damage Type: Crash", relation: RelationValue.Friendly, RelationValue.Bandit),
            new(LogType.HostilityEvent, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "M4Z3", "MRAI_Guardian_5662046311400", RelationValue.Friendly, RelationValue.Neutral),
            new(LogType.HostilityEvent, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "M4Z3", "MRAI_Guardian_5662046311400", RelationValue.Friendly, RelationValue.Neutral),
            new(LogType.HostilityEvent, DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), "Kuehlwagen", "Gentle81", "MRAI_Guardian_5662046311400", RelationValue.Friendly, RelationValue.Bogey)
          ]);
        }
      }
#else
      SetTitle();
      if (PanelLogInfo.Controls.Count > 0) {
        List<UserControlLog> ctrls = [.. PanelLogInfo.Controls.OfType<UserControlLog>()];
        PanelLogInfo.Controls.Clear();
        foreach (UserControlLog c in ctrls) {
          c.StopTimer();
          c.Dispose();
        }
      }
#endif
    }

    private void ChangeStatus(Status status) {
      if (LogStatus != status) {
        LogStatus = status;
        PictureBoxStatus.Invalidate();
      }
    }

    private List<LogMonitorInfo> CheckRegEx(string input) {
      List<LogMonitorInfo> rtnVal = input != null ? new() : null;

      if (rtnVal != null) {
        try {
          Match m = null;
          foreach (string line in input.Split(Environment.NewLine)) {
            if (ProgramSettings.LogMonitor.Filter.Corpse) {
              m = RgxCorpse.Match(line);
              if (m != null && m.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.Corpse,
                  V(m, "Date"),
                  V(m, "Handle"),
                  V(m, "Key"),
                  V(m, "Value"),
                  relation: (Owner as FormHandleQuery).GetHandleRelation(V(m, "Handle"))));
                continue;
              } else {
                m = RgxActorDeath.Match(line);
                if (m != null && m.Success) {
                  rtnVal.Add(new LogMonitorInfo(LogType.ActorDeath,
                    V(m, "Date"),
                    V(m, "Handle"),
                    V(m, "KilledBy"),
                    $"Killed by: {V(m, "KilledBy")}{NL}Using: {V(m, "Using")} ({V(m, "UsingClass")}){NL}Zone: {V(m, "Zone")}{NL}Damage Type: {V(m, "DamageType")}",
                    (Owner as FormHandleQuery).GetHandleRelation(V(m, "Handle")),
                    (Owner as FormHandleQuery).GetHandleRelation(V(m, "KilledBy"))));
                  continue;
                }
              }
            }
            if (ProgramSettings.LogMonitor.Filter.Hostility_Events) {
              m = RgxHostilityEvent.Match(line);
              if (m != null && m.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.HostilityEvent,
                  V(m, "Date"),
                  V(m, "Handle_Victim"),
                  V(m, "Handle_Attacker"),
                  V(m, "Vehicle"),
                  (Owner as FormHandleQuery).GetHandleRelation(V(m, "Handle_Victim")),
                  (Owner as FormHandleQuery).GetHandleRelation(V(m, "Handle_Attacker"))));
                continue;
              }
            }
            if (ProgramSettings.LogMonitor.Filter.LoadingScreenDuration) {
              m = RgxLoadingScreenDuration.Match(line);
              if (m != null && m.Success) {
                rtnVal.Add(new LogMonitorInfo(LogType.LoadingScreenDuration,
                  V(m, "Date"),
                  value: V(m, "Value")));
                continue;
              }
            }
          }
        } catch { }
      }

      return rtnVal;
    }

    private bool FilterNPC(string handle) {
      NPC_Filter ??= [.. ProgramSettings.LogMonitor.Global_NPC_Filter.Union(ProgramSettings.LogMonitor.NPC_Filter, StringComparer.CurrentCultureIgnoreCase)];
      return !ProgramSettings.LogMonitor.Show_NPC_Deaths && NPC_Filter.Any(h => handle.StartsWith(h, StringComparison.CurrentCultureIgnoreCase));
    }

    private static string V(Match match, string group) {
      return match?.Groups[group].Value;
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
      e.Control.Width = PanelLogInfo.Width;
      if (PanelLogInfo.Controls.Count == 1) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Invalidate();
        PictureBoxClearAll.Cursor = Cursors.Hand;
      }
      if (PanelLogInfo.Controls.Count <= ProgramSettings.LogMonitor.EntriesMax) {
        Height += LogicalToDeviceUnits(e.Control.Height + 2);
      }
    }

    private void PanelLogInfo_ControlRemoved(object sender, ControlEventArgs e) {
      Height -= LogicalToDeviceUnits(e.Control.Height + 2);
      if (PanelLogInfo.Controls.Count == 0) {
        PictureBoxClearAll.MouseClick -= PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Invalidate();
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
    }

    public void RemoveControl(UserControlLog uc) {
      uc.StopTimer();
      PanelLogInfo.Controls.Remove(uc);
      uc.Dispose();
    }

    private void ToolTipLogMonitor_Draw(object sender, DrawToolTipEventArgs e) {
      e.DrawBackground();
      e.DrawBorder();
      e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
    }

    internal void SetTooltip(Control control, string text) {
      ToolTipLogMonitor.SetToolTip(control, text);
    }

    private void FormLogMonitor_Activated(object sender, EventArgs e) {
      if (ProgramSettings != null && ProgramSettings.WindowIgnoreMouseInput) {
        SetIgnoreMouseInput(false);
      }
    }

    private void FormLogMonitor_Deactivate(object sender, EventArgs e) {
      if (ProgramSettings != null && ProgramSettings.WindowIgnoreMouseInput) {
        SetIgnoreMouseInput();
      }
    }

    private void PanelLogInfo_SizeChanged(object sender, EventArgs e) {
      foreach (Control control in PanelLogInfo.Controls) {
        control.Width = PanelLogInfo.Width;
      }
    }

    private void PictureBoxClearAll_Paint(object sender, PaintEventArgs e) {
      FormHandleQuery.PaintTrashIcon(e.Graphics, ProgramSettings.Colors.AppForeColor, ProgramSettings.Colors.AppForeColorInactive, PanelLogInfo.Controls.Count > 0);
    }

    private void PictureBoxStatus_Paint(object sender, PaintEventArgs e) {
      var g = e.Graphics;

      g.SmoothingMode = SmoothingMode.AntiAlias;
      Rectangle r = new(2, 2, 16, 16);
      switch (LogStatus) {
        case Status.Inactive: {
            using var bgPen = new Pen(ProgramSettings.Colors.AppStatusInactiveBackColor, 2.0F);
            using var fgPen = new Pen(ProgramSettings.Colors.AppStatusInactiveForeColor, 1.0F);
            g.DrawEllipse(bgPen, r);
            g.FillEllipse(fgPen.Brush, r);
          }
          break;
        case Status.Initializing: {
            using var bgPen = new Pen(ProgramSettings.Colors.AppStatusInitializingBackColor, 2.0F);
            using var fgPen = new Pen(ProgramSettings.Colors.AppStatusInitializingForeColor, 1.0F);
            g.DrawEllipse(bgPen, r);
            g.FillEllipse(fgPen.Brush, r);
          }
          break;
        case Status.Monitoring: {
            using var bgPen = new Pen(ProgramSettings.Colors.AppStatusActiveBackColor, 2.0F);
            using var fgPen = new Pen(ProgramSettings.Colors.AppStatusActiveForeColor, 1.0F);
            g.DrawEllipse(bgPen, r);
            g.FillEllipse(fgPen.Brush, r);
          }
          break;
      }
    }

  }

}
