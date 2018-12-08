using System;
using System.Text.RegularExpressions;
using StsLib.Collections.Generic;
using StsLib.Common.Extensions;

namespace StsLibWin.Windows.Forms
{
  public class CommandLineParser
  {
    private CaseInsensitiveDictionary<string> _parameters;
    public CommandLineParser(string[] args)
    {
      Init(args, false, "/");
    }
    public CommandLineParser(string[] args, bool simple)
    {
      Init(args, simple, "/");
    }
    public CommandLineParser(string[] args, bool simple, string argumentIdentifierPrefix)
    {
      Init(args, simple, argumentIdentifierPrefix);
    }
    public string this[string param] => _parameters[param];
    private void Init(string[] args, bool simple, string argumentIdentifierPrefix)
    {
      _parameters = new CaseInsensitiveDictionary<string>("");
      if (simple)
      {
        var lastArg = "";
        for (var i = 0; i < args.Length; i++)
        {
          if (args[i].StartsWith(argumentIdentifierPrefix))
          {
            lastArg = args[i].TrimStringStart(argumentIdentifierPrefix);
            _parameters.Add(lastArg, null);
          }
          else if (!string.IsNullOrEmpty(lastArg))
          {
            _parameters[lastArg] = args[i];
            lastArg = "";
          }
          else
          {
            throw new ArgumentException();
          }
        }
      }
      else
      {
        var spliter = new Regex(@"^-{1,2}|^/|=|:",
                                RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var remover = new Regex(@"^['""]?(.*?)['""]?$",
                                RegexOptions.IgnoreCase | RegexOptions.Compiled);
        string parameter = null;
        string[] parts;
        foreach (var txt in args)
        {
          parts = spliter.Split(txt, 3);
          switch (parts.Length)
          {
            case 1:
              if (parameter != null)
              {
                if (!_parameters.ContainsKey(parameter))
                {
                  parts[0] =
                      remover.Replace(parts[0], "$1");
                  _parameters.Add(parameter, parts[0]);
                }

                parameter = null;
              }

              break;
            case 2:
              if (parameter != null)
              {
                if (!_parameters.ContainsKey(parameter))
                {
                  _parameters.Add(parameter, "true");
                }
              }

              parameter = parts[1];
              break;
            case 3:
              if (parameter != null)
              {
                if (!_parameters.ContainsKey(parameter))
                {
                  _parameters.Add(parameter, "true");
                }
              }

              parameter = parts[1];
              if (!_parameters.ContainsKey(parameter))
              {
                parts[2] = remover.Replace(parts[2], "$1");
                _parameters.Add(parameter, parts[2]);
              }

              parameter = null;
              break;
          }
        }

        if (parameter != null)
        {
          if (!_parameters.ContainsKey(parameter))
          {
            _parameters.Add(parameter, "true");
          }
        }
      }
    }
    public bool IsEmpty()
    {
      return _parameters.Count == 0;
    }
    public bool HasParameter(string param)
    {
      return _parameters.ContainsKey(param);
    }
  }
}