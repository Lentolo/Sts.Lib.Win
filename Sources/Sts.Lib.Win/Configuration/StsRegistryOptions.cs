using System;

namespace Sts.Lib.Win.Configuration
{
  [Serializable]
  public class StsRegistryOptions : RegistryOptions
  {
    public override string CompanyName
    {
        get { return "Sts"; }
        set
      {
      }
    }
  }
}