using System.Net;
using System.Text.Json.Serialization;

namespace Star_Citizen_Handle_Query.Serialization {

  public class HandleInfo {

    [JsonIgnore]
    public HttpInfo HttpResponse { get; set; }
    public HandleProfileInfo Profile { get; set; }
    public OrganizationsInfo Organizations { get; set; }
    public string Comment { get; set; }

  }

  public class HttpInfo {

    public HttpStatusCode? StatusCode { get; set; }
    public string ErrorText { get; set; }
    public string Source { get; set; }

  }

  public class HandleProfileInfo {

    public string UeeCitizenRecord { get; set; }
    public string Handle { get; set; }
    public string CommunityMonicker { get; set; }
    public DateTime Enlisted { get; set; }
    public string Url { get; set; }
    public string AvatarUrl { get; set; }
    public string DisplayTitle { get; set; }
    public string DisplayTitleAvatarUrl { get; set; }
    public List<string> Fluency { get; set; } = new List<string>();

  }

  public class OrganizationsInfo {

    public OrganizationInfo MainOrganization { get; set; }
    public List<OrganizationInfo> Affiliations { get; set; }

  }

  public class OrganizationInfo {

    public bool Redacted { get; set; }
    public string RankName { get; set; }
    public int? RankStars { get; set; }
    public string Sid { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string AvatarUrl { get; set; }
    public int? Members { get; set; }
    public string PrimaryActivity { get; set; }
    public string SecondaryActivity { get; set; }
    public string Commitment { get; set; }

  }

}
