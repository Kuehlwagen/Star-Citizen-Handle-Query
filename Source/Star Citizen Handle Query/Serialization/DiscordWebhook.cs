namespace Star_Citizen_Handle_Query.Serialization;

#pragma warning disable IDE1006 // Benennungsstile
public class DiscordWebhook {
  public string content { get; set; }
  public List<DiscordEmbed> embeds { get; set; } = [];
}

public class DiscordEmbed {
  public string title { get; set; }
  public string type { get; set; } = "rich";
  public string description { get; set; }
  public string url { get; set; }
  public int? color { get; set; }
  public List<DiscordField> fields { get; set; } = [];
  public DiscordFooter footer { get; set; }
}

public class DiscordField {
  public string name { get; set; }
  public string value { get; set; }
}

public class DiscordFooter {
  public string text { get; set; }
  public string icon_url { get; set; }
}
#pragma warning restore IDE1006 // Benennungsstile
