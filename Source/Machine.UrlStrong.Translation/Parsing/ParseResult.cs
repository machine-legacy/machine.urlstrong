using System.Collections.Generic;
using System.Linq;
using Machine.UrlStrong.Translation.Model;

namespace Machine.UrlStrong.Translation.Parsing
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


    public UrlConfig UrlConfig
    {
      get; private set;
    }

    public ParseResult(UrlConfig urlConfig, IEnumerable<ParseError> errors)
    {
      UrlConfig = urlConfig;
      Errors = errors;
    }
  }
}