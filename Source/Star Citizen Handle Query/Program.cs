using Star_Citizen_Handle_Query.Dialogs;
using System.Text.Json;
using System.Text;
using Star_Citizen_Handle_Query.Serialization;
using static Star_Citizen_Handle_Query.Dialogs.FormHandleQuery;

namespace Star_Citizen_Handle_Query {

  internal static class Program {

    private static FormHandleQuery FormMain;
    private static EventWaitHandle WaitHandle;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Settings settings = GetProgramSettings();
      if (settings?.DpiUnaware ?? false) {
        Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
      } else {
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
      }
      ApplicationConfiguration.Initialize();

      bool restart = false;
      WaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, Application.ProductName, out bool isNew);
      if (isNew) {
        FormMain = new(settings);
        Thread thread = new(BringThreadToFront);
        thread.Start();
        Application.Run(FormMain);
        restart = FormMain.DialogResult == DialogResult.Retry;
        FormMain.Dispose();
        FormMain = null;
      }
      WaitHandle.Set();
      if (restart) {
        Application.Restart();
      }
    }

    private static void BringThreadToFront() {
      for (; ; ) {
        WaitHandle.WaitOne();
        if (FormMain == null) {
          break;
        }
        FormMain.BeginInvoke(new ThreadStart(BringToFront));
      }
    }

    private static void BringToFront() {
      FormMain.ShowWindow();
    }

    private static Settings GetProgramSettings() {
      Settings rtnVal = null;

      // Einstellungen aus Datei lesen
      string newPath = GetSettingsFilePath();
      if (File.Exists(newPath)) {
        rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(newPath));
      } else {
        Version programVersion = FormHandleQuery.GetProgramVersion();
        foreach (string directory in Directory.GetDirectories(Directory.GetParent(GetSaveFilesRootPath()).FullName).OrderByDescending(x => x).Select(x => x.Split('+')[0])) {
          Version version = new(Path.GetFileName(directory) + ".0");
          if (version < programVersion) {
            string legacyPath = Path.Combine(directory, GetSettingsFileName());
            if (File.Exists(legacyPath)) {
              rtnVal = JsonSerializer.Deserialize<Settings>(File.ReadAllText(legacyPath));
              if (rtnVal != null) {
                try {
                  File.Move(legacyPath, newPath);
                } catch { }
              }
              legacyPath = Path.Combine(directory, GetAppColorsFileName());
              if (File.Exists(legacyPath)) {
                try {
                  File.Move(legacyPath, GetAppColorsFilePath());
                } catch { }
              }
              legacyPath = Path.Combine(directory, "Relations.json");
              if (File.Exists(legacyPath)) {
                try {
                  File.Move(legacyPath, GetCachePath(CacheDirectoryType.Root, "Relations"));
                } catch { }
              }
              legacyPath = Path.Combine(directory, "Cache");
              newPath = GetCachePath(CacheDirectoryType.Root);
              if (Directory.Exists(legacyPath) && !Directory.Exists(newPath)) {
                try {
                  Directory.Move(legacyPath, newPath);
                } catch { }
              }
              legacyPath = Path.Combine(directory, @"Localization\Templates");
              if (Directory.Exists(legacyPath)) {
                foreach (string file in Directory.GetFiles(legacyPath)) {
                  try {
                    File.Delete(file);
                  } catch { }
                }
                try {
                  Directory.Delete(legacyPath);
                } catch { }
              }
              legacyPath = Path.Combine(legacyPath, @"..\");
              newPath = FormSettings.GetLocalizationPath();
              if (Directory.Exists(legacyPath)) {
                if (!Directory.Exists(newPath)) {
                  Directory.CreateDirectory(newPath);
                }
                foreach (string file in Directory.GetFiles(legacyPath)) {
                  try {
                    File.Move(file, Path.Combine(newPath, Path.GetFileName(file)));
                  } catch { }
                }
                try {
                  Directory.Delete(legacyPath);
                } catch { }
              }
              legacyPath = Path.Combine(directory, "Templates");
              newPath = FormSettings.GetTemplatesPath();
              if (Directory.Exists(legacyPath)) {
                if (!Directory.Exists(newPath)) {
                  Directory.CreateDirectory(newPath);
                }
                foreach (string file in Directory.GetFiles(legacyPath)) {
                  try {
                    File.Move(file, Path.Combine(newPath, Path.GetFileName(file)));
                  } catch { }
                }
                try {
                  Directory.Delete(legacyPath);
                } catch { }
              }
              try {
                Directory.Delete(directory);
              } catch { }
            }
            break;
          }
        }
      }

      if (rtnVal != null) {
        // Ggf. abweichende Farben laden
        string colorsFilePath = FormHandleQuery.GetAppColorsFilePath();
        if (File.Exists(colorsFilePath)) {
          string jsonColors = File.ReadAllText(colorsFilePath, Encoding.UTF8);
          rtnVal.Colors = JsonSerializer.Deserialize<AppColors>(jsonColors);
          rtnVal.Colors ??= new();
        }
      }

      if (rtnVal != null && !rtnVal.DpiUnaware && Environment.GetCommandLineArgs().Any(x => x.Equals("-DpiUnaware", StringComparison.InvariantCultureIgnoreCase))) {
        rtnVal.DpiUnaware = true;
      }

      return rtnVal;
    }

  }

}
