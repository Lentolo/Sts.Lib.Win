using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Common.Extensions;
using Sts.Lib.Data;

namespace Sts.Lib.Win.Windows.Forms.Data;

public partial class DlgConnectionstringBuilder : Form
{
    public DlgConnectionstringBuilder()
    {
        InitializeComponent();
    }

    public GenericConnectionString ConnectionString
    {
        get;
        private set;
    }

    private DatabaseConnectionBuilderBase CurrentControl
    {
        get
        {
            return GrpControl.Controls.OfType<DatabaseConnectionBuilderBase>()
                             .FirstOrDefault(c => c.DatabaseTypeName.EqualsNoCase(CmbCnType.SelectedItem as string));
        }
    }

    public List<DatabaseConnectionBuilderBase> ConnectionStringBuilders
    {
        get;
    } = new();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadCombo();
    }

    private void LoadCombo()
    {
        GrpControl.SuspendLayout();
        CmbCnType.Items.Clear();
        GrpControl.Controls.Clear();
        var builderType = typeof(DatabaseConnectionBuilderBase);
        var connectionBuilders = ConnectionStringBuilders;

        if (!connectionBuilders.Any())
        {
            connectionBuilders = Reflection.Utils
                                           .LoadTypesFromFolder(Path.GetDirectoryName(GetType().Assembly.Location),
                                                                type => type != builderType
                                                                        && Linq.Utils.GetAncestorsWhile(type, t => t.BaseType, t => t != null)
                                                                               .Any(t => builderType.FullName == t.FullName)
                                                                        && type.GetConstructors().Any(c => !c.GetParameters().Any())).Select(T =>
                                                                                                                                                 Reflection.Utils.CreateInstance<DatabaseConnectionBuilderBase>(T)).ToList();
        }

        foreach (var ctl in connectionBuilders)
        {
            CmbCnType.Items.Add(ctl.DatabaseTypeName);
            ctl.Visible = false;
            ctl.Location = new Point(0, 0);
            ctl.Dock = DockStyle.Fill;
            GrpControl.Controls.Add(ctl);
        }

        GrpControl.ResumeLayout();
        GrpControl.PerformLayout();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        if (DialogResult != DialogResult.OK)
        {
            return;
        }

        e.Cancel = CurrentControl != null && !CurrentControl.Test();

        if (e.Cancel)
        {
            System.Windows.Forms.MessageBox.Show(this, "Invalid connection string", "", MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);
        }
        else
        {
            ConnectionString = CurrentControl?.ConnectionString;
        }
    }

    private void BtnTest_Click(object sender, EventArgs e)
    {
        bool? val;

        if ((val = CurrentControl?.Test()) != null)
        {
            if (val.Value)
            {
                System.Windows.Forms.MessageBox.Show(this, "Connected", "", MessageBoxButtons.OK,
                                                     MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, "Unable to connect", "", MessageBoxButtons.OK,
                                                     MessageBoxIcon.Exclamation);
            }
        }
        else
        {
            System.Windows.Forms.MessageBox.Show(this, "No database selected", "", MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
        }
    }

    private void CmbCnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (var c in GrpControl.Controls.OfType<DatabaseConnectionBuilderBase>())
        {
            c.Visible = c.DatabaseTypeName == CmbCnType.SelectedItem as string;
        }
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
