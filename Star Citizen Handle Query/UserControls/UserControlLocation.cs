using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;

namespace Star_Citizen_Handle_Query.UserControls {

  public partial class UserControlLocation : UserControl {

    internal readonly LocationInfo Info;

    public UserControlLocation(LocationInfo info) {
      InitializeComponent();
      Info = info;
    }

    private void UserControlLog_Load(object sender, EventArgs e) {
      LabelLocationName.Text = Info.Name;
      LabelType.Text = Info.Type;
      LabelDescription.Text = $"{Info.ParentBody} ({Info.ParentStar})";
    }

    private void LabelLocationName_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        Process.Start("explorer", $"https://dydrmr.github.io/VerseTime/#{Info.Name.Replace(" ", "_")}");
        (Parent.Parent as Form).Close();
      }
    }

  }

}
