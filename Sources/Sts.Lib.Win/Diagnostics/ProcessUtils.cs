using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Threading;
using Sts.Lib.Win.Windows;

namespace Sts.Lib.Win.Diagnostics
{
    public static class ProcessUtils
    {
        public static void KillProcessAndChildren(Process process)
        {
            KillProcessAndChildren(process.Id);
        }

        private static void KillProcessAndChildren(int pid)
        {
            if (pid == 0)
            {
                return;
            }

            using var searcher = new ManagementObjectSearcher("Select ProcessID From Win32_Process Where ParentProcessID = " + pid);
            using var moc = searcher.Get();
            foreach (var o in moc)
            {
                using var mo = (ManagementObject)o;
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                var proc = Process.GetProcessById(pid);
                do
                {
                    proc.Kill();
                    Thread.Sleep(100);
                } while (!proc.WaitForExit(500));
            }
            catch (ArgumentException)
            {
            }
        }

        public static bool CreateProcessWithLogonW(string domain, string user, string password, string fileName, string arguments)
        {
            var startupInfo = new Win32.Structs.StartupInfo();
            return Win32.CreateProcessWithLogonW(user, domain, password, Win32.Constants.LogonWithProfile, fileName, arguments, Win32.Constants.CreateNewConsole, 0, null, ref startupInfo, out _);
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