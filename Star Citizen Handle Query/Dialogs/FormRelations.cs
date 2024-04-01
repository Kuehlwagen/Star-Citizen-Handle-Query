using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Properties;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLongA(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLongA(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }
      }

      // Übersetzung laden
      SetTranslation();
    }

    private void SetTranslation() {
      // Prüfen, ob die Übersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        LabelTitle.Text = $"{ProgramTranslation.Relations.Title}";
        ToolTipRelations.SetToolTip(CheckBoxFilterFriendly, ProgramTranslation.Local_Cache.Relation.Friendly);
        ToolTipRelations.SetToolTip(CheckBoxFilterNeutral, ProgramTranslation.Local_Cache.Relation.Neutral);
        ToolTipRelations.SetToolTip(CheckBoxFilterBogey, ProgramTranslation.Local_Cache.Relation.Bogey);
        ToolTipRelations.SetToolTip(CheckBoxFilterBandit, ProgramTranslation.Local_Cache.Relation.Bandit);
        ToolTipRelations.SetToolTip(CheckBoxFilterOrganization, ProgramTranslation.Local_Cache.Columns.Organization.ToUpper());
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
    }

    private void FormRelations_Shown(object sender, EventArgs e) {
      Height = LogicalToDeviceUnits(31);
      if (IsRPCSync) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        ChangeSync(SyncStatus.Disconnected);
        StartStopSync();
      } else {
        ImportRelationInfos();
      }
    }

    public void ClearRelations() {
      if (PanelRelations.Controls.Count > 0) {
        UserControlRelations.Clear();
        List<UserControlRelation> ctrls = new(PanelRelations.Controls.OfType<UserControlRelation>());
        PanelRelations.Controls.Clear();
        foreach (UserControlRelation c in ctrls) {
          c.Dispose();
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
        infos.Relations.Add(new RelationInfo() {
          Name = kvp.Value.RelationName,
          Relation = kvp.Value.Relation,
          Type = kvp.Value.Type
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
          infos = RPC_Wrapper.GetRelations(ProgramSettings.Relations.RPC_Channel);
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
            foreach (RelationInfo info in infos.Relations) {
              AddControl(info.Name, info.Type, info.Relation);
            }
            PanelRelations.ResumeLayout();
          }
        }
        FilterRelations();
      } catch { }
    }

    internal Relation GetRPCRelation(RelationType type, string name) {
      Relation rtnVal = Relation.NotAssigned;

      if (IsRPCSync && Sync == SyncStatus.Connected) {
        rtnVal = RPC_Wrapper.GetRelation(ProgramSettings.Relations.RPC_Channel, type, name);
      }

      return rtnVal;
    }

    private void PictureBoxClearAll_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        if (IsRPCSync) {
          StartStopSync();
        } else {
          ClearRelations();
        }
      }
    }

    private void StartStopSync() {
      if (IsRPCSync) {
        if (Sync == SyncStatus.Disconnected) {
          ImportRelationInfos();
          CancelToken = new CancellationTokenSource();
          Task.Run(() => RPC_Wrapper.SyncRelations(this, ProgramSettings.Relations.RPC_Channel, CancelToken));
        } else {
          // Die gRPC-Liste leeren, wenn Strg- und Umschalt-Taste gedrückt sind
          if (ModifierKeys == (Keys.Control | Keys.Shift)) {
            if (RPC_Wrapper.RemoveRelations(ProgramSettings.Relations.RPC_Channel)) {
              ClearRelations();
            }
          } else if (ModifierKeys == (Keys.Control | Keys.Shift | Keys.Alt)) {
            RPC_Wrapper.RestoreRelations(ProgramSettings.Relations.RPC_Channel);
          } else {
            CancelToken.Cancel();
          }
        }
      }
    }

    internal void ChangeSync(SyncStatus status) {
      if (IsRPCSync) {
        if (InvokeRequired) {
          Invoke(() => PictureBoxClearAll.Cursor = Cursors.Hand);
          Invoke(() => ToolTipRelations.SetToolTip(PictureBoxClearAll, ProgramSettings.Relations.RPC_Channel));
        } else {
          PictureBoxClearAll.Cursor = Cursors.Hand;
          ToolTipRelations.SetToolTip(PictureBoxClearAll, ProgramSettings.Relations.RPC_Channel);
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

    private void AddControl(string name, RelationType relationType, Relation relation) {
      string controlName = $"{relationType}.{name}";
      UserControlRelation control = new(name, relationType, relation) { Name = $"UserControlRelation_{relationType}_{name}", Visible = RelationIsVisible(relation) };
      UserControlRelations.Add(controlName, control);
      PanelRelations.Controls.Add(control);
      if (ProgramSettings.Relations.SortAlphabetically && UserControlRelations.ContainsKey(controlName)) {
        PanelRelations.Controls.SetChildIndex(control, UserControlRelations.IndexOfKey(controlName));
      }
    }

    public void RemoveControl(UserControlRelation uc) {
      string controlName = $"{uc.Type}.{uc.RelationName}";
      if (UserControlRelations.ContainsKey(controlName)) {
        UserControlRelations.Remove(controlName);
      }
      PanelRelations.Controls.Remove(uc);
      uc.Dispose();
    }

    public void UpdateRelation(string name, RelationType relationType, Relation relation, bool withoutRPCSet = false) {
      if (!string.IsNullOrWhiteSpace(name)) {
        if (IsRPCSync && !withoutRPCSet && Sync == SyncStatus.Connected) {
          RPC_Wrapper.SetRelation(ProgramSettings.Relations.RPC_Channel, relationType, name, relation);
        }
        Control[] controls = PanelRelations.Controls.Find($"UserControlRelation_{relationType}_{name}", false);
        if (controls?.Length == 1) {
          if (relation == Relation.NotAssigned) {
            if (InvokeRequired) {
              Invoke(() => RemoveControl(controls[0] as UserControlRelation));
            } else {
              RemoveControl(controls[0] as UserControlRelation);
            }
          } else if (controls[0] is UserControlRelation control) {
            if (InvokeRequired) {
              Invoke(() => control.UpdateRelation(relation));
              Invoke(() => control.Visible = RelationIsVisible(relation));
            } else {
              control.UpdateRelation(relation);
              control.Visible = RelationIsVisible(relation);
            }
          }
        } else if (relation > Relation.NotAssigned) {
          // Da gefiltert werden kann, die Daten nicht auf die maximale Anzahl von darzustellenden Einträgen begrenzen
          //if (PanelRelations.Controls.Count == ProgramSettings.Relations.EntriesMax) {
          //  RemoveControl(PanelRelations.Controls[0] as UserControlRelation);
          //}
          if (InvokeRequired) {
            Invoke(() => AddControl(name, relationType, relation));
          } else {
            AddControl(name, relationType, relation);
          }
        }
        if (InvokeRequired) {
          Invoke(FilterRelations);
        } else {
          FilterRelations();
        }
      }
    }

    private bool RelationIsVisible(Relation relation) {
      return relation switch {
        Relation.Friendly => CheckBoxFilterFriendly.Checked,
        Relation.Neutral => CheckBoxFilterNeutral.Checked,
        Relation.Bogey => CheckBoxFilterBogey.Checked,
        Relation.Bandit => CheckBoxFilterBandit.Checked,
        _ => false,
      };
    }

    public Relation GetOrganizationRelation(string sid) {
      Relation rtnVal = Relation.NotAssigned;
      rtnVal = GetRPCRelation(RelationType.Organization, sid);
      if (rtnVal == Relation.NotAssigned) {
        UserControlRelation control = UserControlRelations.Select(x => x.Value).FirstOrDefault(x => x.Type == RelationType.Organization && x.RelationName == sid);
        if (control != null) {
          rtnVal = control.Relation;
        }
      }
      return rtnVal;
    }

    public Relation GetHandleRelation(string handle) {
      Relation rtnVal = Relation.NotAssigned;
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
          switch (control.Relation) {
            case Relation.Friendly:
              control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterFriendly.Checked;
              break;
            case Relation.Neutral:
              control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterNeutral.Checked;
              break;
            case Relation.Bogey:
              control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterBogey.Checked;
              break;
            case Relation.Bandit:
              control.Visible = (control.Type != RelationType.Organization || CheckBoxFilterOrganization.Checked) && CheckBoxFilterBandit.Checked;
              break;
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
      e.DrawText();
    }

  }

}
