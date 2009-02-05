using System.Collections.Generic;

namespace Machine.UrlStrong.Translation.Parsing
{
  public interface IParseListener
  {
    void BeginLine(int lineNumber, string line);
    void AddError(string error);
    void OnUrl(IEnumerable<string> verbs, string url);
    void OnUsingNamespace(string @namespace);
  }
}