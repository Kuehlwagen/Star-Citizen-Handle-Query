using SCHQ_Protos;
using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Properties;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormRelations : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;
    private readonly SortedList<string, UserControlRelation> UserControlRelations = [];
    private CancellationTokenSource CancelToken = new();
    private SyncStatus Sync = SyncStatus.Disconnected;

    private bool IsRPCSync {
      get {
        return !string.IsNullOrWhiteSpace(ProgramSettings.Relations.RPC_URL) && !string.IsNullOrWhiteSpace(ProgramSettings.Relations.RPC_Channel);
      }
    }

    public FormRelations(Settings programSettings, Translation translation) {
      InitializeComponent();
      ProgramSettings = programSettings;
      ProgramTranslation = translation;

      // Prüfen, ob die Programm-Einstellungen valide sind
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        InitialWindowStyle = User32Wrappers.GetWindowLongA(Handle, User32Wrappers.GWL.ExStyle);

        // Farben setzen
        if (programSettings.Colors != null) {
          ForeColor = programSettings.Colors.AppForeColor;
          PanelHeader.BackColor = programSettings.Colors.AppBackColor;
        }
      }

      // Übersetzung laden
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
      // Prüfen, ob die Übersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        LabelTitle.Text = $"{ProgramTranslation.Relations.Title}";
        SetToolTip(CheckBoxFilterFriendly, ProgramTranslation.Local_Cache.Relation.Friendly);
        SetToolTip(CheckBoxFilterNeutral, ProgramTranslation.Local_Cache.Relation.Neutral);
        SetToolTip(CheckBoxFilterBogey, ProgramTranslation.Local_Cache.Relation.Bogey);
        SetToolTip(CheckBoxFilterBandit, ProgramTranslation.Local_Cache.Relation.Bandit);
        SetToolTip(CheckBoxFilterOrganization, ProgramTranslation.Local_Cache.Columns.Organization.ToUpper());
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
      Location = new Point(0, 125);
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
        UcResize.BackColor = locked ? Color.Transparent : Color.Yellow;
        UcResize.Cursor = locked ? Cursors.Default : Cursors.SizeWE;
      }
    }

    private readonly int ResizeWidth = 2;
    private bool IsDragging = false;
    private Rectangle LastRectangle = new();
    private UserControl UcResize = null;
    private void FormRelations_Shown(object sender, EventArgs e) {
      Height = LogicalToDeviceUnits(31);
      if (IsRPCSync) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        ChangeSync(SyncStatus.Disconnected);
        StartStopSync(true);
      } else {
        ImportRelationInfos();
      }

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

    public void ClearRelations(bool force = false) {
      if (PanelRelations.Controls.Count > 0) {
        if (force || MessageBox.Show(ProgramTranslation.Relations.Clear, ProgramTranslation.Relations.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
          UserControlRelations.Clear();
          List<UserControlRelation> ctrls = [.. PanelRelations.Controls.OfType<UserControlRelation>()];
          PanelRelations.Controls.Clear();
          foreach (UserControlRelation c in ctrls) {
            c.Dispose();
          }
        }
      }
    }

    private void FormRelations_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
      } else {
        ExportRelationInfos();
      }
    }

    private readonly JsonSerializerOptions JsonSerOptions = new() {
      WriteIndented = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    internal void ExportRelationInfos(string exportPath = null) {
      RelationInfos infos = new() {
        FilterVisibility = new() {
          Organization = CheckBoxFilterOrganization.Checked,
          Friendly = CheckBoxFilterFriendly.Checked,
          Neutral = CheckBoxFilterNeutral.Checked,
          Bogey = CheckBoxFilterBogey.Checked,
          Bandit = CheckBoxFilterBandit.Checked
        }
      };
      foreach (KeyValuePair<string, UserControlRelation> kvp in UserControlRelations.OrderByDescending(x => x.Value.Type).ThenBy(x => x.Value.RelationName)) {
        infos.Relations.Add(new RelationInformation() {
          Name = kvp.Value.RelationName,
          Relation = kvp.Value.Relation,
          Type = kvp.Value.Type,
          Comment = kvp.Value.Comment
        });
      }
      try {
        File.WriteAllText(exportPath ?? FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Root, "Relations"),
          JsonSerializer.Serialize(infos, JsonSerOptions), Encoding.UTF8);
      } catch { }
    }

    internal void ImportRelationInfos(string importPath = null) {
      try {
        RelationInfos infos = null;
        bool isRPC = IsRPCSync && importPath == null;
        if (isRPC) {
          infos = RPC_Wrapper.GetRelations(ProgramSettings.Relations.RPC_Channel, ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted);
        } else {
          string jsonFilePath = importPath ?? FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Root, "Relations");
          if (File.Exists(jsonFilePath)) {
            infos = JsonSerializer.Deserialize<RelationInfos>(File.ReadAllText(jsonFilePath, Encoding.UTF8));
          }
        }
        if (infos != null) {
          PanelRelations.Controls.Clear();
          UserControlRelations.Clear();
          if (infos.FilterVisibility != null) {
            CheckBoxFilterOrganization.Checked = infos.FilterVisibility.Organization;
            CheckBoxFilterFriendly.Checked = infos.FilterVisibility.Friendly;
            CheckBoxFilterNeutral.Checked = infos.FilterVisibility.Neutral;
            CheckBoxFilterBogey.Checked = infos.FilterVisibility.Bogey;
            CheckBoxFilterBandit.Checked = infos.FilterVisibility.Bandit;
          }
          if (infos.Relations?.Count > 0) {
            PanelRelations.SuspendLayout();
            foreach (RelationInformation info in infos.Relations) {
              AddControl(info.Name, info.Type, info.Relation, info.Comment, isRPC);
            }
            PanelRelations.ResumeLayout();
          }
        }
        FilterRelations();
      } catch { }
    }

    private void PictureBoxClearAll_MouseClick(object sender, MouseEventArgs e) {
      switch (e.Button) {
        case MouseButtons.Left:
          if (IsRPCSync) {
            StartStopSync();
          } else {
            ClearRelations();
          }
          break;
        case MouseButtons.Middle:
          if (IsRPCSync && Sync == SyncStatus.Connected) {
            RelationInfos infos = RPC_Wrapper.GetRelations(ProgramSettings.Relations.RPC_Channel, ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted);
            if (infos.Relations?.Count > 0) {
              UserControlRelations.Clear();
              PanelRelations.Controls.Clear();
              PanelRelations.SuspendLayout();
              foreach (RelationInformation info in infos.Relations) {
                AddControl(info.Name, info.Type, info.Relation, info.Comment);
              }
              PanelRelations.ResumeLayout();
            }
          }
          break;
      }
    }

    private void StartStopSync(bool startup = false) {
      if (IsRPCSync) {
        if (Sync == SyncStatus.Disconnected && (ProgramSettings.Relations.RPC_Sync_On_Startup || !startup)) {
          ImportRelationInfos();
          CancelToken = new CancellationTokenSource();
          Task.Run(() => RPC_Wrapper.SyncRelations(this, ProgramSettings.Relations.RPC_Channel, ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted, CancelToken));
        } else {
          CancelToken.Cancel();
        }
      }
    }

    public void SetToolTip(Control control, string tooltip) {
      ToolTipRelations.SetToolTip(control, tooltip);
    }

    internal void ChangeSync(SyncStatus status) {
      if (IsRPCSync) {
        if (InvokeRequired) {
          Invoke(() => PictureBoxClearAll.Cursor = Cursors.Hand);
          Invoke(() => SetToolTip(PictureBoxClearAll, GetSyncStatusToolTip(status)));
        } else {
          PictureBoxClearAll.Cursor = Cursors.Hand;
          SetToolTip(PictureBoxClearAll, GetSyncStatusToolTip(status));
        }
        Sync = status;
        Image img = Resources.StatusRed;
        switch (Sync) {
          case SyncStatus.Connecting:
            img = Resources.StatusOrange;
            break;
          case SyncStatus.Connected:
            img = Resources.StatusGreen;
            break;
        }
        if (InvokeRequired) {
          Invoke(() => PictureBoxClearAll.Image = img);
        } else {
          PictureBoxClearAll.Image = img;
        }
      }
    }

    internal string GetSyncStatusToolTip(SyncStatus status) {
      string statusText = status switch {
        SyncStatus.Disconnected => ProgramTranslation.Relations.RPC_Status_Disconnected,
        SyncStatus.Connecting => ProgramTranslation.Relations.RPC_Status_Connecting,
        SyncStatus.Connected => ProgramTranslation.Relations.RPC_Status_Connected,
        _ => status.ToString()
      };
      return $"{ProgramTranslation.Settings.Relations.RPC_Server_Channel} {ProgramSettings.Relations.RPC_Channel}{Environment.NewLine}{statusText}";
    }

    internal enum SyncStatus {
      Disconnected,
      Connecting,
      Connected
    }

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      FormHandleQuery.CheckSnap(this, Location);
    }

    private void PanelRelations_ControlAdded(object sender, ControlEventArgs e) {
      e.Control.Width = PanelRelations.Width;
      if (PanelRelations.Controls.Count == 1 && !IsRPCSync) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Resources.ClearAll;
        PictureBoxClearAll.Cursor = Cursors.Hand;
      }
      if (PanelRelations.Controls.Count <= ProgramSettings.Relations.EntriesMax) {
        Height += LogicalToDeviceUnits(e.Control.Height + 2);
      }
    }

    private void PanelRelations_ControlRemoved(object sender, ControlEventArgs e) {
      if (PanelRelations.Controls.Count < ProgramSettings.Relations.EntriesMax) {
        Height -= LogicalToDeviceUnits(e.Control.Height + 2);
      }
      if (PanelRelations.Controls.Count == 0 && !IsRPCSync) {
        PictureBoxClearAll.MouseClick -= PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Resources.ClearAll_Deactivated;
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
    }

    private void AddControl(string name, RelationType relationType, RelationValue relation, string comment, bool hide = false) {
      string controlName = $"{relationType}.{name}";
      UserControlRelation control = new(ProgramSettings, name, relationType, relation, comment) { Name = $"UserControlRelation_{relationType}_{name}", Visible = RelationIsVisible(relation) };
      UserControlRelations[controlName] = control;
      if (!hide && !PanelRelations.Controls.ContainsKey(controlName)) {
        PanelRelations.Controls.Add(control);
        if (ProgramSettings.Relations.SortAlphabetically && UserControlRelations.ContainsKey(controlName)) {
          PanelRelations.Controls.SetChildIndex(control, UserControlRelations.IndexOfKey(controlName));
        }
      }
    }

    public void RemoveControl(UserControlRelation uc) {
      string controlName = $"{uc.Type}.{uc.RelationName}";
      UserControlRelations.Remove(controlName);
      PanelRelations.Controls.Remove(uc);
      uc.Dispose();
    }

    public void UpdateRelation(string name, RelationType relationType, RelationValue relation, string comment = null, bool withoutRPCSet = false) {
      if (!string.IsNullOrWhiteSpace(name)) {
        if (IsRPCSync && !withoutRPCSet && Sync == SyncStatus.Connected) {
          if (!RPC_Wrapper.SetRelation(ProgramSettings.Relations.RPC_Channel, ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted, relationType, name, relation, comment)) {
            return;
          }
        }
        Control[] controls = PanelRelations.Controls.Find($"UserControlRelation_{relationType}_{name}", false);
        if (controls?.Length == 1) {
          if (relation == RelationValue.NotAssigned) {
            if (InvokeRequired) {
              Invoke(() => RemoveControl(controls[0] as UserControlRelation));
            } else {
              RemoveControl(controls[0] as UserControlRelation);
            }
          } else if (controls[0] is UserControlRelation control) {
            if (InvokeRequired) {
              Invoke(() => control.UpdateRelation(relation));
              Invoke(() => control.UpdateComment(comment));
              Invoke(() => control.Visible = RelationIsVisible(relation));
            } else {
              control.UpdateRelation(relation);
              control.UpdateComment(comment);
              control.Visible = RelationIsVisible(relation);
            }
          }
        } else if (relation > RelationValue.NotAssigned) {
          // Da gefiltert werden kann, die Daten nicht auf die maximale Anzahl von darzustellenden Einträgen begrenzen
          //if (PanelRelations.Controls.Count == ProgramSettings.Relations.EntriesMax) {
          //  RemoveControl(PanelRelations.Controls[0] as UserControlRelation);
          //}
          if (InvokeRequired) {
            Invoke(() => AddControl(name, relationType, relation, comment));
          } else {
            AddControl(name, relationType, relation, comment);
          }
        }
        if (InvokeRequired) {
          Invoke(FilterRelations);
        } else {
          FilterRelations();
        }
      }
    }

    private bool RelationIsVisible(RelationValue relation) {
      return relation switch {
        RelationValue.Friendly => CheckBoxFilterFriendly.Checked,
        RelationValue.Neutral => CheckBoxFilterNeutral.Checked,
        RelationValue.Bogey => CheckBoxFilterBogey.Checked,
        RelationValue.Bandit => CheckBoxFilterBandit.Checked,
        _ => false,
      };
    }

    public void SetComment(string name, string comment, RelationType relationType = RelationType.Handle) {
      if (IsRPCSync && Sync == SyncStatus.Connected && !string.IsNullOrWhiteSpace(name) && comment != null) {
        RelationValue relation = GetHandleRelation(name);
        if (RPC_Wrapper.SetRelation(ProgramSettings.Relations.RPC_Channel, ProgramSettings.Relations.RPC_Sync_Channel_Password_Decrypted, relationType, name, relation, comment)) {
          UserControlRelation control = UserControlRelations.Select(x => x.Value).FirstOrDefault(x => x.Type == relationType && x.RelationName == name);
          if (control != null) {
            control.UpdateComment(comment);
            Control[] controls = PanelRelations.Controls.Find($"UserControlRelation_{relationType}_{name}", false);
            if (controls?.Length == 1) {
              if (InvokeRequired) {
                Invoke(() => (controls[0] as UserControlRelation).UpdateComment(comment));
              } else {
                (controls[0] as UserControlRelation).UpdateComment(comment);
              }
            }
          }
        }
      }
    }

    public RelationValue GetOrganizationRelation(string sid) {
      RelationValue rtnVal = RelationValue.NotAssigned;
      UserControlRelation control = UserControlRelations.Select(x => x.Value).FirstOrDefault(x => x.Type == RelationType.Organization && x.RelationName == sid);
      if (control != null) {
        rtnVal = control.Relation;
      }
      return rtnVal;
    }

    public RelationValue GetHandleRelation(string handle) {
      RelationValue rtnVal = RelationValue.NotAssigned;
      UserControlRelation control = UserControlRelations.Select(x => x.Value).FirstOrDefault(x => x.Type == RelationType.Handle && x.RelationName == handle);
      if (control != null) {
        rtnVal = control.Relation;
      }
      return rtnVal;
    }

    private void CheckBoxFilterChanged(object sender, EventArgs e) {
      FilterRelations();
    }

    public void FilterRelations() {
      for (int i = PanelRelations.Controls.Count - 1; i >= 0; i--) {
        if (PanelRelations.Controls[i] is UserControlRelation control) {
          if (control.Type == RelationType.Organization &&
            CheckBoxFilterOrganization.Checked &&
            !CheckBoxFilterFriendly.Checked &&
            !CheckBoxFilterNeutral.Checked &&
            !CheckBoxFilterBogey.Checked &&
            !CheckBoxFilterBandit.Checked) {
            control.Visible = true;
          } else {
            switch (control.Relation) {
              case RelationValue.Friendly:
                control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterFriendly.Checked;
                break;
              case RelationValue.Neutral:
                control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterNeutral.Checked;
                break;
              case RelationValue.Bogey:
                control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterBogey.Checked;
                break;
              case RelationValue.Bandit:
                control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterBandit.Checked;
                break;
            }
          }
        }
      }
    }

    public void FilterRelations(Keys keyCode) {
      switch (keyCode) {
        case Keys.D0:
        case Keys.NumPad0:
          bool check = !CheckBoxFilterFriendly.Checked;
          CheckBoxFilterFriendly.Checked = check;
          CheckBoxFilterNeutral.Checked = check;
          CheckBoxFilterBogey.Checked = check;
          CheckBoxFilterBandit.Checked = check;
          break;
        case Keys.D1:
        case Keys.NumPad1:
          CheckBoxFilterFriendly.Checked = !CheckBoxFilterFriendly.Checked;
          break;
        case Keys.D2:
        case Keys.NumPad2:
          CheckBoxFilterNeutral.Checked = !CheckBoxFilterNeutral.Checked;
          break;
        case Keys.D3:
        case Keys.NumPad3:
          CheckBoxFilterBogey.Checked = !CheckBoxFilterBogey.Checked;
          break;
        case Keys.D4:
        case Keys.NumPad4:
          CheckBoxFilterBandit.Checked = !CheckBoxFilterBandit.Checked;
          break;
        case Keys.D5:
        case Keys.NumPad5:
          CheckBoxFilterOrganization.Checked = !CheckBoxFilterOrganization.Checked;
          break;
      }
    }

    private void CheckBoxFilter_Paint(object sender, PaintEventArgs e) {
      if (sender is CheckBox checkBox && checkBox.Checked) {
        int x = (checkBox.Width / 2) - LogicalToDeviceUnits(3);
        int y = (checkBox.Height / 2) - LogicalToDeviceUnits(3);
        int width = LogicalToDeviceUnits(6);
        int height = LogicalToDeviceUnits(6);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(19, 26, 33)), x, y, width, height);
      }
    }

    private void ToolTipHandleQuery_Draw(object sender, DrawToolTipEventArgs e) {
      e.DrawBackground();
      e.DrawBorder();
      e.DrawText(TextFormatFlags.TextBoxControl);
    }

    private void FormRelations_Activated(object sender, EventArgs e) {
      if (ProgramSettings != null && ProgramSettings.WindowIgnoreMouseInput) {
        SetIgnoreMouseInput(false);
      }
    }

    private void FormRelations_Deactivate(object sender, EventArgs e) {
      if (ProgramSettings != null && ProgramSettings.WindowIgnoreMouseInput) {
        SetIgnoreMouseInput();
      }
    }

    private void FormRelations_SizeChanged(object sender, EventArgs e) {
      foreach (Control control in PanelRelations.Controls) {
        control.Width = PanelRelations.Width;
      }
    }

  }

}
