namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class CorpseMonitorInfo : ICloneable {

    public DateTime Date { get; set; } = DateTime.MinValue;

    public string Handle { get; set; } = string.Empty;

    public bool CorpseEnabled { get; set; } = false;

    public string Info { get; set; } = string.Empty;

    public bool IsCriminalArrest {
      get { return Info.ToLower().Contains("criminal arrest"); }
    }

    public bool IsLocalInventory {
      get { return Info.ToLower().Contains("there is a local inventory"); }
    }

    public bool IsValid {
      get { return Date > DateTime.MinValue && Handle?.Length > 0;
      }
    }

    public object Clone() {
      return MemberwiseClone();
    }
  }

}
