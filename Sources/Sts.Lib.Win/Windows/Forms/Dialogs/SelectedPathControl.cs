using System;

namespace Sts.Lib.Win.Windows.Forms.Dialogs;

internal partial class SelectedPathControl : UserControl
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
