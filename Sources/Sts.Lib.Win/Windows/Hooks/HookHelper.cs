using System;
using System.Runtime.InteropServices;

namespace Sts.Lib.Win.Windows.Hooks;

public abstract class HookHelper : IDisposable
{
    public enum HookTypes
    {
        LowLevelKeyboard = 13,
        LowLevelMouse = 14
    }

    private IntPtr _keyboardHook = IntPtr.Zero;
    private readonly HookProc hookProc;

    protected HookHelper()
    {
        hookProc = LowLevelKeyboardProc;
        InstallHook();
    }

    protected abstract HookTypes HookType
    {
        get;
    }

    public void Dispose()
    {
        UninstallHook();
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowsHookEx(HookTypes idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

    [DllImport("user32.dll")]
    private static extern int UnhookWindowsHookEx(IntPtr hHook);

    [DllImport("user32.dll")]
    private static extern IntPtr CallNextHookEx(IntPtr _, int nCode, UIntPtr wParam, IntPtr lParam);

    private void UninstallHook()
    {
        UnhookWindowsHookEx(_keyboardHook);
        _keyboardHook = IntPtr.Zero;
    }

    private void InstallHook()
    {
        if (_keyboardHook == IntPtr.Zero)
        {
            _keyboardHook = SetWindowsHookEx(HookType, hookProc, IntPtr.Zero, 0);
        }
    }

    private IntPtr LowLevelKeyboardProc(int nCode, UIntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            OnHook(wParam, lParam);
        }

        return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
    }

    protected abstract void OnHook(UIntPtr wParam, IntPtr lParam);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate IntPtr HookProc(int nCode, UIntPtr wParam, IntPtr lParam);
}