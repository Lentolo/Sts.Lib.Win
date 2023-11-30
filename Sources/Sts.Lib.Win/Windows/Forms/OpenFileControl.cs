using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic.Dictionaries;

namespace Sts.Lib.Win.Windows.Forms;

public class OpenFileControl : BrowseControl, ControlStatePersister.ISaveStateControl
{
    public OpenFileControl()
    {
        Dialog = new OpenFileDialog();
    }

    public OpenFileDialog Dialog
    {
        get;
    }

    public bool SaveControlState
    {
        get;
        set;
    }

    public void SetControlStateData(Dictionary<string, object> data)
    {
        SelectedPath = data["SelectedPath"] as string ?? "";
    }

    public void RetrieveControlStateData(Dictionary<string, object> data)
    {
        data["SelectedPath"] = SelectedPath;
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
            return (true,
                    Dialog.FileNames.Any()
                        ? Dialog.FileNames.Aggregate("", (s, i) => s + i + Path.PathSeparator)
                        : Dialog.FileName);
        }

        return (false, "");
    }
}
