using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.RouteMap.Parsing
{
  public class Route
  {
    public IEnumerable<HttpVerbs> AcceptedVerbs
    {
      get; private set;
    }

    public IEnumerable<RoutePart> Parts
    {
      get; private set;
    }
  }
}
