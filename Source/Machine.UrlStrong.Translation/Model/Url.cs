using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Translation.Model
{
  public class Url
  {
    public Url(IEnumerable<HttpVerbs> acceptedVerbs, IEnumerable<UrlPart> parts)
    {
      AcceptedVerbs = acceptedVerbs;
      Parts = parts;
    }

    public IEnumerable<HttpVerbs> AcceptedVerbs
    {
      get; private set;
    }

    public IEnumerable<UrlPart> Parts
    {
      get; private set;
    }
  }
}