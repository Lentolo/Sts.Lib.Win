using System.Data.SqlClient;
using System.Linq;
using Sts.Lib.Data;
using Sts.Lib.Data.Connections.SqlServer;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Win.Windows.Forms.Data;

namespace Sts.Lib.Win.Data.Connections.SqlServer
{
    public class DatabaseConnectionBuilder : CommonDatabaseConnectionBuilderBase
    {
        public override GenericConnectionString ConnectionString
        {
            get
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = TxtSrv.Text,
                    MultipleActiveResultSets = true
                };

                if (!string.IsNullOrEmpty(TxtPort.Text) && Common.Convert.Utils.TryParseTo(TxtPort.Text, 1433) != 1433)
                {
                    builder.DataSource = $"{TxtSrv.Text},{TxtPort.Text}";
                }

                if (!string.IsNullOrEmpty(TxtPwd.Text))
                {
                    builder.Password = TxtPwd.Text;
                }

                if (!string.IsNullOrEmpty(CmbDB.SelectedItem as string))
                {
                    builder.InitialCatalog = CmbDB.SelectedItem as string;
                }

                return new GenericConnectionString(typeof(SqlServerEnhancedConnection), builder.ConnectionString);
            }
        }

        public override string DatabaseTypeName
        {
            get
            {
                return "Sql Server";
            }
        }

        protected override string[] GetDatabases(IEnhancedDbConnection db)
        {
            return db.ExecuteReaderAndMap("SELECT NAME FROM SYS.DATABASES;", r => r["NAME"] as string).ToArray();
        }
    }
}
