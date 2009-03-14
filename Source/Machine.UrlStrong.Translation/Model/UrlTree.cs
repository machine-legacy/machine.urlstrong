using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlTree
  {
    readonly UrlNode _root;

    public UrlNode Root
    {
      get { return _root; }
    }

    public UrlTree(IEnumerable<ParsedUrl> urls)
    {
      _root = new UrlRootNode();
      foreach (var url in urls)
      {
        AddUrl(url);
      }
    }

    private void AddUrl(ParsedUrl url)
    {
      var currentNode = _root;

      foreach (var part in url.Parts)
      {
        if (!currentNode.HasChildNamed(part.PartName))
        {
          var child = new UrlNode(part);
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
