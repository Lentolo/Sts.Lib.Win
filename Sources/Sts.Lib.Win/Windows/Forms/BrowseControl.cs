using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
    public class BrowseControl : TxtButtonControl
    {
        private bool _changed;
        protected BrowseControl()
        {
        }
        public string SelectedPath
        {
            get
            {
                _changed = false;
                return base.Text;
            }
            set
            {
                base.Text = value;
                _changed = false;
            }
        }
        public event EventHandler PathChanged;
        private void CallOnPathChanged()
        {
            if (_changed)
            {
                OnPathChanged();
            }
        }
        protected virtual void OnPathChanged()
        {
            Sts.Lib.Delegates.Utils.RaiseEvent(PathChanged, this, new EventArgs());
        }
        private void _btnBrowse_Click(object sender, EventArgs e)
        {
            ShowDialog();
        }
        protected virtual (bool, string) OnShowDialog()
        {
            return (false, "");
        }
        private void ShowDialog()
        {
            var r = OnShowDialog();
            if (!r.Item1)
            {
                return;
            }

            _changed = true;
            Text = r.Item2;
            CallOnPathChanged();
        }
        public override string Text { get => base.Text; set => base.Text = value; }
        private void _txtPath_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                if (Directory.Exists(Text))
                {
                    Sts.Lib.Diagnostics.ProcessUtils.ShellExecute(Text);
                }

                return;
            }

            ShowDialog();
        }
        private void _txtPath_TextChanged(object sender, EventArgs e)
        {
            _changed = true;
        }
        private void _txtPath_Validated(object sender, EventArgs e)
        {
            CallOnPathChanged();
        }
    }
}