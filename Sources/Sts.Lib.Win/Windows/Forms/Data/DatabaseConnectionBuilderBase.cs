using System;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public abstract class DatabaseConnectionBuilderBase : UserControl
    {
        public abstract string ConnectionString
        {
            get;
        }
        public abstract string ConnectionStringNoProvider
        {
            get;
        }
        public abstract string DatabaseTypeName
        {
            get;
        }

        public abstract Type DatabaseConnectionType 
        {
            get;
        }
        public abstract bool Test();
    }
}