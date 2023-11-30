using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Linq.Extensions;

namespace Sts.Lib.Win.Windows.Forms;

public partial class Gantt : UserControl
{
    public enum TimeCluesters
    {
        Days,
        Hours,
        HalfHours,
        Minutes
    }

    private SizeF _blockSize = SizeF.Empty;

    private SizeF _ganttDimensions = SizeF.Empty;

    public Gantt()
    {
        InitializeComponent();
    }

    public TimeCluesters TimeCluester
    {
        get;
        set;
    }

    public virtual List<GanttItem> Data
    {
        get;
        set;
    }

    private SizeF BlockSize
    {
        get
        {
            if (_blockSize == SizeF.Empty)
            {
                using var g = CreateGraphics();
                _blockSize = g.MeasureString("00:00", Font);
            }

            return _blockSize;
        }
    }

    private SizeF GanttDimensions
    {
        get
        {
            if (Data.ToEnumerableOrEmpty().Any() && _ganttDimensions == SizeF.Empty)
            {
                var min = Data.Select(i => i.DateFrom).Min();
                var max = Data.Select(i => i.DateFrom).Max();
                _ganttDimensions = new SizeF(BlockSize.Width * (float)(max - min).TotalHours,
                                             BlockSize.Height * Data.Count);
            }

            return _ganttDimensions;
        }
    }

    private void PnlDrawBottomLeft_Paint(object sender, PaintEventArgs e)
    {
        if (!Data.ToEnumerableOrEmpty().Any())
        {
            return;
        }

        var data = Data.ToEnumerableOrEmpty().Where(i => i.DateFrom < i.DateTo).ToList();

        foreach (var activities in data.GroupBy(ii => ii.Activity).ToItemsList())
        {
            e.Graphics.DrawString(activities.Value.Key, Font, Brushes.Black, 0, activities.Index * BlockSize.Height);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        pnlTopLeft.Height = (int)System.Math.Ceiling(BlockSize.Height);
        pnlTopRight.Height = (int)System.Math.Ceiling(BlockSize.Height);
        pnlDrawBottomLeft.Top = 0;
        pnlDrawBottomLeft.Left = 0;
        pnlDrawBottomRight.Top = 0;
        pnlDrawBottomRight.Left = 0;
        pnlDrawTopLeft.Top = 0;
        pnlDrawTopLeft.Left = 0;
        pnlDrawTopLeft.Height = (int)System.Math.Ceiling(BlockSize.Height);
        pnlDrawTopRight.Top = 0;
        pnlDrawTopRight.Left = 0;
        pnlDrawTopRight.Height = (int)System.Math.Ceiling(BlockSize.Height);
    }

    private void PnlDrawBottomRight_Paint(object sender, PaintEventArgs e)
    {
        if (!Data.ToEnumerableOrEmpty().Any())
        {
            return;
        }

        var data = Data.ToEnumerableOrEmpty().Where(i => i.DateFrom < i.DateTo).ToList();
        var minDate = data.Select(i => i.DateFrom).DefaultIfEmpty(DateTime.MinValue).Min();

        foreach (var activities in data.GroupBy(ii => ii.Activity).ToItemsList())
        foreach (var item in activities.Value)
        {
            e.Graphics.DrawRectangle(Pens.Black, (float)(item.DateFrom - minDate).TotalHours * BlockSize.Width,
                                     activities.Index * BlockSize.Height, (float)(item.DateTo - item.DateFrom).TotalHours * BlockSize.Width,
                                     BlockSize.Height);
        }
    }

    public class GanttItem
    {
        public virtual string Activity
        {
            get;
            set;
        }

        public virtual DateTime DateFrom
        {
            get;
            set;
        }

        public virtual DateTime DateTo
        {
            get;
            set;
        }
    }
}
