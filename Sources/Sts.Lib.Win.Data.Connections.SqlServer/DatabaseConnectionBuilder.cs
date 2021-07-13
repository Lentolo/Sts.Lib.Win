using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data.Connections.SqlServer;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Win.Windows.Forms.Data;
using Sts.Lib.Win.Windows.Forms.Extensions;
using ComboBox = Sts.Lib.Win.Windows.Forms.ComboBox;
using Label = Sts.Lib.Win.Windows.Forms.Label;
using TextBox = Sts.Lib.Win.Windows.Forms.TextBox;

namespace Sts.Lib.Win.Data.Connections.SqlServer
{
    public class DatabaseConnectionBuilder : DatabaseConnectionBuilderBase1
    {
        public DatabaseConnectionBuilder() : base()
        {
        }

        public override string ConnectionString
        {
            get
            {
                return Sts.Lib.Data.DatabaseConnectionUtils.DBProvider + "=" + typeof(SqlConnection).FullName + ";" +
                       ConnectionStringNoProvider;
            }
        }

        public override string ConnectionStringNoProvider
        {
            get
            {
                var connectionStringNoProvider =
                    $"MultipleActiveResultSets=True;User ID={TxtUid.Text};Server={TxtSrv.Text};";
                if (!string.IsNullOrEmpty(TxtPort.Text) && TxtPort.Text != "1433")
                {
                    connectionStringNoProvider = $"User ID={TxtUid.Text};Server={TxtSrv.Text},{TxtPort.Text};";
                }

                if (!string.IsNullOrEmpty(TxtPwd.Text))
                {
                    connectionStringNoProvider += $"Password={TxtPwd.Text};";
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
            get { return "Sql Server"; }
        }

        public override Type DatabaseConnectionType
        {
            get { return typeof(SqlConnection); }
        }

        public override bool Test()
        {
            try
            {
                using var db = OpenConnection();
                return true;
            }
            catch
            {
            }

            return false;
        }

        private IDbConnection OpenConnection()
        {
            var db = new SqlConnection(ConnectionStringNoProvider);
            db.Open();
            return db;
        }

        protected override void FillCombo()
        {
            if (CmbDB.Items.Count == 0 && !string.IsNullOrEmpty(TxtSrv.Text) && !string.IsNullOrEmpty(TxtUid.Text))
            {
                try
                {
                    using var db = OpenConnection();
                    CmbDB.Items.AddRange(db
                        .ExecuteReaderAndMap("SELECT NAME FROM SYS.DATABASES;", r => r["NAME"] as string)
                        .ToArray());
                }
                catch
                {
                }
            }
        }
    }
}