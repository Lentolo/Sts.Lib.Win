using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic;

namespace Sts.Lib.Win.Windows.Forms
{
    public class OpenFileControl : BrowseControl, ControlStatePersister.ISaveStateControl
    {
        public OpenFileControl()
        {
            Dialog = new OpenFileDialog();
        }
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.FileSystem;
        }

        public OpenFileDialog Dialog { get; }

        protected override (bool, string) OnShowDialog()
        {
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                return (true, Dialog.FileNames.Any() ? Dialog.FileNames.Aggregate("", (s, i) => s + i + System.IO.Path.PathSeparator) : Dialog.FileName);
            }

            return (false, "");
        }

        public bool SaveControlState { get; set; }

        public void SetControlStateData(Dictionary<string, object> data)
        {
            SelectedPath = data["SelectedPath"] as string ?? "";
        }

        public void RetrieveControlStateData(Dictionary<string, object> data)
        {
            data["SelectedPath"] = SelectedPath;
        }
    }
}