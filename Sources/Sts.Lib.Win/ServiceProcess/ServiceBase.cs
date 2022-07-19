using System;
using Topshelf;

namespace Sts.Lib.Win.ServiceProcess;

public abstract class ServiceBase<T>
    where T : ServiceBase<T>, new()
{
    protected abstract string ServiceName
    {
        get;
    }

    protected abstract string ServiceDisplayName
    {
        get;
    }

    protected abstract string ServiceDescription
    {
        get;
    }

    public virtual int Run(string[] commandLine)
    {
        var code = HostFactory.Run(hostConfigurator =>
        {
            hostConfigurator.Service<T>(serviceConfigurator =>
            {
                serviceConfigurator.ConstructUsing(name => new T());
                serviceConfigurator.WhenContinued(serviceBase => serviceBase.Continue());
                serviceConfigurator.WhenCustomCommandReceived((serviceBase, hostControl, command) => serviceBase.CustomCommandReceived(hostControl, command));
                serviceConfigurator.WhenPaused(serviceBase => serviceBase.Pause());
                serviceConfigurator.WhenPowerEvent((serviceBase, hostControl, powerEventArguments) => serviceBase.PowerEvent(hostControl, powerEventArguments));
                serviceConfigurator.WhenSessionChanged((serviceBase, hostControl, sessionChangedArguments) => serviceBase.SessionChanged(hostControl, sessionChangedArguments));
                serviceConfigurator.WhenShutdown(serviceBase => serviceBase.Shutdown());
                serviceConfigurator.WhenStarted(serviceBase => serviceBase.Start(commandLine));
                serviceConfigurator.WhenStopped(serviceBase => serviceBase.Stop());
            });
            hostConfigurator.SetDescription(ServiceDescription);
            hostConfigurator.SetDisplayName(ServiceDisplayName);
            hostConfigurator.SetServiceName(ServiceName);
            hostConfigurator.EnablePauseAndContinue();
            hostConfigurator.EnableShutdown();
            hostConfigurator.RunAsLocalSystem();
            hostConfigurator.Disabled();
        });

        return (int) Convert.ChangeType(code, code.GetTypeCode());
    }

    protected virtual void SessionChanged(HostControl hostControl, SessionChangedArguments changedArguments)
    { }

    protected virtual bool PowerEvent(HostControl hostControl, PowerEventArguments powerEventArguments)
    {
        return false;
    }

    protected abstract void Start(string[] commandLine);

    protected virtual void Continue()
    { }

    protected virtual void Shutdown()
    { }

    protected virtual void Pause()
    { }

    protected abstract void Stop();

    protected virtual void CustomCommandReceived(HostControl hostControl, int command)
    { }
}