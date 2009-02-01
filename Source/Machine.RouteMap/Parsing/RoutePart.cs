using System;
using System.Collections.Generic;

namespace Machine.RouteMap.Parsing
{
  public class RoutePart
  {
    readonly List<string> _parameters = new List<string>();
    readonly string _partText;
    readonly string _formatString;

    public RoutePart(string part)
    {
      var bits = SplitPartIntoBits(part);

      string partText = "";
      string formatString = "";
      int count = 0;
      foreach (var bit in bits)
      {
        if (IsParameterBit(bit))
        {
          _parameters.Add(GetParameterNameFromBit(bit));
          partText += '_';
          formatString += "{" + count + "}";
          ++count;
        }
        else
        {
          formatString += bit;
          partText += bit;
        }
      }

      _formatString = formatString;
      _partText = partText;
    }

    static string[] SplitPartIntoBits(string part)
    {
      return part.Replace("[", "|[").Replace("]", "]|").
        Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
    }

    static bool IsParameterBit(string bit)
    {
      return bit[0] == '[';
    }

    static string GetParameterNameFromBit(string bit)
    {
      return bit.Substring(1, bit.Length - 2);
    }

    public IEnumerable<string> Parameters
    {
      get { return _parameters; }
    }

    public string PartText
    {
      get { return _partText; }
    }

    public string Build(params object[] parameters)
    {
      return String.Format(_formatString, parameters);
    }
  }
}