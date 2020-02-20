using System.Data;
using Oracle.ManagedDataAccess.Client;
using StsLib.Data;
using StsLib.Data.Generic;
using StsLib.Data.Interfaces;
using StsLib.Data.Schema;

namespace StsLibWin.Data.Connections.Oracle
{
    [ConnectionProviderName("StsOracle", "Sts Connection for Oracle")]
    public class DatabaseConnection : GenericDatabaseConnection<OracleConnection>
    {
        public override Database DatabaseSchema => new Database(new ServerSchemaExtractor(this));
        public DatabaseConnection()
        : this(new OracleConnection())
        {
        }
        public DatabaseConnection(OracleConnection dbConnection)
            : base(dbConnection, new SqlConverter(), new GenericSqlExpressionHelper())
        {
        }
        public static DatabaseConnection CreateAndOpen(string connectionString)
        {
            var rVal = new DatabaseConnection(new OracleConnection(connectionString));
            rVal.Open();
            return rVal;
        }
        public override IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new DatabaseTransaction(DbConnection.BeginTransaction(isolationLevel), SqlConverter, SqlExpressionHelper);
        }
        public override IDatabaseTransaction BeginTransaction()
        {
            return BeginTransaction(IsolationLevel.ReadCommitted);
        }
        public override string GetDbConnectionType()
        {
            return "Oracle";
        }
    }
}