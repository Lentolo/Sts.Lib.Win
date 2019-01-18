using System;
using System.Collections.Specialized;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;
using StsLib.Diagnostics.Log;
using StsLibWin.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
//using StsLibWin.Diagnostics.Log;

namespace StsLibWin.ServiceProcess
{
  public class ServiceBase : System.ServiceProcess.ServiceBase
  {
    private string _displayName = "";
    private ServiceController _serviceController;
    public string DisplayName
    {
      get => string.IsNullOrEmpty(_displayName) ? ServiceName : _displayName;
      set => _displayName = value;
    }
    public string Description
    {
      get;
      set;
    } = "";
    public ServiceStartMode StartType
    {
      get;
      set;
    } = ServiceStartMode.Disabled;
    public ServiceAccount ServiceAccount
    {
      get;
      set;
    } = ServiceAccount.LocalService;
    private ServiceController ServiceController
    {
      get
      {
        return _serviceController ?? (_serviceController = ServiceController.GetServices().FirstOrDefault(itm => string.Compare(itm.ServiceName, ServiceName, StringComparison.OrdinalIgnoreCase) == 0));
      }
    }
    public virtual void ParseCommandLine(string[] commandLine)
    {
      var commandLineParser = new CommandLineParser(commandLine);
      if (commandLineParser.HasParameter("install"))
      {
        Install(commandLineParser.HasParameter("silent"), commandLineParser.HasParameter("force"));
      }
      else if (commandLineParser.HasParameter("uninstall"))
      {
        Uninstall(commandLineParser.HasParameter("silent"));
      }
      else if (commandLineParser.HasParameter("start"))
      {
        Start(commandLineParser.HasParameter("silent"));
      }
      else if (commandLineParser.HasParameter("stop"))
      {
        Stop(commandLineParser.HasParameter("silent"));
      }
      else
      {
        Run(this);
      }
    }
    public bool IsServiceInstalled()
    {
      return ServiceController != null;
    }
    protected virtual void OnInstall()
    {
      Logger.Instance.Debug("ServiceBase", "OnInstall", null);
    }
    protected virtual void OnUninstall()
    {
      Logger.Instance.Debug("ServiceBase", "OnUninstall", null);
    }
    protected void Install(bool silent, bool force)
    {
      try
      {
        if (force)
        {
          Stop(true);
          Uninstall(true);
        }

        if (!IsServiceInstalled())
        {
          var serviceProcessInstaller = new ServiceProcessInstaller
          {
              Account = ServiceAccount
          };
          var context = new InstallContext();
          var processPath = Process.GetCurrentProcess().MainModule.FileName;
          if (!string.IsNullOrWhiteSpace(processPath))
          {
            var fi = new FileInfo(processPath);
            var path = $"/assemblypath={fi.FullName}";
            string[] cmdline =
            {
                path
            };
            context = new InstallContext("", cmdline);
          }

          var serviceInstaller = new ServiceInstaller();
          serviceInstaller.Context = context;
          serviceInstaller.ServiceName = ServiceName;
          serviceInstaller.DisplayName = DisplayName;
          serviceInstaller.Description = Description;
          serviceInstaller.StartType = StartType;
          serviceInstaller.Parent = serviceProcessInstaller;
          var state = new ListDictionary();
          serviceInstaller.Install(state);
          using (var oKey = Registry.LocalMachine.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{ServiceName}", true))
          {
            try
            {
              var sValue = oKey?.GetValue("ImagePath");
              oKey?.SetValue("ImagePath", sValue);
            }
            catch (Exception exc)
            {
              Logger.Instance.Exception("ServiceBase", exc);
            }
          }

          OnInstall();
          ShowMessage(silent, @"Service installed", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          ShowMessage(silent, @"Service already installed, please uninstall first", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception exc)
      {
        Logger.Instance.Exception("ServiceBase", exc);
        ShowMessage(silent, exc.Message, ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private void ShowMessage(bool silent, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      if (icon == MessageBoxIcon.Error || icon == MessageBoxIcon.Stop || icon == MessageBoxIcon.Hand)
      {
        Logger.Instance.Error("ServiceBase", text, null);
      }
      else if (icon == MessageBoxIcon.Warning || icon == MessageBoxIcon.Exclamation)
      {
        Logger.Instance.Warning("ServiceBase", text, null);
      }
      else if (icon == MessageBoxIcon.Asterisk || icon == MessageBoxIcon.Information)
      {
        Logger.Instance.Info("ServiceBase", text, null);
      }
      else
      {
        Logger.Instance.Debug("ServiceBase", text, null);
      }

      if (!silent)
      {
        MessageBox.Show(text, caption, buttons, icon);
      }
    }
    protected void Uninstall(bool silent)
    {
      try
      {
        if (IsServiceInstalled())
        {
          var serviceInstaller = new ServiceInstaller();
          var context = new InstallContext();
          serviceInstaller.Context = context;
          serviceInstaller.ServiceName = ServiceName;
          serviceInstaller.Uninstall(null);
          OnUninstall();
          ShowMessage(silent, @"Service uninstalled", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          ShowMessage(silent, @"Service not found", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception exc)
      {
        ShowMessage(silent, exc.Message, ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    protected void Start(bool silent)
    {
      try
      {
        if (IsServiceInstalled() && ServiceController.Status == ServiceControllerStatus.Stopped)
        {
          ServiceController.Start();
          ShowMessage(silent, @"Service started", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      catch (Exception exc)
      {
        ShowMessage(silent, exc.Message, ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    protected void Stop(bool silent)
    {
      try
      {
        if (IsServiceInstalled() && ServiceController.Status == ServiceControllerStatus.Running && ServiceController.CanStop)
        {
          ServiceController.Stop();
          ShowMessage(silent, @"Service stopped", ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      catch (Exception exc)
      {
        ShowMessage(silent, exc.Message, ServiceName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}