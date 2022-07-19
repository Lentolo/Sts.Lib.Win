using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.Extensions;

public static class Extensions
{
    public static TOut Invoke<TControl, TOut>(this TControl control, Func<TControl, TOut> func)
        where TControl : Control
    {
        return (TOut)control.Invoke(func, control);
    }
    public static void Invoke(this Control control, Action func)
    {
        control.Invoke(func);
    }

    public static TreeNode AddNodeIfNotExist(this TreeNodeCollection treeNodeCollection, TreeNode node)
    {
        if (treeNodeCollection[node.Name] == null)
        {
            treeNodeCollection.Add(node);
        }
        return treeNodeCollection[node.Name];
    }
}