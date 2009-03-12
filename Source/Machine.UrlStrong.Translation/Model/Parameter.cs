namespace Machine.UrlStrong.Translation.Model
{
  public class Parameter
  {
    public string Name
    {
      get; private set;
    }

    public string TypeName
    {
      get; private set;
    }

    public Parameter(string name, string typeName)
    {
      Name = name;
      TypeName = typeName;
    }

    public string FieldDeclaration
    { 
      get
      {
        return string.Format("{0} _{1};", TypeName, Name);
      }
    }

    public string FieldAssignment
    { 
      get
      {
        return string.Format("_{0} = {1};", Name, Name);
      }
    }

    public string FormalDeclaration
    {
      get
      {
        return string.Format("{0} {1}", TypeName, Name);
      }
    }
  }
}