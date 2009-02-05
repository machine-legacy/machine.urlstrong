using Machine.Specifications;

namespace Machine.UrlStrong.Specs
{
  public class SpecsWithMocks
  {
    Cleanup after = () => 
      Mock.ClearMap();
  }
}