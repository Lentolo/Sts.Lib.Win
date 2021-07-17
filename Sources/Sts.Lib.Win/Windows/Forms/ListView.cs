using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Drawing.Extensions;

namespace Sts.Lib.Win.Windows.Forms
{
    public class ListView : System.Windows.Forms.ListView
    {
        public ListView()
        {
            base.OwnerDraw = true;
        }

        public new bool OwnerDraw
        {
            get;
            set;
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            e.DrawDefault = true;
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);
            e.DrawDefault = true;
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);

            switch (View)
            {
                case View.LargeIcon:
                    DrawItemLargeIcon(e.Item, e.Graphics, e.Bounds, e.State, LargeImageList, Font, ForeColor);
                    break;
                case View.Details:
                    e.DrawDefault = true;
                    break;
                case View.SmallIcon:
                    e.DrawDefault = true;
                    break;
                case View.List:
                    e.DrawDefault = true;
                    break;
                case View.Tile:
                    e.DrawDefault = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void DrawItemLargeIcon(ListViewItem item, Graphics graphics, Rectangle bounds, ListViewItemStates state, ImageList imageList, Font font, Color foreColor)
        {
            if (imageList == null)
            {
                return;
            }

            Debug.WriteLine(state);
            var imageBounds = new RectangleF(0, 0, bounds.Width, imageList.ImageSize.Height);
            var textBounds = new RectangleF(0, 0, bounds.Width, bounds.Height - imageList.ImageSize.Height);
            var focused = (state & ListViewItemStates.Focused) == ListViewItemStates.Focused;
            var ico = imageList.Images[item.ImageKey];

            if (ico != null)
            {
                graphics.DrawImage(ico, new RectangleF
                {
                    X = 0,
                    Y = 0,
                    Width = ico.Width,
                    Height = ico.Height
                }.Align(imageBounds, ContentAlignment.MiddleCenter).Translate(bounds.Location));
            }

            var textColor = focused ? SystemColors.HighlightText : foreColor;
            var measureString = graphics.MeasureString(item.Text, font).ToRectangle();
            if (focused)
            {
                using var brush = new SolidBrush(SystemColors.Highlight);
                graphics.FillRectangle(brush, textBounds.Translate(new PointF(0, imageList.ImageSize.Height)).Translate(bounds.Location));
            }

            using (var brush = new SolidBrush(textColor))
            {
                graphics.DrawString(item.Text, font, brush, measureString.Align(textBounds, ContentAlignment.MiddleCenter).Translate(new PointF(0, imageList.ImageSize.Height)).Translate(bounds.Location));
            }
        }
    }
}
