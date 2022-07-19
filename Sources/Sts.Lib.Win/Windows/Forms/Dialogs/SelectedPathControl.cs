using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.Dialogs;

internal partial class SelectedPathControl : Sts.Lib.Win.Windows.Forms.UserControl
{
    public SelectedPathControl()
    {
        InitializeComponent();
    }

    public string Path
    {
        get
        {
            return txtPath.Text;
        }
        set
        {
            txtPath.Text = value;
        }
    }

    public event EventHandler ClickDelete;
    private void btnDelete_Click(object sender, EventArgs e)
    {
        ClickDelete?.Invoke(this, e);
    }
}