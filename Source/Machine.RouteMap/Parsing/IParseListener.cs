using System.Collections.Generic;

namespace Machine.RouteMap.Parsing
{
  public interface IParseListener
  {
    void AddError(string line);
    void OnRoute(IEnumerable<string> verbs, string route);
  }
}