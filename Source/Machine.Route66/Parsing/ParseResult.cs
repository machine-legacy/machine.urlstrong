using System.Collections.Generic;
using System.Linq;
using Machine.Route66.Model;

namespace Machine.Route66.Parsing
{
  public class ParseResult
  {
    public bool HasErrors
    {
      get
      {
        return Errors.Any();
      } 
    }

    public IEnumerable<ParseError> Errors
    {
      get; private set;
    }


    public RouteConfig RouteConfig
    {
      get; private set;
    }

    public ParseResult(RouteConfig routeConfig, IEnumerable<ParseError> errors)
    {
      RouteConfig = routeConfig;
      Errors = errors;
    }
  }
}