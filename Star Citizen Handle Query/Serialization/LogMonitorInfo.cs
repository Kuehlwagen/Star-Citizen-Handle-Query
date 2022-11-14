using System.Globalization;

namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class LogMonitorInfo : ICloneable {

    public LogMonitorInfo(string date, string handle, string info, string corpse = null) {
      Date = DateTime.Parse(date, CultureInfo.InvariantCulture).ToLocalTime();
      Handle = handle ?? string.Empty;
      IsCorpseEnabled = corpse?.ToLower() == "yes";
      Info = info ?? string.Empty;
    }

    public DateTime Date { get; } = DateTime.MinValue;

    public string Handle { get; } = string.Empty;

    public string Info { get; } = string.Empty;

    public bool IsCorpseEnabled { get; } = false;

    public bool IsCriminalArrest { get { return Info.ToLower().Contains("criminal arrest"); } }

    public bool IsLocalInventoryAvailable { get { return Info.ToLower().Contains("there is a local inventory"); } }

    public bool IsValid { get { return Date > DateTime.MinValue && Handle?.Length > 0; } }

    public object Clone() {
      return MemberwiseClone();
    }

  }

}
