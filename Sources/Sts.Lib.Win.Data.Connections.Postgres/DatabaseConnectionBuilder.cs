using System.Data;
using System.Linq;
using Sts.Lib.Data;
using Sts.Lib.Data.Connections.Postgres;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Win.Windows.Forms.Data;

namespace Sts.Lib.Win.Data.Connections.Postgres;

public class DatabaseConnectionBuilder : CommonDatabaseConnectionBuilderBase
{
    public DatabaseConnectionBuilder():base()
    {
        this.TxtPort.Text = "5432";
    }

    public override GenericConnectionString ConnectionString
    {
        get
        {
            var builder = new Npgsql.NpgsqlConnectionStringBuilder
            {
                Username = TxtUid.Text,
                Host = TxtSrv.Text
            };

            if (!string.IsNullOrEmpty(TxtPwd.Text))
            {
                builder.Password= TxtPwd.Text;
            }

            if (!string.IsNullOrEmpty(TxtPort.Text) && Sts.Lib.Common.Convert.Utils.TryParseTo( TxtPort.Text ,5432) != 5432)
            {
                builder.Port+=  Sts.Lib.Common.Convert.Utils.TryParseTo( TxtPort.Text ,5432) ;
            }

            if (!string.IsNullOrEmpty(CmbDB.SelectedItem as string))
            {
                builder.Database+= CmbDB.SelectedItem as string;
            }

            return new GenericConnectionString(typeof(PostgresEnhancedConnection), builder.ConnectionString);
        }
    }

    public override string DatabaseTypeName
    {
        get { return "Postgres"; }
    }

    protected override string[] GetDatabases(IEnhancedDbConnection db)
    {
        return db
              .ExecuteReaderAndMap("SELECT datname FROM pg_database;", r => r["datname"] as string)
              .OrderBy(i => i.ToLowerInvariant()).ToArray();
    }
}