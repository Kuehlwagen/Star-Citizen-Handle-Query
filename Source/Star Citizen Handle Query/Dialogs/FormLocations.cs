using Star_Citizen_Handle_Query.Classes;
using Star_Citizen_Handle_Query.Properties;
using Star_Citizen_Handle_Query.Serialization;
using Star_Citizen_Handle_Query.UserControls;
using System.Net;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.Dialogs {

  public partial class FormLocations : Form {

    private const string LocationsCsvUrl = "https://raw.githubusercontent.com/Kuehlwagen/Star-Citizen-Handle-Query/refs/heads/master/Source/Star%20Citizen%20Handle%20Query/Resources/locations.csv";
    private readonly int InitialWindowStyle = 0;
    private bool WindowLocked = true;
    private readonly Settings ProgramSettings;
    private readonly Translation ProgramTranslation;
    private readonly List<LocationInfo> Locations = [];
    private readonly TypeAssistant TextChangedAssistant;

    public FormLocations(Settings programSettings, Translation translation) {
      InitializeComponent();
      TextChangedAssistant = new();
      TextChangedAssistant.Idled += TextChangedAssistant_Idled;

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

      // Ggf. Cache-Verzeichnis für Ort-Bilder erstellen
      CreateDirectory(CacheDirectoryType.Location);

      // Orte ermitteln
      Task.Run(LoadLocations);
    }

    internal void ShowWindow() {
      // Fenster einblenden
      User32Wrappers.SetForegroundWindow(Handle);
      Activate();
      TextBoxFilterLocations.Focus();
    }

    private async void LoadLocations() {
      // Orte initial aus Ressourcen auslesen
      string locationCsv = Resources.Locations;
      // Wenn Orte noch nicht ermittelt wurden, versuchen via GitHub auszulesen
      HttpInfo httpInfo = await GetSource(LocationsCsvUrl, CancelToken);
      if (httpInfo.StatusCode == HttpStatusCode.OK) {
        locationCsv = httpInfo.Source;
      }
      foreach (string line in locationCsv.Split(['\n', '\r'])) {
        string[] v = line.Split(',');
        Locations.Add(new() {
          Name = v[0],
          Type = v[1],
          ParentBody = v[2],
          ParentStar = v[3],
          CoordinateX = v[4],
          CoordinateY = v[5],
          CoordinateZ = v[6],
          WikiLink = v[7],
          Private = v[8] == "1",
          Quantum = v[9] == "1"
        });
      }
      Locations.RemoveAt(0);
    }

    private void TextChangedAssistant_Idled(object sender, EventArgs e) {
      Invoke(new MethodInvoker(() => {
        PanelLocations.Controls.Clear();
        if (!string.IsNullOrWhiteSpace(TextBoxFilterLocations.Text)) {
          IEnumerable<LocationInfo> filter = Locations.Where(
            x => x.Name.Contains(TextBoxFilterLocations.Text, StringComparison.InvariantCultureIgnoreCase))
            .OrderBy(y => y.Name.StartsWith(TextBoxFilterLocations.Text, StringComparison.InvariantCultureIgnoreCase) ? 0 : 1)
            .ThenBy(z => z.Name);
          foreach (LocationInfo location in filter.Take(ProgramSettings.Locations.EntriesMax)) {
            PanelLocations.Controls.Add(new UserControlLocation(location, ProgramSettings));
          }
          int differenz = filter.Count() - PanelLocations.Controls.Count;
          if (differenz > 0) {
            PanelLocations.Controls.Add(new UserControlDimmedInfo($"{differenz} {(differenz == 1 ? ProgramTranslation.Locations.More_Location : ProgramTranslation.Locations.More_Locations)}"));
          }
        }
      }));
    }

    private void TextBoxFilterLocations_TextChanged(object sender, EventArgs e) {
      TextChangedAssistant.TextChanged(string.IsNullOrWhiteSpace(TextBoxFilterLocations.Text));
    }

    private void TextBoxFilterLocations_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
        TextChangedAssistant.TextChanged(true);
      }
    }

    private void SetTranslation() {
      // Prüfen, ob die Übersetzung valide ist
      if (ProgramTranslation != null) {
        // Control-Texte setzen
        LabelTitle.Text = ProgramTranslation.Locations.Title;
        TextBoxFilterLocations.PlaceholderText = ProgramTranslation.Locations.Filter_Placeholder;
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
      Location = new Point(Location.X + LogicalToDeviceUnits(352), 0);
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

    protected override void OnResizeEnd(EventArgs e) {
      base.OnResizeEnd(e);
      FormHandleQuery.CheckSnap(this, Location);
    }

    private void PanelLocations_ControlAdded(object sender, ControlEventArgs e) {
      Height += LogicalToDeviceUnits(e.Control.Height + 2);
    }

    private void PanelLocations_ControlRemoved(object sender, ControlEventArgs e) {
      Height -= LogicalToDeviceUnits(e.Control.Height + 2);
    }

    private void FormLocations_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
      }
    }

    private void FormLocations_Deactivate(object sender, EventArgs e) {
      TextBoxFilterLocations.Clear();
    }

    private void FormLocations_Shown(object sender, EventArgs e) {
      Height = LogicalToDeviceUnits(31);
    }

  }

}
