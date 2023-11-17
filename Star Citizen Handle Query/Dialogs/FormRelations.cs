using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormRelations : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;
    private readonly SortedList<string, UserControlRelation> UserControlRelations = new();

    public FormRelations(Settings programSettings, Translation translation) {
      InitializeComponent();
      ProgramSettings = programSettings;
      ProgramTranslation = translation;

      // Pr�fen, ob die Programm-Einstellungen valide sind
      if (ProgramSettings != null) {
        // Fenster-Deckkraft setzen
        Opacity = (double)ProgramSettings.WindowOpacity / 100.0;

        if (ProgramSettings.WindowIgnoreMouseInput) {
          // Durch das Fenster klicken lassen
          InitialWindowStyle = User32Wrappers.GetWindowLongA(Handle, User32Wrappers.GWL.ExStyle);
          _ = User32Wrappers.SetWindowLongA(Handle, User32Wrappers.GWL.ExStyle, InitialWindowStyle | (int)User32Wrappers.WS_EX.Layered | (int)User32Wrappers.WS_EX.Transparent);
        }
      }

      // �bersetzung laden
      SetTranslation();
    }

    private void SetTranslation() {
      // Pr�fen, ob die �bersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        LabelTitle.Text = $"{ProgramTranslation.Relations.Title}";
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

    private void FormRelations_Shown(object sender, EventArgs e) {
      Height = 31;
      ImportRelationInfos();
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
          JsonSerializer.Serialize(infos, new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
          }), Encoding.UTF8);
      } catch { }
    }

    internal void ImportRelationInfos(string importPath = null) {
      string jsonFilePath = importPath ?? FormHandleQuery.GetCachePath(FormHandleQuery.CacheDirectoryType.Root, "Relations");
      if (File.Exists(jsonFilePath)) {
        try {
          RelationInfos infos = JsonSerializer.Deserialize<RelationInfos>(File.ReadAllText(jsonFilePath, Encoding.UTF8));
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
              foreach (RelationInfo info in infos.Relations) {
                AddControl(info.Name, info.Type, info.Relation);
              }
            }
          }
          FilterRelations();
        } catch { }
      }
    }

    private void PictureBoxClearAll_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        ClearRelations();
      }
    }

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      FormHandleQuery.CheckSnap(this, Location);
    }

    private void PanelRelations_ControlAdded(object sender, ControlEventArgs e) {
      if (PanelRelations.Controls.Count == 1) {
        PictureBoxClearAll.MouseClick += PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll;
        PictureBoxClearAll.Cursor = Cursors.Hand;
      }
      if (PanelRelations.Controls.Count <= ProgramSettings.Relations.EntriesMax) {
        Height += e.Control.Height + 2;
      }
    }

    private void PanelRelations_ControlRemoved(object sender, ControlEventArgs e) {
      if (PanelRelations.Controls.Count < ProgramSettings.Relations.EntriesMax) {
        Height -= e.Control.Height + 2;
      }
      if (PanelRelations.Controls.Count == 0) {
        PictureBoxClearAll.MouseClick -= PictureBoxClearAll_MouseClick;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
    }

    private void AddControl(string name, RelationType relationType, Relation relation) {
      UserControlRelation control = new(name, relationType, relation) { Name = $"UserControlRelation_{relationType}_{name}", Visible = RelationIsVisible(relation) };
      UserControlRelations.Add(name, control);
      PanelRelations.Controls.Add(control);
      if (ProgramSettings.Relations.SortAlphabetically && UserControlRelations.ContainsKey(name)) {
        PanelRelations.Controls.SetChildIndex(control, UserControlRelations.IndexOfKey(name));
      }
    }

    public void RemoveControl(UserControlRelation uc) {
      if (UserControlRelations.ContainsKey(uc.RelationName)) {
        UserControlRelations.Remove(uc.RelationName);
      }
      PanelRelations.Controls.Remove(uc);
      uc.Dispose();
    }

    public void UpdateRelation(string name, RelationType relationType, Relation relation) {
      if (!string.IsNullOrWhiteSpace(name)) {
        Control[] controls = PanelRelations.Controls.Find($"UserControlRelation_{relationType}_{name}", false);
        if (controls?.Length == 1) {
          if (relation == Relation.NotAssigned) {
            RemoveControl(controls[0] as UserControlRelation);
          } else if (controls[0] is UserControlRelation control) {
            control.UpdateRelation(relation);
            control.Visible = RelationIsVisible(relation);
          }
        } else if (relation > Relation.NotAssigned) {
          // Da gefiltert werden kann, die Daten nicht auf die maximale Anzahl von darzustellenden Eintr�gen begrenzen
          //if (PanelRelations.Controls.Count == ProgramSettings.Relations.EntriesMax) {
          //  RemoveControl(PanelRelations.Controls[0] as UserControlRelation);
          //}
          AddControl(name, relationType, relation);
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
      UserControlRelation control = UserControlRelations.Select(x => x.Value).FirstOrDefault(x => x.Type == RelationType.Organization && x.RelationName == sid);
      if (control != null) {
        rtnVal = control.Relation;
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

    private void FilterRelations() {
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
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(19, 26, 33)), 4, 4, 6, 6);
      }
    }

  }

}
