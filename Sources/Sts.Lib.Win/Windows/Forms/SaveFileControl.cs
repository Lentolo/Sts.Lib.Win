using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class SaveFileControl : BrowseControl
{
    protected SaveFileControl()
    {
        Dialog = new SaveFileDialog();
    }

    public SaveFileDialog Dialog
    {
        get;
    }

    protected override void InitializeComponent()
    {
        base.InitializeComponent();
        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txt.AutoCompleteSource = AutoCompleteSource.FileSystem;
    }

    protected override (bool, string) OnShowDialog()
    {
        if (Dialog.ShowDialog() == DialogResult.OK)
        {
            return (true, Dialog.FileName);
        }

        return (false, "");
    }
}
