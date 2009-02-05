using System.Text.RegularExpressions;

namespace Machine.Route66.Parsing
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