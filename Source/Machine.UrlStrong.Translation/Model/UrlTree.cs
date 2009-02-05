using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlTree
  {
    readonly UrlNode _root;

    public UrlTree()
    {
      _root = new UrlNode("root");
    }

    public void AddUrl(Url url)
    {
      var currentNode = _root;

      foreach (var part in url.Parts)
      {
        if (!currentNode.HasChildNamed(part.PartName))
        {
          var child = new UrlNode(part.PartName);
          currentNode.AddChild(child);
        }

        currentNode = currentNode.GetChild(part.PartName);
      }

      currentNode.Url = url;
    }

    public override string ToString()
    {
      return _root.ToString();
    }
  }
}
