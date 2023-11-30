using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Diagnostics;

namespace Sts.Lib.Win.Windows.Forms;

public class BrowseControl : TxtButtonControl
{
    public delegate void OnBeforeFileDropDelegate(object sender, BeforeFileDropEventArgs beforeFileDropEventArgs);

    public delegate void OnFileDropDelegate(object sender, FileDropEventArgs fileDropEventArgs);

    private const string ClipboardFormat = "FileDrop";
    private bool _changed;

    protected BrowseControl()
    { }

    public string SelectedPath
    {
        get
        {
            _changed = false;
            return base.Text;
        }
        set
        {
            base.Text = value;
            _changed = false;
        }
    }

    protected override void InitializeComponent()
    {
        base.InitializeComponent();
    }

    protected override void OnDragEnter(DragEventArgs drgevent)
    {
        base.OnDragEnter(drgevent);
        var dropEventArgs =
            BeforeFileDropEventArgs.Create(drgevent.Data.GetData(ClipboardFormat) as string[] ?? Array.Empty<string>());
        OnBeforeFileDrop(dropEventArgs);
        drgevent.Effect = dropEventArgs.Cancel ? DragDropEffects.None : DragDropEffects.Copy;
    }

    protected virtual void OnBeforeFileDrop(BeforeFileDropEventArgs beforeFileDropEventArgs)
    {
        BeforeFileDrop?.Invoke(this, beforeFileDropEventArgs);
    }

    public event OnBeforeFileDropDelegate BeforeFileDrop;
    public event OnFileDropDelegate FileDrop;

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
        base.OnDragDrop(drgevent);
        var fileDropEventArgs =
            FileDropEventArgs.Create((drgevent.Data.GetData(ClipboardFormat) as string[] ?? Array.Empty<string>())
                                    .ToList());
        OnFileDrop(fileDropEventArgs);
        txt.Text = fileDropEventArgs.Files.Aggregate("", (s, f) => $"{s}{f};").Trim(';');
    }

    protected virtual void OnFileDrop(FileDropEventArgs filePaths)
    {
        FileDrop?.Invoke(this, filePaths);
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
        PathChanged?.Invoke(this, new EventArgs());
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
        Text = r.Item2;
        CallOnPathChanged();
    }

    protected override void OnTxtDblClick()
    {
        if (!string.IsNullOrEmpty(Text))
        {
            if (Directory.Exists(Text))
            {
                ProcessUtils.ShellExecute(Text);
            }

            return;
        }

        ShowDialog();
    }

    protected override void OnBtnClick()
    {
        ShowDialog();
    }

    protected override void OnTextChanged()
    {
        _changed = true;
    }

    protected override void OnTextValidated()
    {
        CallOnPathChanged();
    }

    public sealed class BeforeFileDropEventArgs : EventArgs
    {
        private BeforeFileDropEventArgs(string[] files)
        {
            Files = files;
        }

        public bool Cancel
        {
            get;
            set;
        }

        public string[] Files
        {
            get;
        }

        public static BeforeFileDropEventArgs Create(string[] files)
        {
            return new BeforeFileDropEventArgs(files);
        }
    }

    public sealed class FileDropEventArgs : EventArgs
    {
        private FileDropEventArgs(List<string> files)
        {
            Files = files;
        }

        public List<string> Files
        {
            get;
        }

        public static FileDropEventArgs Create(List<string> files)
        {
            return new FileDropEventArgs(files);
        }
    }
}
