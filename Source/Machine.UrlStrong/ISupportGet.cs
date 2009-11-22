using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong
{
  public interface IUrl
  {
    IEnumerable<KeyValuePair<string, object>> Parameters { get; }
    string ToParameterizedUrl();
  }

  public interface ISupportGet : IUrl
  {
  }
}