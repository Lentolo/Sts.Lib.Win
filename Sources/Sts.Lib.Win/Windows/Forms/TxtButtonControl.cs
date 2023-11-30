using System;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic.Dictionaries;

namespace Sts.Lib.Win.Windows.Forms;

public class TxtButtonControl : UserControl, ControlStatePersister.ISaveStateControl
{
    protected Button btn;
    protected TextBox txt;

    public TxtButtonControl()
    {
        InitializeComponent();
    }

    public override string Text
    {
        get
        {
            return txt.Text;
        }
        set
        {
            txt.Text = value;
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
        txt.Top = 0;
        txt.Left = 0;
        txt.Height = Height;
        txt.Width = Width - btn.Width;

        btn.Top = -1;
        btn.Left = Width - btn.Width;
        btn.Height = Height;
    }

    protected virtual void InitializeComponent()
    {
        btn = new Button();
        txt = new TextBox();
        SuspendLayout();
        // 
        // _btn
        // 
        btn.Location = new Point(563, 0);
        btn.Margin = new Padding(0);
        btn.Name = "btn";
        btn.Size = new Size(34, 21);
        btn.TabIndex = 1;
        btn.Text = "...";
        btn.UseVisualStyleBackColor = true;
        btn.Click += Btn_Click;
        // 
        // _txt
        // 
        txt.Location = new Point(0, 0);
        txt.Margin = new Padding(0);
        txt.Name = "txt";
        txt.SaveControlState = false;
        txt.Size = new Size(563, 23);
        txt.TabIndex = 0;
        txt.TextChanged += Txt_TextChanged;
        txt.DoubleClick += Txt_DoubleClick;
        txt.Leave += Txt_Leave;
        txt.Validated += Txt_Validated;
        // 
        // TxtButtonControl
        // 
        Controls.Add(txt);
        Controls.Add(btn);
        Margin = new Padding(0);
        Name = "TxtButtonControl";
        Size = new Size(597, 27);
        ResumeLayout(false);
        PerformLayout();
    }

    private void Txt_Leave(object sender, EventArgs e)
    {
        OnTextLeave();
    }

    private void Txt_Validated(object sender, EventArgs e)
    {
        OnTextValidated();
    }

    private void Txt_TextChanged(object sender, EventArgs e)
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
