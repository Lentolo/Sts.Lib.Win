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
        protected override void OnTxtDblClick()
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
        protected override void OnBtnClick()
        {
            ShowDialog();
        }
        protected override void OnTextChanged()
        {
            _changed = true;
        }
        protected override void OnTextValidated()
        {
            CallOnPathChanged();
        }
    }
}