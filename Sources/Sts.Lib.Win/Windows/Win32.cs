﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows;

internal static class Win32
{
    internal static class Structs
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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
        internal static readonly int EmGetscrollpos = (int)Enums.WmConstants.WmUser + 221;
        internal static readonly int EmSetscrollpos = (int)Enums.WmConstants.WmUser + 222;
        internal static readonly int EmGeteventmask = (int)Enums.WmConstants.WmUser + 59;
        internal static readonly int EmSeteventmask = (int)Enums.WmConstants.WmUser + 69;
        internal static readonly short KsOn = 0x01;
        internal static readonly short KsKeydown = 0x80;
    }

    internal static class Enums
    {
        [Flags]
        internal enum SPIF
        {
            None = 0x00,
            /// <summary>Writes the new system-wide parameter setting to the user profile.</summary>
            SPIF_UPDATEINIFILE = 0x01,
            /// <summary>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</summary>
            SPIF_SENDCHANGE = 0x02,
            /// <summary>Same as SPIF_SENDCHANGE.</summary>
            SPIF_SENDWININICHANGE = 0x02
        }
        /// <summary>
        /// SPI_ System-wide parameter - Used in SystemParametersInfo function
        /// </summary>
        [Description("SPI_(System-wide parameter - Used in SystemParametersInfo function )")]
        internal enum SPI : uint
        {
            /// <summary>
            /// Determines whether the warning beeper is on.
            /// The pvParam parameter must point to a BOOL variable that receives TRUE if the beeper is on, or FALSE if it is off.
            /// </summary>
            SPI_GETBEEP = 0x0001,

            /// <summary>
            /// Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
            /// </summary>
            SPI_SETBEEP = 0x0002,

            /// <summary>
            /// Retrieves the two mouse threshold values and the mouse speed.
            /// </summary>
            SPI_GETMOUSE = 0x0003,

            /// <summary>
            /// Sets the two mouse threshold values and the mouse speed.
            /// </summary>
            SPI_SETMOUSE = 0x0004,

            /// <summary>
            /// Retrieves the border multiplier factor that determines the width of a window's sizing border.
            /// The pvParam parameter must point to an integer variable that receives this value.
            /// </summary>
            SPI_GETBORDER = 0x0005,

            /// <summary>
            /// Sets the border multiplier factor that determines the width of a window's sizing border.
            /// The uiParam parameter specifies the new value.
            /// </summary>
            SPI_SETBORDER = 0x0006,

            /// <summary>
            /// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second)
            /// through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from
            /// a linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
            /// </summary>
            SPI_GETKEYBOARDSPEED = 0x000A,

            /// <summary>
            /// Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0
            /// (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second).
            /// The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%.
            /// If uiParam is greater than 31, the parameter is set to 31.
            /// </summary>
            SPI_SETKEYBOARDSPEED = 0x000B,

            /// <summary>
            /// Not implemented.
            /// </summary>
            SPI_LANGDRIVER = 0x000C,

            /// <summary>
            /// Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view.
            /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON.
            /// To retrieve this value, pvParam must point to an integer that receives the current value.
            /// </summary>
            SPI_ICONHORIZONTALSPACING = 0x000D,

            /// <summary>
            /// Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives the value.
            /// </summary>
            SPI_GETSCREENSAVETIMEOUT = 0x000E,

            /// <summary>
            /// Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds,
            /// that the system must be idle before the screen saver activates.
            /// </summary>
            SPI_SETSCREENSAVETIMEOUT = 0x000F,

            /// <summary>
            /// Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE
            /// if screen saving is enabled, or FALSE otherwise.
            /// </summary>
            SPI_GETSCREENSAVEACTIVE = 0x0010,

            /// <summary>
            /// Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
            /// </summary>
            SPI_SETSCREENSAVEACTIVE = 0x0011,

            /// <summary>
            /// Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable
            /// that receives the granularity.
            /// </summary>
            SPI_GETGRIDGRANULARITY = 0x0012,

            /// <summary>
            /// Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.
            /// </summary>
            SPI_SETGRIDGRANULARITY = 0x0013,

            /// <summary>
            /// Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap,
            /// set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the wallpaper.
            /// Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
            /// </summary>
            SPI_SETDESKWALLPAPER = 0x0014,

            /// <summary>
            /// Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.
            /// </summary>
            SPI_SETDESKPATTERN = 0x0015,

            /// <summary>
            /// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3
            /// (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam parameter must point to an integer variable that receives the setting.
            /// </summary>
            SPI_GETKEYBOARDDELAY = 0x0016,

            /// <summary>
            /// Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay
            /// (approximately 250 ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may
            /// vary depending on the hardware.
            /// </summary>
            SPI_SETKEYBOARDDELAY = 0x0017,

            /// <summary>
            /// Sets or retrieves the height, in pixels, of an icon cell.
            /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CYICON.
            /// To retrieve this value, pvParam must point to an integer that receives the current value.
            /// </summary>
            SPI_ICONVERTICALSPACING = 0x0018,

            /// <summary>
            /// Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE
            /// if enabled, or FALSE otherwise.
            /// </summary>
            SPI_GETICONTITLEWRAP = 0x0019,

            /// <summary>
            /// Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
            /// </summary>
            SPI_SETICONTITLEWRAP = 0x001A,

            /// <summary>
            /// Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item.
            /// The pvParam parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
            /// </summary>
            SPI_GETMENUDROPALIGNMENT = 0x001B,

            /// <summary>
            /// Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
            /// </summary>
            SPI_SETMENUDROPALIGNMENT = 0x001C,

            /// <summary>
            /// Sets the width of the double-click rectangle to the value of the uiParam parameter.
            /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered
            /// as a double-click.
            /// To retrieve the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
            /// </summary>
            SPI_SETDOUBLECLKWIDTH = 0x001D,

            /// <summary>
            /// Sets the height of the double-click rectangle to the value of the uiParam parameter.
            /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered
            /// as a double-click.
            /// To retrieve the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
            /// </summary>
            SPI_SETDOUBLECLKHEIGHT = 0x001E,

            /// <summary>
            /// Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT structure,
            /// and the pvParam parameter must point to the LOGFONT structure to fill in.
            /// </summary>
            SPI_GETICONTITLELOGFONT = 0x001F,

            /// <summary>
            /// Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number
            /// of milliseconds that can occur between the first and second clicks of a double-click. You can also call the SetDoubleClickTime
            /// function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
            /// </summary>
            SPI_SETDOUBLECLICKTIME = 0x0020,

            /// <summary>
            /// Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings
            /// of the buttons, or FALSE to restore their original meanings.
            /// </summary>
            SPI_SETMOUSEBUTTONSWAP = 0x0021,

            /// <summary>
            /// Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure,
            /// and the pvParam parameter must point to a LOGFONT structure.
            /// </summary>
            SPI_SETICONTITLELOGFONT = 0x0022,

            /// <summary>
            /// This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is enabled.
            /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
            /// </summary>
            SPI_GETFASTTASKSWITCH = 0x0023,

            /// <summary>
            /// This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching.
            /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
            /// </summary>
            SPI_SETFASTTASKSWITCH = 0x0024,

            //#if(WINVER >= 0x0400)
            /// <summary>
            /// Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
            /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
            /// </summary>
            SPI_SETDRAGFULLWINDOWS = 0x0025,

            /// <summary>
            /// Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled, or FALSE otherwise.
            /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
            /// </summary>
            SPI_GETDRAGFULLWINDOWS = 0x0026,

            /// <summary>
            /// Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point
            /// to a NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
            /// to sizeof(NONCLIENTMETRICS).
            /// </summary>
            SPI_GETNONCLIENTMETRICS = 0x0029,

            /// <summary>
            /// Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point
            /// to a NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure
            /// and the uiParam parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
            /// </summary>
            SPI_SETNONCLIENTMETRICS = 0x002A,

            /// <summary>
            /// Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
            /// </summary>
            SPI_GETMINIMIZEDMETRICS = 0x002B,

            /// <summary>
            /// Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
            /// </summary>
            SPI_SETMINIMIZEDMETRICS = 0x002C,

            /// <summary>
            /// Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives
            /// the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
            /// </summary>
            SPI_GETICONMETRICS = 0x002D,

            /// <summary>
            /// Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains
            /// the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
            /// </summary>
            SPI_SETICONMETRICS = 0x002E,

            /// <summary>
            /// Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar
            /// or by application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area rectangle,
            /// expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work area
            /// of the monitor that contains the specified rectangle.
            /// </summary>
            SPI_SETWORKAREA = 0x002F,

            /// <summary>
            /// Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured
            /// by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives
            /// the coordinates of the work area, expressed in virtual screen coordinates.
            /// To get the work area of a monitor other than the primary display monitor, call the GetMonitorInfo function.
            /// </summary>
            SPI_GETWORKAREA = 0x0030,

            /// <summary>
            /// Windows Me/98/95:  Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE
            /// when unloading pen windows. The pvParam parameter is null.
            /// </summary>
            SPI_SETPENWINDOWS = 0x0031,

            /// <summary>
            /// Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
            /// For a general discussion, see remarks.
            /// Windows NT:  This value is not supported.
            /// </summary>
            /// <remarks>
            /// There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme changes
            /// the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options in the control panel.
            /// The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to modify their appearance
            /// for visually-impaired users. It involves such things as audible warning to users and customized color scheme
            /// (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN.
            /// For more information on general accessibility features, see Accessibility on MSDN.
            /// </remarks>
            SPI_GETHIGHCONTRAST = 0x0042,

            /// <summary>
            /// Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
            /// Windows NT:  This value is not supported.
            /// </summary>
            SPI_SETHIGHCONTRAST = 0x0043,

            /// <summary>
            /// Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard interfaces
            /// that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if the user relies on the keyboard; or FALSE otherwise.
            /// Windows NT:  This value is not supported.
            /// </summary>
            SPI_GETKEYBOARDPREF = 0x0044,

            /// <summary>
            /// Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse,
            /// and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise.
            /// Windows NT:  This value is not supported.
            /// </summary>
            SPI_SETKEYBOARDPREF = 0x0045,

            /// <summary>
            /// Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output device,
            /// such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual information
            /// in situations where it would otherwise present the information graphically.
            /// The pvParam parameter is a pointer to a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise.
            /// Windows NT:  This value is not supported.
            /// </summary>
            SPI_GETSCREENREADER = 0x0046,

            /// <summary>
            /// Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off.
            /// Windows NT:  This value is not supported.
            /// </summary>
            SPI_SETSCREENREADER = 0x0047,

            /// <summary>
            /// Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
            /// </summary>
            SPI_GETANIMATION = 0x0048,

            /// <summary>
            /// Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
            /// </summary>
            SPI_SETANIMATION = 0x0049,

            /// <summary>
            /// Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear smoother
            /// by painting pixels at different gray levels.
            /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is enabled, or FALSE if it is not.
            /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
            /// </summary>
            SPI_GETFONTSMOOTHING = 0x004A,

            /// <summary>
            /// Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother
            /// by painting pixels at different gray levels.
            /// To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set uiParam to FALSE.
            /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
            /// </summary>
            SPI_SETFONTSMOOTHING = 0x004B,

            /// <summary>
            /// Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value.
            /// To retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
            /// </summary>
            SPI_SETDRAGWIDTH = 0x004C,

            /// <summary>
            /// Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value.
            /// To retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
            /// </summary>
            SPI_SETDRAGHEIGHT = 0x004D,

            /// <summary>
            /// Used internally; applications should not use this value.
            /// </summary>
            SPI_SETHANDHELD = 0x004E,

            /// <summary>
            /// Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer variable
            /// that receives the value. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_GETLOWPOWERTIMEOUT = 0x004F,

            /// <summary>
            /// Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer variable
            /// that receives the value. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_GETPOWEROFFTIMEOUT = 0x0050,

            /// <summary>
            /// Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value.
            /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_SETLOWPOWERTIMEOUT = 0x0051,

            /// <summary>
            /// Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value.
            /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_SETPOWEROFFTIMEOUT = 0x0052,

            /// <summary>
            /// Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_GETLOWPOWERACTIVE = 0x0053,

            /// <summary>
            /// Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_GETPOWEROFFACTIVE = 0x0054,

            /// <summary>
            /// Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate.
            /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_SETLOWPOWERACTIVE = 0x0055,

            /// <summary>
            /// Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate.
            /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
            /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
            /// Windows 95:  This flag is supported for 16-bit applications only.
            /// </summary>
            SPI_SETPOWEROFFACTIVE = 0x0056,

            /// <summary>
            /// Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.
            /// </summary>
            SPI_SETCURSORS = 0x0057,

            /// <summary>
            /// Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.
            /// </summary>
            SPI_SETICONS = 0x0058,

            /// <summary>
            /// Retrieves the input locale identifier for the system default input language. The pvParam parameter must point
            /// to an HKL variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
            /// </summary>
            SPI_GETDEFAULTINPUTLANG = 0x0059,

            /// <summary>
            /// Sets the default input language for the system shell and applications. The specified language must be displayable
            /// using the current system character set. The pvParam parameter must point to an HKL variable that contains
            /// the input locale identifier for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
            /// </summary>
            SPI_SETDEFAULTINPUTLANG = 0x005A,

            /// <summary>
            /// Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used.
            /// The value sets the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" = CTRL+SHIFT, and "3" = none.
            /// </summary>
            SPI_SETLANGTOGGLE = 0x005B,

            /// <summary>
            /// Windows 95:  Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1.
            /// The pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
            /// </summary>
            SPI_GETWINDOWSEXTENSION = 0x005C,

            /// <summary>
            /// Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing
            /// a trail of cursors and quickly erasing them.
            /// To disable the feature, set the uiParam parameter to zero or 1. To enable the feature, set uiParam to a value greater than 1
            /// to indicate the number of cursors drawn in the trail.
            /// Windows 2000/NT:  This value is not supported.
            /// </summary>
            SPI_SETMOUSETRAILS = 0x005D,

            /// <summary>
            /// Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements
            /// by briefly showing a trail of cursors and quickly erasing them.
            /// The pvParam parameter must point to an integer variable that receives a value. If the value is zero or 1, the feature is disabled.
            /// If the value is greater than 1, the feature is enabled and the value indicates the number of cursors drawn in the trail.
            /// The uiParam parameter is not used.
            /// Windows 2000/NT:  This value is not supported.
            /// </summary>
            SPI_GETMOUSETRAILS = 0x005E,

            /// <summary>
            /// Windows Me/98:  Used internally; applications should not use this flag.
            /// </summary>
            SPI_SETSCREENSAVERRUNNING = 0x0061,

            /// <summary>
            /// Same as SPI_SETSCREENSAVERRUNNING.
            /// </summary>
            SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
            //#endif /* WINVER >= 0x0400 */

            /// <summary>
            /// Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
            /// </summary>
            SPI_GETFILTERKEYS = 0x0032,

            /// <summary>
            /// Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
            /// </summary>
            SPI_SETFILTERKEYS = 0x0033,

            /// <summary>
            /// Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
            /// </summary>
            SPI_GETTOGGLEKEYS = 0x0034,

            /// <summary>
            /// Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
            /// </summary>
            SPI_SETTOGGLEKEYS = 0x0035,

            /// <summary>
            /// Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
            /// </summary>
            SPI_GETMOUSEKEYS = 0x0036,

            /// <summary>
            /// Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
            /// </summary>
            SPI_SETMOUSEKEYS = 0x0037,

            /// <summary>
            /// Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application
            /// to present information visually in situations where it would otherwise present the information only in audible form.
            /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off.
            /// Using this value is equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
            /// </summary>
            SPI_GETSHOWSOUNDS = 0x0038,

            /// <summary>
            /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
            /// </summary>
            SPI_SETSHOWSOUNDS = 0x0039,

            /// <summary>
            /// Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
            /// </summary>
            SPI_GETSTICKYKEYS = 0x003A,

            /// <summary>
            /// Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
            /// </summary>
            SPI_SETSTICKYKEYS = 0x003B,

            /// <summary>
            /// Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point
            /// to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
            /// to sizeof(ACCESSTIMEOUT).
            /// </summary>
            SPI_GETACCESSTIMEOUT = 0x003C,

            /// <summary>
            /// Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT
            /// structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
            /// </summary>
            SPI_SETACCESSTIMEOUT = 0x003D,

            //#if(WINVER >= 0x0400)
            /// <summary>
            /// Windows Me/98/95:  Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point
            /// to a SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
            /// to sizeof(SERIALKEYS).
            /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
            /// </summary>
            SPI_GETSERIALKEYS = 0x003E,

            /// <summary>
            /// Windows Me/98/95:  Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point
            /// to a SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter
            /// to sizeof(SERIALKEYS).
            /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
            /// </summary>
            SPI_SETSERIALKEYS = 0x003F,
            //#endif /* WINVER >= 0x0400 */

            /// <summary>
            /// Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
            /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
            /// </summary>
            SPI_GETSOUNDSENTRY = 0x0040,

            /// <summary>
            /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
            /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
            /// </summary>
            SPI_SETSOUNDSENTRY = 0x0041,

            //#if(_WIN32_WINNT >= 0x0400)
            /// <summary>
            /// Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves
            /// to the default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE if the feature is on, or FALSE if it is off.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETSNAPTODEFBUTTON = 0x005F,

            /// <summary>
            /// Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default button,
            /// such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable it.
            /// Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse cursor.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETSNAPTODEFBUTTON = 0x0060,
            //#endif /* _WIN32_WINNT >= 0x0400 */

            //#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
            /// <summary>
            /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETMOUSEHOVERWIDTH = 0x0062,

            /// <summary>
            /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETMOUSEHOVERWIDTH = 0x0063,

            /// <summary>
            /// Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETMOUSEHOVERHEIGHT = 0x0064,

            /// <summary>
            /// Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. Set the uiParam parameter to the new height.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETMOUSEHOVERHEIGHT = 0x0065,

            /// <summary>
            /// Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETMOUSEHOVERTIME = 0x0066,

            /// <summary>
            /// Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent
            /// to generate a WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to TrackMouseEvent. Set the uiParam parameter to the new time.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETMOUSEHOVERTIME = 0x0067,

            /// <summary>
            /// Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point
            /// to a UINT variable that receives the number of lines. The default value is 3.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETWHEELSCROLLLINES = 0x0068,

            /// <summary>
            /// Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter.
            /// The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys.
            /// If the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines viewable,
            /// and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted
            /// as clicking once in the page down or page up regions of the scroll bar.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETWHEELSCROLLLINES = 0x0069,

            /// <summary>
            /// Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is
            /// over a submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_GETMENUSHOWDELAY = 0x006A,

            /// <summary>
            /// Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is
            /// over a submenu item.
            /// Windows 95:  Not supported.
            /// </summary>
            SPI_SETMENUSHOWDELAY = 0x006B,

            /// <summary>
            /// Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL variable
            /// that receives TRUE if the status window is visible, or FALSE if it is not.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETSHOWIMEUI = 0x006E,

            /// <summary>
            /// Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or FALSE for off.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETSHOWIMEUI = 0x006F,
            //#endif

            //#if(WINVER >= 0x0500)
            /// <summary>
            /// Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse moves.
            /// The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20 (fastest).
            /// A value of 10 is the default. The value can be set by an end user using the mouse control panel application or
            /// by an application using SPI_SETMOUSESPEED.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETMOUSESPEED = 0x0070,

            /// <summary>
            /// Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the default.
            /// This value is typically set using the mouse control panel application.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETMOUSESPEED = 0x0071,

            /// <summary>
            /// Determines whether a screen saver is currently running on the window station of the calling process.
            /// The pvParam parameter must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise.
            /// Note that only the interactive window station, "WinSta0", can have a screen saver running.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETSCREENSAVERRUNNING = 0x0072,

            /// <summary>
            /// Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer
            /// that receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETDESKWALLPAPER = 0x0073,
            //#endif /* WINVER >= 0x0500 */

            //#if(WINVER >= 0x0500)
            /// <summary>
            /// Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must point
            /// to a BOOL variable that receives TRUE for on, or FALSE for off.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETACTIVEWINDOWTRACKING = 0x1000,

            /// <summary>
            /// Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for off.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETACTIVEWINDOWTRACKING = 0x1001,

            /// <summary>
            /// Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects.
            /// The pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled.
            /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETMENUANIMATION = 0x1002,

            /// <summary>
            /// Enables or disables menu animation. This master switch must be on for any menu animation to occur.
            /// The pvParam parameter is a BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation.
            /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETMENUANIMATION = 0x1003,

            /// <summary>
            /// Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE for enabled, or FALSE for disabled.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETCOMBOBOXANIMATION = 0x1004,

            /// <summary>
            /// Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect,
            /// or FALSE to disable it.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETCOMBOBOXANIMATION = 0x1005,

            /// <summary>
            /// Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE for enabled, or FALSE for disabled.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

            /// <summary>
            /// Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the smooth-scrolling effect,
            /// or FALSE to disable it.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

            /// <summary>
            /// Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable
            /// that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor function.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETGRADIENTCAPTIONS = 0x1008,

            /// <summary>
            /// Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to disable it.
            /// The gradient effect is possible only if the system has a color depth of more than 256 colors. For more information about
            /// the gradient effect, see the GetSysColor function.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETGRADIENTCAPTIONS = 0x1009,

            /// <summary>
            /// Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the keyboard.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETKEYBOARDCUES = 0x100A,

            /// <summary>
            /// Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always underline menu
            /// access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETKEYBOARDCUES = 0x100B,

            /// <summary>
            /// Same as SPI_GETKEYBOARDCUES.
            /// </summary>
            SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,

            /// <summary>
            /// Same as SPI_SETKEYBOARDCUES.
            /// </summary>
            SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,

            /// <summary>
            /// Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must point
            /// to a BOOL variable that receives TRUE for on, or FALSE for off.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETACTIVEWNDTRKZORDER = 0x100C,

            /// <summary>
            /// Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE
            /// for on or FALSE for off.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETACTIVEWNDTRKZORDER = 0x100D,

            /// <summary>
            /// Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam parameter
            /// must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled.
            /// Hot tracking means that when the cursor moves over an item, it is highlighted but not selected. You can query this value to decide
            /// whether to use hot tracking in the user interface of your application.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETHOTTRACKING = 0x100E,

            /// <summary>
            /// Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to TRUE
            /// to enable it, or FALSE to disable it.
            /// Hot-tracking means that when the cursor moves over an item, it is highlighted but not selected.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETHOTTRACKING = 0x100F,

            /// <summary>
            /// Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation.
            /// This flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag.
            /// For more information, see AnimateWindow.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETMENUFADE = 0x1012,

            /// <summary>
            /// Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it.
            /// If fade animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system
            /// has a color depth of more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information,
            /// see AnimateWindow.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETMENUFADE = 0x1013,

            /// <summary>
            /// Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled or FALSE if disabled.
            /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out
            /// after the menu is dismissed.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETSELECTIONFADE = 0x1014,

            /// <summary>
            /// Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it.
            /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out
            /// after the menu is dismissed. The selection fade effect is possible only if the system has a color depth of more than 256 colors.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETSELECTIONFADE = 0x1015,

            /// <summary>
            /// Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or slide animation.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETTOOLTIPANIMATION = 0x1016,

            /// <summary>
            /// Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE
            /// to specify fade or slide animation.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETTOOLTIPANIMATION = 0x1017,

            /// <summary>
            /// If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide effect.
            ///  The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide animation.
            ///  For more information on slide and fade effects, see AnimateWindow.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETTOOLTIPFADE = 0x1018,

            /// <summary>
            /// If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade effect
            /// or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is possible only
            /// if the system has a color depth of more than 256 colors. For more information on the slide and fade effects,
            /// see the AnimateWindow function.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETTOOLTIPFADE = 0x1019,

            /// <summary>
            /// Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256 colors.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETCURSORSHADOW = 0x101A,

            /// <summary>
            /// Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the shadow
            /// or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETCURSORSHADOW = 0x101B,

            //#if(_WIN32_WINNT >= 0x0501)
            /// <summary>
            /// Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_GETMOUSESONAR = 0x101C,

            /// <summary>
            /// Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse pointer
            /// when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off.
            /// For more information, see About Mouse Input.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_SETMOUSESONAR = 0x101D,

            /// <summary>
            /// Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled, or FALSE otherwise. For more information, see About Mouse Input.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_GETMOUSECLICKLOCK = 0x101E,

            /// <summary>
            /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button
            /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies
            /// TRUE for on,
            /// or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_SETMOUSECLICKLOCK = 0x101F,

            /// <summary>
            /// Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_GETMOUSEVANISH = 0x1020,

            /// <summary>
            /// Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears
            /// when the user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off.
            /// For more information, see About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_SETMOUSEVANISH = 0x1021,

            /// <summary>
            /// Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable
            /// that returns TRUE if the flat menu appearance is set, or FALSE otherwise.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETFLATMENU = 0x1022,

            /// <summary>
            /// Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance
            /// or FALSE to disable it.
            /// When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup background, COLOR_MENUHILIGHT
            /// for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current menu selection.
            /// If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETFLATMENU = 0x1023,

            /// <summary>
            /// Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE
            /// if enabled or FALSE if disabled.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETDROPSHADOW = 0x1024,

            /// <summary>
            /// Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it.
            /// You must also have CS_DROPSHADOW in the window class style.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETDROPSHADOW = 0x1025,

            /// <summary>
            /// Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function
            /// to simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if the simulated input will be blocked, or FALSE otherwise.
            /// </summary>
            SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

            /// <summary>
            /// Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard
            /// or mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input,
            /// or FALSE if the screensaver will be deactivated by simulated input.
            /// </summary>
            SPI_SETBLOCKSENDINPUTRESETS = 0x1027,
            //#endif /* _WIN32_WINNT >= 0x0501 */

            /// <summary>
            /// Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE
            /// if all UI effects are enabled, or FALSE if they are disabled.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETUIEFFECTS = 0x103E,

            /// <summary>
            /// Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI effects.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETUIEFFECTS = 0x103F,

            /// <summary>
            /// Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications
            /// to force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

            /// <summary>
            /// Sets the amount of time following user input, in milliseconds, during which the system does not allow applications
            /// to force themselves into the foreground. Set pvParam to the new timeout value.
            /// The calling thread must be able to change the foreground window, otherwise the call fails.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

            /// <summary>
            /// Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable
            /// that receives the time.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

            /// <summary>
            /// Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window
            /// under the mouse pointer.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

            /// <summary>
            /// Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request.
            /// The pvParam parameter must point to a DWORD variable that receives the value.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

            /// <summary>
            /// Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request.
            /// Set pvParam to the number of times to flash.
            /// Windows NT, Windows 95:  This value is not supported.
            /// </summary>
            SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

            /// <summary>
            /// Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETCARETWIDTH = 0x2006,

            /// <summary>
            /// Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
            /// Windows NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETCARETWIDTH = 0x2007,

            //#if(_WIN32_WINNT >= 0x0501)
            /// <summary>
            /// Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives
            /// the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_GETMOUSECLICKLOCKTIME = 0x2008,

            /// <summary>
            /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button
            /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter
            /// specifies TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
            /// Windows 2000/NT, Windows 98/95:  This value is not supported.
            /// </summary>
            SPI_SETMOUSECLICKLOCKTIME = 0x2009,

            /// <summary>
            /// Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETFONTSMOOTHINGTYPE = 0x200A,

            /// <summary>
            /// Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD,
            /// if standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD.
            /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise,
            /// SystemParametersInfo fails.
            /// </summary>
            SPI_SETFONTSMOOTHINGTYPE = 0x200B,

            /// <summary>
            /// Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT
            /// that receives the information.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

            /// <summary>
            /// Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value.
            /// Valid contrast values are from 1000 to 2200. The default value is 1400.
            /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise,
            /// SystemParametersInfo fails.
            /// SPI_SETFONTSMOOTHINGTYPE must also be set to FE_FONTSMOOTHINGCLEARTYPE.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

            /// <summary>
            /// Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect.
            /// The pvParam parameter must point to a UINT.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETFOCUSBORDERWIDTH = 0x200E,

            /// <summary>
            /// Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETFOCUSBORDERWIDTH = 0x200F,

            /// <summary>
            /// Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect.
            /// The pvParam parameter must point to a UINT.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_GETFOCUSBORDERHEIGHT = 0x2010,

            /// <summary>
            /// Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
            /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
            /// </summary>
            SPI_SETFOCUSBORDERHEIGHT = 0x2011,

            /// <summary>
            /// Not implemented.
            /// </summary>
            SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

            /// <summary>
            /// Not implemented.
            /// </summary>
            SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
        }
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
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SystemParametersInfo(Enums.SPI uiAction, uint uiParam, IntPtr pvParam, Enums.SPIF fWinIni);
}