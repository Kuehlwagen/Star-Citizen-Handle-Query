namespace Star_Citizen_Handle_Query.Serialization {

#pragma warning disable IDE1006 // Benennungsstile
  public class ApiOrganizationInfo : ApiBaseInfo {
    public ApiOrganizationInfoData data { get; set; }
  }

  public class ApiOrganizationInfoData {
    public string archetype { get; set; }
    public string banner { get; set; }
    public string commitment { get; set; }
    public ApiOrganizationInfoDataFocus focus { get; set; }
    public ApiOrganizationInfoDataHeadline headline { get; set; }
    public string href { get; set; }
    public string lang { get; set; }
    public string logo { get; set; }
    public int members { get; set; }
    public object[] members_list { get; set; }
    public string name { get; set; }
    public bool recruiting { get; set; }
    public bool roleplay { get; set; }
    public string sid { get; set; }
    public string url { get; set; }
  }

  public class ApiOrganizationInfoDataFocus {
    public ApiOrganizationInfoDataFocusFocus primary { get; set; }
    public ApiOrganizationInfoDataFocusFocus secondary { get; set; }
  }

  public class ApiOrganizationInfoDataFocusFocus {
    public string image { get; set; }
    public string name { get; set; }
  }

  public class ApiOrganizationInfoDataHeadline {
    public string html { get; set; }
    public string plaintext { get; set; }
  }
#pragma warning restore IDE1006 // Benennungsstile

}
