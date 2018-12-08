using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class OpenFileControl : BrowseControl
  {
    public OpenFileDialog Dialog
    {
      get;
      private set;
    }
    protected OpenFileControl()
    {
      Dialog = new OpenFileDialog();
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
}