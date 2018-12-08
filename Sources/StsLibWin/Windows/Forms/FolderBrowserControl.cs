using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class FolderBrowserControl : BrowseControl
  {
    public FolderBrowserDialog Dialog
    {
      get;
      private set;
    }
    protected FolderBrowserControl()
    {
      Dialog = new FolderBrowserDialog();
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