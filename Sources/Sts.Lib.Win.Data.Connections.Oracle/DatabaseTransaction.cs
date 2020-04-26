using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using StsLib.Data;
using StsLib.Data.Generic;
using StsLib.Data.Interfaces;

namespace StsLibWin.Data.Connections.Oracle
{
  public class DatabaseTransaction : GenericDatabaseTransaction<OracleTransaction>
  {
    public DatabaseTransaction(OracleTransaction dbTransaction, ISqlConverter toSqlConverter, ISqlExpressionHelper sqlExpressionHelper)
        : base(dbTransaction, toSqlConverter,sqlExpressionHelper)
    {
    }
    public override IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel)
    {
      throw new NotImplementedException();
    }
    public override IDatabaseTransaction BeginTransaction()
    {
      throw new NotImplementedException();
    }
    public override string GetDbConnectionType()
    {
      return "Oracle";
    }
  }
}