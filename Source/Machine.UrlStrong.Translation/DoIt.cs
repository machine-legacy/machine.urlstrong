using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Parsing;
using Machine.UrlStrong.Translation.Generation;

namespace Machine.UrlStrong
{
  public class DoIt
  {
    public void Now(TextReader reader, TextWriter writer)
    {
      var parser = new UrlMapParser();
      var listener = new ParseResultBuilder();

      parser.Parse(reader, listener);

      var result = listener.GetResult();

      var generator = new Generator();
      generator.GenerateSafeUrls(result.UrlConfig, writer);
    }
  }
}
