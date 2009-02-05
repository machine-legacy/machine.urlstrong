using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlConfig
  {
    readonly List<Url> _urls;
    readonly List<string> _namespaces;

    public UrlConfig(List<Url> urls, List<string> namespaces)
    {
      _urls = urls;
      _namespaces = namespaces;
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
