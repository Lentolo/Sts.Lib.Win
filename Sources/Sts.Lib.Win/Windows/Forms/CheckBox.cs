using Sts.Lib.Collections.Generic.Dictionaries;

namespace Sts.Lib.Win.Windows.Forms;

public class CheckBox : System.Windows.Forms.CheckBox, ControlStatePersister.ISaveStateControl
{
    public bool SaveControlState { get; set; }

    public void SetControlStateData(Dictionary<string, object> data)
    {
        Checked = data["Checked"] as bool? ?? false;
    }

    public void RetrieveControlStateData(Dictionary<string, object> data)
    {
        data["Checked"] = Checked;
    }
}