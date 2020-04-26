using System;
using Microsoft.Win32;

namespace Sts.Lib.Win.Configuration
{
  [Serializable]
  public class RegistryValueBase
  {
    public RegistryValueBase(RegistryKey rootKey, string subKey, string valueName)
    {
      RootKey = rootKey;
      SubKey = subKey;
      ValueName = valueName;
    }
    protected RegistryKey RootKey
    {
      get;
    }
    protected string SubKey
    {
      get;
    } = "";
    protected string ValueName
    {
      get;
    } = "";
    public void DeleteValue()
    {
      try
      {
        RootKey.OpenSubKey(SubKey, true).DeleteValue(ValueName);
      }
      catch
      {
      }
    }
  }
}