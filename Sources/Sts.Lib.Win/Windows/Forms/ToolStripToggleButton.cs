using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class ToolStripToggleButton : ToolStripButton
{
    private CheckState _checkState = CheckState.Indeterminate;

    public ToolStripToggleButton()
    {
        UseThreeState = true;
        CheckState = CheckState.Checked;
    }

    public Image ImageChecked
    {
        get;
        set;
    }

    public Image ImageUnChecked
    {
        get;
        set;
    }

    public Image ImageIndeterminate
    {
        get;
        set;
    }

    public bool UseThreeState
    {
        get;
        set;
    }

    public new bool Checked
    {
        get
        {
            return CheckState == CheckState.Checked;
        }
        set
        {
            CheckState = value ? CheckState.Checked : CheckState.Unchecked;
        }
    }

    public new bool CheckOnClick
    {
        get
        {
            return false;
        }
    }

    public new CheckState CheckState
    {
        get
        {
            return _checkState;
        }
        set
        {
            _checkState = value;

            switch (_checkState)
            {
                case CheckState.Checked:
                    Image = ImageChecked;
                    break;
                case CheckState.Unchecked:
                    Image = ImageUnChecked;
                    break;
                case CheckState.Indeterminate:
                    Image = ImageIndeterminate;
                    break;
            }
        }
    }

    protected override void OnClick(EventArgs e)
    {
        switch (CheckState)
        {
            case CheckState.Checked:
                CheckState = CheckState.Unchecked;
                break;
            case CheckState.Unchecked when UseThreeState:
                CheckState = CheckState.Indeterminate;
                break;
            case CheckState.Unchecked when !UseThreeState:
            case CheckState.Indeterminate:
                CheckState = CheckState.Checked;
                break;
        }

        base.OnClick(e);
    }
}
