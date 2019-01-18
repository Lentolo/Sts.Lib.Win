using System;
using System.Reflection;

namespace StsLibWin.Reflection.Plugins.Specialized
{
  [Serializable]
  public class SimpleAppDomain<TO> : PluginContainer<Func<TO>, TO>
  {
    [Serializable]
    public new class RemoteProxy : PluginContainer<Func<TO>, TO>.RemoteProxy
    {
    }
    [Serializable]
    public class Plugin : IPlugin
    {
      public TO Run(Func<TO> data)
      {
        return data();
      }
    }
    public SimpleAppDomain()
        : base(new PluginContainerSetup
        {
            AssemblyPath = Assembly.GetExecutingAssembly().Location,
            RemoteProxyClass = typeof(RemoteProxy).FullName
        })
    {
    }
  }
}