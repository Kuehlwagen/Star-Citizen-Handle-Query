using System.Runtime.InteropServices;

namespace Star_Citizen_Handle_Query.ExternClasses {
  #region License_Do_Not_Remove
  /* 
  *  Made by TheDarkJoker94. 
  *  Check http://thedarkjoker94.cer33.com/ for more C# Tutorials 
  *  and also SUBSCRIBE to my Youtube Channel http://www.youtube.com/user/TheDarkJoker094  
  *  GlobalKeyboardHook is licensed under a Creative Commons Attribution 3.0 Unported License.(http://creativecommons.org/licenses/by/3.0/)
  *  This means you can use this Code for whatever you want as long as you credit me! That means...
  *  DO NOT REMOVE THE LINES ABOVE !!! 
  */
  #endregion

  using System.Runtime.InteropServices;

  namespace Star_Citizen_Handle_Query.ExternClasses {

    public class GlobalHotKey {

      [DllImport("user32.dll")]
      static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref KeyBoardHookStruct lParam);
      [DllImport("user32.dll")]
      static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);
      [DllImport("user32.dll")]
      static extern bool UnhookWindowsHookEx(IntPtr hInstance);
      [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
      static extern IntPtr LoadLibrary(string lpFileName);
      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]

      private static extern short GetKeyState(int keyCode);

      public delegate int LLKeyboardHook(int Code, int wParam, ref KeyBoardHookStruct lParam);

      public struct KeyBoardHookStruct {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
      }

      const int WH_KEYBOARD_LL = 13;
      const int WM_KEYDOWN = 0x0100;
      const int WM_KEYUP = 0x0101;
      const int WM_SYSKEYDOWN = 0x0104;
      const int WM_SYSKEYUP = 0x0105;

      private const int VK_SHIFT = 0x10;
      private const int VK_CONTROL = 0x11;
      private const int VK_MENU = 0x12;
      private const int VK_CAPITAL = 0x14;

      readonly LLKeyboardHook llkh;
      public List<Keys> HookedKeys = new();

      IntPtr GlobalHook = IntPtr.Zero;

      public event KeyEventHandler KeyDown;
      public event KeyEventHandler KeyUp;

      public GlobalHotKey() {
        llkh = new LLKeyboardHook(HookProc);
      }

      ~GlobalHotKey() { Unhook(); }

      public void Hook() {
        IntPtr hInstance = LoadLibrary("User32");
        GlobalHook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
      }

      public void Unhook() {
        UnhookWindowsHookEx(GlobalHook);
      }

      /// <summary>
      /// Checks whether Alt, Shift, Control or CapsLock
      /// is pressed at the same time as the hooked key.
      /// Modifies the keyCode to include the pressed keys.
      /// </summary>
      private static Keys AddModifiers(Keys key) {
        ////CapsLock
        if ((GetKeyState(VK_CAPITAL) & 0x0001) != 0) key |= Keys.CapsLock;

        //Shift
        if ((GetKeyState(VK_SHIFT) & 0x8000) != 0) key |= Keys.Shift;

        //Ctrl
        if ((GetKeyState(VK_CONTROL) & 0x8000) != 0) key |= Keys.Control;

        //Alt
        if ((GetKeyState(VK_MENU) & 0x8000) != 0) key |= Keys.Alt;

        return key;
      }

      public int HookProc(int Code, int wParam, ref KeyBoardHookStruct lParam) {
        if (Code >= 0) {
          Keys key = (Keys)lParam.vkCode;
          if (HookedKeys.Contains(key)) {

            //Get modifiers
            key = AddModifiers(key);

            KeyEventArgs kArg = new(key);
            if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && KeyDown != null)
              KeyDown(this, kArg);
            else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && KeyUp != null)
              KeyUp(this, kArg);
            if (kArg.Handled)
              return 1;
          }
        }
        return CallNextHookEx(GlobalHook, Code, wParam, ref lParam);
      }

    }

  }
}
