using System;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.Extensions
{
  public static class Utils
  {
      public static TOut Invoke<TControl, TOut>(this TControl control, Func<TControl, TOut> func)
          where TControl : Control
      {
          return (TOut)control.Invoke(func, control);
      }
      public static void Invoke(this Control control, Action func)
      {
          control.Invoke(func);
      }
  }
}