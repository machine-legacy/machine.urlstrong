using Machine.UrlStrong.Mvc.Parameters;

namespace Machine.UrlStrong.Mvc
{
  public static class Parameter
  {
    public static IParameterConstraint Constraint(string constraint)
    {
      return new ParameterInfo(null, constraint);
    }
    
    public static IDefault Default(object @default)
    {
      return new ParameterInfo(@default, null);
    }
  }
}