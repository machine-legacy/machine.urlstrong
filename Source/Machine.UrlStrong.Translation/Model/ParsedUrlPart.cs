using System;
using System.Collections.Generic;
using Machine.Core;

namespace Machine.UrlStrong.Translation.Model
{
  public class ParsedUrlPart
  {
    readonly List<string> _parameters = new List<string>();
    readonly string _partName;
    readonly string _formatString;
    readonly bool _isOnlyParameter;

    public ParsedUrlPart(string part)
    {
      var bits = SplitPartIntoBits(part);
      if (bits.Length == 0)
        return;

      _isOnlyParameter = true;

      string formatString = "";
      int count = 0;
      foreach (var bit in bits)
      {
        if (IsParameterBit(bit))
        {
          _parameters.Add(GetParameterNameFromBit(bit));
          formatString += "{" + count + "}";
          ++count;
        }
        else
        {
          _isOnlyParameter = false;
          formatString += bit;
        }
      }

      _formatString = formatString;
      _partName = part.Replace('[', '_').Replace(']', '_');
    }

    public bool IsOnlyParameter
    {
      get { return _isOnlyParameter; }
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

    public string PartName
    {
      get { return _partName; }
    }

    public string Build(params object[] parameters)
    {
      return String.Format(_formatString, parameters);
    }

    public bool Equals(ParsedUrlPart obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;

      if (_partName != obj._partName) return false;
      if (_parameters.Count != obj._parameters.Count) return false;

      return (_parameters.ElementsEqualInOrder(obj._parameters));
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(ParsedUrlPart)) return false;
      return Equals((ParsedUrlPart) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((_parameters != null ? _parameters.GetHashCode() : 0)*397) ^ (_partName != null ? _partName.GetHashCode() : 0);
      }
    }
  }
}