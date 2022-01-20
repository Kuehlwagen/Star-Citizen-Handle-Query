using System;
using System.Runtime.InteropServices;

namespace Star_Citizen_Handle_Query.ExternClasses {

  public class User32Wrappers {

    public enum GWL : int {
      ExStyle = -20
    }

    public enum WS_EX : int {
      Transparent = 0x20,
      Layered = 0x80000
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static internal extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static internal extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static internal extern bool SetForegroundWindow(IntPtr hWnd);

  }

}
