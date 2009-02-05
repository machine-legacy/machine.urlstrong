using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Route66.Parsing;

namespace Machine.Route66.Model
{
  public class Route
  {
    public Route(IEnumerable<HttpVerbs> acceptedVerbs, IEnumerable<RoutePart> parts)
    {
      AcceptedVerbs = acceptedVerbs;
      Parts = parts;
    }

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