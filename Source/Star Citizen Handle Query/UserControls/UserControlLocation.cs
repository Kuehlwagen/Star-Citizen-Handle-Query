using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;
using System.Reflection;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLocation : UserControl {

    private readonly LocationInfo Info;
    private readonly Settings ProgramSettings;

    public UserControlLocation(LocationInfo info, Settings programSettings) {
      InitializeComponent();

      // Farben setzen
      if (programSettings.Colors != null) {
        BackColor = programSettings.Colors.AppBackColor;
        ForeColor = programSettings.Colors.AppForeColor;
        LabelDescription.ForeColor = programSettings.Colors.AppForeColorInactive;
        LabelType.ForeColor = programSettings.Colors.AppForeColorInactive;
      }

      Info = info;
      ProgramSettings = programSettings;
    }

    private async void UserControlLog_Load(object sender, EventArgs e) {
      LabelLocationName.Text = Info.Name;
      LabelType.Text = Info.Type;
      LabelDescription.Text = $"{Info.ParentBody} ({Info.ParentStar})";
      PictureBoxLocation.Image = await GetImage(CacheDirectoryType.Location, Info.ThemeImage, Info.Name, ProgramSettings.LocalCacheMaxAge);
    }

    private void LabelLocationName_MouseClick(object sender, MouseEventArgs e) {
      try {
        switch (e.Button) {
          case MouseButtons.Left:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.LMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.LMB_URL));
            }
            break;
          case MouseButtons.Middle:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.MMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.MMB_URL));
            }
            break;
          case MouseButtons.Right:
            if (!string.IsNullOrWhiteSpace(ProgramSettings.Locations.RMB_URL)) {
              Process.Start("explorer", ReplaceLocationInfo(ProgramSettings.Locations.RMB_URL));
            }
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
