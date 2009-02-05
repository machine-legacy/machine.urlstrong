using System.Collections.Generic;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class PrioritizedLineParser : ILineParser
  {
    readonly IEnumerable<ILineParser> _lineParsers;

    public PrioritizedLineParser(IEnumerable<ILineParser> lineParsers)
    {
      _lineParsers = lineParsers;
    }

    public bool Parse(string line, IParseListener resultBuilder)
    {
      foreach (var parser in _lineParsers)
      {
        var parsed = parser.Parse(line, resultBuilder);
        if (parsed) return true;
      }

      return false;
    }
  }
}