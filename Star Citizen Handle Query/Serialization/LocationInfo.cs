namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable]
  public class LocationInfo {

    public string Name { get; set; }
    public string Type { get; set; }
    public string ParentBody { get; set; }
    public string ParentStar { get; set; }
    public string CoordinateX { get; set; }
    public string CoordinateY { get; set; }
    public string CoordinateZ { get; set; }
    public string ThemeImage { get; set; }

  }

}
