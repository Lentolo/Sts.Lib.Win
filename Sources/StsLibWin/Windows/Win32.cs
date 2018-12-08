using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StsLibWin.Windows
{
  public static class Win32
  {
    [StructLayout(LayoutKind.Sequential)]
    public struct Lastinputinfo
    {
      public static readonly int SizeOf = Marshal.SizeOf(typeof(Lastinputinfo));
      [MarshalAs(UnmanagedType.U4)]
      public uint cbSize;
      [MarshalAs(UnmanagedType.U4)]
      public uint dwTime;
    }
    public static readonly int Spi_Setdeskwallpaper = 0x14;
    public static readonly int Spif_Updateinifile = 0x01;
    public static readonly int Spif_Sendwininichange = 0x02;
    public static readonly int Wm_Close = 0x0010;
    public static readonly int Wm_Destroy = 0x0002;
    public static readonly int Wm_Setredraw = 0x000B;
    public static readonly int Wm_Paint = 0x000F;
    public static readonly int Wm_Erasebkgnd = 0x0014;
    public static readonly int Wm_Nchittest = 0x84;
    public static readonly int Wm_Nclbuttondown = 0x00A1;
    public static readonly int Wm_Keydown = 0x0100;
    public static readonly int Wm_Keyup = 0x0101;
    public static readonly int Wm_Char = 0x0102;
    public static readonly int Wm_Paste = 0x0302;
    public static readonly int Wm_User = 0x0400;
    public static readonly int Wm_Queryendsession = 0x11;
    public static readonly int Em_Getscrollpos = Wm_User + 221;
    public static readonly int Em_Setscrollpos = Wm_User + 222;
    public static readonly int Em_Geteventmask = Wm_User + 59;
    public static readonly int Em_Seteventmask = Wm_User + 69;
    public static readonly int Ht_Caption = 0x2;
    public static readonly int Ht_Left = 10;
    public static readonly int Ht_Right = 11;
    public static readonly int Ht_Top = 12;
    public static readonly int Ht_Topleft = 13;
    public static readonly int Ht_Topright = 14;
    public static readonly int Ht_Bottom = 15;
    public static readonly int Ht_Bottomleft = 16;
    public static readonly int Ht_Bottomright = 17;
    public static readonly int Vk_Control = 0x11;
    public static readonly int Vk_Up = 0x26;
    public static readonly int Vk_Down = 0x28;
    public static readonly int Vk_Numlock = 0x90;
    public static readonly short Ks_On = 0x01;
    public static readonly short Ks_Keydown = 0x80;
    /*
              public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
              //Declare the hook handle as an int.
              static int hHook = 0;
              //Declare the mouse hook constant.
              //For other hook types, you can obtain these values from Winuser.h in the Microsoft SDK.
              public const int WH_MOUSE = 7;
              //Declare the wrapper managed POINT class.
              [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
              public class POINT
              {
                  public int x;
                  public int y;
              }
              //Declare the wrapper managed MouseHookStruct class.
              [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
              public class MouseHookStruct
              {
                  public POINT pt;
                  public int hwnd;
                  public int wHitTestCode;
                  public int dwExtraInfo;
              }
       
              //This is the Import for the SetWindowsHookEx function.
              //Use this function to install a thread-specific hook.
              [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
              public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
              IntPtr hInstance, int threadId);
              //This is the Import for the UnhookWindowsHookEx function.
              //Call this function to uninstall the hook.
              [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
              public static extern bool UnhookWindowsHookEx(int idHook);
              //This is the Import for the CallNextHookEx function.
              //Use this function to pass the hook information to the next hook procedure in chain.
              [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
              public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
      */
    [DllImport("winmm.dll")]
    public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
    [DllImport("winmm.dll")]
    public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(Keys vKey);
    [DllImport("user32.dll")]
    public static extern int GetKeyState(Keys vKey);
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
    [DllImport("user32.dll")]
    public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int nVirtKey);
    [DllImport("user32.dll")]
    public static extern int LockWindowUpdate(IntPtr hwnd);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    [DllImport("user32.dll")]
    public static extern bool GetLastInputInfo(ref Lastinputinfo plii);
  }
}