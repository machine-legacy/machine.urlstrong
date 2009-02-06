using System.Text.RegularExpressions;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class NamespaceLineParser : ILineParser
  {
    static readonly Regex regex = new Regex(
      @"^\s*namespace\s+(?<namespace>\w+(\.\w+)*);?\s*$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

    public bool Parse(string line, IParseListener listener)
    {
      var match = regex.Match(line);
      if (!match.Success)
        return false;

      listener.OnNamespace(match.Groups["namespace"].Value);

      return true;
    }
  }
}