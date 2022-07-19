using System;
using Microsoft.Win32;

namespace Sts.Lib.Win.Configuration;

[Serializable]
public class RegistryOptions
{
    private string _applicationName = "";
    private string _companyName = "";
    public virtual string ApplicationName
    {
        get
        {
            if (string.IsNullOrEmpty(_applicationName))
            {
                throw new ArgumentNullException();
            }

            return _applicationName;
        }
        set { _applicationName = value; }
    }

    public virtual string CompanyName
    {
        get
        {
            if (string.IsNullOrEmpty(_companyName))
            {
                throw new ArgumentNullException();
            }

            return _companyName;
        }
        set { _companyName = value; }
    }

    protected RegistryValue<T> NewRegistryValue<T>(string name, T Default, bool createValueIfNotExists)
    {
        return new RegistryValue<T>(Registry.LocalMachine, "software\\" + CompanyName + "\\" + ApplicationName, name, Default, createValueIfNotExists, 0);
    }
    protected RegistryValue<T> NewRegistryValue<T>(string name, T Default, bool createValueIfNotExists, int expireSeconds)
    {
        return new RegistryValue<T>(Registry.LocalMachine, "software\\" + CompanyName + "\\" + ApplicationName, name, Default, createValueIfNotExists, expireSeconds);
    }
    protected RegistryValue<T> NewUserRegistryValue<T>(string name, T Default, bool createValueIfNotExists, int expireSeconds)
    {
        return new RegistryValue<T>(Registry.CurrentUser, "software\\" + CompanyName + "\\" + ApplicationName, name, Default, createValueIfNotExists, expireSeconds);
    }
    protected RegistryValue<T> NewUserRegistryValue<T>(string name, T Default, bool createValueIfNotExists)
    {
        return NewUserRegistryValue(name, Default, createValueIfNotExists, 0);
    }
    private string GetSubKey(string section)
    {
        if (string.IsNullOrEmpty(ApplicationName) || string.IsNullOrEmpty(ApplicationName.Replace("\\", "")) || string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(CompanyName.Replace("\\", "")))
        {
            throw new InvalidOperationException();
        }

        var rVal = "Software\\" + CompanyName.Replace("\\", "") + "\\" + ApplicationName.Replace("\\", "");
        if (!string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(section.Trim("\\".ToCharArray())))
        {
            rVal += "\\" + section.Trim("\\".ToCharArray());
        }

        return rVal;
    }
}