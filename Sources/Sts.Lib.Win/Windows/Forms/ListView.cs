using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Sts.Lib.Common.Extensions;
using Sts.Lib.Drawing;
using Sts.Lib.Drawing.Extensions;

namespace Sts.Lib.Win.Windows.Forms;

public class ListView : System.Windows.Forms.ListView
{ }

//public class ListView : System.Windows.Forms.ListView
//{
//    public ListView()
//    {
//        base.OwnerDraw = true;
//    }

//    public new bool OwnerDraw
//    {
//        get;
//        set;
//    }

//    protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
//    {
//        base.OnDrawColumnHeader(e);
//        e.DrawDefault = true;
//    }

//    protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
//    {
//        base.OnDrawSubItem(e);
//        e.DrawDefault = true;
//    }

//    protected override void OnDrawItem(DrawListViewItemEventArgs e)
//    {
//        base.OnDrawItem(e);

//        switch (View)
//        {
//            case View.LargeIcon:
//                //DrawItemLargeIcon(LargeImageList.Images[e.Item.ImageKey], e.Graphics, e.Bounds, e.Item.Text, Font, ForeColor, CheckBoxes, (e.State & ListViewItemStates.Focused) == ListViewItemStates.Focused, e.Item.Selected, e.Item.Checked);
//                e.DrawDefault = true;
//                break;
//            case View.Details:
//                e.DrawDefault = true;
//                break;
//            case View.SmallIcon:
//                e.DrawDefault = true;
//                break;
//            case View.List:
//                e.DrawDefault = true;
//                break;
//            case View.Tile:
//                e.DrawDefault = true;
//                break;
//            default:
//                throw new ArgumentOutOfRangeException();
//        }
//    }

//    private static void DrawItemLargeIcon(Image image, Graphics graphics, Rectangle bounds, string itemText, Font font, Color foreColor, bool useCheckBoxes, bool itemFocused, bool itemSelected, bool itemChecked)
//    {
//        var drawingBounds = ((RectangleD)bounds).Expand(-1);
//        var centerX = 0;
//        var centerY = (int)(2 * drawingBounds.Height / 3);
//        var glyphSize = Size.Empty;
//        //if (image != null)
//        //{
//        //    centerY = image.Height;
//        //}
//        if (useCheckBoxes)
//        {
//            glyphSize = CheckBoxRenderer.GetGlyphSize(graphics, itemChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
//            centerX = (int)(2 * glyphSize.Width);
//        }
//        var checkboxBounds = new RectangleD(0, centerY, centerX, drawingBounds.Height - centerY);
//        var textBounds = new RectangleD(centerX, centerY, drawingBounds.Width-centerX, drawingBounds.Height - centerY);
//        var imageBounds = new RectangleD(0, 0, drawingBounds.Width , centerY);

//        if (image != null)
//        {
//            graphics.DrawImage(image, new RectangleD
//            {
//                X = 0,
//                Y = 0,
//                Width = image.Width,
//                Height = image.Height
//            }.Align(imageBounds, System.Drawing.ContentAlignment.MiddleCenter).Offset(drawingBounds.Location).ToRectangle());
//        }

//        if (useCheckBoxes)
//        {
//            CheckBoxRenderer.DrawCheckBox(graphics, RectangleD.FromSize(glyphSize).Align(checkboxBounds, System.Drawing.ContentAlignment.MiddleCenter).Offset(drawingBounds.Location).Location.ToPoint(), itemChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
//        }

//        if (itemSelected)
//        {
//            graphics.FillRectangle(SystemBrushes.Highlight, textBounds.Offset(drawingBounds.Location).ToRectangleF());
//        }
//        if (itemFocused)
//        {
//            graphics.DrawRectangle(SystemPens.ActiveBorder, textBounds.Offset(drawingBounds.Location).ToRectangle());
//        }

//        using var stringFormat = new StringFormat()
//        {
//            Trimming = StringTrimming.EllipsisCharacter,
//            Alignment = StringAlignment.Center,
//            LineAlignment = StringAlignment.Center
//        };
//        graphics.DrawString(itemText, font, itemSelected ? SystemBrushes.HighlightText : SystemBrushes.ControlText, textBounds.Offset(drawingBounds.Location).ToRectangleF(), stringFormat);

//        //var strings = new[] { itemText };
//        //var pixelsGapBetweenLines = 1;
//        //var measureString = RectangleD.FromSize(graphics.MeasureStrings(font, pixelsGapBetweenLines, strings)); ;
//        //var lines = 2;
//        //while (true)
//        //{
//        //    if (textBounds.Contains(measureString) || lines > 3)
//        //    {
//        //        break;
//        //    }

//        //    strings = itemText.BlockSplit(lines++).Where(s => !string.IsNullOrEmpty(s)).ToArray();
//        //    measureString = RectangleD.FromSize(graphics.MeasureStrings(font, pixelsGapBetweenLines, strings)); ;
//        //}

//        //if (strings.Length == 1)
//        //{
//        //    using var stringFormat = new StringFormat()
//        //    {
//        //        Trimming = StringTrimming.EllipsisCharacter,
//        //        Alignment = StringAlignment.Center,
//        //        LineAlignment = StringAlignment.Center
//        //    };
//        //    graphics.DrawString(strings.First(), font, itemSelected ? SystemBrushes.HighlightText : SystemBrushes.ControlText, textBounds.Offset(drawingBounds.Location).ToRectangleF(), stringFormat);
//        //}
//        //else
//        //{
//        //    graphics.DrawStrings(font, itemSelected ? SystemBrushes.HighlightText : SystemBrushes.ControlText, measureString.Align(textBounds, System.Drawing.ContentAlignment.MiddleCenter).Offset(drawingBounds.Location).Location.ToPointF(), pixelsGapBetweenLines, strings);
//        //}

//    }
//}