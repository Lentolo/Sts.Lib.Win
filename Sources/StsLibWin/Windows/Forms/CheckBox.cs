using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StsLib.Linq.Extensions;

namespace StsLibWin.Windows.Forms
{
  public class Gantt : System.Windows.Forms.Panel
  {
    readonly System.Windows.Forms.Panel _innerPanel = new System.Windows.Forms.Panel();

    public virtual List<GanttItem> Data
    {
      get; set;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      var d = StsLib.Linq.Utils.ToEnumerableOrEmpty(Data).Where(i => i.DateFrom < i.DateTo).ToList();
      var mind = d.Select(i => i.DateFrom).DefaultIfEmpty(DateTime.MinValue).Min();
      var pixel = e.Graphics.MeasureString("00:00", Font);
      foreach (var iiii in d.GroupBy(ii => ii.Activity).ToItemsList())
      {
        foreach (var i in iiii.Data)
        {
          e.Graphics.DrawRectangle(System.Drawing.Pens.Black, (float)(i.DateFrom - mind).TotalHours * pixel.Width, iiii.Index * pixel.Height, (float)(i.DateTo - i.DateFrom).TotalHours * pixel.Width, pixel.Height);
        }
      }
    }
    void Create()
    {
      SuspendLayout();
      var dd = StsLib.Linq.Utils.ToEnumerableOrEmpty(Data).Where(i => i.DateFrom < i.DateTo).ToList();
      //var ff = StsLib.Linq.Utils.ToEnumerableOrEmpty(Data).GroupBy(i => i.Activity + i.DateFrom + i.DateTo).Any(g => g.Count() > 1);



      Controls.Add(_innerPanel);
      ResumeLayout();
    }
    public class GanttItem
    {
      public virtual string Activity
      {
        get; set;
      }
      public virtual DateTime DateFrom
      {
        get; set;
      }
      public virtual DateTime DateTo
      {
        get; set;
      }
    }
  }
  public class CheckBox : System.Windows.Forms.CheckBox, ControlStatePersister.ISaveStateControl
  {
    public bool CanSaveControlState { get; set; }

    public void LoadControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data)
    {
      Checked = data["Checked"] as bool? ?? false;
    }

    public void SaveControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data)
    {
      data["Checked"] = Checked;
    }
  }
}