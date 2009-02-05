using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Route66.Model
{
  public class RouteNode
  {
    readonly string _name;

    public string Name
    {
      get { return _name; }
    }

    public Route Route
    {
      get; set;
    }

    readonly Dictionary<string, RouteNode> _children;

    public RouteNode(string name)
    {
      _name = name;
      _children = new Dictionary<string, RouteNode>();
    }

    public bool HasChildNamed(string name)
    {
      return _children.ContainsKey(name);
    }

    public void AddChild(RouteNode child)
    {
      _children[child.Name] = child;
    }

    public RouteNode GetChild(string name)
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
