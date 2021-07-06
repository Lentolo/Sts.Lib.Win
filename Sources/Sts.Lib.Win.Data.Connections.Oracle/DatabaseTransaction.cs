using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Sts.Lib.Data;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;

namespace Sts.Lib.Win.Data.Connections.Oracle
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