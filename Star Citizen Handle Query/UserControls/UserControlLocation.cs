using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Reflection;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLocation : UserControl {

    private readonly LocationInfo Info;
    private readonly Settings ProgramSettings;

    public UserControlLocation(LocationInfo info, Settings programSettings) {
      InitializeComponent();
      Info = info;
      ProgramSettings = programSettings;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelLocationName.Text = Info.Name;
      LabelType.Text = Info.Type;
      LabelDescription.Text = $"{Info.ParentBody} ({Info.ParentStar})";
    }

    private void LabelLocationName_MouseClick(object sender, MouseEventArgs e) {
      try {
        switch (e.Button) {
          case MouseButtons.Left:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.LMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.LMB_URL));
            }
            (Parent.Parent as Form).Close();
            break;
          case MouseButtons.Middle:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.MMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.MMB_URL));
            }
            (Parent.Parent as Form).Close();
            break;
          case MouseButtons.Right:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.RMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.RMB_URL));
            }
            (Parent.Parent as Form).Close();
            break;
        }
      } catch { }
    }

    private string ReplaceLocationInfo(string locationInfo) {
      string rtnVal = string.Empty;

      // Ggf. mehrere Texte (getrennt durch Pipe) auswerten
      foreach (string s in locationInfo.Split("|")) {
        // LocationInfo-Properties ersetzen
        rtnVal = s;
        foreach (PropertyInfo prop in Info.GetType().GetProperties()) {
          rtnVal = rtnVal.Replace($"{{{prop.Name.ToUpper()}}}", $"{prop.GetValue(Info)}", StringComparison.InvariantCultureIgnoreCase);
        }
        if (!string.IsNullOrWhiteSpace(rtnVal)) {
          break;
        }
      }
      // Leerzeichen durch Unterstrich ersetzen
      rtnVal = rtnVal.Replace(" ", "_");

      return rtnVal;
    }

  }

}
