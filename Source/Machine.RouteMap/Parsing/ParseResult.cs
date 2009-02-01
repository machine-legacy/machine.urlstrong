using System.Collections.Generic;
using System.Linq;

namespace Machine.RouteMap.Parsing
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

    public IEnumerable<Route> Routes
    {
      get; private set;
    }

    public IEnumerable<ParseError> Errors
    {
      get; private set;
    }

    public IEnumerable<string> Namespaces
    {
      get; private set;
    }

    public ParseResult(IEnumerable<Route> routes, IEnumerable<ParseError> errors, IEnumerable<string> namespaces)
    {
      Routes = routes;
      Errors = errors;
      Namespaces = namespaces;
    }
  }
}