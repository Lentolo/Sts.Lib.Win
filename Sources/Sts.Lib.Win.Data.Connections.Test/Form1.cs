using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Win.Data.Connections.Postgres;
using Sts.Lib.Win.Windows.Forms.Data;
using StsLibWin.Data.Connections.Oracle;

namespace Sts.Lib.Win.Data.Connections.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.ConnectionStringBuilders.AddRange(new DatabaseConnectionBuilderBase[]{
                new   Sts.Lib.Win.Data.Connections.SqlServer.DatabaseConnectionBuilder(),
                new Sts.Lib.Win.Data.Connections.Postgres.DatabaseConnectionBuilder(),
                new StsLibWin.Data.Connections.Oracle.  DatabaseConnectionBuilder(),
                new StsLibWin.Data.Connections.SqLite.DatabaseConnectionBuilder(),
                new StsLibWin.Data.Connections.OleDB.DatabaseConnectionBuilder(),
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = textBox1.CreateAndOpenConnection();
                MessageBox.Show("Ok");
            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }
    }
}
