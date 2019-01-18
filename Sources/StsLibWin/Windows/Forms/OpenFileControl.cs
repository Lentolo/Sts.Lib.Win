using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class OpenFileControl : BrowseControl
  {
    protected OpenFileControl()
    {
      Dialog = new OpenFileDialog();
    }
    public OpenFileDialog Dialog
    {
      get;
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