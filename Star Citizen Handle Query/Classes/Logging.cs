using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query.Classes;
internal static class Logging {

  private static readonly string _logPath = new(Path.Combine(GetCachePath(CacheDirectoryType.Base), "SC_Handle_Query.log"));

  internal static void Log(string group, string message) {
    try {
      using StreamWriter sw = new(_logPath, true) { AutoFlush = true };
      sw.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm::ss} [{group}] {message}");
    } catch { }
  }

}
