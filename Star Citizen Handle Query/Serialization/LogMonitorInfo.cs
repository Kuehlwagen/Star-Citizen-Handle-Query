using System.Globalization;

namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class LogMonitorInfo : ICloneable {

    public LogMonitorInfo(LogType logType, string date, string handle = null, string info = null, string additionalInfo = null) {
      LogType = logType;
      Date = DateTime.Parse(date, CultureInfo.InvariantCulture).ToLocalTime();
      Handle = handle ?? string.Empty;
      Info = info ?? string.Empty;
      IsCorpseEnabled = logType == LogType.Corpse && additionalInfo?.ToLower() == "yes";
    }

    public LogType LogType { get; } = LogType.Corpse;

    public DateTime Date { get; } = DateTime.MinValue;

    public string Handle { get; } = string.Empty;

    public string Info { get; } = string.Empty;

    public bool IsCorpseEnabled { get; } = false;

    public bool IsCriminalArrest { get { return LogType == LogType.Corpse && Info.ToLower().Contains("criminal arrest"); } }

    public bool IsLocalInventoryAvailable { get { return LogType == LogType.Corpse && Info.ToLower().Contains("there is a local inventory"); } }

    public bool IsValid { get { return Date > DateTime.MinValue; } }

    public object Clone() {
      return MemberwiseClone();
    }

  }

  public enum LogType {
    Corpse
  }

}
