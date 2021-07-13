using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data;
using Sts.Lib.Data.Connections.Postgres;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Win.Windows.Forms.Data;
using Sts.Lib.Win.Windows.Forms.Extensions;
using ComboBox = Sts.Lib.Win.Windows.Forms.ComboBox;
using Label = Sts.Lib.Win.Windows.Forms.Label;
using TextBox = Sts.Lib.Win.Windows.Forms.TextBox;

namespace Sts.Lib.Win.Data.Connections.Postgres
{
    public class DatabaseConnectionBuilder : CommonDatabaseConnectionBuilderBase
    {
        public DatabaseConnectionBuilder():base()
        {
            this.TxtPort.Text = "5432";
        }

        protected override IDbConnection OpenConnection()
        {
            var db = new Npgsql.NpgsqlConnection
            {
                ConnectionString = ConnectionStringNoProvider
            };
            db.Open();
            return db;
        }

        public override string ConnectionString
        {
            get
            {
                return DatabaseConnectionUtils.DBProvider + "=" +
                       typeof(Npgsql.NpgsqlConnection).FullName + ";" +
                       ConnectionStringNoProvider;
            }
        }

        public override string ConnectionStringNoProvider
        {
            get
            {
                var connectionStringNoProvider = $"User ID={TxtUid.Text};Host={TxtSrv.Text};";
                if (!string.IsNullOrEmpty(TxtPwd.Text))
                {
                    connectionStringNoProvider += $"Password={TxtPwd.Text};";
                }

                if (!string.IsNullOrEmpty(TxtPort.Text) && TxtPort.Text != "5432")
                {
                    connectionStringNoProvider += $"Port={TxtPort.Text};";
                }

                if (!string.IsNullOrEmpty(CmbDB.SelectedItem as string))
                {
                    connectionStringNoProvider += $"Database={CmbDB.SelectedItem as string};";
                }

                return connectionStringNoProvider;
            }
        }

        public override string DatabaseTypeName
        {
            get { return "Postgres"; }
        }

        public override Type DatabaseConnectionType
        {
            get { return typeof(Npgsql.NpgsqlConnection); }
        }

        protected override string[] GetDatabases(IDbConnection db)
        {
            return db
                .ExecuteReaderAndMap("SELECT datname FROM pg_database;", r => r["datname"] as string)
                .OrderBy(i => i.ToLowerInvariant()).ToArray();
        }
    }
}