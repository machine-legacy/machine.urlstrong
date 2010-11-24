using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Translation.Model
{
  public class ParsedUrl
  {
    public ParsedUrl(IEnumerable<HttpVerbs> acceptedVerbs, IEnumerable<ParsedUrlPart> parts, string hash, string comment)
    {
      AcceptedVerbs = acceptedVerbs;
      Parts = parts;
      Hash = hash;
      Comment = comment;
    }

    public IEnumerable<HttpVerbs> AcceptedVerbs
    {
      get; private set;
    }

    public IEnumerable<ParsedUrlPart> Parts
    {
      get; private set;
    }
    public string Hash 
    {
      get; private set; 
    }

    public string Comment
    {
      get; private set;
    }
  }
}