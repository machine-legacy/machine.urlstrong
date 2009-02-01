using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.RouteMap.Parsing
{
  public class ParseResultBuilder : IParseListener
  {
    public void AddError(string line)
    {
    }

    public void OnRoute(IEnumerable<string> verbs, string route)
    {
      throw new System.NotImplementedException();
    }

    public void OnUsingNamespace(string @namespace)
    {
      throw new System.NotImplementedException();
    }
  }
}
