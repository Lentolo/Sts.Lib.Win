using System;
using System.ComponentModel;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic;

namespace Sts.Lib.Win.Windows.Forms
{
    public class ToolStripTextBox : System.Windows.Forms.ToolStripTextBox
    { }
    public class ToolStripComboBox : System.Windows.Forms.ToolStripComboBox
    { }
    public class ToolStripDropDown : System.Windows.Forms.ToolStripDropDown
    { }
    
    public class ToolTip : System.Windows.Forms.ToolTip
    {
        public ToolTip()
        { }
        public ToolTip(IContainer container):base(container)
        { }
    }
    public class TextBox : System.Windows.Forms.TextBox, ControlStatePersister.ISaveStateControl
    {
        public bool SaveControlState { get; set; }

        public void SetControlStateData(Dictionary<string, object> data)
        {
            Text = data["Text"] as string ?? "";
        }

        public void RetrieveControlStateData(Dictionary<string, object> data)
        {
            data["Text"] = Text;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!string.IsNullOrEmpty(Text))
            {
                SelectAll();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Alt && e.Control && !e.Shift && e.KeyCode == Keys.A)
            {
                SelectAll();
            }
        }
    }
}