using System;
using System.Collections.Generic;
using Machine.Core;

namespace Machine.UrlStrong.Translation.Model
{
  public class UrlPart
  {
    readonly List<string> _parameters = new List<string>();
    readonly string _partName;
    readonly string _formatString;

    public UrlPart(string part)
    {
      var bits = SplitPartIntoBits(part);

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
          formatString += bit;
        }
      }

      _formatString = formatString;
      _partName = part.Replace('[', '_').Replace(']', '_');
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

    public bool Equals(UrlPart obj)
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
      if (obj.GetType() != typeof(UrlPart)) return false;
      return Equals((UrlPart) obj);
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