using System;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

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
