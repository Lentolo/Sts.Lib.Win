using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class FolderBrowserControl : BrowseControl
  {
    public FolderBrowserControl()
    {
      Dialog = new FolderBrowserDialog();
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