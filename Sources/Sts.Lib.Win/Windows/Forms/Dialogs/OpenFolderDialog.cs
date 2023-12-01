using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Common.Extensions;
using Sts.Lib.IO.Extensions;
using Sts.Lib.IO.PathSystems;
using Sts.Lib.Linq.Extensions;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Dialogs;

internal partial class OpenFolderDialog : Form
{
    private const string ImageKeyFolder = "folder";
    private const string ImageKeyOpenFolder = "open-folder";
    private const string ImageKeyDrive = "hdd";
    private bool _checkBoxes;
    private bool _currentPathChanged;

    public OpenFolderDialog()
    {
        InitializeComponent();
        InitializeDialog();
    }

    public bool CheckBoxes
    {
        get
        {
            return lvFolders.CheckBoxes;
        }
        set
        {
            _checkBoxes = value;
            lvFolders.CheckBoxes = _checkBoxes && lvFolders.MultiSelect;
        }
    }

    public bool MultiSelect
    {
        get
        {
            return lvFolders.MultiSelect;
        }
        set
        {
            lvFolders.MultiSelect = value;
            lvFolders.CheckBoxes = _checkBoxes && lvFolders.MultiSelect;
        }
    }

    public bool ShowHiddenFolders
    {
        get;
        set;
    }

    public bool HideDotFolders
    {
        get;
        set;
    }

    public bool ShowSystemFolders
    {
        get;
        set;
    }

    private IEnumerable<SelectedPathControl> SelectedPathControls
    {
        get
        {
            return pnlSelectedFolders.Controls.OfType<SelectedPathControl>();
        }
    }

    public IReadOnlyCollection<string> SelectedPaths
    {
        get;
        private set;
    }

    public bool ShowUserProfile
    {
        get;
        set;
    } = true;

    public bool ShowMyDocuments
    {
        get;
        set;
    } = true;

    public bool ShowDesktop
    {
        get;
        set;
    } = true;

    private void InitializeDialog()
    {
        using var bitmap = new Bitmap(ilIcons16.Images[ImageKeyOpenFolder]);
        Icon = Icon.FromHandle(bitmap.GetHicon());
        tsddbView.DropDownItems.Clear();
        tsddbView.DropDownItems.AddRange(Enum.GetValues(typeof(View)).OfType<View>().Where(v => v != View.Tile).Select(v =>
        {
            var toolStripMenuItem = new ToolStripMenuItem
            {
                Name = v.ToString(),
                Text = v.ToString(),
                Tag = v
            };
            toolStripMenuItem.Click += (s, e) =>
            {
                var view = (View)((ToolStripMenuItem)s).Tag;
                lvFolders.View = view;

                if (view == View.Details)
                {
                    lvFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            };
            return toolStripMenuItem;
        }).ToArray());
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        var rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.MyComputer);

        foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
        {
            rootNode.Nodes.AddNodeIfNotExist(new RootNode
            {
                Name = drive.Name,
                Text = $"{drive.VolumeLabel} ({drive.Name})",
                Path = drive.Name,
                ImageKey = ImageKeyDrive,
                SelectedImageKey = ImageKeyDrive
            });
        }

        if (ShowDesktop)
        {
            rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.Desktop);
            AddChilds(rootNode);
        }

        if (ShowMyDocuments)
        {
            rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.MyDocuments);
            AddChilds(rootNode);
        }

        if (ShowUserProfile)
        {
            rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.UserProfile);
            AddChilds(rootNode);
        }
    }

    private RootNode AddSpecialFolderDrive(Environment.SpecialFolder folder)
    {
        var localRootNode = (RootNode)twFolders.Nodes.AddNodeIfNotExist(new RootNode
        {
            Name = folder.ToString(),
            Text = folder.ToString(),
            Path = Environment.GetFolderPath(folder),
            ImageKey = folder.ToString(),
            SelectedImageKey = folder.ToString()
        });

        return localRootNode;
    }

    private void AddChilds(FolderNode rootNode)
    {
        foreach (var path in GetFolders(rootNode.Path).OrderBy(p => Path.GetFileName(p).ToLowerInvariant()))
        {
            rootNode.Nodes.AddNodeIfNotExist(new FolderNode
            {
                Name = Path.GetFileName(path),
                Text = Path.GetFileName(path),
                Path = path,
                ImageKey = ImageKeyFolder,
                SelectedImageKey = ImageKeyFolder
            });
        }
    }

    private string[] GetFolders(string path)
    {
        var attributesToSkip = (ShowHiddenFolders ? 0 : FileAttributes.Hidden) | (ShowSystemFolders ? 0 : FileAttributes.System) | FileAttributes.Offline;
        return Directory.GetDirectories(path, "*", new EnumerationOptions
        {
            AttributesToSkip = attributesToSkip,
            IgnoreInaccessible = true,
            RecurseSubdirectories = false,
            ReturnSpecialDirectories = false
        }).Where(f => !HideDotFolders || !Path.GetFileName(f).StartsWith(".")).ToArray();
    }

    private void twFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        if (e.Node is not FolderNode node)
        {
            return;
        }

        foreach (var childNode in node.Nodes.OfType<FolderNode>().Where(n => n.Nodes.Count == 0))
        {
            AddChilds(childNode);
        }
    }

    private void SetCurrentPath(string path, NavigationSource navigationSource)
    {
        _currentPathChanged = false;

        if (!Directory.Exists(path ?? ""))
        {
            return;
        }

        tstbCurrentPath.Text = path;

        if (!lvFolders.CheckBoxes)
        {
            pnlSelectedFolders.Controls.Clear();
        }
        else if (navigationSource == NavigationSource.ItemDblClick)
        {
            UpdateList(tstbCurrentPath.Text, FindSelectedPathIndex(tstbCurrentPath.Text) < 0, false);
        }

        lvFolders.Items.Clear();
        var numFolders = 0;

        foreach (var subPath in GetFolders(tstbCurrentPath.Text))
        {
            numFolders++;
            var di = new DirectoryInfo(subPath);
            var listViewItem = new FolderItem
            {
                Name = Path.GetFileName(subPath),
                Text = Path.GetFileName(subPath),
                Path = subPath,
                ImageKey = ImageKeyFolder,
                Checked = lvFolders.CheckBoxes && FindSelectedPathIndex(subPath) >= 0
            };
            listViewItem.SubItems.Add(di.CreationTime.ToShortDateTimeString());
            listViewItem.SubItems.Add(di.LastWriteTime.ToShortDateTimeString());
            lvFolders.Items.Add(listViewItem);
        }

        tsslNumFolders.Text = $"{numFolders} folders";

        if (navigationSource != NavigationSource.NodeClick && navigationSource != NavigationSource.NodeKeyPress)
        {
            var windowsPathSystem = new WindowsPathSystem();
            var current =
                ExpandIfCollapsed(Linq.Utils.GetAncestorUntil(twFolders.SelectedNode, n => n.Parent, n => n == null) as FolderNode);
            var sp = windowsPathSystem.SplitPath(path.EnsureTrailingString($"{windowsPathSystem.FolderSeparatorChar}")
                                                     .TrimStringStart(current.Path, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(current.Path))
            {
                current = ExpandIfCollapsed(current?.Nodes[sp.VolumePath] as FolderNode);
            }

            foreach (var folder in sp.Folders)
            {
                current = ExpandIfCollapsed(current?.Nodes[folder] as FolderNode);
            }
        }
    }

    private static FolderNode ExpandIfCollapsed(FolderNode treeNode)
    {
        if (!treeNode?.IsExpanded ?? false)
        {
            treeNode.Expand();
        }

        return treeNode;
    }

    private void twFolders_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter
            && !e.Shift
            && !e.Alt
            && !e.Control
            && twFolders.SelectedNode is FolderNode folder)
        {
            SetCurrentPath(folder.Path, NavigationSource.NodeKeyPress);
        }
    }

    private void lvFolders_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (lvFolders.GetItemAt(e.X, e.Y) is FolderItem item)
        {
            SetCurrentPath(item.Path, NavigationSource.ItemDblClick);
        }
    }

    private void twFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Node is FolderNode node && twFolders.HitTest(e.Location).Location != TreeViewHitTestLocations.PlusMinus)
        {
            SetCurrentPath(node.Path, NavigationSource.NodeClick);
        }
    }

    private void twFolders_AfterCollapse(object sender, TreeViewEventArgs e)
    {
        if (e.Node is FolderNode node and not RootNode)
        {
            node.ImageKey = ImageKeyFolder;
            node.SelectedImageKey = ImageKeyFolder;
        }
    }

    private void twFolders_AfterExpand(object sender, TreeViewEventArgs e)
    {
        if (e.Node is not (FolderNode node and not RootNode))
        {
            return;
        }

        node.ImageKey = ImageKeyOpenFolder;
        node.SelectedImageKey = ImageKeyOpenFolder;
    }

    private void lvFolders_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !e.Shift && !e.Alt && !e.Control && lvFolders.SelectedItems.OfType<FolderItem>().FirstOrDefault() is { } folder)
        {
            SetCurrentPath(folder.Path, NavigationSource.ItemKeyPress);
        }

        if (e.KeyCode == Keys.Up && !e.Shift && e.Alt && !e.Control && Directory.Exists(tstbCurrentPath.Text))
        {
            NavigateToParent();
        }
    }

    private void tsbUp_Click(object sender, EventArgs e)
    {
        NavigateToParent();
    }

    private void NavigateToParent()
    {
        if (Directory.Exists(tstbCurrentPath.Text))
        {
            SetCurrentPath(Path.GetDirectoryName(tstbCurrentPath.Text), NavigationSource.NodeKeyPress);
        }
    }

    private void lvFolders_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (!CheckBoxes || e.Item is not FolderItem item)
        {
            return;
        }

        UpdateList(item.Path, item.Checked, false);
    }

    private void UpdateList(string itemPath, bool itemSelected, bool updateList)
    {
        var idx = FindSelectedPathIndex(itemPath);

        if (itemSelected && idx < 0)
        {
            var selectedPathControl = new SelectedPathControl
            {
                Path = itemPath,
                Dock = DockStyle.Top
            };
            selectedPathControl.ClickDelete += SelectedPathControl_ClickDelete;
            pnlSelectedFolders.Controls.Add(selectedPathControl);
        }

        if (!itemSelected && idx >= 0)
        {
            pnlSelectedFolders.Controls.RemoveAt(idx);
        }

        FolderItem folderItem;

        if (updateList
            && (folderItem = lvFolders.Items.OfType<FolderItem>()
                                      .FirstOrDefault(i => string.Compare(i.Path, itemPath, StringComparison.OrdinalIgnoreCase) == 0))
            != null)
        {
            if (CheckBoxes)
            {
                folderItem.Checked = itemSelected;
            }
            else
            {
                folderItem.Selected = itemSelected;
            }
        }
    }

    private int FindSelectedPathIndex(string itemPath)
    {
        return SelectedPathControls.IndexOf(s =>
                                                       string.Compare(itemPath, s.Path, StringComparison.OrdinalIgnoreCase) == 0);
    }

    private void SelectedPathControl_ClickDelete(object sender, EventArgs e)
    {
        var selectedPathControl = (SelectedPathControl)sender;
        UpdateList(selectedPathControl.Path, false, true);
    }

    private void lvFolders_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (!CheckBoxes && e.Item is FolderItem item)
        {
            UpdateList(item.Path, item.Selected, false);
        }
    }

    private void tstbCurrentPath_Leave(object sender, EventArgs e)
    {
        if (_currentPathChanged)
        {
            SetCurrentPath(tstbCurrentPath.Text, NavigationSource.TextBox);
        }
    }

    private void tstbCurrentPath_TextChanged(object sender, EventArgs e)
    {
        _currentPathChanged = true;
    }

    private void tstbCurrentPath_KeyDown(object sender, KeyEventArgs e)
    {
        if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Enter && _currentPathChanged)
        {
            SetCurrentPath(tstbCurrentPath.Text, NavigationSource.TextBox);
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        SelectedPaths = SelectedPathControls.Select(c => c.Path).ToArray();
        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        SelectedPaths = Array.Empty<string>();
        DialogResult = DialogResult.Cancel;
    }

    private void tsbRefresh_Click(object sender, EventArgs e)
    {
        SetCurrentPath(tstbCurrentPath.Text, NavigationSource.Refresh);
    }

    private enum NavigationSource
    {
        NodeClick,
        NodeKeyPress,
        ItemDblClick,
        ItemKeyPress,
        TextBox,
        Refresh
    }

    private class FolderItem : ListViewItem
    {
        public string Path
        {
            get;
            init;
        }
    }

    private class FolderNode : TreeNode
    {
        public string Path
        {
            get;
            init;
        }
    }

    private class RootNode : FolderNode
    { }
}
