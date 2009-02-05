using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Model
{
  public class RouteConfig
  {
    readonly List<Route> _routes;
    readonly List<string> _namespaces;

    public RouteConfig(List<Route> routes, List<string> namespaces)
    {
      _routes = routes;
      _namespaces = namespaces;
    }

    public IEnumerable<Route> Routes
    {
      get { return _routes; }
    }

    public IEnumerable<string> Namespaces
    {
      get { return _namespaces; }
    }
  }
}
