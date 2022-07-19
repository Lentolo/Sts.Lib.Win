using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.DataGridViewComponents;

public class DataGridViewNumericColumn : DataGridViewColumn
{
    public DataGridViewNumericColumn() : base(new DataGridViewNumericTextBoxCell())
    { }

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
}