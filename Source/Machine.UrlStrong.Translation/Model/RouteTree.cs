using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class RouteTree
  {
    readonly RouteNode _root;

    public RouteTree()
    {
      _root = new RouteNode("root");
    }

    public void AddRoute(Route route)
    {
      var currentNode = _root;

      foreach (var part in route.Parts)
      {
        if (!currentNode.HasChildNamed(part.PartName))
        {
          var child = new RouteNode(part.PartName);
          currentNode.AddChild(child);
        }

        currentNode = currentNode.GetChild(part.PartName);
      }

      currentNode.Route = route;
    }

    public override string ToString()
    {
      return _root.ToString();
    }
  }
}
