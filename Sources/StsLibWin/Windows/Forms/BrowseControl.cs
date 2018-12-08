using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StsLib.Diagnostics;

namespace StsLibWin.Windows.Forms
{
  public class BrowseControl : UserControl
  {
    private Button _btnBrowse;
    private TextBox _txtPath;
    protected BrowseControl()
    {
      InitializeComponent();
    }
    public string SelectedPath => _txtPath.Text;
    private void _btnBrowse_Click(object sender, EventArgs e)
    {
      ShowDialog();
    }
    protected virtual (bool, string) OnShowDialog()
    {
      return (false, "");
    }
    private void ShowDialog()
    {
      var r = OnShowDialog();
      if (!r.Item1)
      {
        return;
      }

      _txtPath.Text = r.Item2;
      _txtPath.Focus();
    }
    private void _txtPath_DoubleClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(_txtPath.Text))
      {
        if (Directory.Exists(_txtPath.Text))
        {
          Process.ShellExecute(_txtPath.Text);
        }

        return;
      }

      ShowDialog();
    }
    private void InitializeComponent()
    {
      _btnBrowse = new Button();
      _txtPath = new TextBox();
      SuspendLayout();
      // 
      // _btnBrowse
      // 
      _btnBrowse.Dock = DockStyle.Right;
      _btnBrowse.Location = new Point(664, 0);
      _btnBrowse.Name = "_btnBrowse";
      _btnBrowse.Size = new Size(30, 22);
      _btnBrowse.TabIndex = 1;
      _btnBrowse.Text = "...";
      _btnBrowse.UseVisualStyleBackColor = true;
      _btnBrowse.Click += _btnBrowse_Click;
      // 
      // _txtPath
      // 
      _txtPath.Dock = DockStyle.Fill;
      _txtPath.Location = new Point(0, 0);
      _txtPath.Margin = new Padding(0);
      _txtPath.Multiline = true;
      _txtPath.Name = "_txtPath";
      _txtPath.Size = new Size(664, 22);
      _txtPath.TabIndex = 2;
      _txtPath.DoubleClick += _txtPath_DoubleClick;
      // 
      // BrowseControl
      // 
      Controls.Add(_txtPath);
      Controls.Add(_btnBrowse);
      Margin = new Padding(0);
      Name = "BrowseControl";
      Size = new Size(694, 22);
      ResumeLayout(false);
      PerformLayout();
    }
  }
}