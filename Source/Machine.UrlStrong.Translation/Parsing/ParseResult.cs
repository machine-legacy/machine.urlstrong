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


    public UrlStrongModel UrlStrongModel
    {
      get; private set;
    }

    public ParseResult(UrlStrongModel urlStrongModel, IEnumerable<ParseError> errors)
    {
      UrlStrongModel = urlStrongModel;
      Errors = errors;
    }
  }
}