namespace Machine.UrlStrong.Mvc.Parameters
{
  public interface IDefaultAndConstraint {}
  public interface IDefault
  {
    IDefaultAndConstraint Constraint(string constraint);
  }

  public interface IParameterConstraint
  {
    IDefaultAndConstraint Default(object @default);
  }

  public class ParameterInfo : IParameterConstraint, IDefault, IDefaultAndConstraint
  {
    object _default;
    string _constraint;

    public object GetDefault()
    {
      return _default;
    }

    public string GetConstraint()
    {
      return _constraint;
    }

    public ParameterInfo(object @default, string constraint)
    {
      _default = @default;
      _constraint = constraint;
    }

    public IDefaultAndConstraint Constraint(string constraint)
    {
      _constraint = constraint;
      return this;
    }
    
    public IDefaultAndConstraint Default(object @default)
    {
      _default = @default;
      return this;
    }
  }
}