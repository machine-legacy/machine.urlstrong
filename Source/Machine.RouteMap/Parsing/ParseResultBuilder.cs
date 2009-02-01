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

    public void OnRouteBegin()
    {
      throw new System.NotImplementedException();
    }

    public void OnAcceptedVerb(HttpVerbs verb)
    {
      throw new System.NotImplementedException();
    }

    public void OnPart(string part)
    {
      throw new System.NotImplementedException();
    }

    public void OnRouteEnd()
    {
      throw new System.NotImplementedException();
    }

    public ParseResult BuildResult()
    {
      throw new NotImplementedException();
    }
  }
}
