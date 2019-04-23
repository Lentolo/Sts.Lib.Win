using System;
using System.Drawing;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class TxtButtonControl : UserControl
  {
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      _btn.Left = Width - _btn.Width - _btn.Margin.Left - _btn.Margin.Right;
      _btn.Top = 0;
      _txt.Left = 0;
      _txt.Width = Width - _btn.Width - _txt.Margin.Left - _txt.Margin.Right;
      _txt.Top = (_btn.Height - _txt.Height) / 2;
    }
    private Button _btn;
    private TextBox _txt;
    public TxtButtonControl()
    {
      InitializeComponent();
    }
    public override string Text
    {
      get => _txt.Text;
      set => _txt.Text = value;
    }
    private void InitializeComponent()
    {
      this._btn = new StsLibWin.Windows.Forms.Button();
      this._txt = new StsLibWin.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // _btn
      // 
      this._btn.Location = new System.Drawing.Point(563, 3);
      this._btn.Margin = new System.Windows.Forms.Padding(0);
      this._btn.Name = "_btn";
      this._btn.Size = new System.Drawing.Size(34, 20);
      this._btn.TabIndex = 1;
      this._btn.Text = "...";
      this._btn.UseVisualStyleBackColor = true;
      this._btn.Click += new System.EventHandler(this.Btn_Click);
      // 
      // _txt
      // 
      this._txt.Location = new System.Drawing.Point(0, 3);
      this._txt.Margin = new System.Windows.Forms.Padding(0);
      this._txt.Name = "_txt";
      this._txt.Size = new System.Drawing.Size(563, 20);
      this._txt.TabIndex = 0;
      this._txt.DoubleClick += new System.EventHandler(this.Txt_DoubleClick);
      // 
      // TxtButtonControl
      // 
      this.Controls.Add(this._txt);
      this.Controls.Add(this._btn);
      this.Name = "TxtButtonControl";
      this.Size = new System.Drawing.Size(597, 27);
      this.ResumeLayout(false);
      this.PerformLayout();

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