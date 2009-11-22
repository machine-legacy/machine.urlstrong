using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong
{
  public class UrlPart
  {
    protected UrlPart _parent;
    private readonly IDictionary<string, object> _parameters;

    protected UrlPart(UrlPart parent)
    {
      _parent = parent;
      _parameters = parent._parameters;
    }

    protected void AddParameter(string name, object value)
    {
      if (_parameters.ContainsKey(name))
        throw new InvalidOperationException("Looks like " + GetType() + " has multiple " + name + " parameters");

      _parameters[name] = value;
    }
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
