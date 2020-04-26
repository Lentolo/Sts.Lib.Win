using System;
using System.Windows.Forms;
using Sts.Lib.Collections.Generic;

namespace Sts.Lib.Win.Windows.Forms
{
  //Declare a class that inherits from ToolStripControlHost.
  public class ToolStripDateTimePicker : ToolStripControlHost, ControlStatePersister.ISaveStateControl
  {
    // Call the base constructor passing in a MonthCalendar instance.
    public ToolStripDateTimePicker()
        : base(new DateTimePicker())
    {
    }

    public DateTimePicker DateTimePickerControl
    {
      get
      {
        return Control as DateTimePicker;
      }
    }

    // Subscribe and unsubscribe the control events you wish to expose.
    protected override void OnSubscribeControlEvents(Control c)
    {
      // Call the base so the base events are connected.
      base.OnSubscribeControlEvents(c);

      // Cast the control to a MonthCalendar control.
      var dateTimePicker = (DateTimePicker) c;

      // Add the event.
      dateTimePicker.TextChanged += dateTimePicker_TextChanged;
    }

    private void dateTimePicker_TextChanged(object sender, EventArgs e)
    {
      DateChanged?.Invoke(this, e);
    }

    protected override void OnUnsubscribeControlEvents(Control c)
    {
      // Call the base method so the basic events are unsubscribed.
      base.OnUnsubscribeControlEvents(c);

      // Cast the control to a MonthCalendar control.
      var dateTimePicker = (DateTimePicker) c;
      dateTimePicker.TextChanged -= dateTimePicker_TextChanged;
    }

    // Declare the DateChanged event.
    public event EventHandler DateChanged;
    public bool CanSaveControlState
    {
      get;
      set;
    }
    public void LoadControlStateData(Dictionary<string, object> data)
    {
      if (data["SelectedDate"] is DateTime d)
      {
        DateTimePickerControl.Value = d;
      }
    }
    public void SaveControlStateData(Dictionary<string, object> data)
    {
      data["SelectedDate"] = DateTimePickerControl.Value;
    }
  }
}