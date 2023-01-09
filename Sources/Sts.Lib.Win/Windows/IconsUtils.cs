using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Sts.Lib.Common;

namespace Sts.Lib.Win.Windows;

public static class IconsUtils
{
    public enum FolderType
    {
        Open = 0,
        Closed = 1
    }

    public enum IconSize
    {
        Large = 0,
        Small = 1
    }

    private static Icon MakeTransparent(Icon icon)
    {
        using var bmp = new Bitmap(4*icon.Width, 4*icon.Height);
        using var gp = Graphics.FromImage(bmp);
        gp.Clear(Color.Transparent);
        gp.DrawIcon(icon, new Rectangle(0, 0, 4*icon.Width, 4*icon.Height));
        return Icon.FromHandle(bmp.GetHicon());
    }

    public static IconInfo GetSpecialFolderIcon(Environment.SpecialFolder specialFolder, IconSize size, bool linkOverlay)
    {
        var csidl = specialFolder switch
        {
            Environment.SpecialFolder.Desktop => Win32.Enums.CSIDL.CSIDL_DESKTOP,
            Environment.SpecialFolder.Programs => Win32.Enums.CSIDL.CSIDL_PROGRAMS,
            Environment.SpecialFolder.MyDocuments => Win32.Enums.CSIDL.CSIDL_PERSONAL,
            Environment.SpecialFolder.Favorites => Win32.Enums.CSIDL.CSIDL_FAVORITES,
            Environment.SpecialFolder.Startup => Win32.Enums.CSIDL.CSIDL_STARTUP,
            Environment.SpecialFolder.Recent => Win32.Enums.CSIDL.CSIDL_RECENT,
            Environment.SpecialFolder.SendTo => Win32.Enums.CSIDL.CSIDL_SENDTO,
            Environment.SpecialFolder.StartMenu => Win32.Enums.CSIDL.CSIDL_STARTMENU,
            Environment.SpecialFolder.MyMusic => Win32.Enums.CSIDL.CSIDL_MYMUSIC,
            Environment.SpecialFolder.MyVideos => Win32.Enums.CSIDL.CSIDL_MYVIDEO,
            Environment.SpecialFolder.DesktopDirectory => Win32.Enums.CSIDL.CSIDL_DESKTOPDIRECTORY,
            Environment.SpecialFolder.MyComputer => Win32.Enums.CSIDL.CSIDL_DRIVES,
            Environment.SpecialFolder.NetworkShortcuts => Win32.Enums.CSIDL.CSIDL_NETHOOD,
            Environment.SpecialFolder.Fonts => Win32.Enums.CSIDL.CSIDL_FONTS,
            Environment.SpecialFolder.Templates => Win32.Enums.CSIDL.CSIDL_TEMPLATES,
            Environment.SpecialFolder.CommonStartMenu => Win32.Enums.CSIDL.CSIDL_COMMON_STARTMENU,
            Environment.SpecialFolder.CommonPrograms => Win32.Enums.CSIDL.CSIDL_COMMON_PROGRAMS,
            Environment.SpecialFolder.CommonStartup => Win32.Enums.CSIDL.CSIDL_COMMON_STARTUP,
            Environment.SpecialFolder.CommonDesktopDirectory => Win32.Enums.CSIDL.CSIDL_COMMON_DESKTOPDIRECTORY,
            Environment.SpecialFolder.ApplicationData => Win32.Enums.CSIDL.CSIDL_APPDATA,
            Environment.SpecialFolder.PrinterShortcuts => Win32.Enums.CSIDL.CSIDL_PRINTHOOD,
            Environment.SpecialFolder.LocalApplicationData => Win32.Enums.CSIDL.CSIDL_LOCAL_APPDATA,
            Environment.SpecialFolder.InternetCache => Win32.Enums.CSIDL.CSIDL_INTERNET_CACHE,
            Environment.SpecialFolder.Cookies => Win32.Enums.CSIDL.CSIDL_COOKIES,
            Environment.SpecialFolder.History => Win32.Enums.CSIDL.CSIDL_HISTORY,
            Environment.SpecialFolder.CommonApplicationData => Win32.Enums.CSIDL.CSIDL_COMMON_APPDATA,
            Environment.SpecialFolder.Windows => Win32.Enums.CSIDL.CSIDL_WINDOWS,
            Environment.SpecialFolder.System => Win32.Enums.CSIDL.CSIDL_SYSTEM,
            Environment.SpecialFolder.ProgramFiles => Win32.Enums.CSIDL.CSIDL_PROGRAM_FILES,
            Environment.SpecialFolder.MyPictures => Win32.Enums.CSIDL.CSIDL_MYPICTURES,
            Environment.SpecialFolder.UserProfile => Win32.Enums.CSIDL.CSIDL_PROFILE,
            Environment.SpecialFolder.SystemX86 => Win32.Enums.CSIDL.CSIDL_SYSTEMX86,
            Environment.SpecialFolder.ProgramFilesX86 => Win32.Enums.CSIDL.CSIDL_PROGRAM_FILESX86,
            Environment.SpecialFolder.CommonProgramFiles => Win32.Enums.CSIDL.CSIDL_PROGRAM_FILES_COMMON,
            Environment.SpecialFolder.CommonProgramFilesX86 => Win32.Enums.CSIDL.CSIDL_PROGRAM_FILES_COMMONX86,
            Environment.SpecialFolder.CommonTemplates => Win32.Enums.CSIDL.CSIDL_COMMON_TEMPLATES,
            Environment.SpecialFolder.CommonDocuments => Win32.Enums.CSIDL.CSIDL_COMMON_DOCUMENTS,
            Environment.SpecialFolder.CommonAdminTools => Win32.Enums.CSIDL.CSIDL_COMMON_ADMINTOOLS,
            Environment.SpecialFolder.AdminTools => Win32.Enums.CSIDL.CSIDL_ADMINTOOLS,
            Environment.SpecialFolder.CommonMusic => Win32.Enums.CSIDL.CSIDL_COMMON_MUSIC,
            Environment.SpecialFolder.CommonPictures => Win32.Enums.CSIDL.CSIDL_COMMON_PICTURES,
            Environment.SpecialFolder.CommonVideos => Win32.Enums.CSIDL.CSIDL_COMMON_VIDEO,
            Environment.SpecialFolder.Resources => Win32.Enums.CSIDL.CSIDL_RESOURCES,
            Environment.SpecialFolder.LocalizedResources => Win32.Enums.CSIDL.CSIDL_RESOURCES_LOCALIZED,
            Environment.SpecialFolder.CommonOemLinks => Win32.Enums.CSIDL.CSIDL_COMMON_OEM_LINKS,
            Environment.SpecialFolder.CDBurning => Win32.Enums.CSIDL.CSIDL_CDBURN_AREA,
            _ => throw new ArgumentOutOfRangeException(nameof(specialFolder), specialFolder, null)
        };

        IntPtr pidl;
        Win32.SHGetFolderLocation(IntPtr.Zero, (int)csidl, IntPtr.Zero, 0, out pidl);
        return GetFileIcon(pidl, size, linkOverlay, Win32.Constants.SHGFI_PIDL| Win32.Constants.SHGFI_ICON | Win32.Constants.SHGFI_ICONLOCATION | Win32.Constants.SHGFI_TYPENAME | Win32.Constants.SHGFI_EXETYPE);
    }
    public static IconInfo GetFileIcon(IntPtr pszPath, IconSize size, bool linkOverlay, uint flags)
    {
        var psfi = new Win32.Structs.SHFILEINFO();
        using var disposable = DisposableDelegate.Create(() => { }, () => Win32.DestroyIcon(psfi.hIcon));
        var uFlags = flags;
        if (linkOverlay)
        {
            uFlags += Win32.Constants.SHGFI_LINKOVERLAY;
        }

        uFlags += IconSize.Small == size ? Win32.Constants.SHGFI_SMALLICON : Win32.Constants.SHGFI_LARGEICON;
        Win32.SHGetFileInfo(pszPath, 0, ref psfi, (uint)Marshal.SizeOf(psfi), uFlags);

        if (psfi.hIcon == IntPtr.Zero)
        {
            using var b = new Bitmap(256, 256);
            using var gp = Graphics.FromImage(b);
            gp.Clear(Color.Transparent);
            return new IconInfo
            {
                Icon = Icon.FromHandle(b.GetHicon()) ,
                Index = 0,
                Location = "##TransparentIcon##"
            };
        }

        using var clone = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
        return new IconInfo
        {
            Icon = MakeTransparent(clone),
            Index = psfi.iIcon,
            Location = psfi.szDisplayName
        };
    }

    public static IconInfo GetFileIcon(string name, IconSize size, bool linkOverlay)
    {
        return GetFileIcon(Marshal.StringToHGlobalAnsi(name), size, linkOverlay, Win32.Constants.SHGFI_ICON | Win32.Constants.SHGFI_ICONLOCATION | Win32.Constants.SHGFI_TYPENAME | Win32.Constants.SHGFI_EXETYPE);
    }

    public static IconInfo GetFolderIcon(IconSize size, FolderType folderType)
    {
        var flags = Win32.Constants.SHGFI_ICON | Win32.Constants.SHGFI_USEFILEATTRIBUTES;

        if (FolderType.Open == folderType)
        {
            flags += Win32.Constants.SHGFI_OPENICON;
        }

        if (IconSize.Small == size)
        {
            flags += Win32.Constants.SHGFI_SMALLICON;
        }
        else
        {
            flags += Win32.Constants.SHGFI_LARGEICON;
        }

        var shfi = new Win32.Structs.SHFILEINFO();
        using var ddd = DisposableDelegate.Create(() =>
                                                  { }, () => Win32.DestroyIcon(shfi.hIcon));
        Win32.SHGetFileInfo(IntPtr.Zero, Win32.Constants.FILE_ATTRIBUTE_DIRECTORY, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
        return new IconInfo
        {
            Icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone(),
            Index = shfi.iIcon,
            Location = shfi.szDisplayName
        };
    }

    public sealed class IconInfo : IDisposable
    {
        public Icon Icon
        {
            get;
            internal set;
        }

        public string Location
        {
            get;
            internal set;
        }

        public int Index
        {
            get;
            internal set;
        }

        public void Dispose()
        {
            Icon?.Dispose();
        }
    }

}