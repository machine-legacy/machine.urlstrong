using Machine.Specifications;

namespace Machine.Route66.Specs
{
  public class SpecsWithMocks
  {
    Cleanup after = () => 
      Mock.ClearMap();
  }
}