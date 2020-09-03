using System.IO;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
    public class FolderBrowserControl : BrowseControl
    {
        public FolderBrowserControl()
        {
            Dialog = new FolderBrowserDialog();
        }
        public bool CreateFolderIfNotExits
        {
            get;
            set;
        }
        public override string Text
        {
            get
            {
                if (CreateFolderIfNotExits && !string.IsNullOrEmpty(base.Text) && !Directory.Exists(base.Text))
                {
                    Sts.Lib.IO.Utils.EnsureDirectory(base.Text);
                }

                return base.Text;
            }
            set => base.Text = value;
        }
        public FolderBrowserDialog Dialog
        {
            get;
        }
        protected override (bool, string) OnShowDialog()
        {
            if (!string.IsNullOrEmpty(Text) && System.IO.Directory.Exists(Text))
            {
                Dialog.SelectedPath = Text;
            }
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                return (true, Dialog.SelectedPath);
            }

            return (false, "");
        }
    }
}