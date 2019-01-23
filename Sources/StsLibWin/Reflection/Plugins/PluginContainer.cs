using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using StsLib.Common.Extensions;
using StsLib.Diagnostics.Log;
using StsLib.Reflection;

namespace StsLibWin.Reflection.Plugins
{
  public abstract class PluginContainer<TIn, TOut> : IDisposable
  {
    public sealed class ExecutionResult
    {
      public TOut Result
      {
        get;
        internal set;
      }
      public Exception Exception
      {
        get;
        internal set;
      }
    }
    public interface IPlugin
    {
      TOut Run(TIn data);
    }
    public abstract class RemoteProxy : MarshalByRefObject
    {
      internal void InitializeEnvironment<TInitData>(Action<TInitData> action, TInitData initData)
      {
        (action ?? (d =>
                     {
                     }))(initData);
      }
      public TOut Run(string className, TIn data)
      {
        return Utils.CreateInstance<IPlugin>(className).Run(data);
      }
    }
    private readonly AppDomain _domain;
    private readonly RemoteProxy _remoteProxy;
    protected PluginContainer(PluginContainerSetup pluginContainerSetup)
    {
      var ads = new AppDomainSetup
      {
          ApplicationTrust = AppDomain.CurrentDomain.ApplicationTrust,
          ApplicationBase = Path.GetDirectoryName(pluginContainerSetup.AssemblyPath),
          ConfigurationFile = pluginContainerSetup.AssemblyPath + ".config",
          DisallowBindingRedirects = false,
          DisallowCodeDownload = true
      };

      AssemblyName tryGetAssemblyName(string path)
      {
        try
        {
          return AssemblyName.GetAssemblyName(path);
        }
        catch
        {
        }

        return null;
      }

      _domain = AppDomain.CreateDomain(StsLib.Common.Utils.NewGuid(), null, ads);
      _domain.AssemblyResolve += (sender, args) =>
      {
        Debug.WriteLine("AssemblyResolve Request: " + args.Name);
        var ass = Directory.GetFiles(((AppDomain) sender).BaseDirectory, "*.dll").Select(f => new
        {
            Path = f,
            AssemblyName = tryGetAssemblyName(f)
        }).FirstOrDefault(i =>
        {
          Debug.WriteLine("AssemblyResolve Found: " + i?.AssemblyName?.FullName + " [" + i?.Path + "]");
          return i?.AssemblyName?.FullName?.SplitString(",", true, true, true)?.FirstOrDefault() == args.Name.SplitString(",", true, true, true).FirstOrDefault();
        });
        if (ass != null)
        {
          return ((AppDomain) sender).Load(ass.AssemblyName);
        }

        return null;
      };
      _remoteProxy = (RemoteProxy) _domain.CreateInstanceFromAndUnwrap(pluginContainerSetup.AssemblyPath, pluginContainerSetup.RemoteProxyClass);
      _remoteProxy.InitializeEnvironment(d =>
      {
        Logger.CreateLoggerFunc = () => d;
      }, Logger.Instance);
      Logger.Instance.Debug("PluginContainer", "Appdomain Created", new
      {
          AppDomainName = _domain.FriendlyName,
          pluginContainerSetup.AssemblyPath,
          pluginContainerSetup.RemoteProxyClass
      });
    }
    public void Dispose()
    {
      Logger.Instance.Debug("PluginContainer", "Disposing Appdomain", new
      {
          AppDomainName = _domain.FriendlyName
      });
      AppDomain.Unload(_domain);
    }
    public ExecutionResult Run(string className, TIn data)
    {
      try
      {
        Logger.Instance.Debug("PluginContainer", "Run", new
        {
            ClassName = className
        });
        return new ExecutionResult
        {
            Result = _remoteProxy.Run(className, data)
        };
      }
      catch (Exception exc)
      {
        Logger.Instance.Exception("PluginContainer", exc);
        return new ExecutionResult
        {
            Exception = exc
        };
      }
    }
  }
}