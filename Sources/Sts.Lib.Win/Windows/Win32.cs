using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows
{
    internal static class Win32
    {
        internal static class Structs
        {
            [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
            public struct ShItemId
            {
                /// <summary>
                /// The size of identifier, in bytes, including cb itself.
                /// </summary>
                public ushort cb;
                /// <summary>
                /// A variable-length item identifier.
                /// </summary>
                public byte[] abID;
            }
            [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
            public struct ItemIdList
            {
                /// <summary>
                /// A list of item identifiers.
                /// </summary>
                [MarshalAs(UnmanagedType.Struct)]
                public ShItemId mkid;
            }
            [StructLayout(LayoutKind.Sequential)]
            internal struct Lastinputinfo
            {
                internal static readonly int SizeOf = Marshal.SizeOf(typeof(Lastinputinfo));

                [MarshalAs(UnmanagedType.U4)]
                internal uint cbSize;

                [MarshalAs(UnmanagedType.U4)]
                internal uint dwTime;
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

            internal struct KeyboardHookStruct
            {
                internal int VkCode;
                internal int ScanCode;
                internal int Flags;
                internal int Time;
                internal int DwExtraInfo;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct SHFILEINFO
            {
                internal const int NAMESIZE = 80;
                internal IntPtr hIcon;
                internal int iIcon;
                internal uint dwAttributes;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.MAX_PATH)]
                internal string szDisplayName;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
                internal string szTypeName;
            }
        }

        internal static class Constants
        {
            internal const int MAX_PATH = 256;
            internal const uint SHGFI_ICON = 0x000000100; // get icon
            internal const uint SHGFI_DISPLAYNAME = 0x000000200; // get display name
            internal const uint SHGFI_TYPENAME = 0x000000400; // get type name
            internal const uint SHGFI_ATTRIBUTES = 0x000000800; // get attributes
            internal const uint SHGFI_ICONLOCATION = 0x000001000; // get icon location
            internal const uint SHGFI_EXETYPE = 0x000002000; // return exe type
            internal const uint SHGFI_LINKOVERLAY = 0x000008000; // put a link overlay on icon
            internal const uint SHGFI_SELECTED = 0x000010000; // show icon in selected state
            internal const uint SHGFI_ATTR_SPECIFIED = 0x000020000; // get only specified attributes
            internal const uint SHGFI_LARGEICON = 0x000000000; // get large icon
            internal const uint SHGFI_SMALLICON = 0x000000001; // get small icon
            internal const uint SHGFI_OPENICON = 0x000000002; // get open icon
            internal const uint SHGFI_SHELLICONSIZE = 0x000000004; // get shell size icon
            internal const uint SHGFI_PIDL = 0x000000008; // pszPath is a pidl
            internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010; // use passed dwFileAttribute
            internal const uint SHGFI_ADDOVERLAYS = 0x000000020; // apply the appropriate overlays
            internal const uint SHGFI_OVERLAYINDEX = 0x000000040; // Get the index of the overlay
            internal const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
            internal const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
            internal static readonly uint Httransparent = 0xFFFFFFFF;
            internal static readonly uint Htclient = 1;
            internal static readonly uint Htcaption = 2;
            internal static readonly uint HwndTop = 0;
            internal static readonly int HwndBroadcast = 0xffff;
            internal static readonly uint ScMinimize = 61472;
            internal static readonly uint ScRestore = 61728;
            internal static readonly uint ScMaximize = 61488;
            internal static readonly uint GwlWndproc = 0xFFFFFFFC;
            internal static readonly uint GwlExstyle = 0xFFFFFFEC;
            internal static readonly uint CreateDefaultErrorMode = 0x04000000;
            internal static readonly uint CreateNewConsole = 0x00000010;
            internal static readonly uint CreateNewProcessGroup = 0x00000200;
            internal static readonly uint CreateSeparateWowVdm = 0x00000800;
            internal static readonly uint CreateSuspended = 0x00000004;
            internal static readonly uint CreateUnicodeEnvironment = 0x00000400;
            internal static readonly uint ExtendedStartupinfoPresent = 0x00080000;
            internal static readonly uint LogonNetcredentialsOnly = 2;
            internal static readonly uint LogonWithProfile = 1;
            internal static readonly int SpiSetdeskwallpaper = 0x14;
            internal static readonly int SpifUpdateinifile = 0x01;
            internal static readonly int SpifSendwininichange = 0x02;
            internal static readonly int EmGetscrollpos = (int) Enums.WmConstants.WmUser + 221;
            internal static readonly int EmSetscrollpos = (int) Enums.WmConstants.WmUser + 222;
            internal static readonly int EmGeteventmask = (int) Enums.WmConstants.WmUser + 59;
            internal static readonly int EmSeteventmask = (int) Enums.WmConstants.WmUser + 69;
            internal static readonly short KsOn = 0x01;
            internal static readonly short KsKeydown = 0x80;
        }

        internal static class Enums
        {
            internal enum EndSession : long
            {
                EndsessionCloseapp = 0x00000001,
                EndsessionCritical = 0x40000000,
                EndsessionLogoff = 0x80000000
            }

            internal enum HTCodes
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

            internal enum LogonProvider
            {
                /// <summary>
                ///     Use the standard logon provider for the system.
                ///     The default security provider is negotiate, unless you pass NULL for the domain name and the user name
                ///     is not in UPN format. In this case, the default provider is NTLM.
                ///     NOTE: Windows 2000/NT:   The default security provider is NTLM.
                /// </summary>
                Logon32ProviderDefault = 0,
                Logon32ProviderWinnt35 = 1,
                Logon32ProviderWinnt40 = 2,
                Logon32ProviderWinnt50 = 3
            }

            internal enum LogonType
            {
                /// <summary>
                ///     This logon type is intended for users who will be interactively using the computer, such as a user being logged on
                ///     by a terminal server, remote shell, or similar process.
                ///     This logon type has the additional expense of caching logon information for disconnected operations;
                ///     therefore, it is inappropriate for some client/server applications,
                ///     such as a mail server.
                /// </summary>
                Logon32LogonInteractive = 2,

                /// <summary>
                ///     This logon type is intended for high performance servers to authenticate plaintext passwords.
                ///     The LogonUser function does not cache credentials for this logon type.
                /// </summary>
                Logon32LogonNetwork = 3,

                /// <summary>
                ///     This logon type is intended for batch servers, where processes may be executing on behalf of a user without
                ///     their direct intervention. This type is also for higher performance servers that process many plaintext
                ///     authentication attempts at a time, such as mail or Web servers.
                ///     The LogonUser function does not cache credentials for this logon type.
                /// </summary>
                Logon32LogonBatch = 4,

                /// <summary>
                ///     Indicates a service-type logon. The account provided must have the service privilege enabled.
                /// </summary>
                Logon32LogonService = 5,

                /// <summary>
                ///     This logon type is for GINA DLLs that log on users who will be interactively using the computer.
                ///     This logon type can generate a unique audit record that shows when the workstation was unlocked.
                /// </summary>
                Logon32LogonUnlock = 7,

                /// <summary>
                ///     This logon type preserves the name and password in the authentication package, which allows the server to make
                ///     connections to other network servers while impersonating the client. A server can accept plaintext credentials
                ///     from a client, call LogonUser, verify that the user can access the system across the network, and still
                ///     communicate with other servers.
                ///     NOTE: Windows NT:  This value is not supported.
                /// </summary>
                Logon32LogonNetworkCleartext = 8,

                /// <summary>
                ///     This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
                ///     The new logon session has the same local identifier but uses different credentials for other network connections.
                ///     NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
                ///     NOTE: Windows NT:  This value is not supported.
                /// </summary>
                Logon32LogonNewCredentials = 9
            }

            internal enum VirtualKeyCodes
            {
                VkControl = 0x11,
                VkUp = 0x26,
                VkDown = 0x28,
                VkNumlock = 0x90
            }

            internal enum WmConstants
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
                WmQueryEndSession = 0x11
            }

            internal enum CSIDL
            {
                CSIDL_ADMINTOOLS = 0x0030,
                CSIDL_ALTSTARTUP = 0x001d,
                CSIDL_APPDATA = 0x001a,
                CSIDL_BITBUCKET = 0x000a,
                CSIDL_CDBURN_AREA = 0x003b,
                CSIDL_COMMON_ADMINTOOLS = 0x002f,
                CSIDL_COMMON_ALTSTARTUP = 0x001e,
                CSIDL_COMMON_APPDATA = 0x0023,
                CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,
                CSIDL_COMMON_DOCUMENTS = 0x002e,
                CSIDL_COMMON_FAVORITES = 0x001f,
                CSIDL_COMMON_MUSIC = 0x0035,
                CSIDL_COMMON_OEM_LINKS = 0x003a,
                CSIDL_COMMON_PICTURES = 0x0036,
                CSIDL_COMMON_PROGRAMS = 0X0017,
                CSIDL_COMMON_STARTMENU = 0x0016,
                CSIDL_COMMON_STARTUP = 0x0018,
                CSIDL_COMMON_TEMPLATES = 0x002d,
                CSIDL_COMMON_VIDEO = 0x0037,
                CSIDL_COMPUTERSNEARME = 0x003d,
                CSIDL_CONNECTIONS = 0x0031,
                CSIDL_CONTROLS = 0x0003,
                CSIDL_COOKIES = 0x0021,
                CSIDL_DESKTOP = 0x0000,
                CSIDL_DESKTOPDIRECTORY = 0x0010,
                CSIDL_DRIVES = 0x0011,
                CSIDL_FAVORITES = 0x0006,
                CSIDL_FLAG_CREATE = 0x8000,
                CSIDL_FLAG_DONT_VERIFY = 0x4000,
                CSIDL_FLAG_MASK = 0xFF00,
                CSIDL_FLAG_NO_ALIAS = 0x1000,
                CSIDL_FLAG_PER_USER_INIT = 0x0800,
                CSIDL_FONTS = 0x0014,
                CSIDL_HISTORY = 0x0022,
                CSIDL_INTERNET = 0x0001,
                CSIDL_INTERNET_CACHE = 0x0020,
                CSIDL_LOCAL_APPDATA = 0x001c,
                CSIDL_MYDOCUMENTS = 0x000c,
                CSIDL_MYMUSIC = 0x000d,
                CSIDL_MYPICTURES = 0x0027,
                CSIDL_MYVIDEO = 0x000e,
                CSIDL_NETHOOD = 0x0013,
                CSIDL_NETWORK = 0x0012,
                CSIDL_PERSONAL = 0x0005,
                CSIDL_PRINTERS = 0x0004,
                CSIDL_PRINTHOOD = 0x001b,
                CSIDL_PROFILE = 0x0028,
                CSIDL_PROGRAM_FILES = 0x0026,
                CSIDL_PROGRAM_FILES_COMMON = 0x002b,
                CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,
                CSIDL_PROGRAM_FILESX86 = 0x002a,
                CSIDL_PROGRAMS = 0x0002,
                CSIDL_RECENT = 0x0008,
                CSIDL_RESOURCES = 0x0038,
                CSIDL_RESOURCES_LOCALIZED = 0x0039,
                CSIDL_SENDTO = 0x0009,
                CSIDL_STARTMENU = 0x000b,
                CSIDL_STARTUP = 0x0007,
                CSIDL_SYSTEM = 0x0025,
                CSIDL_SYSTEMX86 = 0x0029,
                CSIDL_TEMPLATES = 0x0015,
                CSIDL_WINDOWS = 0x0024
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
        }

        internal delegate int KeyboardHookProc(int code, int wParam, ref Structs.KeyboardHookStruct lParam);

        internal delegate int Win32WndProc(IntPtr hWnd, int msg, int wParam, int lParam);

        /*
                  internal delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
                  //Declare the hook handle as an int.
                  static int hHook = 0;
                  //Declare the mouse hook constant.
                  //For other hook types, you can obtain these values from Winuser.h in the Microsoft SDK.
                  internal const int WH_MOUSE = 7;
                  //Declare the wrapper managed POINT class.
                  [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
                  internal class POINT
                  {
                      internal int x;
                      internal int y;
                  }
                  //Declare the wrapper managed MouseHookStruct class.
                  [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
                  internal class MouseHookStruct
                  {
                      internal POINT pt;
                      internal int hwnd;
                      internal int wHitTestCode;
                      internal int dwExtraInfo;
                  }

                  //This is the Import for the SetWindowsHookEx function.
                  //Use this function to install a thread-specific hook.
                  [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
                  internal static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
                  IntPtr hInstance, int threadId);
                  //This is the Import for the UnhookWindowsHookEx function.
                  //Call this function to uninstall the hook.
                  [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
                  internal static extern bool UnhookWindowsHookEx(int idHook);
                  //This is the Import for the CallNextHookEx function.
                  //Use this function to pass the hook information to the next hook procedure in chain.
                  [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
                  internal static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
          */
        [DllImport("winmm.dll")]
        internal static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        internal static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("user32.dll")]
        internal static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        internal static extern int GetKeyState(Keys vKey);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        internal static extern int LockWindowUpdate(IntPtr hwnd);

        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("kernel32.dll")]
        internal static extern uint GetLastError();

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateProcessWithLogonW(string userName, string domain, string password, uint logonFlags, string applicationName, string commandLine, uint creationFlags, uint environment, string currentDirectory, ref Structs.StartupInfo startupInfo, out Structs.ProcessInformation processInformation);

        [DllImport("winspool.drv", SetLastError = true)]
        internal static extern int OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        internal static extern int ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        internal static extern int EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, uint dwCount, out uint dwWritten);

        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern uint StartDocPrinter(IntPtr hPrinter, int level, [In] ref Structs.DocInfo_1W di);

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
        internal static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll")]
        internal static extern bool DuplicateToken(IntPtr existingTokenHandle, int securityImpersonationLevel, ref IntPtr duplicateTokenHandle);

        [DllImport("user32.dll")]
        internal static extern bool GetLastInputInfo(ref Structs.Lastinputinfo plii);

        [DllImport("user32")]
        internal static extern int RegisterWindowMessage(string message);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [DllImport("shell32.dll")]
        internal static extern int SHGetFolderLocation(IntPtr hwndOwner, int nFolder, IntPtr hToken, uint dwReserved, out IntPtr ppidl);

        [DllImport("Shell32.dll")]
        internal static extern IntPtr SHGetFileInfo(IntPtr pszPath, uint dwFileAttributes, ref Structs.SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        /// <summary>
        ///     Provides access to function required to delete handle. This method is used internally
        ///     and is not required to be called separately.
        /// </summary>
        /// <param name="hIcon">Pointer to icon handle.</param>
        /// <returns>N/A</returns>
        [DllImport("User32.dll")]
        internal static extern int DestroyIcon(IntPtr hIcon);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal class PrinterDefaults
        {
            /// <summary>
            ///     Specifies desired access rights for a printer.
            ///     The <see cref="OpenPrinter(string, out IntPtr, IntPtr)" /> function uses
            ///     this member to set access rights to the printer. These rights can affect
            ///     the operation of the SetPrinter and DeletePrinter functions.
            /// </summary>
            internal Enums.AccessMask DesiredAccess;

            /// <summary>
            ///     Pointer to a null-terminated string that specifies the
            ///     default data type for a printer.
            /// </summary>
            internal IntPtr pDatatype;

            /// <summary>
            ///     Pointer to a DEVMODE structure that identifies the
            ///     default environment and initialization data for a printer.
            /// </summary>
            internal IntPtr pDevMode;
        }

        internal delegate bool EnumWindowsProc(IntPtr intPtr, int lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
    }
}
