namespace Star_Citizen_Handle_Query.Serialization {

#pragma warning disable IDE1006 // Benennungsstile
  public class ApiHandleInfo : ApiBaseInfo {
    public ApiHandleInfoData data { get; set; }
  }

  public class ApiHandleInfoData {
    public ApiHandleInfoDataOrganization[] affiliation { get; set; }
    public ApiHandleInfoDataOrganization organization { get; set; }
    public ApiHandleInfoDataProfile profile { get; set; }
  }

  public class ApiHandleInfoDataOrganization {
    public string image { get; set; }
    public string name { get; set; }
    public string rank { get; set; }
    public string sid { get; set; }
    public int stars { get; set; }
  }

  public class ApiHandleInfoDataProfile {
    public string badge { get; set; }
    public string badge_image { get; set; }
    public string bio { get; set; }
    public string display { get; set; }
    public DateTime enlisted { get; set; }
    public string[] fluency { get; set; }
    public string handle { get; set; }
    public string id { get; set; }
    public string image { get; set; }
    public ApiHandleInfoDataProfilePage page { get; set; }
  }

  public class ApiHandleInfoDataProfilePage {
    public string title { get; set; }
    public string url { get; set; }
  }
#pragma warning restore IDE1006 // Benennungsstile

}
