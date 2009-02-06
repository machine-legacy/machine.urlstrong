using System;
using System.Collections.Generic;
using System.IO;
using Machine.UrlStrong.Translation.Model;

namespace Machine.UrlStrong.Translation.Parsing
{
  public class UrlMapParser : IUrlMapParser
  {
    readonly List<Url> _urls;
    readonly List<UrlPart> _urlParts;
    readonly ILineParser _lineParser;
    int _currentLineNumber;

    public UrlMapParser()
    {
      _urls = new List<Url>();
      _urlParts = new List<UrlPart>();
      _lineParser = new PrioritizedLineParser(new ILineParser[]
      {
        new BlankLineSkipper(),
        new UsingLineParser(),
        new NamespaceLineParser(),
        new UrlLineParser()
      });
    }

    public void Parse(TextReader reader, IParseListener listener)
    {
      if (reader == null) throw new ArgumentNullException("reader");

      _currentLineNumber = 0;
      string line = reader.ReadLine();
      while (line != null)
      {
        ParseLine(line, listener);

        ++_currentLineNumber;
        line = reader.ReadLine();
      }
    }

    void ParseLine(string line, IParseListener listener)
    {
      listener.BeginLine(_currentLineNumber, line);
      var parsed = _lineParser.Parse(line, listener);

      if (!parsed)
      {
        listener.AddError("Sorry, no idea what this line is supposed to be.");
      }
    }
  }
}