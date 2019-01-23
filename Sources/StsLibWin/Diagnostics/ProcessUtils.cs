using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using StsLib.Common;
using StsLibWin.Windows;

namespace StsLibWin.Diagnostics
{
    public static class ProcessUtils
    {
        public static bool CreateProcessWithLogonW(string domain, string user, string password, string fileName, string arguments)
        {
            var startupInfo = new Win32.StartupInfo();
            return Win32.CreateProcessWithLogonW(user, domain, password, Win32.LogonWithProfile, fileName, arguments, Win32.CreateNewConsole, 0, null, ref startupInfo, out _);
        }
        public static string StartWaitAndGetOutput(ProcessStartInfo processStartInfo)
        {
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            using (var process = Process.Start(processStartInfo))
            {
                var rVal = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return rVal;
            }
        }
        public static string StartWaitAndGetOutput(string fileName, string arguments)
        {
            return StartWaitAndGetOutput(new ProcessStartInfo
            {
                Arguments = arguments,
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
        public static Process ShellExecute(string fileName)
        {
            return ShellExecute(fileName, null);
        }
        public static Process ShellExecute(string fileName, string arguments)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Environment.ExpandEnvironmentVariables(fileName),
                Arguments = arguments,
                UseShellExecute = true
            };
            return Process.Start(processStartInfo);
        }
        public static IEnumerable<ProcessWindow> GetWindows()
        {
            var rval = new List<ProcessWindow>();
            Win32.EnumWindows(delegate(IntPtr hWnd, int lParam)
            {
                uint processId;
                Win32.GetWindowThreadProcessId(hWnd, out processId);
                var length = Win32.GetWindowTextLength(hWnd);
                var sb = new StringBuilder(length + 1);
                Win32.GetWindowText(hWnd, sb, length + 1);
                rval.Add(new ProcessWindow
                {
                    Hwnd = hWnd,
                    Visible = Win32.IsWindowVisible(hWnd),
                    Title = sb.ToString().Trim(),
                    Process = Process.GetProcessById((int) processId).ProcessName
                });
                return true;
            }, 0);
            return rval.AsReadOnly();
        }
        public sealed class ProcessWindow
        {
            public IntPtr Hwnd
            {
                get;
                internal set;
            }
            public bool Visible
            {
                get;
                internal set;
            }
            public string Title
            {
                get;
                internal set;
            }
            public string Process
            {
                get;
                internal set;
            }
        }
    }
}