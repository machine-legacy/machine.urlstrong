using System.Collections.Generic;

namespace Machine.RouteMap.Parsing
{
  public class ParseResult
  {
    public bool HasErrors
    {
      get; private set;
    }

    public IEnumerable<Route> Routes
    {
      get; private set;
    }
  }
}