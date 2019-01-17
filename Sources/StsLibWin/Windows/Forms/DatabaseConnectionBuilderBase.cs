using System;

namespace StsLibWin.Windows.Forms
{
  public class DatabaseConnectionBuilderBase : UserControl
  {
    public virtual string ConnectionString
    {
      get => "";
      set
      {
      }
    }
    public virtual string ConnectionStringNoProvider
    {
      get => "";
      set
      {
      }
    }
    public virtual string DatabaseTypeName => "";
    public virtual Type DatabaseConnectionType => null;
    public virtual bool Test()
    {
      return false;
    }
  }
}