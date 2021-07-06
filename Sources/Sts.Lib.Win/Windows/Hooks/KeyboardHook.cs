using System;
using System.Runtime.InteropServices;

namespace Sts.Lib.Win.Windows.Hooks
{
    public class KeyboardHook : HookHelper
    {
        public enum KeyboardMessageTypes
        {
            KeyDown = 0x100,
            KeyUp = 0x101,
            SysKeyDown = 0x104,
            SysKeyUp = 0x105
        }

        protected override HookTypes HookType
        {
            get
            {
                return HookTypes.LowLevelKeyboard;
            }
        }

        public event EventHandler<Sts.Lib.Common. ReadonlyDataArgs<(int KeyCode,KeyboardMessageTypes MessageType)>> KeyboardHookEvent;

        protected override void OnHook(UIntPtr wParam, IntPtr lParam)
        {
            KeyboardHookEvent?.Invoke(this, new Common.ReadonlyDataArgs<(int KeyCode,KeyboardMessageTypes MessageType)>((Marshal.PtrToStructure<KeyboardLowLevelHookStruct>(lParam).vkCode, (KeyboardMessageTypes) wParam)));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KeyboardLowLevelHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }
    }
}