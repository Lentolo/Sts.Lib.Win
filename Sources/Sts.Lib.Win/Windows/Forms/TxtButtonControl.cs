using System;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic;
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
        get { return txt.Text; }
        set { txt.Text = value; }
    }

    public virtual bool SaveControlState { get; set; }

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
        this.btn = new Sts.Lib.Win.Windows.Forms.Button();
        this.txt = new Sts.Lib.Win.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // _btn
        // 
        this.btn.Location = new System.Drawing.Point(563, 0);
        this.btn.Margin = new System.Windows.Forms.Padding(0);
        this.btn.Name = "btn";
        this.btn.Size = new System.Drawing.Size(34, 21);
        this.btn.TabIndex = 1;
        this.btn.Text = "...";
        this.btn.UseVisualStyleBackColor = true;
        this.btn.Click += new System.EventHandler(this.Btn_Click);
        // 
        // _txt
        // 
        this.txt.Location = new System.Drawing.Point(0, 0);
        this.txt.Margin = new System.Windows.Forms.Padding(0);
        this.txt.Name = "txt";
        this.txt.SaveControlState = false;
        this.txt.Size = new System.Drawing.Size(563, 23);
        this.txt.TabIndex = 0;
        this.txt.TextChanged += new System.EventHandler(this.Txt_TextChanged);
        this.txt.DoubleClick += new System.EventHandler(this.Txt_DoubleClick);
        this.txt.Leave += new System.EventHandler(this.Txt_Leave);
        this.txt.Validated += new System.EventHandler(this.Txt_Validated);
        // 
        // TxtButtonControl
        // 
        this.Controls.Add(this.txt);
        this.Controls.Add(this.btn);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "TxtButtonControl";
        this.Size = new System.Drawing.Size(597, 27);
        this.ResumeLayout(false);
        this.PerformLayout();

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
    {
    }

    protected virtual void OnTextChanged()
    {
    }

    protected virtual void OnTextValidated()
    {
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