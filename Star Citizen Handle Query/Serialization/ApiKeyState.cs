namespace Star_Citizen_Handle_Query.Serialization {

#pragma warning disable IDE1006 // Benennungsstile
  public class ApiKeyState {
    public ApiKeyState_Data data { get; set; }
    public string message { get; set; }
    public object source { get; set; }
    public int success { get; set; }
  }

  public class ApiKeyState_Data {
    public int creation_date { get; set; }
    public int edition_date { get; set; }
    public int id { get; set; }
    public string oauth_id { get; set; }
    public int privileged { get; set; }
    public string provider { get; set; }
    public string user_key { get; set; }
    public int value { get; set; }
  }
#pragma warning restore IDE1006 // Benennungsstile

}
