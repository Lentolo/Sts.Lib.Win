using System.ComponentModel;

namespace Sts.Lib.Win.Windows.Forms
{
    public class ToolTip : System.Windows.Forms.ToolTip
    {
        public ToolTip()
        { }
        public ToolTip(IContainer container):base(container)
        { }
    }
}