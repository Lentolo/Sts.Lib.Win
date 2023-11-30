using System;
using System.Linq;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class ToolStripSpringItem : ToolStripLabel
{
    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            base.Text = "";
        }
    }

    protected override void OnParentChanged(System.Windows.Forms.ToolStrip oldParent,
                                            System.Windows.Forms.ToolStrip newParent)
    {
        base.OnParentChanged(oldParent, newParent);

        if (oldParent != null)
        {
            oldParent.Resize -= Parent_Resize;
            oldParent.VisibleChanged -= Parent_VisibleChanged;
        }

        if (newParent != null)
        {
            newParent.Resize += Parent_Resize;
            newParent.VisibleChanged += Parent_VisibleChanged;
        }
    }

    private void Parent_VisibleChanged(object sender, EventArgs e)
    {
        SetupWidth();
    }

    private void Parent_Resize(object sender, EventArgs e)
    {
        SetupWidth();
    }

    protected override void OnLayout(LayoutEventArgs e)
    {
        base.OnLayout(e);
        AutoSize = false;
        AutoToolTip = false;
        ToolTipText = "";
        base.Text = "";
    }

    private void SetupWidth()
    {
        var toolbarWith = Parent.Width
                          - (Parent.GripStyle == ToolStripGripStyle.Visible
                                 ? Parent.GripRectangle.Width + Parent.GripMargin.Left + Parent.GripMargin.Right
                                 : 0)
                          - Margin.Left
                          - Margin.Right;
        var toolStripItems = Parent.Items.OfType<ToolStripItem>().Where(i => i != this).ToList();
        var itemsWith = toolStripItems.Sum(i => i.Width + i.Margin.Right + i.Margin.Left);
        Width = System.Math.Max(0, toolbarWith - itemsWith - 1);
    }
}
