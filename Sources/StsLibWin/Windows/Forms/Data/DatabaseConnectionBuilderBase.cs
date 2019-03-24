using System;

namespace StsLibWin.Windows.Forms.Data
{
    public class DatabaseConnectionBuilderBase : UserControl
    {
      
        public virtual string ConnectionString
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
        public virtual string ConnectionStringNoProvider
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
        public virtual string DatabaseTypeName
        {
            get
            {
                return "";
            }
        }
        public virtual Type DatabaseConnectionType
        {
            get
            {
                return null;
            }
        }
        public virtual bool Test()
        {
            return false;
        }
    }
}