using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlStrongModel
  {
    readonly List<Url> _urls;
    readonly List<string> _namespaces;
    readonly string _defaultNamespace;
    readonly UrlTree _urlTree;

    public UrlStrongModel(List<Url> urls, List<string> namespaces, string defaultNamespace)
    {
      _urls = urls;
      _namespaces = namespaces;
      _defaultNamespace = defaultNamespace;
      _urlTree = new UrlTree(_urls);
    }

    public UrlTree UrlTree
    {
      get { return _urlTree; }
    }

    public string DefaultNamespace
    {
      get { return _defaultNamespace; }
    }

    public IEnumerable<Url> Urls
    {
      get { return _urls; }
    }

    public IEnumerable<string> Namespaces
    {
      get { return _namespaces; }
    }
  }
}
