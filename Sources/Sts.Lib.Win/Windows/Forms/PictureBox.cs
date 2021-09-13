namespace Sts.Lib.Win.Windows.Forms
{
    public class PictureBox: System.Windows.Forms.PictureBox
    {
        public PictureBox()
        {
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}