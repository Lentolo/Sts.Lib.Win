using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public static class Utils
  {
    private static object GetControlValue(Control control)
    {
      switch (control)
      {
        case ISaveStateControl stateControl when stateControl.CanSaveState():
          return stateControl.GetControlState();
        case TextBox textBox:
          return textBox.Text;
        case CheckBox checkBox:
          return checkBox.Checked;
      }

      return null;
    }
    public static KeyValuePair<string, object>[] GetChildControlsData(Control control)
    {
      return StsLib.Linq.Utils.FlattenHierarchy(Tuple.Create(control, control.Name), c => c.Item1.Controls.OfType<Control>().Select(cc => Tuple.Create(cc, c.Item2 + "-" + cc.Name)), (p, c, l) => c != null).Select(i => new KeyValuePair<string, object>(i.Item.Item2, GetControlValue(i.Item.Item1))).ToArray();
    }
  }
}