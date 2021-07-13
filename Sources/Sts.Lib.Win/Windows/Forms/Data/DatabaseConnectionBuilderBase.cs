using System;
using System.Data;
using System.Linq;
using Sts.Lib.Data.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public class DatabaseConnectionBuilderBase : UserControl
    {
        public virtual string ConnectionString
        {
            get;
        }
        public virtual string ConnectionStringNoProvider
        {
            get;
        }
        public virtual string DatabaseTypeName
        {
            get;
        }

        public virtual Type DatabaseConnectionType
        {
            get;
        }
        public virtual bool Test()
        {
            try
            {
                using var db = OpenConnection();
                return true;
            }
            catch
            {
            }

            return false;
        }

        protected virtual IDbConnection OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}