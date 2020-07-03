﻿using System.Windows.Forms;
using Sts.Lib.Collections.Generic;

namespace Sts.Lib.Win.Windows.Forms
{
    public class OpenFileControl : BrowseControl, ControlStatePersister.ISaveStateControl
    {
        public OpenFileControl()
        {
            Dialog = new OpenFileDialog();
        }

        public OpenFileDialog Dialog { get; }

        protected override (bool, string) OnShowDialog()
        {
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                return (true, Dialog.FileName);
            }

            return (false, "");
        }

        public bool SaveControlState { get; set; }

        public void SetControlStateData(Dictionary<string, object> data)
        {
            SelectedPath = data["SelectedPath"] as string ?? "";
        }

        public void RetrieveControlStateData(Dictionary<string, object> data)
        {
            data["SelectedPath"] = SelectedPath;
        }
    }
}