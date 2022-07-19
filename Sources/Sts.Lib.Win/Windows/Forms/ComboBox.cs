using System;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class ComboBox : System.Windows.Forms.ComboBox
{
    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        if (!string.IsNullOrEmpty(Text))
        {
            SelectAll();
        }
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (!e.Alt && e.Control && !e.Shift && e.KeyCode == Keys.A)
        {
            SelectAll();
        }
    }
}