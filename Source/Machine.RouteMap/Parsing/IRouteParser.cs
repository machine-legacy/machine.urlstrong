using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Machine.RouteMap.Parsing
{
  public interface IRouteParser
  {
    ParseResult Parse(TextReader reader);
  }
}
