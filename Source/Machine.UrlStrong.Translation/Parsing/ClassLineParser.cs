using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class ClassLineParser : ILineParser
  {
    static readonly Regex regex = new Regex(
      @"^\s*class\s+(?<className>\w+(\.\w+)*);?\s*$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

    public bool Parse(string line, IParseListener listener)
    {
      var match = regex.Match(line);
      if (!match.Success)
        return false;

      listener.OnClassName(match.Groups["className"].Value);

      return true;
    }
  }
}
