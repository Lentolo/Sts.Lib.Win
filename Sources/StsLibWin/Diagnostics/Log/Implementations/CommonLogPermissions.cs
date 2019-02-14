using System;
using System.Collections.Generic;
using System.Linq;
using StsLib.Collections.Generic;
using StsLib.Configuration;
using StsLib.Diagnostics.Log;
using StsLib.Linq.Extensions;
using StsLib.Security.Permissions;
using StsLib.Xml.Extensions;
using Convert = StsLib.Common.Convert;

namespace StsLibWin.Diagnostics.Log.Implementations
{
  [Serializable]
  public class CommonLogPermissions : ILogPermissions
  {
    protected CommonLogPermissions()
    {
    }
    public StsLib.Collections.Generic.Dictionary<LogTypes, InheritablePolicy> LogTypesPermissions
    {
      get;
    } = new StsLib.Collections.Generic.Dictionary<LogTypes, InheritablePolicy>(InheritablePolicy.Inherit);
    public CaseInsensitiveDictionary<InheritablePolicy> CategoriesPermissions
    {
      get;
    } = new CaseInsensitiveDictionary<InheritablePolicy>(InheritablePolicy.Inherit);
    public Policy DefaultPolicy
    {
      get;
      set;
    }
    public bool LogEnabled
    {
      get;
      set;
    }
    public bool CanLog(LogTypes logType, string category)
    {
      return LogEnabled && (CategoriesPermissions[category] == InheritablePolicy.Deny && LogTypesPermissions[logType] == InheritablePolicy.Inherit && DefaultPolicy == Policy.Allow || CategoriesPermissions[category] == InheritablePolicy.Deny && LogTypesPermissions[logType] == InheritablePolicy.Allow || CategoriesPermissions[category] == InheritablePolicy.Inherit && LogTypesPermissions[logType] == InheritablePolicy.Inherit && DefaultPolicy == Policy.Allow || CategoriesPermissions[category] == InheritablePolicy.Inherit && LogTypesPermissions[logType] == InheritablePolicy.Allow || CategoriesPermissions[category] == InheritablePolicy.Allow && LogTypesPermissions[logType] != InheritablePolicy.Deny);
    }
    public static CommonLogPermissions LoadFromConfig()
    {
      try
      {
        var rval = new CommonLogPermissions();
        var xml = ConfigurationSection.GetSection("CommonLogPermissions");
        rval.LogEnabled = Convert.TryParseTo(xml.GetNodeProperty("/CommonLogPermissions/LogEnabled", x => x.InnerText, "false"), false);
        rval.DefaultPolicy = Convert.TryParseTo(xml.GetNodeProperty("/CommonLogPermissions/DefaultPolicy", x => x.InnerText, "Deny"), Policy.Deny);
        rval.LogTypesPermissions.CopyFrom(xml.TrySelectNodes("/CommonLogPermissions/LogTypesPermissions/Item").Select(n =>
        {
          var logTypes = LogTypes.Info;
          var ok = Enum.TryParse(n.TryGetAttributeValue("name", ""), out logTypes);
          var policy = InheritablePolicy.Inherit;
          ok = ok && Enum.TryParse(n.TryGetAttributeValue("value", ""), out policy);
          return new
          {
            LogTypes = logTypes,
            Policy = policy,
            Result = ok
          };
        }).Where(i => i.Result).Select(i => new KeyValuePair<LogTypes, InheritablePolicy>(i.LogTypes, i.Policy)).Distinct(i => i.Key.ToString()).ToDictionary(i => i.Key, i => i.Value));
        rval.CategoriesPermissions.CopyFrom(xml.TrySelectNodes("/CommonLogPermissions/CategoriesPermissions/Item").Select(n =>
        {
          var na = n.TryGetAttributeValue("name", "");
          var policy = InheritablePolicy.Inherit;
          var ok = Enum.TryParse(n.TryGetAttributeValue("value", ""), out policy);
          return new
          {
            Name = na,
            Policy = policy,
            Result = ok
          };
        }).Where(i => i.Result).Select(i => new KeyValuePair<string, InheritablePolicy>(i.Name, i.Policy)).Distinct(i => i.Key.ToLowerInvariant()).ToDictionary(i => i.Key, i => i.Value));
        return rval;
      }
      catch (Exception exc)
      {
        try
        {
          System.IO.File.WriteAllText("c:\\temp\\log.txt", StsLib.Diagnostics.Utils.ExtractError(exc));
        }
        catch
        { }
        // ignored
      }

      return new CommonLogPermissions();
    }
  }
}