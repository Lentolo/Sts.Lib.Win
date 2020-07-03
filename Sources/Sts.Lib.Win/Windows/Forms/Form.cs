using System;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
  public class Form : System.Windows.Forms.Form
  {
    protected virtual void OnWmQueryEndSession(Sts.Lib.Common.ReadonlyDataArgs<Win32.EndSession> e)
    {
    }
    protected virtual void OnFirstShown(EventArgs e)
    { }
    bool _firstShown = true;
    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      if (_firstShown)
      {
        _firstShown = false;
        OnFirstShown(e);
      }
    }
    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
      if (m.Msg == (int)Win32.WmConstants.WmQueryEndSession)
      {
        OnWmQueryEndSession(new Sts.Lib.Common.ReadonlyDataArgs<Win32.EndSession>((Win32.EndSession)(long)m.LParam));
      }
    }
    protected void SetDesktopLocationWithEnsureBounds(int x, int y)
    {
      var s = Screen.FromControl(this).WorkingArea;
      var container = new System.Drawing.Rectangle(s.X, s.Y, s.Width, s.Height);
      var content = new System.Drawing.Rectangle(Left, Top, Width, Height);
      var point = Sts.Lib.Drawing.Utils.EnsureVisible(container, content);
      SetDesktopLocation(point.X, point.Y);
    }
  }
}