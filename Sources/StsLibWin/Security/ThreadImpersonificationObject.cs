using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using StsLib.Common.Extensions;
using Microsoft.Win32.SafeHandles;


namespace StsLibWin.Security
{


  public class ThreadImpersonificationObject : StsLib.Security.IThreadImpersonificationObject
  {
    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

    private sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
      private SafeTokenHandle()
        : base(true)
      {
      }

      [DllImport("kernel32.dll")]
      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      [SuppressUnmanagedCodeSecurity]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool CloseHandle(IntPtr handle);

      protected override bool ReleaseHandle()
      {
        return CloseHandle(handle);
      }
    }

    public void Dispose()
    {
      LogOff();
    }
    SafeTokenHandle _safeTokenHandle;
    WindowsImpersonationContext _impersonatedUser;
    public bool Login(string userName, string password)
    {
      LogOff();
      string domain = userName.SubstringBeforeToken("\\");
      string user = string.IsNullOrEmpty(domain) ? userName : userName.SubstringAfterToken("\\");
      if (LogonUser(user, domain, password, 2, 0, out _safeTokenHandle))
      {
        _impersonatedUser = WindowsIdentity.Impersonate(_safeTokenHandle.DangerousGetHandle());
        return true;
      }
      return false;
    }

    public void LogOff()
    {
      _impersonatedUser?.Dispose();
      _safeTokenHandle?.Dispose();
    }
  }
}
