using Machine.Specifications;

namespace Machine.RouteMap.Specs
{
  public class SpecsWithMocks
  {
    Cleanup after = () => 
      Mock.ClearMap();
  }
}