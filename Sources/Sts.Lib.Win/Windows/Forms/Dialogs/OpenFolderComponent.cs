using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.Dialogs;

public partial class OpenFolderComponent : Component
{
    private OpenFolderDialog OpenFolderDialog
    {
        get
        {
            return components.Components["OpenFolderDialog"] as OpenFolderDialog;
        }
    }

    public OpenFolderComponent()
    {
        InitializeComponent();
    }

    public OpenFolderComponent(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
    public bool CheckBoxes
    {
        get;
        set;
    }

    public bool MultiSelect
    {
        get;
        set;
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
    public bool ShowUserProfile
    {
        get;
        set;
    }

    public bool ShowMyDocuments
    {
        get;
        set;
    }

    public bool ShowDesktop
    {
        get;
        set;
    } = true;
    public IReadOnlyCollection<string> SelectedPaths
    {
        get
        {
            return OpenFolderDialog.SelectedPaths;
        }
    } 

    public DialogResult ShowDialog(IWin32Window owner)
    {
        OpenFolderDialog.ShowDesktop = ShowDesktop;
        OpenFolderDialog.ShowHiddenFolders= ShowHiddenFolders;
        OpenFolderDialog.ShowSystemFolders= ShowSystemFolders;
        OpenFolderDialog.ShowUserProfile= ShowUserProfile;
        OpenFolderDialog.HideDotFolders=HideDotFolders;
        OpenFolderDialog.MultiSelect=MultiSelect;
        OpenFolderDialog.CheckBoxes=CheckBoxes;
        return OpenFolderDialog.ShowDialog(owner);
    }
}