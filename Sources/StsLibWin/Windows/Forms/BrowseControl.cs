using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class BrowseControl : UserControl
  {
    private Button _btnBrowse;
    private bool _changed;
    private TextBox _txtPath;
    protected BrowseControl()
    {
      InitializeComponent();
    }
    public string SelectedPath

    {
      get
      {
        _changed = false;
        return _txtPath.Text;
      }
      set
      {
        _txtPath.Text = value;
        _changed = false;
      }
    }
    public event EventHandler PathChanged;
    private void CallOnPathChanged()
    {
      if (_changed)
      {
        OnPathChanged();
      }
    }
    protected virtual void OnPathChanged()
    {
      StsLib.Delegates.Utils.RaiseEvent(PathChanged, this, new EventArgs());
    }
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
      _changed = true;
      _txtPath.Text = r.Item2;
      _txtPath.Focus();
      CallOnPathChanged();
    }
    private void _txtPath_DoubleClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(_txtPath.Text))
      {
        if (Directory.Exists(_txtPath.Text))
        {
          StsLib.Diagnostics.Process.ShellExecute(_txtPath.Text);
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
      _txtPath.TextChanged += _txtPath_TextChanged;
      _txtPath.DoubleClick += _txtPath_DoubleClick;
      _txtPath.Validated += _txtPath_Validated;
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

    private void _txtPath_TextChanged(object sender, EventArgs e)
    {
      _changed = true;
    }

    private void _txtPath_Validated(object sender, EventArgs e)
    {
      CallOnPathChanged();
    }
  }
}