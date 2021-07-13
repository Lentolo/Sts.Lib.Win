using System;
using Oracle.ManagedDataAccess.Client;
using Sts.Lib.Data;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Data.Schema;

namespace Sts.Lib.Win.Data.Connections.Oracle
{
    [DbProvider("Sts.Db.Oracle")]
    public class OracleEnhancedConnection : EnhancedDbConnectionBase<OracleConnection>
    {
        public override IServerSchemaExtractor ServerSchemaExtractor
        {
            get
            {
                return new ServerSchemaExtractor(this, SqlConverter);
            }
        }

        public override ISqlConverter SqlConverter
        {
            get;
        } = new SqlConverter();

        public override ISqlExpressionHelper SqlExpressionHelper
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}