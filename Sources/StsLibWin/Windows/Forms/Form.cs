using StsLib.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class Form : System.Windows.Forms.Form
  {
    protected void SetDesktopLocationWithEnsureBounds(int x, int y)
    {
      var s = Screen.FromControl(this).WorkingArea;
      var container = new System.Drawing.Rectangle(s.X, s.Y, s.Width, s.Height);
      var content = new System.Drawing.Rectangle(Left, Top, Width, Height);
      var point = StsLib.Drawing.Utils.EnsureVisible(container, content);
      SetDesktopLocation(point.X, point.Y);
    }
  }
}