using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public class TxtConnectionStringBuilder : TxtButtonControl
    {
        private bool _setText;


        public GenericConnectionString ConnectionString
        {
            get;
            private set;
        }

        public List<DatabaseConnectionBuilderBase> ConnectionStringBuilders
        {
            get;
        } = new List<DatabaseConnectionBuilderBase>();

        public override bool SaveControlState
        {
            get
            {
                return false;
            }
            set
            { }
        }

        protected override void OnTextChanged()
        {
            base.OnTextChanged();
            if (!_setText)
            {
                ConnectionString = new GenericConnectionString(Text);
            }
        }

        protected override void OnBtnClick()
        {
            var dlg = new DlgConnectionstringBuilder
            {
                StartPosition = FormStartPosition.CenterParent
            };
            dlg.ConnectionStringBuilders.AddRange(ConnectionStringBuilders);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                using (Sts.Lib.Common.DelegateDisposable.CreateDelegateDisposable(() => _setText = true, () => _setText = false))
                {
                    Text = NoProviderInConnectionString ? dlg.ConnectionString.ConnectionString : dlg.ConnectionString.FullConnectionString;
                    ConnectionString = dlg.ConnectionString;
                }
                RaiseOnConnectionStringAvailable();
            }
        }

        public bool NoProviderInConnectionString
        {
            get;
            set;
        }

        public event EventHandler ConnectionStringAvailable;

        protected virtual void OnConnectionStringAvailable()
        {
            ConnectionStringAvailable?.Invoke(this, EventArgs.Empty);
        }

        private async void RaiseOnConnectionStringAvailable()
        {
            var raise = false;
            try
            {
                using var cn = await ConnectionString.CreateAndOpenConnectionAsync();
                raise = cn != null;
            }
            catch 
            {
                raise = false;
            }
            if (raise)
            {
                OnConnectionStringAvailable();
            }
        }

        protected override void OnTextValidated()
        {
            RaiseOnConnectionStringAvailable();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // _btn
            // 
            this.btn.Location = new System.Drawing.Point(563, 3);
            // 
            // _txt
            // 
            this.txt.Location = new System.Drawing.Point(0, 2);
            // 
            // TxtConnectionStringBuilder
            // 
            this.Name = "TxtConnectionStringBuilder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}