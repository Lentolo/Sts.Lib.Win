using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Dialogs
{
    public partial class OpenFolderDialog : Form
    {
        public class FolderNode : TreeNode
        {
            public string Path
            { get; set; }
        }
        public class DrivesNode : TreeNode
        { }

        public class DriveNode : FolderNode
        { }
        public OpenFolderDialog()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var rootNode = AddSpecialFolderDrive<DriveNode>(Environment.SpecialFolder.MyComputer, "MyComputer", "MyComputer");
            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                using var ico = IconsUtils.GetFileIcon(drive.Name, IconsUtils.IconSize.Large, false);
                var key = AddToImageListAndGetKey(ico);
                rootNode.Nodes.AddNodeIfNotExist(new DriveNode()
                {
                    Name = drive.Name,
                    Text = $"{drive.VolumeLabel} ({drive.Name})",
                    Path = drive.Name,
                    ImageKey = key,
                    SelectedImageKey = key,
                });
            }
            rootNode = AddSpecialFolderDrive<DriveNode>(Environment.SpecialFolder.Desktop, "Desktop", "Desktop");
            AddChilds(rootNode);
            rootNode = AddSpecialFolderDrive<DriveNode>(Environment.SpecialFolder.MyDocuments, "MyDocuments", "MyDocuments");
            AddChilds(rootNode);
        }

        private void AddChilds(FolderNode rootNode)
        {
            foreach (var path in Sts.Lib.Delegates.Utils.TryExecuteExecuteFunc(() => System.IO.Directory.GetDirectories(rootNode.Path), Array.Empty<string>()))
            {
                using var ico = IconsUtils.GetFileIcon(path, IconsUtils.IconSize.Large, false);
                var key = AddToImageListAndGetKey(ico);
                rootNode.Nodes.AddNodeIfNotExist(new DriveNode()
                {
                    Name = path,
                    Text = System.IO.Path.GetFileName(path),
                    Path = path,
                    ImageKey = key,
                    SelectedImageKey = key,
                });
            }
        }

        private T AddSpecialFolderDrive<T>(Environment.SpecialFolder folder, string name, string text)
        where T : FolderNode, new()
        {
            using var ico = IconsUtils.GetSpecialFolderIcon(folder, IconsUtils.IconSize.Large, false);
            var key = AddToImageListAndGetKey(ico);
            var rootNode = (T)twFolders.Nodes.AddNodeIfNotExist(new T()
            {
                Name = name,
                Text = text,
                Path = Environment.GetFolderPath(folder),
                ImageKey = key,
                SelectedImageKey = key,
            });

            return rootNode;
        }

        private string AddToImageListAndGetKey(IconsUtils.IconInfo ico)
        {
            var key = $"{ico.Location}{ico.Index}";

            if (ilFolders.Images[key] == null)
            {
                ilFolders.Images.Add(key, (Icon)ico.Icon.Clone());
            }

            return key;
        }

        private void twFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is not FolderNode node)
            {
                return;
            }

            foreach (var nn in node.Nodes.OfType<FolderNode>().Where(n => n.Nodes.Count == 0))
            {
                AddChilds(nn);
            }
        }
    }
}
