using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Sts.Lib.Diagnostics.Extensions;
using Sts.Lib.Diagnostics.Log;

namespace Sts.Lib.Win.Diagnostics
{
  public static class Utils
  {
    public static void MakeEventViewerLog(string source, LogTypes type, string text)
    {
      try
      {
        if (!string.IsNullOrEmpty(text))
        {
          if (string.IsNullOrEmpty(source))
          {
            source = "Application";
          }

          if (!EventLog.SourceExists(source))
          {
            try
            {
              EventLog.CreateEventSource(source, source);
              var evtLog = new EventLog(source);
              evtLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 7);
              evtLog.MaximumKilobytes = 2048;
            }
            catch
            {
              source = "Application";
            }
          }

          if (type == LogTypes.Error)
          {
            EventLog.WriteEntry(source, text, EventLogEntryType.Error);
          }
          else if (type == LogTypes.Info)
          {
            EventLog.WriteEntry(source, text, EventLogEntryType.Information);
          }
          else if (type == LogTypes.Warning)
          {
            EventLog.WriteEntry(source, text, EventLogEntryType.Warning);
          }
        }
      }
      catch
      {
      }
    }
    public static void LogErrorToEventLog(Exception exc)
    {
      try
      {
        EventLog.WriteEntry("Application", Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + "\r\n\r\n" + exc.ExtractError(), EventLogEntryType.Error);
      }
      catch
      {
      }
    }
  }
}