using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class UrlLineParser : ILineParser
  {
    const string AcceptedVerb = @"(?<acceptedVerb>\w+)";
    const string WildcardVerb = @"(?<acceptedVerb>\*)";
    const string Url = @"(?<url>(/([-\w]+|\[\w+\])*)+)";
    const string Hash = @"(\#(?<hash>[-\w]+))?";
    const string Comment = @"(?<comment>.*)";
    const string CommentToken = @"\s\#\s?";
    static readonly Regex Regex = new Regex(string.Format(
      @"^\s*({2}|({0}(\s*\|\s*{0})*))\s+{1}{3}\s*?({4}{5})?$", AcceptedVerb, Url, WildcardVerb, Hash, CommentToken, Comment), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    public bool Parse(string line, IParseListener listener)
    {
      var match = Regex.Match(line);
      if (!match.Success)
        return false;

      var verbs = match.GroupCaptures("acceptedVerb").Select(x => x.Value);
      var url = match.Groups["url"].Value;
      var hash = match.Groups["hash"].Value;
      var comment = match.Groups["comment"].Value;

      listener.OnUrl(verbs, url, hash, comment);

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