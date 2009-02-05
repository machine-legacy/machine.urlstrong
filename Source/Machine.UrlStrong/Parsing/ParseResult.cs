using System.Collections.Generic;
using System.Linq;
using Machine.UrlStrong.Model;

namespace Machine.UrlStrong.Parsing
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