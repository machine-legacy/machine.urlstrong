using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Core;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlNode
  {
    readonly string _name;

    public string Name
    {
      get { return _name; }
    }

    public string ClassName
    {
      get { return _name.ToPascalCase(); }
    }

    public string AccessorName
    {
      get { return _name.ToCamelCase(); }
    }

    public Url Url
    {
      get; set;
    }

    public bool HasParameters
    {
      get
      {
        return !IsOnlyParameter && _parameterNames.Any();
      }
    }

    readonly Dictionary<string, UrlNode> _children;
    readonly bool _isOnlyParameter;
    readonly IEnumerable<string> _parameterNames;

    public UrlNode(UrlPart part)
    {
      _name = part.PartName;
      _isOnlyParameter = part.IsOnlyParameter;
      _parameterNames = part.Parameters;
      _children = new Dictionary<string, UrlNode>();
    }

    public string FormalParameters
    {
      get
      {
        if (!_parameterNames.Any())
          return string.Empty;

        StringBuilder sb = new StringBuilder();
        sb.Append("object ");
        sb.Append(_parameterNames.First());

        foreach (string parameter in _parameterNames.Skip(1))
        {
          sb.Append(", object ");
          sb.Append(parameter);
        }

        return sb.ToString();
      }
    }

    public string ActualParameters
    {
      get
      {
        if (!_parameterNames.Any())
          return string.Empty;

        StringBuilder sb = new StringBuilder();
        sb.Append(_parameterNames.First());

        foreach (string parameter in _parameterNames.Skip(1))
        {
          sb.Append(", ");
          sb.Append(parameter);
        }

        return sb.ToString();
      }
    }

    public bool HasChildNamed(string name)
    {
      return _children.ContainsKey(name);
    }

    public void AddChild(UrlNode child)
    {
      _children[child.Name] = child;
    }

    public UrlNode GetChild(string name)
    {
      return _children[name];
    }

    public IEnumerable<UrlNode> Children
    {
      get { return _children.Values; }
    }

    public bool IsOnlyParameter
    {
      get { return _isOnlyParameter; }
    }

    public override string ToString()
    {
      string ret = this.Name;

      if (_children.Any())
      {
        ret += "/\n";

        foreach (var child in _children)
        {
          foreach (var line in child.ToString().Split('\n'))
          {
            ret += "  " + line + "\n";
          }
        }
      }

      return ret;
    }
  }
}
