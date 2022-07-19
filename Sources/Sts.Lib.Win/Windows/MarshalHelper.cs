using System;
using System.Runtime.InteropServices;

namespace Sts.Lib.Win.Windows;

public sealed class MarshalHelper<T> : IDisposable
{
    public MarshalHelper()
    {
        IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
    }
    public IntPtr IntPtr
    {
        get; set;
    }
    public void Dispose()
    {
        Marshal.FreeHGlobal(IntPtr);
    }
}