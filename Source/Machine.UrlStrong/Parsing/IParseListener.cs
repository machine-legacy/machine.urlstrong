using System.Collections.Generic;

namespace Machine.UrlStrong.Parsing
{
  public interface IParseListener
  {
    void BeginLine(int lineNumber, string line);
    void AddError(string error);
    void OnRoute(IEnumerable<string> verbs, string route);
    void OnUsingNamespace(string @namespace);
  }
}