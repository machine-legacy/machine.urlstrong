using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Translation.Parsing
{
  public interface IRouteParser
  {
    void Parse(TextReader reader, IParseListener listener);
  }
}
