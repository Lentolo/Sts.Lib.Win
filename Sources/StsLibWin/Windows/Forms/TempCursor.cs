using System;
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
  public class Form : System.Windows.Forms.Form
  { }
  public class TempCursor : IDisposable
  {
    private readonly Control _control;
    private Cursor _cursor;
    public TempCursor(Cursor newCursor)
    {
      Init(Cursor.Current, newCursor);
    }
    public TempCursor(Control control, Cursor newCursor)
    {
      _control = control;
      Init(control.Cursor, newCursor);
    }
    public void Dispose()
    {
      if (_control == null)
      {
        Cursor.Current = _cursor;
      }
      else
      {
        _control.Cursor = _cursor;
      }
    }
    private void Init(Cursor currentCursor, Cursor newCursor)
    {
      _cursor = currentCursor;
      Cursor.Current = newCursor;
    }
  }
}