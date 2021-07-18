using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Common.Extensions;
using Sts.Lib.IO.Extensions;
using Sts.Lib.IO.PathSystems;
using Sts.Lib.Linq.Extensions;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Dialogs
{
    public partial class OpenFolderDialog : Form
    {
        private const string MyComputerName = "MyComputer";
        private const string MyComputerText = "MyComputer";
        private const string ImageKey_Folder = "folder";
        private const string ImageKey_OpenFolder = "open-folder";
        private const string ImageKey_MyComputer = "monitor";
        private const string ImageKey_Desktop = "desktop";
        private const string ImageKey_Documents = "documents";
        private const string ImageKey_Drive = "hdd";
        private bool _checkBoxes;

        public OpenFolderDialog()
        {
            InitializeComponent();
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            using var bitmap = new Bitmap(ilIcons16.Images[ImageKey_OpenFolder]);
            Icon = Icon.FromHandle(bitmap.GetHicon());
            CheckBoxes = true;
            MultiSelect = true;
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
                    var view = (View) ((ToolStripMenuItem) s).Tag;
                    lvFolders.View = view;

                    if (view == View.Details)
                    {
                        lvFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                };
                return toolStripMenuItem;
            }).ToArray());
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

        public bool ShowSystemFolders
        {
            get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            RootNode AddSpecialFolderDrive(Environment.SpecialFolder folder, string name, string text, string ImageKey)
            {
                var rootNode = (RootNode)twFolders.Nodes.AddNodeIfNotExist(new RootNode
                {
                    Name = name,
                    Text = text,
                    Path = Environment.GetFolderPath(folder),
                    ImageKey = ImageKey,
                    SelectedImageKey = ImageKey
                });

                return rootNode;
            }

            base.OnLoad(e);

            var rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.MyComputer, MyComputerName, MyComputerText, ImageKey_MyComputer);

            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                rootNode.Nodes.AddNodeIfNotExist(new RootNode
                {
                    Name = drive.Name,
                    Text = $"{drive.VolumeLabel} ({drive.Name})",
                    Path = drive.Name,
                    ImageKey = ImageKey_Drive,
                    SelectedImageKey = ImageKey_Drive
                });
            }

            rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.Desktop, "Desktop", "Desktop", ImageKey_Desktop);
            AddChilds(rootNode);
            rootNode = AddSpecialFolderDrive(Environment.SpecialFolder.MyDocuments, "MyDocuments", "MyDocuments", ImageKey_Documents);
            AddChilds(rootNode);
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
                    ImageKey = ImageKey_Folder,
                    SelectedImageKey = ImageKey_Folder
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
            });
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
            if (!Directory.Exists(path))
            {
                return;
            }

            tstbCurrentPath.Text = path;

            if (!lvFolders.CheckBoxes)
            {
                pnlSelectedFolders.Controls.Clear();
            }

            lvFolders.Items.Clear();

            foreach (var subPath in GetFolders(tstbCurrentPath.Text))
            {
                var di = new DirectoryInfo(subPath);
                var listViewItem = new FolderItem
                {
                    Name = Path.GetFileName(subPath),
                    Text = Path.GetFileName(subPath),
                    Path = subPath,
                    ImageKey = ImageKey_Folder,
                    Checked = lvFolders.CheckBoxes && FindSelectedPathIndex(subPath) >= 0
                };
                listViewItem.SubItems.Add(di.CreationTime.ToShortDateTimeString());
                listViewItem.SubItems.Add(di.LastWriteTime.ToShortDateTimeString());
                lvFolders.Items.Add(listViewItem);
            }

            if (navigationSource != NavigationSource.NodeClick && navigationSource != NavigationSource.NodeKeyPress)
            {
                var windowsPathSystem = new WindowsPathSystem();
                var sp = windowsPathSystem.SplitPath(path.EnsureTrailingString($"{windowsPathSystem.FolderSeparatorChar}"));
                var current = ExpandIfCollapsed(Linq.Utils.GetAncestorUntil(twFolders.SelectedNode, n => n.Parent, n => n == null));
                current = ExpandIfCollapsed(current?.Nodes[sp.VolumePath]);

                foreach (var folder in sp.Folders)
                {
                    current = ExpandIfCollapsed(current?.Nodes[folder]);
                }
            }
        }

        private static TreeNode ExpandIfCollapsed(TreeNode treeNode)
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
                SetCurrentPath(item.Path, NavigationSource.ItemClick);
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
                node.ImageKey = ImageKey_Folder;
                node.SelectedImageKey = ImageKey_Folder;
            }
        }

        private void twFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node is FolderNode node and not RootNode)
            {
                node.ImageKey = ImageKey_OpenFolder;
                node.SelectedImageKey = ImageKey_OpenFolder;
            }
        }

        private void lvFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && !e.Shift
                && !e.Alt
                && !e.Control
                && lvFolders.SelectedItems.OfType<FolderItem>().FirstOrDefault() is { } folder)
            {
                SetCurrentPath(folder.Path, NavigationSource.ItemKeyPress);
            }

            if (e.KeyCode == Keys.Up
                && !e.Shift
                && e.Alt
                && !e.Control
                && Directory.Exists(tstbCurrentPath.Text))
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
            if (CheckBoxes && e.Item is FolderItem item)
            {
                UpdateList(item.Path, item.Checked, false);
            }
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
            if (updateList && (folderItem = lvFolders.Items.OfType<FolderItem>().FirstOrDefault(i => string.Compare(i.Path, itemPath, StringComparison.OrdinalIgnoreCase) == 0)) != null)
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
            return pnlSelectedFolders.Controls.OfType<SelectedPathControl>().FindFirstIndex(s => string.Compare(itemPath, s.Path, StringComparison.OrdinalIgnoreCase) == 0);
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

        private enum NavigationSource
        {
            NodeClick,
            NodeKeyPress,
            ItemClick,
            ItemKeyPress
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
}
