using System;
using System.Collections.Generic;
using Machine.Core;

namespace Machine.Route66.Model
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

    public bool Equals(RoutePart obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;

      if (_partText != obj._partText) return false;
      if (_parameters.Count != obj._parameters.Count) return false;

      return (_parameters.ElementsEqualInOrder(obj._parameters));
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(RoutePart)) return false;
      return Equals((RoutePart) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((_parameters != null ? _parameters.GetHashCode() : 0)*397) ^ (_partText != null ? _partText.GetHashCode() : 0);
      }
    }
  }
}