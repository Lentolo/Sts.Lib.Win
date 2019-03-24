using System;
using System.Runtime.InteropServices;
using System.Text;
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
    [Flags]
    internal enum AccessMask : uint
    {
      Delete = 0x00010000,
      ReadControl = 0x00020000,
      WriteDac = 0x00040000,
      WriteOwner = 0x00080000,
      Synchronize = 0x00100000,
      StandardRightsRequired = 0x000F0000,
      StandardRightsRead = 0x00020000,
      StandardRightsWrite = 0x00020000,
      StandardRightsExecute = 0x00020000,
      StandardRightsAll = 0x001F0000,
      SpecificRightsAll = 0x0000FFFF,
      AccessSystemSecurity = 0x01000000,
      MaximumAllowed = 0x02000000,
      GenericRead = 0x80000000,
      GenericWrite = 0x40000000,
      GenericExecute = 0x20000000,
      GenericAll = 0x10000000,
      DesktopReadobjects = 0x00000001,
      DesktopCreatewindow = 0x00000002,
      DesktopCreatemenu = 0x00000004,
      DesktopHookcontrol = 0x00000008,
      DesktopJournalrecord = 0x00000010,
      DesktopJournalplayback = 0x00000020,
      DesktopEnumerate = 0x00000040,
      DesktopWriteobjects = 0x00000080,
      DesktopSwitchdesktop = 0x00000100,
      WinstaEnumdesktops = 0x00000001,
      WinstaReadattributes = 0x00000002,
      WinstaAccessclipboard = 0x00000004,
      WinstaCreatedesktop = 0x00000008,
      WinstaWriteattributes = 0x00000010,
      WinstaAccessglobalatoms = 0x00000020,
      WinstaExitwindows = 0x00000040,
      WinstaEnumerate = 0x00000100,
      WinstaReadscreen = 0x00000200,
      WinstaAllAccess = 0x0000037F
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct DocInfo_1W
    {
      [MarshalAs(UnmanagedType.LPWStr)]
      internal readonly string pDocName;
      [MarshalAs(UnmanagedType.LPWStr)]
      internal readonly string pOutputFile;
      [MarshalAs(UnmanagedType.LPWStr)]
      internal readonly string pDataType;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal class PrinterDefaults
    {
      /// <summary>
      ///   Specifies desired access rights for a printer.
      ///   The <see cref="OpenPrinter(string, out IntPtr, IntPtr)" /> function uses
      ///   this member to set access rights to the printer. These rights can affect
      ///   the operation of the SetPrinter and DeletePrinter functions.
      /// </summary>
      internal AccessMask DesiredAccess;
      /// <summary>
      ///   Pointer to a null-terminated string that specifies the
      ///   default data type for a printer.
      /// </summary>
      internal IntPtr pDatatype;
      /// <summary>
      ///   Pointer to a DEVMODE structure that identifies the
      ///   default environment and initialization data for a printer.
      /// </summary>
      internal IntPtr pDevMode;
    }
    internal struct ProcessInformation
    {
      internal IntPtr Process;
      internal int ProcessId;
      internal IntPtr Thread;
      internal int ThreadId;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct StartupInfo
    {
      internal int cb;
      internal string reserved;
      internal string desktop;
      internal string title;
      internal int x;
      internal int y;
      internal int xSize;
      internal int ySize;
      internal int xCountChars;
      internal int yCountChars;
      internal int fillAttribute;
      internal int flags;
      internal ushort showWindow;
      internal ushort reserved2;
      internal byte reserved3;
      internal IntPtr stdInput;
      internal IntPtr stdOutput;
      internal IntPtr stdError;
    }
    internal delegate bool EnumWindowsProc(IntPtr intPtr, int lParam);
    public struct KeyboardHookStruct
    {
      public int VkCode;
      public int ScanCode;
      public int Flags;
      public int Time;
      public int DwExtraInfo;
    }
    public delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);
    public delegate int Win32WndProc(IntPtr hWnd, int msg, int wParam, int lParam);
    public enum HTCodes
    {
      HtCaption = 0x2,
      HtLeft = 10,
      HtRight = 11,
      HtTop = 12,
      HtTopleft = 13,
      HtTopright = 14,
      HtBottom = 15,
      HtBottomleft = 16,
      HtBottomright = 17
    }
    public enum LogonProvider
    {
      /// <summary>
      ///   Use the standard logon provider for the system.
      ///   The default security provider is negotiate, unless you pass NULL for the domain name and the user name
      ///   is not in UPN format. In this case, the default provider is NTLM.
      ///   NOTE: Windows 2000/NT:   The default security provider is NTLM.
      /// </summary>
      Logon32ProviderDefault = 0,
      Logon32ProviderWinnt35 = 1,
      Logon32ProviderWinnt40 = 2,
      Logon32ProviderWinnt50 = 3
    }
    public enum LogonType
    {
      /// <summary>
      ///   This logon type is intended for users who will be interactively using the computer, such as a user being logged on
      ///   by a terminal server, remote shell, or similar process.
      ///   This logon type has the additional expense of caching logon information for disconnected operations;
      ///   therefore, it is inappropriate for some client/server applications,
      ///   such as a mail server.
      /// </summary>
      Logon32LogonInteractive = 2,
      /// <summary>
      ///   This logon type is intended for high performance servers to authenticate plaintext passwords.
      ///   The LogonUser function does not cache credentials for this logon type.
      /// </summary>
      Logon32LogonNetwork = 3,
      /// <summary>
      ///   This logon type is intended for batch servers, where processes may be executing on behalf of a user without
      ///   their direct intervention. This type is also for higher performance servers that process many plaintext
      ///   authentication attempts at a time, such as mail or Web servers.
      ///   The LogonUser function does not cache credentials for this logon type.
      /// </summary>
      Logon32LogonBatch = 4,
      /// <summary>
      ///   Indicates a service-type logon. The account provided must have the service privilege enabled.
      /// </summary>
      Logon32LogonService = 5,
      /// <summary>
      ///   This logon type is for GINA DLLs that log on users who will be interactively using the computer.
      ///   This logon type can generate a unique audit record that shows when the workstation was unlocked.
      /// </summary>
      Logon32LogonUnlock = 7,
      /// <summary>
      ///   This logon type preserves the name and password in the authentication package, which allows the server to make
      ///   connections to other network servers while impersonating the client. A server can accept plaintext credentials
      ///   from a client, call LogonUser, verify that the user can access the system across the network, and still
      ///   communicate with other servers.
      ///   NOTE: Windows NT:  This value is not supported.
      /// </summary>
      Logon32LogonNetworkCleartext = 8,
      /// <summary>
      ///   This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
      ///   The new logon session has the same local identifier but uses different credentials for other network connections.
      ///   NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
      ///   NOTE: Windows NT:  This value is not supported.
      /// </summary>
      Logon32LogonNewCredentials = 9
    }
    public enum VirtualKeyCodes
    {
      VkControl = 0x11,
      VkUp = 0x26,
      VkDown = 0x28,
      VkNumlock = 0x90
    }
    public enum WmConstants
    {
      WmNcmousemove = 160,
      WmNclbuttonup = 162,
      WmNclbuttondblclk = 163,
      WmWindowposchanging = 70,
      WmEntersizemove = 561,
      WmExitsizemove = 562,
      WmSyscommand = 274,
      WmSize = 5,
      WmActivate = 6,
      WmSetfocus = 7,
      WmSetcursor = 32,
      WmMousemove = 0x0200,
      WmLbuttondown = 0x0201,
      WmLbuttonup = 0x0202,
      WmLbuttondblclk = 0x0203,
      WmRbuttondown = 0x0204,
      WmRbuttonup = 0x0205,
      WmRbuttondblclk = 0x0206,
      WmMbuttondown = 0x0207,
      WmMbuttonup = 0x0208,
      WmMbuttondblclk = 0x0209,
      WmMousewheel = 0x020A,
      WmXbuttondown = 0x020B,
      WmXbuttonup = 0x020C,
      WmXbuttondblclk = 0x020D,
      WmMouseleave = 0x02A3,
      WmWindowposchanged = 0x0047,
      WmNcactivate = 0X0086,
      WmClose = 0x0010,
      WmDestroy = 0x0002,
      WmSetredraw = 0x000B,
      WmPaint = 0x000F,
      WmErasebkgnd = 0x0014,
      WmNchittest = 0x84,
      WmNclbuttondown = 0x00A1,
      WmKeydown = 0x0100,
      WmKeyup = 0x0101,
      WmChar = 0x0102,
      WmPaste = 0x0302,
      WmUser = 0x0400,
      WmQueryendsession = 0x11
    }
    public static readonly uint Httransparent = 0xFFFFFFFF;
    public static readonly uint Htclient = 1;
    public static readonly uint Htcaption = 2;
    public static readonly uint HwndTop = 0;
    public static readonly uint ScMinimize = 61472;
    public static readonly uint ScRestore = 61728;
    public static readonly uint ScMaximize = 61488;
    public static readonly uint GwlWndproc = 0xFFFFFFFC;
    public static readonly uint GwlExstyle = 0xFFFFFFEC;
    public static readonly uint CreateDefaultErrorMode = 0x04000000;
    public static readonly uint CreateNewConsole = 0x00000010;
    public static readonly uint CreateNewProcessGroup = 0x00000200;
    public static readonly uint CreateSeparateWowVdm = 0x00000800;
    public static readonly uint CreateSuspended = 0x00000004;
    public static readonly uint CreateUnicodeEnvironment = 0x00000400;
    public static readonly uint ExtendedStartupinfoPresent = 0x00080000;
    public static readonly uint LogonNetcredentialsOnly = 2;
    public static readonly uint LogonWithProfile = 1;
    public static readonly int SpiSetdeskwallpaper = 0x14;
    public static readonly int SpifUpdateinifile = 0x01;
    public static readonly int SpifSendwininichange = 0x02;
    public static readonly int EmGetscrollpos = (int) WmConstants.WmUser + 221;
    public static readonly int EmSetscrollpos = (int) WmConstants.WmUser + 222;
    public static readonly int EmGeteventmask = (int) WmConstants.WmUser + 59;
    public static readonly int EmSeteventmask = (int) WmConstants.WmUser + 69;
    public static readonly short KsOn = 0x01;
    public static readonly short KsKeydown = 0x80;
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
    [DllImport("kernel32.dll")]
    internal static extern uint GetLastError();
    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool CreateProcessWithLogonW(string userName, string domain, string password, uint logonFlags, string applicationName, string commandLine, uint creationFlags, uint environment, string currentDirectory, ref StartupInfo startupInfo, out ProcessInformation processInformation);
    [DllImport("winspool.drv", SetLastError = true)]
    internal static extern int OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);
    [DllImport("winspool.drv", SetLastError = true)]
    internal static extern int ClosePrinter(IntPtr hPrinter);
    [DllImport("winspool.drv", SetLastError = true)]
    internal static extern int EndDocPrinter(IntPtr hPrinter);
    [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    internal static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, uint dwCount, out uint dwWritten);
    [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    internal static extern uint StartDocPrinter(IntPtr hPrinter, int level, [In] ref DocInfo_1W di);
    [DllImport("USER32.DLL")]
    internal static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    [DllImport("USER32.DLL")]
    internal static extern int GetWindowText(IntPtr intPtr, StringBuilder lpString, int nMaxCount);
    [DllImport("USER32.DLL")]
    internal static extern int GetWindowTextLength(IntPtr intPtr);
    [DllImport("advapi32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool LogonUser([MarshalAs(UnmanagedType.LPStr)] string pszUserName, [MarshalAs(UnmanagedType.LPStr)] string pszDomain, [MarshalAs(UnmanagedType.LPStr)] string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("USER32.DLL")]
    internal static extern bool IsWindowVisible(IntPtr intPtr);
    [DllImport("USER32.DLL")]
    internal static extern IntPtr GetShellWindow();
    [DllImport("kernel32.dll")]
    internal static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
    [DllImport("kernel32.dll")]
    internal static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);
    [DllImport("advapi32.dll")]
    public static extern bool DuplicateToken(IntPtr existingTokenHandle, int securityImpersonationLevel, ref IntPtr duplicateTokenHandle);
    [DllImport("user32.dll")]
    public static extern bool GetLastInputInfo(ref Lastinputinfo plii);
  }
}