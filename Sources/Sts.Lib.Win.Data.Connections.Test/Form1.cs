using System;
using System.Windows.Forms;
using Sts.Lib.Win.Data.Connections.SqlServer;
using Sts.Lib.Win.Windows.Forms.Data;

namespace Sts.Lib.Win.Data.Connections.Test;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        textBox1.ConnectionStringBuilders.AddRange(new DatabaseConnectionBuilderBase[]
        {
            new DatabaseConnectionBuilder(),
            new Postgres.DatabaseConnectionBuilder(),
            new Oracle.DatabaseConnectionBuilder(),
            new SqLite.DatabaseConnectionBuilder(),
            new OleDB.DatabaseConnectionBuilder()
        });
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            using var db = textBox1.ConnectionString.CreateAndOpenConnection();
            MessageBox.Show("Ok");
        }
        catch
        {
            MessageBox.Show("Error");
        }
    }
}
