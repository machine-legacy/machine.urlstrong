using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Model;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class ParseResultBuilder : IParseListener
  {
    int _currentLineNumber;
    string _currentLine;
    List<Url> _urls = new List<Url>();
    List<string> _namespaces = new List<string>();
    List<ParseError> _errors = new List<ParseError>();

    public void BeginLine(int lineNumber, string line)
    {
      _currentLine = line;
      _currentLineNumber = lineNumber;
    }

    public void AddError(string error)
    {
      var parseError = new ParseError(_currentLineNumber, _currentLine, error);
      _errors.Add(parseError);
    }

    public void OnUrl(IEnumerable<string> verbs, string url)
    {
      var parsedVerbs = ParseVerbs(verbs);
      var parsedUrlParts = ParseUrl(url);

      _urls.Add(new Url(parsedVerbs, parsedUrlParts));
    }

    static IEnumerable<UrlPart> ParseUrl(string url)
    {
      List<UrlPart> parts = new List<UrlPart>();
      foreach (var part in url.Split(new [] {'/'}, StringSplitOptions.RemoveEmptyEntries))
      {
        parts.Add(new UrlPart(part));
      }

      return parts;
    }

    IEnumerable<HttpVerbs> ParseVerbs(IEnumerable<string> verbs)
    {
      if (verbs.Contains("*"))
      {
        return Enum.GetValues(typeof(HttpVerbs)).Cast<HttpVerbs>();
      }

      List<HttpVerbs> parsedVerbs = new List<HttpVerbs>();

      foreach (var verb in verbs)
      {
        try
        {
          HttpVerbs parsedVerb = (HttpVerbs)Enum.Parse(typeof(HttpVerbs), verb, true);

          parsedVerbs.Add(parsedVerb);
        }
        catch (ArgumentException)
        {
          AddError(String.Format("Unknown verb: {0}, try one of these: {1}", verb,
            String.Join(", ", Enum.GetNames(typeof(HttpVerbs)).Select(x => x.ToUpper()).ToArray())));
        }
      }

      return parsedVerbs;
    }

    public void OnUsingNamespace(string @namespace)
    {
      _namespaces.Add(@namespace);
    }

    public ParseResult GetResult()
    {
      var urlConfig = new UrlConfig(_urls, _namespaces);

      return new ParseResult(urlConfig, _errors);
    }
  }

  public class ParseError
  {
    readonly int _lineNumber;
    readonly string _line;
    readonly string _error;

    public ParseError(int lineNumber, string line, string error)
    {
      _lineNumber = lineNumber;
      _line = line;
      _error = error;
    }
  }
}
