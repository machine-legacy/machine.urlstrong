using System;
using System.Collections.Generic;
using System.IO;

namespace Machine.RouteMap.Parsing
{
  public class RouteParser : IRouteParser
  {
    readonly List<Route> _routes;
    readonly List<RoutePart> _routeParts;
    readonly ParseResultBuilder _resultBuilder;
    readonly ILineParser _lineParser;

    public RouteParser()
    {
      _resultBuilder = new ParseResultBuilder();
      _routes = new List<Route>();
      _routeParts = new List<RoutePart>();
      _lineParser = new PrioritizedLineParser(new ILineParser[]
      {
        new UsingLineParser(),
        new RouteLineParser()
      });
    }

    public ParseResult Parse(TextReader reader)
    {
      if (reader == null) throw new ArgumentNullException("reader");

      string line = reader.ReadLine();
      while (line != null)
      {
        ParseLine(line);
      }

      return null;
    }

    void ParseLine(string line)
    {
      var parsed = _lineParser.Parse(line, _resultBuilder);

      if (!parsed)
      {
        _resultBuilder.AddError(line);
      }
    }
  }
}