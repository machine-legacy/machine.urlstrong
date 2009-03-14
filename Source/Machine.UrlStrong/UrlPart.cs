using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong
{
  public class UrlPart
  {
    public static string Join(string left, string right)
    {
      if (left.EndsWith("/"))
      {
        return left + right;
      }

      return left + "/" + right;
    }
  }
}
