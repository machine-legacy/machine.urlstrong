using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class UrlLineParser : ILineParser
  {
    const string acceptedVerb = @"(?<acceptedVerb>\w+)";
    const string wildcardVerb = @"(?<acceptedVerb>\*)";
    const string url = @"(?<url>(/(\w+|\[\w+\])*)+)";
    static readonly Regex regex = new Regex(string.Format(
      @"^\s*({2}|({0}(\s*\|\s*{0})*))\s+{1}\s*$", acceptedVerb, url, wildcardVerb), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    public bool Parse(string line, IParseListener listener)
    {
      var match = regex.Match(line);
      if (!match.Success)
        return false;

      var verbs = match.GroupCaptures("acceptedVerb").Select(x => x.Value);
      var url = match.Groups["url"].Value;

      listener.OnUrl(verbs, url);

      return true;
    }
  }

  public static class RegexExtensionMethods
  {
    public static IEnumerable<Capture> GroupCaptures(this Match match, string groupName)
    {
      var group = match.Groups[groupName];

      for (int i = 0; i < group.Captures.Count; i++)
      {
        yield return group.Captures[i];
      }
    }
  }
}