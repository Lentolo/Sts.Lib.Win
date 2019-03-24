using System;
using System.Drawing;
using System.Windows.Forms;

namespace StsLib.Windows.Forms
{
    public class TxtButtonControl : UserControl
    {
        private System.Windows.Forms.Button _btn;
        private System.Windows.Forms.TextBox _txt;

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

        private void InitializeComponent()
        {
            _btn = new System.Windows.Forms.Button();
            _txt = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // m_Btn
            // 
            _btn.Dock = DockStyle.Right;
            _btn.Location = new Point(563, 0);
            _btn.Name = "_btn";
            _btn.Size = new Size(34, 27);
            _btn.TabIndex = 0;
            _btn.Text = "...";
            _btn.UseVisualStyleBackColor = true;
            _btn.Click += Btn_Click;
            // 
            // m_Txt
            // 
            _txt.Dock = DockStyle.Fill;
            _txt.Location = new Point(0, 0);
            _txt.Multiline = true;
            _txt.Name = "_txt";
            _txt.Size = new Size(563, 27);
            _txt.TabIndex = 1;
            _txt.DoubleClick += Txt_DoubleClick;
            // 
            // TxtButtonControl
            // 
            Controls.Add(_txt);
            Controls.Add(_btn);
            Margin = new Padding(0);
            Name = "TxtButtonControl";
            Size = new Size(597, 27);
            ResumeLayout(false);
            PerformLayout();
        }
        protected virtual void OnBtnClick()
        {
        }
        protected virtual void OnTxtDblClick()
        {
        }
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