using SCHQ_Protos;
using System.Globalization;

namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class LogMonitorInfo(LogType logType, string date, string handle = null, string key = null, string value = null,
    Bitmap icon = null, RelationValue relation = RelationValue.NotAssigned) : ICloneable {

    public Bitmap Icon { get; } = icon;

    public LogType LogType { get; } = logType;

    public DateTime Date { get; } = DateTime.Parse(date, CultureInfo.InvariantCulture).ToLocalTime();

    public string Handle { get; } = handle ?? string.Empty;

    public string Key { get; } = key ?? string.Empty;

    public string Value { get; } = value ?? string.Empty;

    public bool IsCorpseEnabled { get; } = logType == LogType.Corpse &&
      key != null && key.Equals("IsCorpseEnabled", StringComparison.CurrentCultureIgnoreCase) &&
      value != null && value.StartsWith("Yes", StringComparison.CurrentCultureIgnoreCase);

    public RelationValue RelationValue { get; } = relation;

    public bool IsCriminalArrest { get; } = logType == LogType.Corpse &&
      key != null && key.Equals("IsCorpseEnabled", StringComparison.CurrentCultureIgnoreCase) &&
      value != null && value.Contains("Criminal Arrest", StringComparison.CurrentCultureIgnoreCase);

    public bool IsLocalInventoryAvailable { get; } = logType == LogType.Corpse &&
      key != null && key.Equals("IsCorpseEnabled", StringComparison.CurrentCultureIgnoreCase) &&
      value != null && value.Contains("there is a local inventory", StringComparison.CurrentCultureIgnoreCase);

    public bool IsLocationInfo { get; } = logType == LogType.Corpse &&
      key != null && key.Equals("DoesLocationContainHospital", StringComparison.CurrentCultureIgnoreCase) &&
      !string.IsNullOrWhiteSpace(value);

    public bool IsValid { get { return Date > DateTime.MinValue; } }

    public override bool Equals(object obj) {
      if (obj != null && obj is LogMonitorInfo lmi) {
        return lmi.LogType == LogType &&
          lmi.Handle == Handle &&
          lmi.Date <= Date && lmi.Date.AddSeconds(5) >= Date;
      } else {
        return base.Equals(obj);
      }
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }

    public object Clone() {
      return MemberwiseClone();
    }

  }

  public enum LogType {
    Corpse,
    LoadingScreenDuration
  }

}
