using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class SaveFileControl : BrowseControl
  {
    public SaveFileDialog Dialog
    {
      get;
      private set;
    }
    protected SaveFileControl()
    {
      Dialog = new SaveFileDialog();
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