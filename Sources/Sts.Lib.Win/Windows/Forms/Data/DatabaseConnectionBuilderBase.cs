using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Sts.Lib.Data;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Data.Generic;
using Sts.Lib.Data.Interfaces;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public class DatabaseConnectionBuilderBase : UserControl
    {
        public virtual GenericConnectionString ConnectionString
        {
            get;
        }
        public virtual string DatabaseTypeName
        {
            get;
        }

        public virtual bool Test()
        {
            try
            {
                using var db = ConnectionString.CreateAndOpenConnection();
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }
    }
}