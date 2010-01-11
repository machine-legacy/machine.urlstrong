namespace Machine.UrlStrong.Translation.Model
{
  public class Parameter
  {
    public string Name
    {
      get; private set;
    }

    public string FormalParameterName
    {
      get { return Name.EscapeReservedWords(); }
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
        return string.Format("readonly {0} {1};", TypeName, FieldName);
      }
    }

    public string FieldAssignment
    { 
      get
      {
        return string.Format("{0} = {1};", FieldName, FormalParameterName);
      }
    }

    public string FormalDeclaration
    {
      get
      {
        return string.Format("{0} {1}", TypeName, FormalParameterName);
      }
    }

    public string FieldName
    {
      get { return "_" + Name; }
    }
  }
}