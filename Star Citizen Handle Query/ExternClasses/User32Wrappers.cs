using System.Runtime.InteropServices;

namespace Star_Citizen_Handle_Query.ExternClasses {

  public partial class User32Wrappers {

    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    public const int SW_MINIMIZE = 6;
    public const int SW_RESTORE = 9;

    public enum GWL : int {
      ExStyle = -20
    }

    public enum WS_EX : int {
      Transparent = 0x20,
      Layered = 0x80000
    }

    [LibraryImport("user32.dll")]
    internal static partial int GetWindowLongA(IntPtr hWnd, GWL nIndex);

    [LibraryImport("user32.dll")]
    internal static partial int SetWindowLongA(IntPtr hWnd, GWL nIndex, int dwNewLong);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool SetForegroundWindow(IntPtr hWnd);

    [LibraryImport("user32.dll")]
    internal static partial int SendMessageA(IntPtr hWnd, int Msg, int wParam, int lParam);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ReleaseCapture();

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ShowWindow(IntPtr hwnd, int nCmdShow);

  }

}
