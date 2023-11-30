using System;
using System.Globalization;
using Sts.Lib.Data.Interfaces;

namespace Sts.Lib.Win.Data.Connections.Oracle
{
    internal class SqlConverter : ISqlConverter
    {
        public string ToSql(object val)
        {
            switch (val)
            {
                case null:
                    return "NULL";
                case string s:
                    return ToSql(s);
                case int i:
                    return ToSql(i);
                case DateTime dateTime:
                    return ToSql(dateTime);
                case double d:
                    return ToSql(d);
                case long l:
                    return ToSql(l);
                case decimal dec:
                    return ToSql(dec);
                case bool b:
                    return ToSql(b);
                default:
                    throw new Exception("Invalid data type");
            }
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
            return $"TO_DATE('{val:yyyy/MM/dd HH:mm:ss}', 'YYYY/MM/DD HH:MI:SS')";
        }
        public string ToSql(long val)
        {
            return val.ToString(CultureInfo.InvariantCulture);
        }
        public string WrapIdentifier(string val)
        {
            return "\"" + val + "\"";
        }
        public string ToSql(decimal val)
        {
            return val.ToString(CultureInfo.InvariantCulture);
        }
    }
}