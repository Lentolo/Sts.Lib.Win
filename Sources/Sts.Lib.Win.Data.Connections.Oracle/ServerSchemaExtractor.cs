using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Sts.Lib.Collections.Generic;
using Sts.Lib.Common;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Data.Schema;
using Sts.Lib.Linq.Extensions;
using Utils = Sts.Lib.Text.RegularExpressions.Utils;

namespace Sts.Lib.Win.Data.Connections.Oracle
{
    public class ServerSchemaExtractor : IServerSchemaExtractor
    {
        private readonly IDbConnection _dbConnection;
        private readonly ISqlConverter _sqlConverter;

        private readonly ReadonlyTimeExpireValue<List<(string TABLE_NAME, string COLUMN_NAME, string DATA_TYPE, string
            DATA_TYPE_MOD, string DATA_TYPE_OWNER, decimal DATA_LENGTH, decimal? DATA_PRECISION, decimal? DATA_SCALE,
            string NULLABLE, decimal? COLUMN_ID, decimal? DEFAULT_LENGTH, string DATA_DEFAULT, decimal? NUM_DISTINCT,
            byte[] LOW_VALUE, byte[] HIGH_VALUE, decimal? DENSITY, decimal? NUM_NULLS, decimal? NUM_BUCKETS, DateTime?
            LAST_ANALYZED, decimal? SAMPLE_SIZE, string CHARACTER_SET_NAME, decimal? CHAR_COL_DECL_LENGTH, string
            GLOBAL_STATS, string USER_STATS, decimal? AVG_COL_LEN, decimal? CHAR_LENGTH, string CHAR_USED, string
            V80_FMT_IMAGE, string DATA_UPGRADED, string HISTOGRAM)>> _tableColumns;

        internal ServerSchemaExtractor(IDbConnection dbConnection, ISqlConverter sqlConverter)
        {
            _sqlConverter = sqlConverter;
            _dbConnection = dbConnection;
            _tableColumns =
                new ReadonlyTimeExpireValue<List<(string TABLE_NAME, string COLUMN_NAME, string DATA_TYPE, string
                        DATA_TYPE_MOD, string DATA_TYPE_OWNER, decimal DATA_LENGTH, decimal? DATA_PRECISION, decimal?
                        DATA_SCALE, string NULLABLE, decimal? COLUMN_ID, decimal? DEFAULT_LENGTH, string DATA_DEFAULT,
                        decimal? NUM_DISTINCT, byte[] LOW_VALUE, byte[] HIGH_VALUE, decimal? DENSITY, decimal? NUM_NULLS
                        ,
                        decimal? NUM_BUCKETS, DateTime? LAST_ANALYZED, decimal? SAMPLE_SIZE, string CHARACTER_SET_NAME,
                        decimal? CHAR_COL_DECL_LENGTH, string GLOBAL_STATS, string USER_STATS, decimal? AVG_COL_LEN,
                        decimal
                        ? CHAR_LENGTH, string CHAR_USED, string V80_FMT_IMAGE, string DATA_UPGRADED, string HISTOGRAM)>
                >(60);
            _tableColumns.ExpiredValue += _tableColumns_ExpiredValue;
        }

        public string GetDatabaseName()
        {
            return _dbConnection.ExecuteReaderAndMap("SELECT USER AS NAME FROM DUAL", r => r["NAME"] as string)
                .FirstOrDefault() ?? "";
        }

        public Version GetServerVersion()
        {
            Version.TryParse(
                Utils.MatchOrDefault(
                    _dbConnection.ExecuteReaderAndMap("SELECT version FROM V$INSTANCE", r => r["version"] as string)
                        .FirstOrDefault() ?? "", "(?i)[0-9]+(\\.[0-9]+)+", ""), out var ver);
            return ver;
        }

        public ReadOnlyCollection<ColumnItem> GetTableColumns(Table table)
        {
            var types = _dbConnection
                .ExecuteTable($"select * from {_sqlConverter.WrapIdentifier(table.Name)} where 0<>0").Columns
                .OfType<DataColumn>().ToCaseInsensitiveDictionary(c => c.ColumnName, c => c.DataType, null);
            return _tableColumns.Value
                .Where(i => string.Compare(i.TABLE_NAME, table.Name, StringComparison.OrdinalIgnoreCase) == 0).Select(
                    r => new ColumnItem(r.COLUMN_NAME, types[r.COLUMN_NAME], r.DATA_TYPE, r.NULLABLE == "Y",
                        (long) r.DATA_LENGTH, (long?) r.DATA_PRECISION ?? 0, (long?) r.DATA_SCALE ?? 0, r.DATA_DEFAULT,
                        false)).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<ForeignKeyItem> GetTableForeignKeysOne(Table table)
        {
            return null;
        }

        public ReadOnlyCollection<ForeignKeyItem> GetTableForeignKeysMany(Table table)
        {
            return null;
        }

        public ReadOnlyCollection<UniqueKeyItem> GetTableUniqueKeys(Table table)
        {
            return null;
        }

        public ReadOnlyCollection<Tuple<string, CaseInsensitiveDictionary<string>>> GetDatabaseTables(Database database)
        {
            return _dbConnection
                .ExecuteReaderAndMap("SELECT * FROM user_tables",
                    r => (TABLE_NAME: r["TABLE_NAME"] as string, TABLESPACE_NAME: r["TABLESPACE_NAME"] as string,
                        CLUSTER_NAME: r["CLUSTER_NAME"] as string, IOT_NAME: r["IOT_NAME"] as string,
                        STATUS: r["STATUS"] as string, PCT_FREE: r["PCT_FREE"] as decimal?,
                        PCT_USED: r["PCT_USED"] as decimal?, INI_TRANS: r["INI_TRANS"] as decimal?,
                        MAX_TRANS: r["MAX_TRANS"] as decimal?, INITIAL_EXTENT: r["INITIAL_EXTENT"] as decimal?,
                        NEXT_EXTENT: r["NEXT_EXTENT"] as decimal?, MIN_EXTENTS: r["MIN_EXTENTS"] as decimal?,
                        MAX_EXTENTS: r["MAX_EXTENTS"] as decimal?, PCT_INCREASE: r["PCT_INCREASE"] as decimal?,
                        FREELISTS: r["FREELISTS"] as decimal?, FREELIST_GROUPS: r["FREELIST_GROUPS"] as decimal?,
                        LOGGING: r["LOGGING"] as string, BACKED_UP: r["BACKED_UP"] as string,
                        NUM_ROWS: r["NUM_ROWS"] as decimal?, BLOCKS: r["BLOCKS"] as decimal?,
                        EMPTY_BLOCKS: r["EMPTY_BLOCKS"] as decimal?, AVG_SPACE: r["AVG_SPACE"] as decimal?,
                        CHAIN_CNT: r["CHAIN_CNT"] as decimal?, AVG_ROW_LEN: r["AVG_ROW_LEN"] as decimal?,
                        AVG_SPACE_FREELIST_BLOCKS: r["AVG_SPACE_FREELIST_BLOCKS"] as decimal?,
                        NUM_FREELIST_BLOCKS: r["NUM_FREELIST_BLOCKS"] as decimal?, DEGREE: r["DEGREE"] as string,
                        INSTANCES: r["INSTANCES"] as string, CACHE: r["CACHE"] as string,
                        TABLE_LOCK: r["TABLE_LOCK"] as string, SAMPLE_SIZE: r["SAMPLE_SIZE"] as decimal?,
                        LAST_ANALYZED: r["LAST_ANALYZED"] as DateTime?, PARTITIONED: r["PARTITIONED"] as string,
                        IOT_TYPE: r["IOT_TYPE"] as string, TEMPORARY: r["TEMPORARY"] as string,
                        SECONDARY: r["SECONDARY"] as string, NESTED: r["NESTED"] as string,
                        BUFFER_POOL: r["BUFFER_POOL"] as string, ROW_MOVEMENT: r["ROW_MOVEMENT"] as string,
                        GLOBAL_STATS: r["GLOBAL_STATS"] as string, USER_STATS: r["USER_STATS"] as string,
                        DURATION: r["DURATION"] as string, SKIP_CORRUPT: r["SKIP_CORRUPT"] as string,
                        MONITORING: r["MONITORING"] as string, CLUSTER_OWNER: r["CLUSTER_OWNER"] as string,
                        DEPENDENCIES: r["DEPENDENCIES"] as string, COMPRESSION: r["COMPRESSION"] as string,
                        COMPRESS_FOR: r["COMPRESS_FOR"] as string, DROPPED: r["DROPPED"] as string,
                        READ_ONLY: r["READ_ONLY"] as string)).Select(i => Tuple.Create(i.TABLE_NAME,
                    new[] {(Key: "TABLESPACE_NAME", Val: i.TABLESPACE_NAME)}.ToCaseInsensitiveDictionary(j => j.Key,
                        j => j.Val, ""))).ToList().AsReadOnly();
        }

        private void _tableColumns_ExpiredValue(object sender,
            DataArgs<List<(string TABLE_NAME, string COLUMN_NAME, string DATA_TYPE, string DATA_TYPE_MOD, string
                DATA_TYPE_OWNER, decimal DATA_LENGTH, decimal? DATA_PRECISION, decimal? DATA_SCALE, string NULLABLE,
                decimal? COLUMN_ID, decimal? DEFAULT_LENGTH, string DATA_DEFAULT, decimal? NUM_DISTINCT, byte[]
                LOW_VALUE, byte[] HIGH_VALUE, decimal? DENSITY, decimal? NUM_NULLS, decimal? NUM_BUCKETS, DateTime?
                LAST_ANALYZED, decimal? SAMPLE_SIZE, string CHARACTER_SET_NAME, decimal? CHAR_COL_DECL_LENGTH, string
                GLOBAL_STATS, string USER_STATS, decimal? AVG_COL_LEN, decimal? CHAR_LENGTH, string CHAR_USED, string
                V80_FMT_IMAGE, string DATA_UPGRADED, string HISTOGRAM)>> eventArg)
        {
            eventArg.Data = _dbConnection.ExecuteReaderAndMap("SELECT * FROM USER_TAB_COLUMNS",
                r => (TABLE_NAME: r["TABLE_NAME"] as string, COLUMN_NAME: r["COLUMN_NAME"] as string,
                    DATA_TYPE: r["DATA_TYPE"] as string, DATA_TYPE_MOD: r["DATA_TYPE_MOD"] as string,
                    DATA_TYPE_OWNER: r["DATA_TYPE_OWNER"] as string, DATA_LENGTH: (decimal) r["DATA_LENGTH"],
                    DATA_PRECISION: r["DATA_PRECISION"] as decimal?, DATA_SCALE: r["DATA_SCALE"] as decimal?,
                    NULLABLE: r["NULLABLE"] as string, COLUMN_ID: r["COLUMN_ID"] as decimal?,
                    DEFAULT_LENGTH: r["DEFAULT_LENGTH"] as decimal?, DATA_DEFAULT: r["DATA_DEFAULT"] as string,
                    NUM_DISTINCT: r["NUM_DISTINCT"] as decimal?, LOW_VALUE: r["LOW_VALUE"] as byte[],
                    HIGH_VALUE: r["HIGH_VALUE"] as byte[], DENSITY: r["DENSITY"] as decimal?,
                    NUM_NULLS: r["NUM_NULLS"] as decimal?, NUM_BUCKETS: r["NUM_BUCKETS"] as decimal?,
                    LAST_ANALYZED: r["LAST_ANALYZED"] as DateTime?, SAMPLE_SIZE: r["SAMPLE_SIZE"] as decimal?,
                    CHARACTER_SET_NAME: r["CHARACTER_SET_NAME"] as string,
                    CHAR_COL_DECL_LENGTH: r["CHAR_COL_DECL_LENGTH"] as decimal?,
                    GLOBAL_STATS: r["GLOBAL_STATS"] as string, USER_STATS: r["USER_STATS"] as string,
                    AVG_COL_LEN: r["AVG_COL_LEN"] as decimal?, CHAR_LENGTH: r["CHAR_LENGTH"] as decimal?,
                    CHAR_USED: r["CHAR_USED"] as string, V80_FMT_IMAGE: r["V80_FMT_IMAGE"] as string,
                    DATA_UPGRADED: r["DATA_UPGRADED"] as string, HISTOGRAM: r["HISTOGRAM"] as string)).ToList();
        }
    }
}