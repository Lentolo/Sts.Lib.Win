using System;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.DataGridViewComponents;

public class DataGridViewNumericTextBoxCell : DataGridViewTextBoxCell
{
    public override Type EditType
    {
        get
        {
            return typeof(DataGridViewNumericTextBoxEditingControl);
        }
    }
}
