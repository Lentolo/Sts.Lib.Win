using System;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Common;

namespace Sts.Lib.Win.Windows.Forms
{
    public class Form : System.Windows.Forms.Form
    {
        public enum EndSession
        {
            CloseApp,
            Critical,
            Logoff
        }

        private bool _firstShown = true;

        protected virtual void OnWmQueryEndSession(ReadonlyDataArgs<EndSession> e)
        { }

        protected virtual void OnFirstShown(EventArgs e)
        { }

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

            if (m.Msg == (int) Win32.Enums.WmConstants.WmQueryEndSession)
            {
                var param = (Win32.Enums.EndSession) (long) m.LParam;
                var endSession = param switch
                {
                    Win32.Enums.EndSession.EndsessionCloseapp => EndSession.CloseApp,
                    Win32.Enums.EndSession.EndsessionCritical => EndSession.Critical,
                    Win32.Enums.EndSession.EndsessionLogoff => EndSession.Logoff,
                    _ => throw new ArgumentOutOfRangeException()
                };

                OnWmQueryEndSession(new ReadonlyDataArgs<EndSession>(endSession));
            }
        }

        protected void SetDesktopLocationWithEnsureBounds(int x, int y)
        {
            var s = Screen.FromControl(this).WorkingArea;
            var container = new Rectangle(s.X, s.Y, s.Width, s.Height);
            var content = new Rectangle(Left, Top, Width, Height);
            var point =Sts.Lib. Drawing.Utils.EnsureVisible(container, content);
            SetDesktopLocation(point.X, point.Y);
        }
    }
}
