using System.IO;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
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
          StsLib.IO.Utils.EnsureDirectory(base.Text);
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
      if (Dialog.ShowDialog() == DialogResult.OK)
      {
        return (true, Dialog.SelectedPath);
      }

      return (false, "");
    }
  }
}