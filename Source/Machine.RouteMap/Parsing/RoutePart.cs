using System;

namespace Machine.RouteMap.Parsing
{
  public class SimpleRoutePart : RoutePart
  {
    readonly string _part;

    public SimpleRoutePart(string part)
    {
      if (String.IsNullOrEmpty(part)) throw new ArgumentNullException("part");
      _part = part;
    }

    public bool Equals(SimpleRoutePart obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return Equals(obj._part, _part);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(SimpleRoutePart)) return false;
      return Equals((SimpleRoutePart) obj);
    }

    public override int GetHashCode()
    {
      return _part.GetHashCode();
    }
  }

  public class ParameterRoutePart : RoutePart
  {
    readonly string _parameterName;

    public ParameterRoutePart(string parameterName)
    {
      if (String.IsNullOrEmpty(parameterName)) throw new ArgumentNullException("parameterName");

      _parameterName = parameterName;
    }

    public bool Equals(ParameterRoutePart obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return Equals(obj._parameterName, _parameterName);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(ParameterRoutePart)) return false;
      return Equals((ParameterRoutePart) obj);
    }

    public override int GetHashCode()
    {
      return (_parameterName != null ? _parameterName.GetHashCode() : 0);
    }
  }

  public abstract class RoutePart
  {
  }
}