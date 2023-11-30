using System.Drawing;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms;

public class SplitContainer : System.Windows.Forms.SplitContainer
{
    public SplitContainer()
    {
        Panel1.Cursor = Cursors.Default;
        Panel2.Cursor = Cursors.Default;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var points = new Point[5];
        var w = Width;
        var h = Height;
        var d = SplitterDistance;
        var sW = SplitterWidth;
        var distance = 5;

        if (Orientation == Orientation.Horizontal)
        {
            points[0] = new Point(w / 2, d + sW / 2);
            points[1] = new Point(points[0].X - distance, points[0].Y);
            points[2] = new Point(points[0].X + distance, points[0].Y);
            points[3] = new Point(points[0].X - 2 * distance, points[0].Y);
            points[4] = new Point(points[0].X + 2 * distance, points[0].Y);
        }
        else
        {
            points[0] = new Point(d + sW / 2, h / 2);
            points[1] = new Point(points[0].X, points[0].Y - distance);
            points[2] = new Point(points[0].X, points[0].Y + distance);
            points[3] = new Point(points[0].X, points[0].Y - 2 * distance);
            points[4] = new Point(points[0].X, points[0].Y + 2 * distance);
        }

        foreach (var p in points)
        {
            p.Offset(-2, -2);
            e.Graphics.FillEllipse(SystemBrushes.ControlDark, new Rectangle(p, new Size(3, 3)));
            p.Offset(1, 1);
            e.Graphics.FillEllipse(SystemBrushes.ControlLight, new Rectangle(p, new Size(3, 3)));
        }
    }
}
