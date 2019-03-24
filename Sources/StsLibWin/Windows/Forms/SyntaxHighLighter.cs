using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using StsLib.Common;
using StsLib.Threading;

namespace StsLibWin.Windows.Forms
{
  public class SyntaxHighLighter : RichTextBox
  {
    public class LanguagePlsql : ILanguageElements
    {
      public string[] GetFunctions()
      {
        var sqlFunctions = new List<string>();
        sqlFunctions.Add("DELETEXML");
        sqlFunctions.Add("DENSE_RANK");
        sqlFunctions.Add("DEPTH");
        sqlFunctions.Add("DEREF");
        sqlFunctions.Add("DUMP");
        sqlFunctions.Add("EMPTY_BLOB, EMPTY_CLOB");
        sqlFunctions.Add("EXISTSNODE");
        sqlFunctions.Add("EXP");
        sqlFunctions.Add("EXTRACT (datetime)");
        sqlFunctions.Add("EXTRACT (XML)");
        sqlFunctions.Add("EXTRACTVALUE");
        sqlFunctions.Add("FEATURE_ID");
        sqlFunctions.Add("FEATURE_SET");
        sqlFunctions.Add("FEATURE_VALUE");
        sqlFunctions.Add("FIRST");
        sqlFunctions.Add("FIRST_VALUE *");
        sqlFunctions.Add("FLOOR");
        sqlFunctions.Add("FROM_TZ");
        sqlFunctions.Add("GREATEST");
        sqlFunctions.Add("GROUP_ID");
        sqlFunctions.Add("GROUPING");
        sqlFunctions.Add("GROUPING_ID");
        sqlFunctions.Add("HEXTORAW");
        sqlFunctions.Add("INITCAP");
        sqlFunctions.Add("INSERTCHILDXML");
        sqlFunctions.Add("INSERTXMLBEFORE");
        sqlFunctions.Add("INSTR");
        sqlFunctions.Add("ITERATION_NUMBER");
        sqlFunctions.Add("LAG");
        sqlFunctions.Add("LAST");
        sqlFunctions.Add("LAST_DAY");
        sqlFunctions.Add("LAST_VALUE");
        sqlFunctions.Add("LEAD");
        sqlFunctions.Add("LEAST");
        sqlFunctions.Add("LENGTH");
        sqlFunctions.Add("LN");
        sqlFunctions.Add("LNNVL");
        sqlFunctions.Add("LOCALTIMESTAMP");
        sqlFunctions.Add("LOG");
        sqlFunctions.Add("LOWER");
        sqlFunctions.Add("LPAD");
        sqlFunctions.Add("LTRIM");
        sqlFunctions.Add("MAKE_REF");
        sqlFunctions.Add("MAX");
        sqlFunctions.Add("MEDIAN");
        sqlFunctions.Add("MIN");
        sqlFunctions.Add("MOD");
        sqlFunctions.Add("MONTHS_BETWEEN");
        sqlFunctions.Add("NANVL");
        sqlFunctions.Add("NEW_TIME");
        sqlFunctions.Add("NEXT_DAY");
        sqlFunctions.Add("NLS_CHARSET_DECL_LEN");
        sqlFunctions.Add("NLS_CHARSET_ID");
        sqlFunctions.Add("NLS_CHARSET_NAME");
        sqlFunctions.Add("NLS_INITCAP");
        sqlFunctions.Add("NLS_LOWER");
        sqlFunctions.Add("NLS_UPPER");
        sqlFunctions.Add("NLSSORT");
        sqlFunctions.Add("NTILE");
        sqlFunctions.Add("NULLIF");
        sqlFunctions.Add("NUMTODSINTERVAL");
        sqlFunctions.Add("NUMTOYMINTERVAL");
        sqlFunctions.Add("NVL");
        sqlFunctions.Add("NVL2");
        sqlFunctions.Add("ORA_HASH");
        sqlFunctions.Add("PATH");
        sqlFunctions.Add("PERCENT_RANK");
        sqlFunctions.Add("PERCENTILE_CONT");
        sqlFunctions.Add("PERCENTILE_DISC");
        sqlFunctions.Add("POWER");
        sqlFunctions.Add("POWERMULTISET");
        sqlFunctions.Add("POWERMULTISET_BY_CARDINALITY");
        sqlFunctions.Add("PREDICTION");
        sqlFunctions.Add("PREDICTION_BOUNDS");
        sqlFunctions.Add("PREDICTION_COST");
        sqlFunctions.Add("PREDICTION_DETAILS");
        sqlFunctions.Add("PREDICTION_PROBABILITY");
        sqlFunctions.Add("PREDICTION_SET");
        sqlFunctions.Add("PRESENTNNV");
        sqlFunctions.Add("PRESENTV");
        sqlFunctions.Add("PREVIOUS");
        sqlFunctions.Add("RANK");
        sqlFunctions.Add("RATIO_TO_REPORT");
        sqlFunctions.Add("RAWTOHEX");
        sqlFunctions.Add("RAWTONHEX");
        sqlFunctions.Add("REF");
        sqlFunctions.Add("REFTOHEX");
        sqlFunctions.Add("REGEXP_INSTR");
        sqlFunctions.Add("REGEXP_REPLACE");
        sqlFunctions.Add("REGEXP_SUBSTR");
        sqlFunctions.Add("REGR");
        sqlFunctions.Add("REMAINDER");
        sqlFunctions.Add("REPLACE");
        sqlFunctions.Add("ROUND (date)");
        sqlFunctions.Add("ROUND (number)");
        sqlFunctions.Add("ROW_NUMBER");
        sqlFunctions.Add("ROWIDTOCHAR");
        sqlFunctions.Add("ROWIDTONCHAR");
        sqlFunctions.Add("RPAD");
        sqlFunctions.Add("RTRIM");
        sqlFunctions.Add("SCN_TO_TIMESTAMP");
        sqlFunctions.Add("SESSIONTIMEZONE");
        sqlFunctions.Add("SET");
        sqlFunctions.Add("SIGN");
        sqlFunctions.Add("SIN");
        sqlFunctions.Add("SINH");
        sqlFunctions.Add("SOUNDEX");
        sqlFunctions.Add("SQRT");
        sqlFunctions.Add("STATS_BINOMIAL_TEST");
        sqlFunctions.Add("STATS_CROSSTAB");
        sqlFunctions.Add("STATS_F_TEST");
        sqlFunctions.Add("STATS_KS_TEST");
        sqlFunctions.Add("STATS_MODE");
        sqlFunctions.Add("STATS_MW_TEST");
        sqlFunctions.Add("STATS_ONE_WAY_ANOVA");
        sqlFunctions.Add("STATS_T_TEST_*");
        sqlFunctions.Add("STATS_WSR_TEST");
        sqlFunctions.Add("STDDEV");
        sqlFunctions.Add("STDDEV *");
        sqlFunctions.Add("STDDEV_POP");
        sqlFunctions.Add("STDDEV_POP *");
        sqlFunctions.Add("STDDEV_SAMP");
        sqlFunctions.Add("STDDEV_SAMP *");
        sqlFunctions.Add("SUBSTR");
        sqlFunctions.Add("SUM");
        sqlFunctions.Add("SUM *");
        sqlFunctions.Add("SYS_CONNECT_BY_PATH");
        sqlFunctions.Add("SYS_CONTEXT");
        sqlFunctions.Add("SYS_DBURIGEN");
        sqlFunctions.Add("SYS_EXTRACT_UTC");
        sqlFunctions.Add("SYS_GUID");
        sqlFunctions.Add("SYS_TYPEID");
        sqlFunctions.Add("SYS_XMLAGG");
        sqlFunctions.Add("SYS_XMLGEN");
        sqlFunctions.Add("SYSDATE");
        sqlFunctions.Add("SYSTIMESTAMP");
        sqlFunctions.Add("TAN");
        sqlFunctions.Add("TANH");
        sqlFunctions.Add("TIMESTAMP_TO_SCN");
        sqlFunctions.Add("TO_BINARY_DOUBLE");
        sqlFunctions.Add("TO_BINARY_FLOAT");
        sqlFunctions.Add("TO_CHAR (character)");
        sqlFunctions.Add("TO_CHAR (datetime)");
        sqlFunctions.Add("TO_CHAR (number)");
        sqlFunctions.Add("TO_CLOB");
        sqlFunctions.Add("TO_DATE");
        sqlFunctions.Add("TO_DSINTERVAL");
        sqlFunctions.Add("TO_LOB");
        sqlFunctions.Add("TO_MULTI_BYTE");
        sqlFunctions.Add("TO_NCHAR (character)");
        sqlFunctions.Add("TO_NCHAR (datetime)");
        sqlFunctions.Add("TO_NCHAR (number)");
        sqlFunctions.Add("TO_NCLOB");
        sqlFunctions.Add("TO_NUMBER");
        sqlFunctions.Add("TO_SINGLE_BYTE");
        sqlFunctions.Add("TO_TIMESTAMP");
        sqlFunctions.Add("TO_TIMESTAMP_TZ");
        sqlFunctions.Add("TO_YMINTERVAL");
        sqlFunctions.Add("TRANSLATE");
        sqlFunctions.Add("TRANSLATE ... USING");
        sqlFunctions.Add("TREAT");
        sqlFunctions.Add("TRIM");
        sqlFunctions.Add("TRUNC (date)");
        sqlFunctions.Add("TRUNC (number)");
        sqlFunctions.Add("TZ_OFFSET");
        sqlFunctions.Add("UID");
        sqlFunctions.Add("UNISTR");
        sqlFunctions.Add("UPDATEXML");
        sqlFunctions.Add("UPPER");
        sqlFunctions.Add("USER");
        sqlFunctions.Add("USERENV");
        sqlFunctions.Add("VALUE ");
        sqlFunctions.Add("VAR_POP");
        sqlFunctions.Add("VAR_POP *");
        sqlFunctions.Add("VAR_SAMP");
        sqlFunctions.Add("VAR_SAMP *");
        sqlFunctions.Add("VARIANCE");
        sqlFunctions.Add("VARIANCE * ");
        sqlFunctions.Add("VSIZE");
        sqlFunctions.Add("WIDTH_BUCKET");
        sqlFunctions.Add("XMLAGG");
        sqlFunctions.Add("XMLCAST");
        sqlFunctions.Add("XMLCDATA");
        sqlFunctions.Add("XMLCOLATTVAL");
        sqlFunctions.Add("XMLCOMMENT");
        sqlFunctions.Add("XMLCONCAT");
        sqlFunctions.Add("XMLDIFF");
        sqlFunctions.Add("XMLELEMENT");
        sqlFunctions.Add("XMLEXISTS");
        sqlFunctions.Add("XMLFOREST");
        sqlFunctions.Add("XMLPARSE");
        sqlFunctions.Add("XMLPATCH");
        sqlFunctions.Add("XMLPI");
        sqlFunctions.Add("XMLQUERY");
        sqlFunctions.Add("XMLROOT");
        sqlFunctions.Add("XMLSEQUENCE");
        sqlFunctions.Add("XMLSERIALIZE");
        sqlFunctions.Add("XMLTABLE");
        sqlFunctions.Add("XMLTRANSFORM");
        return sqlFunctions.ToArray();
      }
      public string[] GetKeyWords()
      {
        var sqlKeyWords = new List<string>();
        sqlKeyWords.Add("AS");
        sqlKeyWords.Add("BY");
        sqlKeyWords.Add("CASE");
        sqlKeyWords.Add("DISTINCT");
        sqlKeyWords.Add("END");
        sqlKeyWords.Add("FROM");
        sqlKeyWords.Add("SELECT");
        sqlKeyWords.Add("ORDER");
        sqlKeyWords.Add("ORLANY");
        sqlKeyWords.Add("ORLVARY");
        sqlKeyWords.Add("OTHERS");
        sqlKeyWords.Add("OUT");
        sqlKeyWords.Add("OVERRIDING");
        sqlKeyWords.Add("PACKAGE");
        sqlKeyWords.Add("PARALLEL_ENABLE");
        sqlKeyWords.Add("PARAMETER");
        sqlKeyWords.Add("PARAMETERS");
        sqlKeyWords.Add("PARTITION");
        sqlKeyWords.Add("PASCAL");
        sqlKeyWords.Add("PIPE");
        sqlKeyWords.Add("PIPELINED");
        sqlKeyWords.Add("PRAGMA");
        sqlKeyWords.Add("PRECISION");
        sqlKeyWords.Add("PRIVATE");
        sqlKeyWords.Add("PACKAGE");
        sqlKeyWords.Add("PARALLEL_ENABLE");
        sqlKeyWords.Add("PARAMETER");
        sqlKeyWords.Add("PARAMETERS");
        sqlKeyWords.Add("PARTITION");
        sqlKeyWords.Add("PASCAL");
        sqlKeyWords.Add("PIPE");
        sqlKeyWords.Add("PIPELINED");
        sqlKeyWords.Add("PRAGMA");
        sqlKeyWords.Add("PRECISION");
        sqlKeyWords.Add("PRIVATE");
        sqlKeyWords.Add("RAISE");
        sqlKeyWords.Add("RANGE");
        sqlKeyWords.Add("RAW");
        sqlKeyWords.Add("READ");
        sqlKeyWords.Add("RECORD");
        sqlKeyWords.Add("REF");
        sqlKeyWords.Add("REFERENCE");
        sqlKeyWords.Add("RELIES_ON");
        sqlKeyWords.Add("REM");
        sqlKeyWords.Add("REMAINDER");
        sqlKeyWords.Add("RENAME");
        sqlKeyWords.Add("RESULT");
        sqlKeyWords.Add("RESULT_CACHE");
        sqlKeyWords.Add("RETURN");
        sqlKeyWords.Add("RETURNING");
        sqlKeyWords.Add("REVERSE");
        sqlKeyWords.Add("ROLLBACK");
        sqlKeyWords.Add("ROW");
        sqlKeyWords.Add("RAISE");
        sqlKeyWords.Add("RANGE");
        sqlKeyWords.Add("RAW");
        sqlKeyWords.Add("READ");
        sqlKeyWords.Add("RECORD");
        sqlKeyWords.Add("REF");
        sqlKeyWords.Add("REFERENCE");
        sqlKeyWords.Add("RELIES_ON");
        sqlKeyWords.Add("REM");
        sqlKeyWords.Add("REMAINDER");
        sqlKeyWords.Add("RENAME");
        sqlKeyWords.Add("RESULT");
        sqlKeyWords.Add("RESULT_CACHE");
        sqlKeyWords.Add("RETURN");
        sqlKeyWords.Add("RETURNING");
        sqlKeyWords.Add("REVERSE");
        sqlKeyWords.Add("ROLLBACK");
        sqlKeyWords.Add("ROW");
        sqlKeyWords.Add("SAMPLE");
        sqlKeyWords.Add("SAVE");
        sqlKeyWords.Add("SAVEPOINT");
        sqlKeyWords.Add("SB1");
        sqlKeyWords.Add("SB2");
        sqlKeyWords.Add("SB4");
        sqlKeyWords.Add("SECOND");
        sqlKeyWords.Add("SEGMENT");
        sqlKeyWords.Add("SELF");
        sqlKeyWords.Add("SEPARATE");
        sqlKeyWords.Add("SEQUENCE");
        sqlKeyWords.Add("SERIALIZABLE");
        sqlKeyWords.Add("SET");
        sqlKeyWords.Add("SHORT");
        sqlKeyWords.Add("SIZE_T");
        sqlKeyWords.Add("SOME");
        sqlKeyWords.Add("SPARSE");
        sqlKeyWords.Add("SQLCODE");
        sqlKeyWords.Add("SQLDATA");
        sqlKeyWords.Add("SQLNAME");
        sqlKeyWords.Add("SQLSTATE");
        sqlKeyWords.Add("STANDARD");
        sqlKeyWords.Add("STATIC");
        sqlKeyWords.Add("STDDEV");
        sqlKeyWords.Add("STORED");
        sqlKeyWords.Add("STRING");
        sqlKeyWords.Add("STRUCT");
        sqlKeyWords.Add("STYLE");
        sqlKeyWords.Add("SUBMULTISET");
        sqlKeyWords.Add("SUBPARTITION");
        sqlKeyWords.Add("SUBSTITUTABLE");
        sqlKeyWords.Add("SUBTYPE");
        sqlKeyWords.Add("SUM");
        sqlKeyWords.Add("SYNONYM");
        sqlKeyWords.Add("SAMPLE");
        sqlKeyWords.Add("SAVE");
        sqlKeyWords.Add("SAVEPOINT");
        sqlKeyWords.Add("SB1");
        sqlKeyWords.Add("SB2");
        sqlKeyWords.Add("SB4");
        sqlKeyWords.Add("SECOND");
        sqlKeyWords.Add("SEGMENT");
        sqlKeyWords.Add("SELF");
        sqlKeyWords.Add("SEPARATE");
        sqlKeyWords.Add("SEQUENCE");
        sqlKeyWords.Add("SERIALIZABLE");
        sqlKeyWords.Add("SET");
        sqlKeyWords.Add("SHORT");
        sqlKeyWords.Add("SIZE_T");
        sqlKeyWords.Add("SOME");
        sqlKeyWords.Add("SPARSE");
        sqlKeyWords.Add("SQLCODE");
        sqlKeyWords.Add("SQLDATA");
        sqlKeyWords.Add("SQLNAME");
        sqlKeyWords.Add("SQLSTATE");
        sqlKeyWords.Add("STANDARD");
        sqlKeyWords.Add("STATIC");
        sqlKeyWords.Add("STDDEV");
        sqlKeyWords.Add("STORED");
        sqlKeyWords.Add("STRING");
        sqlKeyWords.Add("STRUCT");
        sqlKeyWords.Add("STYLE");
        sqlKeyWords.Add("SUBMULTISET");
        sqlKeyWords.Add("SUBPARTITION");
        sqlKeyWords.Add("SUBSTITUTABLE");
        sqlKeyWords.Add("SUBTYPE");
        sqlKeyWords.Add("SUM");
        sqlKeyWords.Add("SYNONYM");
        sqlKeyWords.Add("TDO");
        sqlKeyWords.Add("THE");
        sqlKeyWords.Add("TIME");
        sqlKeyWords.Add("TIMESTAMP");
        sqlKeyWords.Add("TIMEZONE_ABBR");
        sqlKeyWords.Add("TIMEZONE_HOUR");
        sqlKeyWords.Add("TIMEZONE_MINUTE");
        sqlKeyWords.Add("TIMEZONE_REGION");
        sqlKeyWords.Add("TRAILING");
        sqlKeyWords.Add("TRANSACTION");
        sqlKeyWords.Add("TRANSACTIONAL");
        sqlKeyWords.Add("TRUSTED");
        sqlKeyWords.Add("TYPE");
        sqlKeyWords.Add("TDO");
        sqlKeyWords.Add("THE");
        sqlKeyWords.Add("THEN");
        sqlKeyWords.Add("TIME");
        sqlKeyWords.Add("TIMESTAMP");
        sqlKeyWords.Add("TIMEZONE_ABBR");
        sqlKeyWords.Add("TIMEZONE_HOUR");
        sqlKeyWords.Add("TIMEZONE_MINUTE");
        sqlKeyWords.Add("TIMEZONE_REGION");
        sqlKeyWords.Add("TRAILING");
        sqlKeyWords.Add("TRANSACTION");
        sqlKeyWords.Add("TRANSACTIONAL");
        sqlKeyWords.Add("TRUSTED");
        sqlKeyWords.Add("TYPE");
        sqlKeyWords.Add("UB1");
        sqlKeyWords.Add("UB2");
        sqlKeyWords.Add("UB4");
        sqlKeyWords.Add("UNDER");
        sqlKeyWords.Add("UNSIGNED");
        sqlKeyWords.Add("UNTRUSTED");
        sqlKeyWords.Add("USE");
        sqlKeyWords.Add("USING");
        sqlKeyWords.Add("UB1");
        sqlKeyWords.Add("UB2");
        sqlKeyWords.Add("UB4");
        sqlKeyWords.Add("UNDER");
        sqlKeyWords.Add("UNSIGNED");
        sqlKeyWords.Add("UNTRUSTED");
        sqlKeyWords.Add("USE");
        sqlKeyWords.Add("USING");
        sqlKeyWords.Add("VALIST");
        sqlKeyWords.Add("VALUE");
        sqlKeyWords.Add("VARIABLE");
        sqlKeyWords.Add("VARIANCE");
        sqlKeyWords.Add("VARRAY");
        sqlKeyWords.Add("VARYING");
        sqlKeyWords.Add("VOID");
        sqlKeyWords.Add("VALIST");
        sqlKeyWords.Add("VALUE");
        sqlKeyWords.Add("VARIABLE");
        sqlKeyWords.Add("VARIANCE");
        sqlKeyWords.Add("VARRAY");
        sqlKeyWords.Add("VARYING");
        sqlKeyWords.Add("VOID");
        sqlKeyWords.Add("WHEN");
        sqlKeyWords.Add("WHILE");
        sqlKeyWords.Add("WORK");
        sqlKeyWords.Add("WRAPPED");
        sqlKeyWords.Add("WRITE");
        sqlKeyWords.Add("WHILE");
        sqlKeyWords.Add("WORK");
        sqlKeyWords.Add("WRAPPED");
        sqlKeyWords.Add("WRITE");
        sqlKeyWords.Add("YEAR");
        sqlKeyWords.Add("YEAR");
        sqlKeyWords.Add("ZONE");
        return sqlKeyWords.ToArray();
      }
      public char[] GetTokenSeparators()
      {
        char[] sqlTokenSeparators =
        {
            ' ',
            '\t',
            '\n',
            '\r',
            '(',
            ')',
            '.',
            '=',
            ',',
            '<',
            '>'
        };
        return sqlTokenSeparators;
      }
      public char[] GetLineSeparators()
      {
        char[] sqlLineSeparators =
        {
            '\n'
        };
        return sqlLineSeparators;
      }
      public bool GetCaseSensitiveLanguage()
      {
        return false;
      }
    }
    public class LanguageTsql : ILanguageElements
    {
      public string[] GetFunctions()
      {
        var sqlFunctions = new List<string>();
        //Aggregate SQLFunctions
        sqlFunctions.Add("AVG");
        sqlFunctions.Add("MIN");
        sqlFunctions.Add("CHECKSUM_AGG");
        sqlFunctions.Add("SUM");
        sqlFunctions.Add("COUNT");
        sqlFunctions.Add("STDEV");
        sqlFunctions.Add("COUNT_BIG");
        sqlFunctions.Add("STDEVP");
        sqlFunctions.Add("GROUPING");
        sqlFunctions.Add("VAR");
        sqlFunctions.Add("MAX");
        sqlFunctions.Add("VARP");
        //Configuration SQLFunctions 
        sqlFunctions.Add("@@DATEFIRST");
        sqlFunctions.Add("@@OPTIONS");
        sqlFunctions.Add("@@DBTS");
        sqlFunctions.Add("@@REMSERVER");
        sqlFunctions.Add("@@LANGID");
        sqlFunctions.Add("@@SERVERNAME");
        sqlFunctions.Add("@@LANGUAGE");
        sqlFunctions.Add("@@SERVICENAME");
        sqlFunctions.Add("@@LOCK_TIMEOUT");
        sqlFunctions.Add("@@SPID");
        sqlFunctions.Add("@@MAX_CONNECTIONS");
        sqlFunctions.Add("@@TEXTSIZE");
        sqlFunctions.Add("@@MAX_PRECISION");
        sqlFunctions.Add("@@VERSION");
        sqlFunctions.Add("@@NESTLEVEL");
        //Cryptographic SQLFunctions 
        sqlFunctions.Add("EncryptByKey");
        sqlFunctions.Add("DecryptByKey");
        sqlFunctions.Add("EncryptByPassPhrase");
        sqlFunctions.Add("DecryptByPassPhrase");
        sqlFunctions.Add("Key_ID");
        sqlFunctions.Add("Key_GUID");
        sqlFunctions.Add("EncryptByAsmKey");
        sqlFunctions.Add("DecryptByAsmKey");
        sqlFunctions.Add("EncryptByCert");
        sqlFunctions.Add("DecryptByCert");
        sqlFunctions.Add("Cert_ID");
        sqlFunctions.Add("AsymKey_ID");
        sqlFunctions.Add("CertProperty");
        sqlFunctions.Add("SignByAsymKey");
        sqlFunctions.Add("VerifySignedByAsmKey");
        sqlFunctions.Add("SignByCert");
        sqlFunctions.Add("VerifySignedByCert");
        sqlFunctions.Add("DecryptByKeyAutoCert");
        //Cursor SQLFunctions 
        sqlFunctions.Add("@@CURSOR_ROWS");
        sqlFunctions.Add("CURSOR_STATUS");
        sqlFunctions.Add("@@FETCH_STATUS");
        //Date and Time SQLFunctions 
        sqlFunctions.Add("SYSDATETIME");
        sqlFunctions.Add("SYSDATETIMEOFFSET");
        sqlFunctions.Add("SYSUTCDATETIME");
        sqlFunctions.Add("CURRENT_TIMESTAMP");
        sqlFunctions.Add("GETDATE");
        sqlFunctions.Add("GETUTCDATE");
        sqlFunctions.Add("DATENAME");
        sqlFunctions.Add("DATEPART");
        sqlFunctions.Add("DAY");
        sqlFunctions.Add("MONTH");
        sqlFunctions.Add("YEAR");
        sqlFunctions.Add("DATEDIFF");
        sqlFunctions.Add("DATEADD");
        sqlFunctions.Add("SWITCHOFFSET");
        sqlFunctions.Add("TODATETIMEOFFSET");
        sqlFunctions.Add("@@DATEFIRST");
        sqlFunctions.Add("SET DATEFIRST");
        sqlFunctions.Add("SET DATEFORMAT");
        sqlFunctions.Add("@@LANGUAGE");
        sqlFunctions.Add("SET LANGUAGE");
        sqlFunctions.Add("sp_helplanguage");
        sqlFunctions.Add("ISDATE");
        //Rowset SQLFunctions 
        sqlFunctions.Add("CONTAINSTABLE");
        sqlFunctions.Add("OPENQUERY");
        sqlFunctions.Add("FREETEXTTABLE");
        sqlFunctions.Add("OPENROWSET");
        sqlFunctions.Add("OPENDATASOURCE");
        sqlFunctions.Add("OPENXML");
        //Math
        sqlFunctions.Add("ABS");
        sqlFunctions.Add("DEGREES");
        sqlFunctions.Add("RAND");
        sqlFunctions.Add("ACOS");
        sqlFunctions.Add("EXP");
        sqlFunctions.Add("ROUND");
        sqlFunctions.Add("ASIN");
        sqlFunctions.Add("FLOOR");
        sqlFunctions.Add("SIGN");
        sqlFunctions.Add("ATAN");
        sqlFunctions.Add("LOG");
        sqlFunctions.Add("SIN");
        sqlFunctions.Add("ATN2");
        sqlFunctions.Add("LOG10");
        sqlFunctions.Add("SQRT");
        sqlFunctions.Add("CEILING");
        sqlFunctions.Add("PI");
        sqlFunctions.Add("SQUARE");
        sqlFunctions.Add("COS");
        sqlFunctions.Add("POWER");
        sqlFunctions.Add("TAN");
        sqlFunctions.Add("COT");
        sqlFunctions.Add("RADIANS");
        //Metadata SQLFunctions 
        sqlFunctions.Add("@@PROCID");
        sqlFunctions.Add("FULLTEXTCATALOGPROPERTY");
        sqlFunctions.Add("AsymKey_ID");
        sqlFunctions.Add("FULLTEXTSERVICEPROPERTY");
        sqlFunctions.Add("asymkeyproperty");
        sqlFunctions.Add("INDEX_COL");
        sqlFunctions.Add("ASSEMBLYPROPERTY");
        sqlFunctions.Add("INDEXKEY_PROPERTY");
        sqlFunctions.Add("Cert_ID");
        sqlFunctions.Add("INDEXPROPERTY");
        sqlFunctions.Add("COL_LENGTH");
        sqlFunctions.Add("Key_ID");
        sqlFunctions.Add("COL_NAME");
        sqlFunctions.Add("Key_GUID");
        sqlFunctions.Add("COLUMNPROPERTY");
        sqlFunctions.Add("KEY_NAME");
        sqlFunctions.Add("DATABASE_PRINCIPAL_ID");
        sqlFunctions.Add("OBJECT_DEFINITION");
        sqlFunctions.Add("DATABASEPROPERTY");
        sqlFunctions.Add("OBJECT_ID");
        sqlFunctions.Add("DATABASEPROPERTYEX");
        sqlFunctions.Add("OBJECT_NAME");
        sqlFunctions.Add("DB_ID");
        sqlFunctions.Add("OBJECT_SCHEMA_NAME");
        sqlFunctions.Add("DB_NAME");
        sqlFunctions.Add("OBJECTPROPERTY");
        sqlFunctions.Add("FILE_ID");
        sqlFunctions.Add("OBJECTPROPERTYEX");
        sqlFunctions.Add("FILE_IDEX");
        sqlFunctions.Add("SCHEMA_ID");
        sqlFunctions.Add("FILE_NAME");
        sqlFunctions.Add("SCHEMA_NAME");
        sqlFunctions.Add("FILEGROUP_ID");
        sqlFunctions.Add("SQL_VARIANT_PROPERTY");
        sqlFunctions.Add("FILEGROUP_NAME");
        sqlFunctions.Add("symkeyproperty");
        sqlFunctions.Add("FILEGROUPPROPERTY");
        sqlFunctions.Add("TYPE_ID");
        sqlFunctions.Add("FILEPROPERTY");
        sqlFunctions.Add("TYPE_NAME");
        sqlFunctions.Add("fn_listextendedproperty");
        sqlFunctions.Add("TYPEPROPERTY");
        //Ranking SQLFunctions 
        sqlFunctions.Add("RANK");
        sqlFunctions.Add("NTILE");
        sqlFunctions.Add("DENSE_RANK");
        sqlFunctions.Add("ROW_NUMBER");
        //Replication SQLFunctions 
        sqlFunctions.Add("PUBLISHINGSERVERNAME");
        //Security SQLFunctions 
        sqlFunctions.Add("CURRENT_USER");
        sqlFunctions.Add("SESSION_USER");
        sqlFunctions.Add("fn_builtin_permissions");
        sqlFunctions.Add("SETUSER");
        sqlFunctions.Add("fn_my_permissions");
        sqlFunctions.Add("SUSER_ID");
        sqlFunctions.Add("HAS_PERMS_BY_NAME");
        sqlFunctions.Add("SUSER_SID");
        sqlFunctions.Add("IS_MEMBER");
        sqlFunctions.Add("SUSER_SNAME");
        sqlFunctions.Add("IS_SRVROLEMEMBER");
        sqlFunctions.Add("SYSTEM_USER");
        sqlFunctions.Add("PERMISSIONS");
        sqlFunctions.Add("SUSER_NAME");
        sqlFunctions.Add("SCHEMA_ID");
        sqlFunctions.Add("USER_ID");
        sqlFunctions.Add("SCHEMA_NAME");
        sqlFunctions.Add("USER_NAME");
        //String SQLFunctions
        sqlFunctions.Add("ASCII");
        sqlFunctions.Add("NCHAR");
        sqlFunctions.Add("SOUNDEX");
        sqlFunctions.Add("CHAR");
        sqlFunctions.Add("PATINDEX");
        sqlFunctions.Add("SPACE");
        sqlFunctions.Add("CHARINDEX");
        sqlFunctions.Add("QUOTENAME");
        sqlFunctions.Add("STR");
        sqlFunctions.Add("DIFFERENCE");
        sqlFunctions.Add("REPLACE");
        sqlFunctions.Add("STUFF");
        sqlFunctions.Add("LEFT");
        sqlFunctions.Add("REPLICATE");
        sqlFunctions.Add("SUBSTRING");
        sqlFunctions.Add("LEN");
        sqlFunctions.Add("REVERSE");
        sqlFunctions.Add("UNICODE");
        sqlFunctions.Add("LOWER");
        sqlFunctions.Add("RIGHT");
        sqlFunctions.Add("UPPER");
        sqlFunctions.Add("LTRIM");
        sqlFunctions.Add("RTRIM");
        //System Statistical SQLFunctions 
        sqlFunctions.Add("@@CONNECTIONS");
        sqlFunctions.Add("@@PACK_RECEIVED");
        sqlFunctions.Add("@@CPU_BUSY");
        sqlFunctions.Add("@@PACK_SENT");
        sqlFunctions.Add("fn_virtualfilestats");
        sqlFunctions.Add("@@TIMETICKS");
        sqlFunctions.Add("@@IDLE");
        sqlFunctions.Add("@@TOTAL_ERRORS");
        sqlFunctions.Add("@@IO_BUSY");
        sqlFunctions.Add("@@TOTAL_READ");
        sqlFunctions.Add("@@PACKET_ERRORS");
        sqlFunctions.Add("@@TOTAL_WRITE");
        //Text and Image SQLFunctions 
        sqlFunctions.Add("PATINDEX");
        sqlFunctions.Add("TEXTVALID");
        sqlFunctions.Add("TEXTPTR");
        //Others
        sqlFunctions.Add("ISNULL");
        return sqlFunctions.ToArray();
      }
      public string[] GetKeyWords()
      {
        var sqlKeyWords = new List<string>();
        sqlKeyWords.Add("ADD");
        sqlKeyWords.Add("EXCEPT");
        sqlKeyWords.Add("PERCENT");
        sqlKeyWords.Add("ALL");
        sqlKeyWords.Add("EXEC");
        sqlKeyWords.Add("PLAN");
        sqlKeyWords.Add("ALTER");
        sqlKeyWords.Add("EXECUTE");
        sqlKeyWords.Add("PRECISION");
        sqlKeyWords.Add("AND");
        sqlKeyWords.Add("EXISTS");
        sqlKeyWords.Add("PRIMARY");
        sqlKeyWords.Add("ANY");
        sqlKeyWords.Add("EXIT");
        sqlKeyWords.Add("PRINT");
        sqlKeyWords.Add("AS");
        sqlKeyWords.Add("FETCH");
        sqlKeyWords.Add("PROC");
        sqlKeyWords.Add("ASC");
        sqlKeyWords.Add("FILE");
        sqlKeyWords.Add("PROCEDURE");
        sqlKeyWords.Add("AUTHORIZATION");
        sqlKeyWords.Add("FILLFACTOR");
        sqlKeyWords.Add("PUBLIC");
        sqlKeyWords.Add("BACKUP");
        sqlKeyWords.Add("FOR");
        sqlKeyWords.Add("RAISERROR");
        sqlKeyWords.Add("BEGIN");
        sqlKeyWords.Add("FOREIGN");
        sqlKeyWords.Add("READ");
        sqlKeyWords.Add("BETWEEN");
        sqlKeyWords.Add("FREETEXT");
        sqlKeyWords.Add("READTEXT");
        sqlKeyWords.Add("BREAK");
        sqlKeyWords.Add("FREETEXTTABLE");
        sqlKeyWords.Add("RECONFIGURE");
        sqlKeyWords.Add("BROWSE");
        sqlKeyWords.Add("FROM");
        sqlKeyWords.Add("REFERENCES");
        sqlKeyWords.Add("BULK");
        sqlKeyWords.Add("FULL");
        sqlKeyWords.Add("REPLICATION");
        sqlKeyWords.Add("BY");
        sqlKeyWords.Add("FUNCTION");
        sqlKeyWords.Add("RESTORE");
        sqlKeyWords.Add("CASCADE");
        sqlKeyWords.Add("GOTO");
        sqlKeyWords.Add("RESTRICT");
        sqlKeyWords.Add("CASE");
        sqlKeyWords.Add("GRANT");
        sqlKeyWords.Add("RETURN");
        sqlKeyWords.Add("CHECK");
        sqlKeyWords.Add("GROUP");
        sqlKeyWords.Add("REVOKE");
        sqlKeyWords.Add("CHECKPOINT");
        sqlKeyWords.Add("HAVING");
        sqlKeyWords.Add("RIGHT");
        sqlKeyWords.Add("CLOSE");
        sqlKeyWords.Add("HOLDLOCK");
        sqlKeyWords.Add("ROLLBACK");
        sqlKeyWords.Add("CLUSTERED");
        sqlKeyWords.Add("IDENTITY");
        sqlKeyWords.Add("ROWCOUNT");
        sqlKeyWords.Add("COALESCE");
        sqlKeyWords.Add("IDENTITY_INSERT");
        sqlKeyWords.Add("ROWGUIDCOL");
        sqlKeyWords.Add("COLLATE");
        sqlKeyWords.Add("IDENTITYCOL");
        sqlKeyWords.Add("RULE");
        sqlKeyWords.Add("COLUMN");
        sqlKeyWords.Add("IF");
        sqlKeyWords.Add("SAVE");
        sqlKeyWords.Add("COMMIT");
        sqlKeyWords.Add("IN");
        sqlKeyWords.Add("SCHEMA");
        sqlKeyWords.Add("COMPUTE");
        sqlKeyWords.Add("INDEX");
        sqlKeyWords.Add("SELECT");
        sqlKeyWords.Add("CONSTRAINT");
        sqlKeyWords.Add("INNER");
        sqlKeyWords.Add("SESSION_USER");
        sqlKeyWords.Add("CONTAINS");
        sqlKeyWords.Add("INSERT");
        sqlKeyWords.Add("SET");
        sqlKeyWords.Add("CONTAINSTABLE");
        sqlKeyWords.Add("INTERSECT");
        sqlKeyWords.Add("SETUSER");
        sqlKeyWords.Add("CONTINUE");
        sqlKeyWords.Add("INTO");
        sqlKeyWords.Add("SHUTDOWN");
        sqlKeyWords.Add("CONVERT");
        sqlKeyWords.Add("IS");
        sqlKeyWords.Add("SOME");
        sqlKeyWords.Add("CREATE");
        sqlKeyWords.Add("JOIN");
        sqlKeyWords.Add("STATISTICS");
        sqlKeyWords.Add("CROSS");
        sqlKeyWords.Add("KEY");
        sqlKeyWords.Add("SYSTEM_USER");
        sqlKeyWords.Add("CURRENT");
        sqlKeyWords.Add("KILL");
        sqlKeyWords.Add("TABLE");
        sqlKeyWords.Add("CURRENT_DATE");
        sqlKeyWords.Add("LEFT");
        sqlKeyWords.Add("TEXTSIZE");
        sqlKeyWords.Add("CURRENT_TIME");
        sqlKeyWords.Add("LIKE");
        sqlKeyWords.Add("THEN");
        sqlKeyWords.Add("CURRENT_TIMESTAMP");
        sqlKeyWords.Add("LINENO");
        sqlKeyWords.Add("TO");
        sqlKeyWords.Add("CURRENT_USER");
        sqlKeyWords.Add("LOAD");
        sqlKeyWords.Add("TOP");
        sqlKeyWords.Add("CURSOR");
        sqlKeyWords.Add("NATIONAL ");
        sqlKeyWords.Add("TRAN");
        sqlKeyWords.Add("DATABASE");
        sqlKeyWords.Add("NOCHECK");
        sqlKeyWords.Add("TRANSACTION");
        sqlKeyWords.Add("DBCC");
        sqlKeyWords.Add("NONCLUSTERED");
        sqlKeyWords.Add("TRIGGER");
        sqlKeyWords.Add("DEALLOCATE");
        sqlKeyWords.Add("NOT");
        sqlKeyWords.Add("TRUNCATE");
        sqlKeyWords.Add("DECLARE");
        sqlKeyWords.Add("NULL");
        sqlKeyWords.Add("TSEQUAL");
        sqlKeyWords.Add("DEFAULT");
        sqlKeyWords.Add("NULLIF");
        sqlKeyWords.Add("UNION");
        sqlKeyWords.Add("DELETE");
        sqlKeyWords.Add("OF");
        sqlKeyWords.Add("UNIQUE");
        sqlKeyWords.Add("DENY");
        sqlKeyWords.Add("OFF");
        sqlKeyWords.Add("UPDATE");
        sqlKeyWords.Add("DESC");
        sqlKeyWords.Add("OFFSETS");
        sqlKeyWords.Add("UPDATETEXT");
        sqlKeyWords.Add("DISK");
        sqlKeyWords.Add("ON");
        sqlKeyWords.Add("USE");
        sqlKeyWords.Add("DISTINCT");
        sqlKeyWords.Add("OPEN");
        sqlKeyWords.Add("USER");
        sqlKeyWords.Add("DISTRIBUTED");
        sqlKeyWords.Add("OPENDATASOURCE");
        sqlKeyWords.Add("VALUES");
        sqlKeyWords.Add("DOUBLE");
        sqlKeyWords.Add("OPENQUERY");
        sqlKeyWords.Add("VARYING");
        sqlKeyWords.Add("DROP");
        sqlKeyWords.Add("OPENROWSET");
        sqlKeyWords.Add("VIEW");
        sqlKeyWords.Add("DUMMY");
        sqlKeyWords.Add("OPENXML");
        sqlKeyWords.Add("WAITFOR");
        sqlKeyWords.Add("DUMP");
        sqlKeyWords.Add("OPTION");
        sqlKeyWords.Add("WHEN");
        sqlKeyWords.Add("ELSE");
        sqlKeyWords.Add("OR");
        sqlKeyWords.Add("WHERE");
        sqlKeyWords.Add("END");
        sqlKeyWords.Add("ORDER");
        sqlKeyWords.Add("WHILE");
        sqlKeyWords.Add("ERRLVL");
        sqlKeyWords.Add("OUTER");
        sqlKeyWords.Add("WITH");
        sqlKeyWords.Add("ESCAPE");
        sqlKeyWords.Add("OVER");
        sqlKeyWords.Add("WRITETEXT");
        return sqlKeyWords.ToArray();
      }
      public char[] GetTokenSeparators()
      {
        char[] sqlTokenSeparators =
        {
            ' ',
            '\t',
            '\n',
            '\r',
            '(',
            ')',
            '.',
            '=',
            ',',
            '<',
            '>'
        };
        return sqlTokenSeparators;
      }
      public char[] GetLineSeparators()
      {
        char[] sqlLineSeparators =
        {
            '\n'
        };
        return sqlLineSeparators;
      }
      public bool GetCaseSensitiveLanguage()
      {
        return false;
      }
    }
    public class LanguageMySql : ILanguageElements
    {
      public string[] GetFunctions()
      {
        var sqlFunctions = new List<string>();
        /*
        //Aggregate SQLFunctions
        SQLFunctions.Add("AVG");
        SQLFunctions.Add("MIN");
        SQLFunctions.Add("CHECKSUM_AGG");
        SQLFunctions.Add("SUM");
        SQLFunctions.Add("COUNT");
        SQLFunctions.Add("STDEV");
        SQLFunctions.Add("COUNT_BIG");
        SQLFunctions.Add("STDEVP");
        SQLFunctions.Add("GROUPING");
        SQLFunctions.Add("VAR");
        SQLFunctions.Add("MAX");
        SQLFunctions.Add("VARP");
        //Configuration SQLFunctions 
        SQLFunctions.Add("@@DATEFIRST");
        SQLFunctions.Add("@@OPTIONS");
        SQLFunctions.Add("@@DBTS");
        SQLFunctions.Add("@@REMSERVER");
        SQLFunctions.Add("@@LANGID");
        SQLFunctions.Add("@@SERVERNAME");
        SQLFunctions.Add("@@LANGUAGE");
        SQLFunctions.Add("@@SERVICENAME");
        SQLFunctions.Add("@@LOCK_TIMEOUT");
        SQLFunctions.Add("@@SPID");
        SQLFunctions.Add("@@MAX_CONNECTIONS");
        SQLFunctions.Add("@@TEXTSIZE");
        SQLFunctions.Add("@@MAX_PRECISION");
        SQLFunctions.Add("@@VERSION");
        SQLFunctions.Add("@@NESTLEVEL");
        //Cryptographic SQLFunctions 
        SQLFunctions.Add("EncryptByKey");
        SQLFunctions.Add("DecryptByKey");
        SQLFunctions.Add("EncryptByPassPhrase");
        SQLFunctions.Add("DecryptByPassPhrase");
        SQLFunctions.Add("Key_ID");
        SQLFunctions.Add("Key_GUID");
        SQLFunctions.Add("EncryptByAsmKey");
        SQLFunctions.Add("DecryptByAsmKey");
        SQLFunctions.Add("EncryptByCert");
        SQLFunctions.Add("DecryptByCert");
        SQLFunctions.Add("Cert_ID");
        SQLFunctions.Add("AsymKey_ID");
        SQLFunctions.Add("CertProperty");
        SQLFunctions.Add("SignByAsymKey");
        SQLFunctions.Add("VerifySignedByAsmKey");
        SQLFunctions.Add("SignByCert");
        SQLFunctions.Add("VerifySignedByCert");
        SQLFunctions.Add("DecryptByKeyAutoCert");
        //Cursor SQLFunctions 
        SQLFunctions.Add("@@CURSOR_ROWS");
        SQLFunctions.Add("CURSOR_STATUS");
        SQLFunctions.Add("@@FETCH_STATUS");
        //Date and Time SQLFunctions 
        SQLFunctions.Add("SYSDATETIME");
        SQLFunctions.Add("SYSDATETIMEOFFSET");
        SQLFunctions.Add("SYSUTCDATETIME");
        SQLFunctions.Add("CURRENT_TIMESTAMP");
        SQLFunctions.Add("GETDATE");
        SQLFunctions.Add("GETUTCDATE");
        SQLFunctions.Add("DATENAME");
        SQLFunctions.Add("DATEPART");
        SQLFunctions.Add("DAY");
        SQLFunctions.Add("MONTH");
        SQLFunctions.Add("YEAR");
        SQLFunctions.Add("DATEDIFF");
        SQLFunctions.Add("DATEADD");
        SQLFunctions.Add("SWITCHOFFSET");
        SQLFunctions.Add("TODATETIMEOFFSET");
        SQLFunctions.Add("@@DATEFIRST");
        SQLFunctions.Add("SET DATEFIRST");
        SQLFunctions.Add("SET DATEFORMAT");
        SQLFunctions.Add("@@LANGUAGE");
        SQLFunctions.Add("SET LANGUAGE");
        SQLFunctions.Add("sp_helplanguage");
        SQLFunctions.Add("ISDATE");
        //Rowset SQLFunctions 
        SQLFunctions.Add("CONTAINSTABLE");
        SQLFunctions.Add("OPENQUERY");
        SQLFunctions.Add("FREETEXTTABLE");
        SQLFunctions.Add("OPENROWSET");
        SQLFunctions.Add("OPENDATASOURCE");
        SQLFunctions.Add("OPENXML");
        //Math
        SQLFunctions.Add("ABS");
        SQLFunctions.Add("DEGREES");
        SQLFunctions.Add("RAND");
        SQLFunctions.Add("ACOS");
        SQLFunctions.Add("EXP");
        SQLFunctions.Add("ROUND");
        SQLFunctions.Add("ASIN");
        SQLFunctions.Add("FLOOR");
        SQLFunctions.Add("SIGN");
        SQLFunctions.Add("ATAN");
        SQLFunctions.Add("LOG");
        SQLFunctions.Add("SIN");
        SQLFunctions.Add("ATN2");
        SQLFunctions.Add("LOG10");
        SQLFunctions.Add("SQRT");
        SQLFunctions.Add("CEILING");
        SQLFunctions.Add("PI");
        SQLFunctions.Add("SQUARE");
        SQLFunctions.Add("COS");
        SQLFunctions.Add("POWER");
        SQLFunctions.Add("TAN");
        SQLFunctions.Add("COT");
        SQLFunctions.Add("RADIANS");
        //Metadata SQLFunctions 
        SQLFunctions.Add("@@PROCID");
        SQLFunctions.Add("FULLTEXTCATALOGPROPERTY");
        SQLFunctions.Add("AsymKey_ID");
        SQLFunctions.Add("FULLTEXTSERVICEPROPERTY");
        SQLFunctions.Add("asymkeyproperty");
        SQLFunctions.Add("INDEX_COL");
        SQLFunctions.Add("ASSEMBLYPROPERTY");
        SQLFunctions.Add("INDEXKEY_PROPERTY");
        SQLFunctions.Add("Cert_ID");
        SQLFunctions.Add("INDEXPROPERTY");
        SQLFunctions.Add("COL_LENGTH");
        SQLFunctions.Add("Key_ID");
        SQLFunctions.Add("COL_NAME");
        SQLFunctions.Add("Key_GUID");
        SQLFunctions.Add("COLUMNPROPERTY");
        SQLFunctions.Add("KEY_NAME");
        SQLFunctions.Add("DATABASE_PRINCIPAL_ID");
        SQLFunctions.Add("OBJECT_DEFINITION");
        SQLFunctions.Add("DATABASEPROPERTY");
        SQLFunctions.Add("OBJECT_ID");
        SQLFunctions.Add("DATABASEPROPERTYEX");
        SQLFunctions.Add("OBJECT_NAME");
        SQLFunctions.Add("DB_ID");
        SQLFunctions.Add("OBJECT_SCHEMA_NAME");
        SQLFunctions.Add("DB_NAME");
        SQLFunctions.Add("OBJECTPROPERTY");
        SQLFunctions.Add("FILE_ID");
        SQLFunctions.Add("OBJECTPROPERTYEX");
        SQLFunctions.Add("FILE_IDEX");
        SQLFunctions.Add("SCHEMA_ID");
        SQLFunctions.Add("FILE_NAME");
        SQLFunctions.Add("SCHEMA_NAME");
        SQLFunctions.Add("FILEGROUP_ID");
        SQLFunctions.Add("SQL_VARIANT_PROPERTY");
        SQLFunctions.Add("FILEGROUP_NAME");
        SQLFunctions.Add("symkeyproperty");
        SQLFunctions.Add("FILEGROUPPROPERTY");
        SQLFunctions.Add("TYPE_ID");
        SQLFunctions.Add("FILEPROPERTY");
        SQLFunctions.Add("TYPE_NAME");
        SQLFunctions.Add("fn_listextendedproperty");
        SQLFunctions.Add("TYPEPROPERTY");
        //Ranking SQLFunctions 
        SQLFunctions.Add("RANK");
        SQLFunctions.Add("NTILE");
        SQLFunctions.Add("DENSE_RANK");
        SQLFunctions.Add("ROW_NUMBER");
        //Replication SQLFunctions 
        SQLFunctions.Add("PUBLISHINGSERVERNAME");
        //Security SQLFunctions 
        SQLFunctions.Add("CURRENT_USER");
        SQLFunctions.Add("SESSION_USER");
        SQLFunctions.Add("fn_builtin_permissions");
        SQLFunctions.Add("SETUSER");
        SQLFunctions.Add("fn_my_permissions");
        SQLFunctions.Add("SUSER_ID");
        SQLFunctions.Add("HAS_PERMS_BY_NAME");
        SQLFunctions.Add("SUSER_SID");
        SQLFunctions.Add("IS_MEMBER");
        SQLFunctions.Add("SUSER_SNAME");
        SQLFunctions.Add("IS_SRVROLEMEMBER");
        SQLFunctions.Add("SYSTEM_USER");
        SQLFunctions.Add("PERMISSIONS");
        SQLFunctions.Add("SUSER_NAME");
        SQLFunctions.Add("SCHEMA_ID");
        SQLFunctions.Add("USER_ID");
        SQLFunctions.Add("SCHEMA_NAME");
        SQLFunctions.Add("USER_NAME");
        //String SQLFunctions
        SQLFunctions.Add("ASCII");
        SQLFunctions.Add("NCHAR");
        SQLFunctions.Add("SOUNDEX");
        SQLFunctions.Add("CHAR");
        SQLFunctions.Add("PATINDEX");
        SQLFunctions.Add("SPACE");
        SQLFunctions.Add("CHARINDEX");
        SQLFunctions.Add("QUOTENAME");
        SQLFunctions.Add("STR");
        SQLFunctions.Add("DIFFERENCE");
        SQLFunctions.Add("REPLACE");
        SQLFunctions.Add("STUFF");
        SQLFunctions.Add("LEFT");
        SQLFunctions.Add("REPLICATE");
        SQLFunctions.Add("SUBSTRING");
        SQLFunctions.Add("LEN");
        SQLFunctions.Add("REVERSE");
        SQLFunctions.Add("UNICODE");
        SQLFunctions.Add("LOWER");
        SQLFunctions.Add("RIGHT");
        SQLFunctions.Add("UPPER");
        SQLFunctions.Add("LTRIM");
        SQLFunctions.Add("RTRIM");
        //System Statistical SQLFunctions 
        SQLFunctions.Add("@@CONNECTIONS");
        SQLFunctions.Add("@@PACK_RECEIVED");
        SQLFunctions.Add("@@CPU_BUSY");
        SQLFunctions.Add("@@PACK_SENT");
        SQLFunctions.Add("fn_virtualfilestats");
        SQLFunctions.Add("@@TIMETICKS");
        SQLFunctions.Add("@@IDLE");
        SQLFunctions.Add("@@TOTAL_ERRORS");
        SQLFunctions.Add("@@IO_BUSY");
        SQLFunctions.Add("@@TOTAL_READ");
        SQLFunctions.Add("@@PACKET_ERRORS");
        SQLFunctions.Add("@@TOTAL_WRITE");
        //Text and Image SQLFunctions 
        SQLFunctions.Add("PATINDEX");
        SQLFunctions.Add("TEXTVALID");
        SQLFunctions.Add("TEXTPTR");
        //Others
        SQLFunctions.Add("ISNULL");
         * */
        return sqlFunctions.ToArray();
      }
      public string[] GetKeyWords()
      {
        var sqlKeyWords = new List<string>();
        sqlKeyWords.Add("ADD");
        sqlKeyWords.Add("EXCEPT");
        sqlKeyWords.Add("PERCENT");
        sqlKeyWords.Add("ALL");
        sqlKeyWords.Add("EXEC");
        sqlKeyWords.Add("PLAN");
        sqlKeyWords.Add("ALTER");
        sqlKeyWords.Add("EXECUTE");
        sqlKeyWords.Add("PRECISION");
        sqlKeyWords.Add("AND");
        sqlKeyWords.Add("EXISTS");
        sqlKeyWords.Add("PRIMARY");
        sqlKeyWords.Add("ANY");
        sqlKeyWords.Add("EXIT");
        sqlKeyWords.Add("PRINT");
        sqlKeyWords.Add("AS");
        sqlKeyWords.Add("FETCH");
        sqlKeyWords.Add("PROC");
        sqlKeyWords.Add("ASC");
        sqlKeyWords.Add("FILE");
        sqlKeyWords.Add("PROCEDURE");
        sqlKeyWords.Add("AUTHORIZATION");
        sqlKeyWords.Add("FILLFACTOR");
        sqlKeyWords.Add("PUBLIC");
        sqlKeyWords.Add("BACKUP");
        sqlKeyWords.Add("FOR");
        sqlKeyWords.Add("RAISERROR");
        sqlKeyWords.Add("BEGIN");
        sqlKeyWords.Add("FOREIGN");
        sqlKeyWords.Add("READ");
        sqlKeyWords.Add("BETWEEN");
        sqlKeyWords.Add("FREETEXT");
        sqlKeyWords.Add("READTEXT");
        sqlKeyWords.Add("BREAK");
        sqlKeyWords.Add("FREETEXTTABLE");
        sqlKeyWords.Add("RECONFIGURE");
        sqlKeyWords.Add("BROWSE");
        sqlKeyWords.Add("FROM");
        sqlKeyWords.Add("REFERENCES");
        sqlKeyWords.Add("BULK");
        sqlKeyWords.Add("FULL");
        sqlKeyWords.Add("REPLICATION");
        sqlKeyWords.Add("BY");
        sqlKeyWords.Add("FUNCTION");
        sqlKeyWords.Add("RESTORE");
        sqlKeyWords.Add("CASCADE");
        sqlKeyWords.Add("GOTO");
        sqlKeyWords.Add("RESTRICT");
        sqlKeyWords.Add("CASE");
        sqlKeyWords.Add("GRANT");
        sqlKeyWords.Add("RETURN");
        sqlKeyWords.Add("CHECK");
        sqlKeyWords.Add("GROUP");
        sqlKeyWords.Add("REVOKE");
        sqlKeyWords.Add("CHECKPOINT");
        sqlKeyWords.Add("HAVING");
        sqlKeyWords.Add("RIGHT");
        sqlKeyWords.Add("CLOSE");
        sqlKeyWords.Add("HOLDLOCK");
        sqlKeyWords.Add("ROLLBACK");
        sqlKeyWords.Add("CLUSTERED");
        sqlKeyWords.Add("IDENTITY");
        sqlKeyWords.Add("ROWCOUNT");
        sqlKeyWords.Add("COALESCE");
        sqlKeyWords.Add("IDENTITY_INSERT");
        sqlKeyWords.Add("ROWGUIDCOL");
        sqlKeyWords.Add("COLLATE");
        sqlKeyWords.Add("IDENTITYCOL");
        sqlKeyWords.Add("RULE");
        sqlKeyWords.Add("COLUMN");
        sqlKeyWords.Add("IF");
        sqlKeyWords.Add("SAVE");
        sqlKeyWords.Add("COMMIT");
        sqlKeyWords.Add("IN");
        sqlKeyWords.Add("SCHEMA");
        sqlKeyWords.Add("COMPUTE");
        sqlKeyWords.Add("INDEX");
        sqlKeyWords.Add("SELECT");
        sqlKeyWords.Add("CONSTRAINT");
        sqlKeyWords.Add("INNER");
        sqlKeyWords.Add("SESSION_USER");
        sqlKeyWords.Add("CONTAINS");
        sqlKeyWords.Add("INSERT");
        sqlKeyWords.Add("SET");
        sqlKeyWords.Add("CONTAINSTABLE");
        sqlKeyWords.Add("INTERSECT");
        sqlKeyWords.Add("SETUSER");
        sqlKeyWords.Add("CONTINUE");
        sqlKeyWords.Add("INTO");
        sqlKeyWords.Add("SHUTDOWN");
        sqlKeyWords.Add("CONVERT");
        sqlKeyWords.Add("IS");
        sqlKeyWords.Add("SOME");
        sqlKeyWords.Add("CREATE");
        sqlKeyWords.Add("JOIN");
        sqlKeyWords.Add("STATISTICS");
        sqlKeyWords.Add("CROSS");
        sqlKeyWords.Add("KEY");
        sqlKeyWords.Add("SYSTEM_USER");
        sqlKeyWords.Add("CURRENT");
        sqlKeyWords.Add("KILL");
        sqlKeyWords.Add("TABLE");
        sqlKeyWords.Add("CURRENT_DATE");
        sqlKeyWords.Add("LEFT");
        sqlKeyWords.Add("TEXTSIZE");
        sqlKeyWords.Add("CURRENT_TIME");
        sqlKeyWords.Add("LIKE");
        sqlKeyWords.Add("THEN");
        sqlKeyWords.Add("CURRENT_TIMESTAMP");
        sqlKeyWords.Add("LINENO");
        sqlKeyWords.Add("TO");
        sqlKeyWords.Add("CURRENT_USER");
        sqlKeyWords.Add("LOAD");
        sqlKeyWords.Add("TOP");
        sqlKeyWords.Add("CURSOR");
        sqlKeyWords.Add("NATIONAL ");
        sqlKeyWords.Add("TRAN");
        sqlKeyWords.Add("DATABASE");
        sqlKeyWords.Add("NOCHECK");
        sqlKeyWords.Add("TRANSACTION");
        sqlKeyWords.Add("DBCC");
        sqlKeyWords.Add("NONCLUSTERED");
        sqlKeyWords.Add("TRIGGER");
        sqlKeyWords.Add("DEALLOCATE");
        sqlKeyWords.Add("NOT");
        sqlKeyWords.Add("TRUNCATE");
        sqlKeyWords.Add("DECLARE");
        sqlKeyWords.Add("NULL");
        sqlKeyWords.Add("TSEQUAL");
        sqlKeyWords.Add("DEFAULT");
        sqlKeyWords.Add("NULLIF");
        sqlKeyWords.Add("UNION");
        sqlKeyWords.Add("DELETE");
        sqlKeyWords.Add("OF");
        sqlKeyWords.Add("UNIQUE");
        sqlKeyWords.Add("DENY");
        sqlKeyWords.Add("OFF");
        sqlKeyWords.Add("UPDATE");
        sqlKeyWords.Add("DESC");
        sqlKeyWords.Add("OFFSETS");
        sqlKeyWords.Add("UPDATETEXT");
        sqlKeyWords.Add("DISK");
        sqlKeyWords.Add("ON");
        sqlKeyWords.Add("USE");
        sqlKeyWords.Add("DISTINCT");
        sqlKeyWords.Add("OPEN");
        sqlKeyWords.Add("USER");
        sqlKeyWords.Add("DISTRIBUTED");
        sqlKeyWords.Add("OPENDATASOURCE");
        sqlKeyWords.Add("VALUES");
        sqlKeyWords.Add("DOUBLE");
        sqlKeyWords.Add("OPENQUERY");
        sqlKeyWords.Add("VARYING");
        sqlKeyWords.Add("DROP");
        sqlKeyWords.Add("OPENROWSET");
        sqlKeyWords.Add("VIEW");
        sqlKeyWords.Add("DUMMY");
        sqlKeyWords.Add("OPENXML");
        sqlKeyWords.Add("WAITFOR");
        sqlKeyWords.Add("DUMP");
        sqlKeyWords.Add("OPTION");
        sqlKeyWords.Add("WHEN");
        sqlKeyWords.Add("ELSE");
        sqlKeyWords.Add("OR");
        sqlKeyWords.Add("WHERE");
        sqlKeyWords.Add("END");
        sqlKeyWords.Add("ORDER");
        sqlKeyWords.Add("WHILE");
        sqlKeyWords.Add("ERRLVL");
        sqlKeyWords.Add("OUTER");
        sqlKeyWords.Add("WITH");
        sqlKeyWords.Add("ESCAPE");
        sqlKeyWords.Add("OVER");
        sqlKeyWords.Add("WRITETEXT");
        return sqlKeyWords.ToArray();
      }
      public char[] GetTokenSeparators()
      {
        char[] sqlTokenSeparators =
        {
            ' ',
            '\t',
            '\n',
            '\r',
            '(',
            ')',
            '.',
            '=',
            ',',
            '<',
            '>'
        };
        return sqlTokenSeparators;
      }
      public char[] GetLineSeparators()
      {
        char[] sqlLineSeparators =
        {
            '\n'
        };
        return sqlLineSeparators;
      }
      public bool GetCaseSensitiveLanguage()
      {
        return false;
      }
    }
    public interface ILanguageElements
    {
      string[] GetFunctions();
      string[] GetKeyWords();
      char[] GetTokenSeparators();
      char[] GetLineSeparators();
      bool GetCaseSensitiveLanguage();
    }
    private delegate void HighLightDelegate();
    private readonly Thread _hilightThread = new Thread();
    private List<string> _functions = new List<string>();
    private bool _hilightSintax = true;
    private List<string> _keyWords = new List<string>();
    private DateTime _lastModification = DateTime.MinValue;
    private List<char> _lineSeparators = new List<char>();
    private bool _needHighLight;
    private List<char> _tokenSeparators = new List<char>();
    public SyntaxHighLighter()
    {
      _hilightThread.ThreadJob += m_HilightThread_ThreadJob;
      _hilightThread.SynchronizeInvokeObject = this;
      //m_HilightThread.SetTimerInterval(1000, 1000);
      //m_HilightThread.Start();
    }
    private StringComparer StringComparer
    {
      get;
      set;
    } = StringComparer.CurrentCulture;
    public bool CaseSensitiveLanguage
    {
      get => StringComparer == StringComparer.CurrentCulture;
      set
      {
        if (value)
        {
          StringComparer = StringComparer.CurrentCulture;
        }
        else
        {
          StringComparer = StringComparer.CurrentCultureIgnoreCase;
        }

        _functions.Sort(StringComparer);
        _keyWords.Sort(StringComparer);
      }
    }
    public string[] KeyWords
    {
      get => _keyWords.ToArray();
      set
      {
        _keyWords = new List<string>(value);
        _keyWords.Sort(StringComparer);
      }
    }
    public string[] Functions
    {
      get => _functions.ToArray();
      set
      {
        _functions = new List<string>(value);
        _functions.Sort(StringComparer);
      }
    }
    public char[] LineSeparators
    {
      get => _lineSeparators.ToArray();
      set
      {
        _lineSeparators = new List<char>(value);
        _lineSeparators.Sort();
      }
    }
    public char[] TokenSeparators
    {
      get => _tokenSeparators.ToArray();
      set
      {
        _tokenSeparators = new List<char>(value);
        _tokenSeparators.Sort();
      }
    }
    public bool HighlightSyntax
    {
      get => false;
      set => _hilightSintax = value;
    }
    private Point ScrollPos
    {
      get
      {
        var pt = new Point(0, 0);
        using (var uo = new UnmanagedObject<Point>(pt))
        {
          Win32.SendMessage(Handle, Win32.EmGetscrollpos, 0, uo.Pointer());
          pt = uo.Structure;
        }

        return pt;
      }
      set
      {
        using (var uo = new UnmanagedObject<Point>(value))
        {
          Win32.SendMessage(Handle, Win32.EmSetscrollpos, 0, uo.Pointer());
        }
      }
    }
    public void SetLanguageElements(ILanguageElements languageElements)
    {
      CaseSensitiveLanguage = languageElements.GetCaseSensitiveLanguage();
      TokenSeparators = languageElements.GetTokenSeparators();
      LineSeparators = languageElements.GetLineSeparators();
      KeyWords = languageElements.GetKeyWords();
      Functions = languageElements.GetFunctions();
    }
    private void m_HilightThread_ThreadJob(Thread instance, object parameters)
    {
      System.Threading.Thread.Sleep(1000);
      instance.SynchronizeInvoke(new HighLightDelegate(HighLight), null);
    }
    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
    }
    private void StartThread()
    {
      //System.Diagnostics.Debug.WriteLine("" + m_HilightThread.ThreadState.ToString());
      //if (m_HilightThread.ThreadState == System.Threading.ThreadState.Stopped ||
      //    m_HilightThread.ThreadState == System.Threading.ThreadState.Unstarted)
      //{
      //    m_HilightThread.Start();
      //}
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if (e.Control && e.KeyCode == Keys.V)
      {
        var rtb = new RichTextBox();
        rtb.Paste();
        SelectedText = rtb.Text;
        e.Handled = true;
      }

      _lastModification = DateTime.Now;
      _needHighLight = true;
      StartThread();
    }
    protected override void OnHScroll(EventArgs e)
    {
      base.OnHScroll(e);
      _lastModification = DateTime.Now;
      _needHighLight = true;
      StartThread();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      _lastModification = DateTime.Now;
      _needHighLight = true;
      StartThread();
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      _lastModification = DateTime.Now;
      _needHighLight = true;
      StartThread();
    }
    protected override void OnVScroll(EventArgs e)
    {
      base.OnVScroll(e);
      _lastModification = DateTime.Now;
      _needHighLight = true;
      StartThread();
    }
    private bool Modifying()
    {
      return (DateTime.Now - _lastModification).TotalMilliseconds < 500;
    }
    private int StopUpdateUi()
    {
      Win32.SendMessage(Handle, (int) Win32.WmConstants.WmSetredraw, 0, IntPtr.Zero);
      return Win32.SendMessage(Handle, Win32.EmGeteventmask, 0, IntPtr.Zero);
    }
    private void StartUpdateUi(int eventMask)
    {
      Win32.SendMessage(Handle, Win32.EmSeteventmask, 0, (IntPtr) eventMask);
      Win32.SendMessage(Handle, (int) Win32.WmConstants.WmSetredraw, 1, IntPtr.Zero);
    }
    private void HighLight(int selStart, int selEnd)
    {
      var iniScrollPos = ScrollPos;
      var iniSelectionStart = SelectionStart;
      var iniSelectionLength = SelectionLength;
      var eventMask = StopUpdateUi();
      try
      {
        Debug.WriteLine("**************************************************");
        Debug.WriteLine(selStart);
        Debug.WriteLine(selEnd);
        Debug.WriteLine(selStart < selEnd);
        Debug.WriteLine(HighlightSyntax);
        Debug.WriteLine(_needHighLight);
        while (selStart < selEnd && HighlightSyntax && _needHighLight)
        {
          while (selStart < selEnd && _tokenSeparators.BinarySearch(Text[selStart]) >= 0)
          {
            selStart++;
          }

          var selLength = 1;
          while (selStart + selLength < selEnd && _tokenSeparators.BinarySearch(Text[selStart + selLength]) < 0)
          {
            selLength++;
          }

          Select(selStart, selLength);
          var token = SelectedText;
          Debug.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@");
          Debug.WriteLine(token);
          Debug.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@");
          if (IsKeyword(token))
          {
            SelectionColor = Color.Blue;
          }
          else if (IsString(token))
          {
            SelectionColor = Color.Red;
          }
          else if (IsFunction(token))
          {
            SelectionColor = Color.Magenta;
          }
          else
          {
            SelectionColor = ForeColor;
          }

          selStart += token.Length;
          Application.DoEvents();
          Debug.WriteLine("--------------------------------------------------");
          Debug.WriteLine(selStart);
          Debug.WriteLine(selEnd);
          Debug.WriteLine(selStart < selEnd);
          Debug.WriteLine(HighlightSyntax);
          Debug.WriteLine(_needHighLight);
        }
      }
      finally
      {
        _needHighLight = _needHighLight && selStart < selEnd;
        Select(iniSelectionStart, iniSelectionLength);
        ScrollPos = iniScrollPos;
        StartUpdateUi(eventMask);
        Invalidate();
        //m_NeedHighLight = false;
      }
    }
    private void HighLight()
    {
      var start = GetFirstCharIndexFromLine(GetLineFromCharIndex(GetCharIndexFromPosition(new Point(0, 0))));
      var end = GetFirstCharIndexFromLine(GetLineFromCharIndex(GetCharIndexFromPosition(new Point(Width, Height))) + 1);
      if (end < 0)
      {
        end = GetFirstCharIndexFromLine(GetLineFromCharIndex(GetCharIndexFromPosition(new Point(Width, Height))));
      }

      HighLight(start, end);
    }
    private void m_HilightThread_TimerThreadJob(TimerThread instance, EventArgs args)
    {
    }
    private bool IsKeyword(string token)
    {
      return _keyWords.BinarySearch(token, StringComparer) > -1;
    }
    private bool IsFunction(string token)
    {
      return _functions.BinarySearch(token, StringComparer) > -1;
    }
    private bool IsString(string token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return false;
      }

      return token[0] == '\'';
    }
  }
}