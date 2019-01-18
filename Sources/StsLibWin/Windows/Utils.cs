using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace StsLibWin.Windows
{
  public static class Utils
  {
    public enum WallpaperPosition
    {
      Fill,
      Fit,
      Stretch,
      Tile,
      Center
    }
    public static string GetCurrentWallpaper()
    {
      return (string) Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallPaper", "");
    }
    public static void SetCurrentWallpaper(string path, WallpaperPosition position)
    {
      switch (position)
      {
        case WallpaperPosition.Center:
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallpaperStyle", "0");
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "TileWallpaper", "0");
          break;
        case WallpaperPosition.Fill:
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallpaperStyle", "10");
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "TileWallpaper", "0");
          break;
        case WallpaperPosition.Fit:
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallpaperStyle", "6");
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "TileWallpaper", "0");
          break;
        case WallpaperPosition.Stretch:
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallpaperStyle", "2");
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "TileWallpaper", "0");
          break;
        default:
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WallpaperStyle", "0");
          Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "TileWallpaper", "1");
          break;
      }

      Win32.SystemParametersInfo(Win32.Spi_Setdeskwallpaper, 0, path, Win32.Spif_Sendwininichange | Win32.Spif_Updateinifile);
    }
    public static void SetWaveVolume(int leftChannel, int rightChannel)
    {
      uint volume = 0;
      rightChannel = Math.Max(0, Math.Min(rightChannel, 100));
      leftChannel = Math.Max(0, Math.Min(leftChannel, 100));
      volume = ((0xFFFF * (uint) rightChannel / 100) << 16) + 0xFFFF * (uint) leftChannel / 100;
      Win32.waveOutSetVolume(IntPtr.Zero, volume);
    }
    public static void GetWaveVolume(out int leftChannel, out int rightChannel)
    {
      uint volume = 0;
      Win32.waveOutGetVolume(IntPtr.Zero, out volume);
      rightChannel = (int) (100.0 * ((volume & 0xFFFF0000) >> 16) / 65535.0);
      leftChannel = (int) (100.0 * (volume & 0x0000FFFF) / 65535.0);
    }
    public static DateTime GetLastInputDateTime()
    {
      return DateTime.Now.AddMilliseconds(-1 * Math.Max(0, (uint) Environment.TickCount - GetLastInputInfo()));
    }
    public static uint GetLastInputInfo()
    {
      var lastInputInfo = new Win32.Lastinputinfo();
      lastInputInfo.cbSize = (uint) Marshal.SizeOf(lastInputInfo);
      if (Win32.GetLastInputInfo(ref lastInputInfo))
      {
        return lastInputInfo.dwTime;
      }

      return 0;
    }
  }
}