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

    public string PropertyName
    {
      get { return _name.ToCamelCase(); }
    }

    public Url Url
    {
      get; set;
    }

    readonly Dictionary<string, UrlNode> _children;

    public UrlNode(string name)
    {
      _name = name;
      _children = new Dictionary<string, UrlNode>();
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
