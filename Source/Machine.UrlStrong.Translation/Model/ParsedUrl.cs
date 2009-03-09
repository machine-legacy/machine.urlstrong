using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Translation.Model
{
  public class ParsedUrl
  {
    public ParsedUrl(IEnumerable<HttpVerbs> acceptedVerbs, IEnumerable<ParsedUrlPart> parts)
    {
      AcceptedVerbs = acceptedVerbs;
      Parts = parts;
    }

    public IEnumerable<HttpVerbs> AcceptedVerbs
    {
      get; private set;
    }

    public IEnumerable<ParsedUrlPart> Parts
    {
      get; private set;
    }
  }
}