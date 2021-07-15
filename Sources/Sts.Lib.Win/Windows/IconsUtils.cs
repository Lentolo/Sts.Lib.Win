using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Sts.Lib.Win.Windows
{
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
                throw new NotImplementedException();
            }
        }
        public static IconInfo GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            var shfi = new Win32.SHFILEINFO();
            using var ddd = Sts.Lib.Common.DelegateDisposable.CreateDelegateDisposable(() => { }, () => Win32.DestroyIcon(shfi.hIcon));
            var flags = Win32.SHGFI_ICON | Win32.SHGFI_ICONLOCATION | Win32.SHGFI_TYPENAME | Win32.SHGFI_USEFILEATTRIBUTES| Win32.SHGFI_EXETYPE;

            if (linkOverlay)
            {
                flags += Win32.SHGFI_LINKOVERLAY;
            }

            flags += IconSize.Small == size ? Win32.SHGFI_SMALLICON : Win32.SHGFI_LARGEICON;
            Win32.SHGetFileInfo(name, Win32.FILE_ATTRIBUTE_NORMAL, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
            return new IconInfo()
            {
                Icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone(),
                Index = shfi.iIcon,
                Location = shfi.szDisplayName,
            };
        }

        public static IconInfo GetFolderIcon(IconSize size, FolderType folderType)
        {
            var flags = Win32.SHGFI_ICON | Win32.SHGFI_USEFILEATTRIBUTES;

            if (FolderType.Open == folderType)
            {
                flags += Win32.SHGFI_OPENICON;
            }

            if (IconSize.Small == size)
            {
                flags += Win32.SHGFI_SMALLICON;
            }
            else
            {
                flags += Win32.SHGFI_LARGEICON;
            }

            var shfi = new Win32.SHFILEINFO();
            using var ddd = Sts.Lib.Common.DelegateDisposable.CreateDelegateDisposable(() => { }, () => Win32.DestroyIcon(shfi.hIcon));
            Win32.SHGetFileInfo(null, Win32.FILE_ATTRIBUTE_DIRECTORY, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
            return new IconInfo()
            {
                Icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone(),
                Index = shfi.iIcon,
                Location = shfi.szDisplayName,
            };
        }
    }
}