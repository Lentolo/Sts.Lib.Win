using System.Linq;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class MdiChildForm : Form
  {
    public MdiChildForm()
    {
      KeyPreview = true;
    }
    public void SetMdiParentForm(Form MdiParentForm)
    {
      MdiParent = MdiParentForm;
      Text = Text + " - [" + (MdiParent.Controls.OfType<MdiChildForm>().Where(I => GetType() == I.GetType()).Count() + 1) + "]";
      Show();
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if (!e.Alt
          && e.Control
          && !e.Shift
          && e.KeyCode == Keys.W
      )
      {
        Close();
      }
    }
  }
}