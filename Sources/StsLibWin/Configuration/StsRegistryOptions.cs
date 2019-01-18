using System;

namespace StsLibWin.Configuration
{
  [Serializable]
  public class StsRegistryOptions : RegistryOptions
  {
    public override string CompanyName
    {
      get => "Sts";
      set
      {
      }
    }
  }
}