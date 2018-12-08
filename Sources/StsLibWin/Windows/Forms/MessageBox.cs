
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public static class MessageBox
  {
    public static DialogResult Show(Control owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      return Show(owner, text, buttons, icon, MessageBoxDefaultButton.Button1);
    }
    public static DialogResult Show(Control owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
    {
      using (new TempCursor(Cursors.Default))
      {
        if (owner != null)
        {
          while (owner.Parent != null)
          {
            owner = owner.Parent;
            if (owner is Form)
            {
              break;
            }
          }
        }

        return System.Windows.Forms.MessageBox.Show(owner, text, owner.Text, buttons, icon, defaultButton);
      }
    }
    public static DialogResult QuestionYesNo(Control owner, string text, MessageBoxDefaultButton defaultButton)
    {
      return Show(owner, text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton);
    }
    public static DialogResult QuestionYesNo(Control owner, string text)
    {
      return Show(owner, text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
    }
    public static DialogResult Information(Control owner, string text)
    {
      return Show(owner, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static DialogResult Warning(Control owner, string text)
    {
      return Show(owner, text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static DialogResult Error(Control owner, string text)
    {
      return Show(owner, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}