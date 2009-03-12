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

    public ParsedUrl Url
    {
      get; set;
    }

    public bool HasParameters
    {
      get
      {
        return !IsOnlyParameter && _parameters.Any();
      }
    }

    readonly Dictionary<string, UrlNode> _children;
    readonly bool _isOnlyParameter;

    readonly IEnumerable<Parameter> _parameters;

    public IEnumerable<Parameter> Parameters
    {
      get { return _parameters; }
    }

    public string ImplementedInterfaces
    {
      get 
      {
        if (Url == null) return string.Empty;

        return ", " + String.Join(", ", Url.AcceptedVerbs.Select(x => "ISupport" + x.ToString().ToPascalCase()).ToArray());
      }
    }

    public UrlNode(ParsedUrlPart part)
    {
      _name = part.PartName;
      if (string.IsNullOrEmpty(_name))
      {
        _name = "root";
      }

      _isOnlyParameter = part.IsOnlyParameter;
      _parameters = part.Parameters.Select(x => new Parameter(x, "object"));
      _children = new Dictionary<string, UrlNode>();
    }

    public string AdditionalConstructorArguments
    {
      get
      {
        if (_parameters.Any())
        {
          return ", " + FormalParameters;
        }
        else
        {
          return string.Empty;
        }
      }
    }

    public string FormalParameters
    {
      get
      {
        if (!_parameters.Any())
          return string.Empty;

        return String.Join(", ", _parameters.Select(x => x.FormalDeclaration).ToArray());
      }
    }

    public string ActualParameters
    {
      get
      {
        if (!_parameters.Any())
          return string.Empty;

        return String.Join(", ", _parameters.Select(x => x.Name).ToArray());
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
