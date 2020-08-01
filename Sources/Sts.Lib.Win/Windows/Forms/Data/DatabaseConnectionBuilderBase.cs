using System;

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
      return false;
    }
  }
}