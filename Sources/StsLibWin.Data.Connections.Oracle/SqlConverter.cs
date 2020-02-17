using System;
using System.Globalization;
using StsLib.Data.Interfaces;

namespace StsLibWin.Data.Connections.Oracle
{
  public class SqlConverter : ISqlConverter
  {
    public string ToSql(object val)
    {
      if (val == null)
      {
        return "NULL";
      }

      if (val is string)
      {
        return ToSql((string)val);
      }

      if (val is int)
      {
        return ToSql((int)val);
      }

      if (val is DateTime)
      {
        return ToSql((DateTime)val);
      }

      if (val is double)
      {
        return ToSql((double)val);
      }

      if (val is long)
      {
        return ToSql((long)val);
      }

      if (val is decimal)
      {
        return ToSql((decimal)val);
      }

      if (val is bool)
      {
        return ToSql((bool)val);
      }

      throw new Exception("Invalid data type");
    }
    public string ToSql(int val)
    {
      return val.ToString(CultureInfo.InvariantCulture);
    }
    public string ToSql(bool val)
    {
      return val ? "(0=0)" : "(0=1)";
    }
    public string ToSql(string val)
    {
      return ToSql(val, true);
    }
    public string ToSql(string val, bool useQuoteMarks)
    {
      if (val == null)
      {
        return "NULL";
      }

      return (useQuoteMarks ? "'" : "") + val.Replace("'", "''") + (useQuoteMarks ? "'" : "");
    }
    public string ToSql(double val)
    {
      return val.ToString(CultureInfo.InvariantCulture);
    }
    public string ToSql(DateTime val)
    {
      return "CONVERT(datetime,'" + val.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "',126)";
    }
    public string ToSql(long val)
    {
      return val.ToString(CultureInfo.InvariantCulture);
    }
    public string WrapIdentifier(string val)
    {
      return "[" + val + "]";
    }
    public string ToSql(decimal val)
    {
      return val.ToString(CultureInfo.InvariantCulture);
    }
  }
}