using System;
using System.Drawing;
using System.Windows.Forms;
using StsLib.Collections.Generic;

namespace StsLibWin.Windows.Forms
{
  public class TxtButtonControl : UserControl, ControlStatePersister.ISaveStateControl
  {
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
    public virtual bool CanSaveControlState { get ; set ; }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      _btn.Left = Width - _btn.Width - _btn.Margin.Left - _btn.Margin.Right;
      _btn.Top = 0;
      _txt.Left = 0;
      _txt.Width = Width - _btn.Width - _txt.Margin.Left - _txt.Margin.Right;
      _txt.Top = (_btn.Height - _txt.Height) / 2;
    }
    private void InitializeComponent()
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

    public virtual void LoadControlStateData(Dictionary<string, object> data)
    {
      throw new NotImplementedException();
    }

    public virtual void SaveControlStateData(Dictionary<string, object> data)
    {
      throw new NotImplementedException();
    }
  }
}