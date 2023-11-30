using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class PictureBox : System.Windows.Forms.PictureBox
{
    public PictureBox()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }
}
