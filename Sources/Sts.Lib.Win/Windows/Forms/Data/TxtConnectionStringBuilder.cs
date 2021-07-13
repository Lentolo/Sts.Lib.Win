using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data;
using Sts.Lib.Data.Interfaces;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public class TxtConnectionStringBuilder : TxtButtonControl
    {
        private bool _setText;

        public string ConnectionStringNoProvider
        {
            get;
            private set;
        }

        public string ConnectionString
        {
            get;
            private set;
        }

        public bool NoProviderInConnectionString
        {
            get;
            set;
        } = false;

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
                var provider = DatabaseConnectionUtils.SplitConnectionStringWithProvider(Text);
                ConnectionStringNoProvider = provider.ConnectionString;
                ConnectionString = Text;
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
                    Text = NoProviderInConnectionString ? dlg.ConnectionStringNoProvider : dlg.ConnectionString;
                    ConnectionStringNoProvider = dlg.ConnectionStringNoProvider;
                    ConnectionString = dlg.ConnectionString;
                }
                RaiseOnConnectionStringAvailable();
            }
        }

        public IDbConnection CreateAndOpenConnection()
        {
            try
            {
                return DatabaseConnectionUtils.CreateAndOpen(ConnectionString, null);
            }
            catch
            { }

            return null;
        }

        public event EventHandler ConnectionStringAvailable;

        protected virtual void OnConnectionStringAvailable()
        {
            ConnectionStringAvailable?.Invoke(this, EventArgs.Empty);
        }

        private async void RaiseOnConnectionStringAvailable()
        {
            var raise = await Task.Run(() =>
            {
                return Delegates.Utils.TryExecuteExecuteFunc(() =>
                {
                    using var cn = CreateAndOpenConnection();
                    return cn != null;
                }, false);
            });
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