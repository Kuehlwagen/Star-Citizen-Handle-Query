using Star_Citizen_Handle_Query.Dialogs;

namespace Star_Citizen_Handle_Query {

  internal static class Program {

    private static FormHandleQuery FormMain;
    private static EventWaitHandle WaitHandle;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      ApplicationConfiguration.Initialize();

      bool restart = false;
      WaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, Application.ProductName, out bool isNew);
      if (isNew) {
        FormMain = new();
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

  }

}
