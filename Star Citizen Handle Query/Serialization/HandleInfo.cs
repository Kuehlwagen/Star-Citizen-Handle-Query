namespace Star_Citizen_Handle_Query.Serialization {

#pragma warning disable IDE1006 // Benennungsstile
  public class HandleInfo {
    public HandleInfoData data { get; set; }
    public string message { get; set; }
    public string source { get; set; }
    public int success { get; set; }
  }

  public class HandleInfoData {
    public HandleInfoDataAffiliation[] affiliation { get; set; }
    public HandleInfoDataOrganization organization { get; set; }
    public HandleInfoDataProfile profile { get; set; }
  }


  public class HandleInfoDataAffiliation {
    public string image { get; set; }
    public string name { get; set; }
    public string rank { get; set; }
    public string sid { get; set; }
    public int stars { get; set; }
  }


  public class HandleInfoDataOrganization {
    public string image { get; set; }
    public string name { get; set; }
    public string rank { get; set; }
    public string sid { get; set; }
    public int stars { get; set; }
  }

  public class HandleInfoDataProfile {
    public string badge { get; set; }
    public string badge_image { get; set; }
    public string bio { get; set; }
    public string display { get; set; }
    public DateTime enlisted { get; set; }
    public string[] fluency { get; set; }
    public string handle { get; set; }
    public string id { get; set; }
    public string image { get; set; }
    public HandleInfoDataProfilePage page { get; set; }
  }

  public class HandleInfoDataProfilePage {
    public string title { get; set; }
    public string url { get; set; }
  }
#pragma warning restore IDE1006 // Benennungsstile

}
