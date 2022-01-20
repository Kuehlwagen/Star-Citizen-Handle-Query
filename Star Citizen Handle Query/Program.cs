using System.Diagnostics;

namespace Star_Citizen_Handle_Query {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      Process[] p = Process.GetProcessesByName(Application.ProductName);
      if (p.Length <= 1) {
        ApplicationConfiguration.Initialize();
        Application.Run(new Dialogs.FormHandleQuery());
      }
    }
  }
}
