using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;
using Sts.Lib.Common.Extensions;
using Sts.Lib.Security;

namespace Sts.Lib.Win.Security
{
    public static class Utils
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);

        public static bool  RunActionImpersonated(Action action, string username, string password, string domain)
        {
            SafeAccessTokenHandle safeTokenHandle=null;

            try
            {
                if (!LogonUser(username, domain, password, 2, 0, out safeTokenHandle))
                {
                    return false;
                }

                WindowsIdentity.RunImpersonated(safeTokenHandle, () =>
                {
                    action?.Invoke();
                });
                return true;
            }
            finally
            {
                safeTokenHandle?.Dispose();
            }
        }
    }
}
