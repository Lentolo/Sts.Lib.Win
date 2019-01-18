﻿using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class SaveFileControl : BrowseControl
  {
    protected SaveFileControl()
    {
      Dialog = new SaveFileDialog();
    }
    public SaveFileDialog Dialog
    {
      get;
    }
    protected override (bool, string) OnShowDialog()
    {
      if (Dialog.ShowDialog() == DialogResult.OK)
      {
        return (true, Dialog.FileName);
      }

      return (false, "");
    }
  }
}