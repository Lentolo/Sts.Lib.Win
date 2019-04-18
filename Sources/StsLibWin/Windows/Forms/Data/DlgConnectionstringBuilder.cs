using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms.Data
{
  public partial class DlgConnectionstringBuilder : Form
  {
    public DlgConnectionstringBuilder()
    {
      InitializeComponent();
    }
    public string Connectionstring
    {
      get;
      private set;
    }
    public string ConnectionStringNoProvider
    {
      get;
      private set;
    }
    private DatabaseConnectionBuilderBase CurrentControl
    {
      get
      {
        return GrpControl.Controls.OfType<DatabaseConnectionBuilderBase>().FirstOrDefault(c => string.Compare(c.DatabaseTypeName, CmbCnType.SelectedItem as string, StringComparison.OrdinalIgnoreCase) == 0);
      }
    }
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
      foreach (var ctl in StsLib.Reflection.Utils.LoadTypesFromFolder(Path.GetDirectoryName(GetType().Assembly.Location), type => type != builderType && StsLib.Linq.Utils.GetAncestorsUntil(type, t => t.BaseType, t => t != null).Any(t => builderType.FullName == t.FullName) && type.GetConstructors().Any(c => !c.GetParameters().Any())).Select(T => StsLib.Reflection.Utils.CreateInstance<DatabaseConnectionBuilderBase>(T)))
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
      if (DialogResult == DialogResult.OK)
      {
        e.Cancel = !(CurrentControl?.Test() ?? false);
        if (e.Cancel)
        {
          System.Windows.Forms.MessageBox.Show(this, "Invalid connection string", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
          Connectionstring = CurrentControl?.ConnectionString;
          ConnectionStringNoProvider = CurrentControl?.ConnectionStringNoProvider;
        }
      }
    }
    private void BtnTest_Click(object sender, EventArgs e)
    {
      bool? val;
      if ((val = CurrentControl?.Test()) != null)
      {
        if (val.Value)
        {
          System.Windows.Forms.MessageBox.Show(this, "Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          System.Windows.Forms.MessageBox.Show(this, "Unable to connect", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
      {
        System.Windows.Forms.MessageBox.Show(this, "No database selected", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
}