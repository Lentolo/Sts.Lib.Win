﻿using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
  public static class Utils
  {
    public static TOut Invoke<TControl,TOut>(this TControl control, Func<TControl, TOut> func)
    where TControl : Control
    {
      return (TOut)control.Invoke(func, control);
    }
  }
}