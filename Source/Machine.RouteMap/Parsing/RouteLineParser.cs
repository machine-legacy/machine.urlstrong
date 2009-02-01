using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Machine.Core;

namespace Machine.RouteMap.Parsing
{
  public class RouteLineParser : ILineParser
  {
    private static string[] httpVerbs = new string[] { "get", "post" };

    static string acceptedVerb = @"(?<acceptedVerb>\w+)";
    static string wildcardVerb = @"(?<acceptedVerb>\*)";
    static string route = @"(?<route>(/(\w+|\[\w+\]))+)";
    private static Regex regex = new Regex(string.Format(
    @"^\s*({2}|({0}(\s*\|\s*{0})*))\s+{1}", acceptedVerb, route, wildcardVerb), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    public bool Parse(string line, IParseListener listener)
    {
      var match = regex.Match(line);
      if (!match.Success)
        return false;

      var verbs = match.GroupCaptures("acceptedVerb").Select(x => x.Value);
      var route = match.Groups["route"].Value;

      verbs.Each(x => Console.WriteLine(x));

      listener.OnRoute(verbs, route);

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