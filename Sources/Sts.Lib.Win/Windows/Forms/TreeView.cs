using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms
{
    public class TreeView : System.Windows.Forms.TreeView
    {
        public TreeNode AddNodeIfNotExist(TreeNode node)
        {
            if (Nodes[node.Name] == null)
            {
                Nodes.Add(node);
            }
            return Nodes[node.Name];
        }
    }
}