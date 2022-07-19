using System;
using System.Runtime.InteropServices;
using Sts.Lib.Common;

namespace Sts.Lib.Win.Windows.Hooks;

public class MouseHook : HookHelper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;
    }
    public enum MouseMessageTypes
    {
        MouseMove = 0x200,
        LButtonDown = 0x201,
        LButtonUp = 0x202,
        RButtonDown = 0x204,
        RButtonUp = 0x205,
        MouseWheel = 0x20a,
        MouseHWheel = 0x20e
    }

    protected override HookTypes HookType
    {
        get
        {
            return HookTypes.LowLevelMouse;
        }
    }

    public event EventHandler<ReadonlyDataArgs<(Point Position, MouseMessageTypes MessageType)>> MouseHookEvent;

    protected override void OnHook(UIntPtr wParam, IntPtr lParam)
    {
        MouseHookEvent?.Invoke(this, new ReadonlyDataArgs<(Point Position, MouseMessageTypes MessageType)>((Marshal.PtrToStructure<MouseLowLevelHookStruct>(lParam).pt, (MouseMessageTypes) wParam)));
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MouseLowLevelHookStruct
    {
        public readonly Point pt;
        public readonly int mouseData;
        public readonly int flags;
        public readonly int time;
        public readonly IntPtr dwExtraInfo;
    }
}