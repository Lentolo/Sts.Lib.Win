using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public static class Utils
  {
    static object GetControlValue(Control control)
    {
      if ((control as ISaveStateControl) != null && (control as ISaveStateControl).CanSaveValue())
      {
        return (control as ISaveStateControl).GetControlValue();
      }
      if ((control as TextBox) != null)
      {
        return (control as TextBox).Text;
      }
      if ((control as CheckBox) != null)
      {
        return (control as CheckBox).Checked;
      }
      return null;
    }
    public static KeyValuePair<string, object>[] GetChildControlsData(Control control)
    {
      return StsLib.Linq.Utils.FlattenHierarchy(Tuple.Create(control, control.Name), c => c.Item1.Controls.OfType<Control>().Select(cc => Tuple.Create(cc, c.Item2 + "-" + cc.Name)), c => c != null, null, true, true, true).Select(i => new KeyValuePair<string, object>(i.Object.Item2, GetControlValue(i.Object.Item1))).ToArray();
    }

  }
}
