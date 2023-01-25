using Star_Citizen_Handle_Query.ExternClasses;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Drawing.Drawing2D;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormRelations : Form {

    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;

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
    }

    public void ClearRelations() {
      if (PanelRelations.Controls.Count > 0) {
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
      }
    }

    private void PictureBoxClearAll_Click(object sender, EventArgs e) {
      ClearRelations();
    }

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      FormHandleQuery.CheckSnap(this, Location);
    }

    private void PanelRelations_ControlAdded(object sender, ControlEventArgs e) {
      if (PanelRelations.Controls.Count == 1) {
        PictureBoxClearAll.Click += PictureBoxClearAll_Click;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll;
        PictureBoxClearAll.Cursor = Cursors.Hand;
      }
      if (PanelRelations.Controls.Count <= ProgramSettings.Relations.EntriesMax) {
        Height += e.Control.Height + 2;
      }
    }

    private void PanelRelations_ControlRemoved(object sender, ControlEventArgs e) {
      Height -= e.Control.Height + 2;
      if (PanelRelations.Controls.Count == 0) {
        PictureBoxClearAll.Click -= PictureBoxClearAll_Click;
        PictureBoxClearAll.Image = Properties.Resources.ClearAll_Deactivated;
        PictureBoxClearAll.Cursor = Cursors.Default;
      }
    }

    public void RemoveControl(UserControlRelation uc) {
      PanelRelations.Controls.Remove(uc);
      uc.Dispose();
    }

    public void UpdateRelation(string handle, Relation relation) {
      if (!string.IsNullOrWhiteSpace(handle)) {
        string controlName = $"UserControlRelation_{handle}";
        Control[] controls = PanelRelations.Controls.Find(controlName, false);
        if (controls?.Length == 1) {
          if (relation == Relation.NotAssigned) {
            RemoveControl(controls[0] as UserControlRelation);
          } else if (controls[0] is UserControlRelation control) {
            control.UpdateRelation(relation);
            control.Visible = RelationIsVisible(relation);
          }
        } else if (relation > Relation.NotAssigned) {
          if (PanelRelations.Controls.Count == ProgramSettings.Relations.EntriesMax) {
            RemoveControl(PanelRelations.Controls[0] as UserControlRelation);
          }
          PanelRelations.Controls.Add(new UserControlRelation(handle, relation) { Name = controlName, Visible = RelationIsVisible(relation) });
        }
      }
    }

    private bool RelationIsVisible(Relation relation) {
      switch (relation) {
        case Relation.Friendly:
          return CheckBoxFilterFriendly.Checked;
        case Relation.Neutral:
          return CheckBoxFilterNeutral.Checked;
        case Relation.Bogey:
          return CheckBoxFilterBogey.Checked;
        case Relation.Bandit:
          return CheckBoxFilterBandit.Checked;
        case Relation.NotAssigned:
        default:
          return false;
      }
    }

    private void CheckBoxFilterFriendly_CheckedChanged(object sender, EventArgs e) {
      FilterRelations(Relation.Friendly, CheckBoxFilterFriendly.Checked);
    }

    private void CheckBoxFilterNeutral_CheckedChanged(object sender, EventArgs e) {
      FilterRelations(Relation.Neutral, CheckBoxFilterNeutral.Checked);
    }

    private void CheckBoxFilterBogey_CheckedChanged(object sender, EventArgs e) {
      FilterRelations(Relation.Bogey, CheckBoxFilterBogey.Checked);
    }

    private void CheckBoxFilterBandit_CheckedChanged(object sender, EventArgs e) {
      FilterRelations(Relation.Bandit, CheckBoxFilterBandit.Checked);
    }

    private void FilterRelations(Relation relation, bool showRelation) {
      for (int i = PanelRelations.Controls.Count - 1; i >= 0; i--) {
        if (PanelRelations.Controls[i] is UserControlRelation control) {
          if (control.HandleRelation == relation) {
            control.Visible = showRelation;
          }
        }
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
