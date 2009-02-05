using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlNode
  {
    readonly string _name;

    public string Name
    {
      get { return _name; }
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
