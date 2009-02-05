using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Machine.Specifications;

namespace Machine.UrlStrong.Specs
{
  public class when_generating_: BigPictureSpecs
  {
    static string currentPath;
    static string result;
    Establish context = () => 
    {
      currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


      using(var reader = new StreamReader(Path.Combine(currentPath, "sample.routes")))
      using(var writer = new StringWriter())
      {
        var doIt = new DoIt();

        doIt.Now(reader, writer);

        result = writer.ToString();
      }
    };

    It should_look_right =()=>
      result.ShouldEqual(new StreamReader(Path.Combine(currentPath, "SampleRouteMap.cs")).ReadToEnd());
  }
  public class BigPictureSpecs
  {
  }
}
