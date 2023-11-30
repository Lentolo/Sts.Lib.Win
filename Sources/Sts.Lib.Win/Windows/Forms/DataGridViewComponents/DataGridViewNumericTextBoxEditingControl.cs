using System.ComponentModel;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.DataGridViewComponents;

public class DataGridViewNumericTextBoxEditingControl : DataGridViewTextBoxEditingControl
{
    private bool _initialized;

    public override System.Windows.Forms.DataGridView EditingControlDataGridView
    {
        get
        {
            return base.EditingControlDataGridView;
        }
        set
        {
            base.EditingControlDataGridView = value;

            if (!_initialized && value?.CurrentCell?.OwningColumn is DataGridViewNumericColumn numericColumn)
            {
                AllowDecimals = numericColumn.AllowDecimals;
                AllowNegative = numericColumn.AllowNegative;
                _initialized = true;
            }
        }
    }

    public bool AllowNegative
    {
        get;
        set;
    }

    public bool AllowDecimals
    {
        get;
        set;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Decimal)
        {
            var a1aaa = (char)e.KeyCode;
            var aaaa = SelectionStart;
            Text = Text.Insert(aaaa, ",");
            e.SuppressKeyPress = true;
        }

        base.OnKeyDown(e);
    }

    protected override void OnValidating(CancelEventArgs e)
    {
        base.OnValidating(e);
    }
}
