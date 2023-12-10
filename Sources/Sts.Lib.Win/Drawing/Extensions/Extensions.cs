using System.Drawing;
using System.Linq;
using Sts.Lib.Linq.Extensions;

namespace Sts.Lib.Win.Drawing.Extensions;

public static class Extensions
{
    public static Font FitFont(this Font font, Graphics graphics, Size clientSize, string text, float deltaFontSize = 0.1f)
    {
        var fontSize = 0.0f;

        while (true)
        {
            fontSize += deltaFontSize;
            using var f = font.CloneFontWithNewSize(fontSize);
            var m = graphics.MeasureString(text, f, int.MaxValue, new StringFormat(StringFormatFlags.NoWrap));

            if (m is { Width: 0, Height: 0 })
            {
                return font.CloneFontWithNewSize(font.Size);
            }

            if (m.Width >= clientSize.Width || m.Height >= clientSize.Height)
            {
                return font.CloneFontWithNewSize(fontSize - deltaFontSize);
            }
        }
    }

    public static Font CloneFontWithNewSize(this Font font, float fontSize)
    {
        return new Font(font.FontFamily, fontSize, font.Style, font.Unit, font.GdiCharSet, font.GdiVerticalFont);
    }

    public static SizeF MeasureStrings(this Graphics graphics, Font font, int pixelsGapBetweenLines, params string[] lines)
    {
        return lines.ToEnumerableOrEmpty().Select(l => graphics.MeasureString(l, font)).ToItemsList().Aggregate(SizeF.Empty, (s, i) => new SizeF(System.Math.Max(s.Width, i.Value.Width), s.Height + i.Value.Height + (i.Last ? 0 : pixelsGapBetweenLines)));
    }

    public static void DrawStrings(this Graphics graphics, Font font, Brush brush, PointF point, int pixelsGapBetweenLines, params string[] lines)
    {
        var p = point;

        foreach (var l in lines.ToEnumerableOrEmpty())
        {
            var s = graphics.MeasureString(l, font);
            graphics.DrawString(l, font, brush, p);
            p = new PointF(p.X, p.Y + s.Height + pixelsGapBetweenLines);
        }
    }
}
