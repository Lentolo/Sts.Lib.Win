using System;
using System.Linq;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
    public class ToolStripSpringItem : Sts.Lib.Win.Windows.Forms.ToolStripLabel
    {
        public ToolStripSpringItem()
        {
        }
        protected override void OnParentChanged(System.Windows.Forms.ToolStrip oldParent, System.Windows.Forms.ToolStrip newParent)
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
            var toolbarWith = Parent.Width - (Parent.GripStyle == ToolStripGripStyle.Visible ? Parent.GripRectangle.Width + Parent.GripMargin.Left + Parent.GripMargin.Right : 0) - this.Margin.Left - this.Margin.Right;
            var toolStripItems = Parent.Items.OfType<ToolStripItem>().Where(i => i != this).ToList();

            System.Diagnostics.Debug.WriteLine($"SetupWidth ---------");
            foreach (var i in toolStripItems)
            {
                System.Diagnostics.Debug.WriteLine($"SetupWidth: {i.Name} - {i.Width} - {i.Padding.Left} - {i.Padding.Right} - {i.Margin.Left} - {i.Margin.Right}");
            }

            var itemsWith = toolStripItems.Sum(i => i.Width + i.Margin.Right + i.Margin.Left);

            System.Diagnostics.Debug.WriteLine($"SetupWidth: {this.Width } - {toolbarWith - itemsWith - 5} - {toolbarWith } - {itemsWith }");

            this.Width = System.Math.Max(0, toolbarWith - itemsWith - 5);
        }

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
    }
}
