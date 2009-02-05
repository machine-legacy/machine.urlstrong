using System.Text.RegularExpressions;

namespace Machine.UrlStrong.Parsing
{
  public class UsingLineParser : ILineParser
  {
    static readonly Regex regex = new Regex(
      @"^\s*using\s+(?<namespace>\w+(\.\w+)*);?\s*$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

    public bool Parse(string line, IParseListener listener)
    {
      var match = regex.Match(line);
      if (!match.Success)
        return false;

      listener.OnUsingNamespace(match.Groups["namespace"].Value);

      return true;
    }
  }
}