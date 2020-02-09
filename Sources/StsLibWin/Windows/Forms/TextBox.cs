using System;
using System.Windows.Forms;
using StsLib.Collections.Generic;

namespace StsLibWin.Windows.Forms
{
    public class TextBox : System.Windows.Forms.TextBox, ControlStatePersister.ISaveStateControl
    {
        public bool CanSaveControlState { get; set; }

        public void LoadControlStateData(Dictionary<string, object> data)
        {
            Text = data["Text"] as string ?? "";
        }

        public void SaveControlStateData(Dictionary<string, object> data)
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