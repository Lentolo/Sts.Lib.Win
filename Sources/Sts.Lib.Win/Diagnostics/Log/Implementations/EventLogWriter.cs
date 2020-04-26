using System;
using System.Diagnostics;
using Sts.Lib.Common.Extensions;
using Sts.Lib.Diagnostics.Log;

namespace Sts.Lib.Win.Diagnostics.Log.Implementations
{
  [Serializable]
  public class EventLogWriter : ILogWriter
  {
    private readonly string _source;
    public EventLogWriter(string source)
    {
      _source = source;
      if (!EventLog.SourceExists(_source))
      {
        EventLog.CreateEventSource(_source, _source);
      }
    }
    public void WriteLog(LogTypes logType, string category, string text, object context)
    {
      var entryType = EventLogEntryType.Information;
      if (logType == LogTypes.Error || logType == LogTypes.Exception)
      {
        entryType = EventLogEntryType.Error;
      }
      else if (logType == LogTypes.Warning)
      {
        entryType = EventLogEntryType.Warning;
      }

      foreach (var line in (category + "\r\n\r\n" + text + "\r\n\r\n" + context).BlockSplit(" '", 16000, "\r\n\r\n-- Continue --"))
      {
        EventLog.WriteEntry(_source, line, entryType);
      }
    }
  }
}