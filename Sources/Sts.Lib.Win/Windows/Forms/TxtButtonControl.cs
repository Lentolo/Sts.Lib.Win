using System;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic;

namespace Sts.Lib.Win.Windows.Forms
{
    public class TxtButtonControl : UserControl, ControlStatePersister.ISaveStateControl
    {
        protected Button _btn;
        protected TextBox _txt;

        public TxtButtonControl()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return _txt.Text;
            }
            set
            {
                _txt.Text = value;
            }
        }

        public virtual bool SaveControlState
        {
            get;
            set;
        }

        public virtual void SetControlStateData(Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }

        public virtual void RetrieveControlStateData(Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _btn.Left = Width - _btn.Width - _btn.Margin.Left - _btn.Margin.Right;
            _btn.Top = 0;
            _txt.Left = 0;
            _txt.Width = Width - _btn.Width - _txt.Margin.Left - _txt.Margin.Right;
            _txt.Top = (_btn.Height - _txt.Height) / 2;
        }

        protected virtual void InitializeComponent()
        {
            _btn = new Button();
            _txt = new TextBox();
            SuspendLayout();
            // 
            // _btn
            // 
            _btn.Location = new Point(563, 3);
            _btn.Margin = new Padding(0);
            _btn.Name = "_btn";
            _btn.Size = new Size(34, 20);
            _btn.TabIndex = 1;
            _btn.Text = "...";
            _btn.UseVisualStyleBackColor = true;
            _btn.Click += Btn_Click;
            // 
            // _txt
            // 
            _txt.Location = new Point(0, 3);
            _txt.Margin = new Padding(0);
            _txt.Name = "_txt";
            _txt.Size = new Size(563, 20);
            _txt.TabIndex = 0;
            _txt.DoubleClick += Txt_DoubleClick;
            _txt.TextChanged += _txt_TextChanged;
            _txt.Validated += _txt_Validated;
            _txt.Leave += _txt_Leave;
            // 
            // TxtButtonControl
            // 
            Controls.Add(_txt);
            Controls.Add(_btn);
            Name = "TxtButtonControl";
            Size = new Size(597, 27);
            ResumeLayout(false);
            PerformLayout();
        }

        private void _txt_Leave(object sender, EventArgs e)
        {
            OnTextLeave();
        }

        private void _txt_Validated(object sender, EventArgs e)
        {
            OnTextValidated();
        }

        private void _txt_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged();
        }

        protected virtual void OnTextLeave()
        { }
        protected virtual void OnTextChanged()
        { }

        protected virtual void OnTextValidated()
        { }

        protected virtual void OnBtnClick()
        { }

        protected virtual void OnTxtDblClick()
        { }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnBtnClick();
        }

        private void Txt_DoubleClick(object sender, EventArgs e)
        {
            OnTxtDblClick();
        }
    }
}