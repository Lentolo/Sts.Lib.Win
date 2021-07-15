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

namespace Sts.Lib.Win.Windows.Forms.Dialogs
{
    public partial class OpenFolderDialog : Form
    {
        public class DriveNode : TreeNode
        { }
        public OpenFolderDialog()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var drive in DriveInfo.GetDrives())
            {
                //var ddddd=Icon.ExtractAssociatedIcon(drive.Name);
                var ico = IconsUtils.GetFileIcon(drive.Name, IconsUtils.IconSize.Large, false);
                using var outputStream = System.IO.File.OpenWrite( "E:\\Temp\\ico.ico");
                ico.Icon.Save( outputStream);
                var key = $"{ico.Location}{ico.Index}";
                if (ilFolders.Images[key] == null)
                {
                    ilFolders.Images.Add(key, ico.Icon);
                }

                twFolders.AddNodeIfNotExist(new DriveNode()
                {
                    Name = drive.Name,
                    Text = $"{drive.VolumeLabel } ({drive.Name})",
                    ImageKey = key,
                    SelectedImageKey = key,
                });
            }
        }
    }
}
