using System.Diagnostics;
using System.Security.Policy;

namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable, DebuggerDisplay("{Name} ({Type}, {ParentBody}, {ParentStar})")]
  public class LocationInfo {

    public string Name { get; set; }
    public string Type { get; set; }
    public string ParentBody { get; set; }
    public string ParentStar { get; set; }
    public string CoordinateX { get; set; }
    public string CoordinateY { get; set; }
    public string CoordinateZ { get; set; }
    public string ThemeImage { get; set; }
    public string WikiLink { get; set; }
    public bool Private { get; set; }
    public bool Quantum { get; set; }
    public string Affiliation { get; set; }

  }

}
