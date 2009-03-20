using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Spark;
using Spark.FileSystem;

namespace Machine.UrlStrong.Translation.Generation
{
  public class SparkViewEngineFactory
  {
    public SparkViewEngine CreateViewEngine()
    {
      var settings = new SparkSettings().SetPageBaseType(typeof(TemplateBase))
        .AddNamespace("System")
        .AddNamespace("System.Linq");
      var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var templates = new FileSystemViewFolder(Path.Combine(dir, "Templates"));
      var engine = new SparkViewEngine(settings) { ViewFolder = templates };

      return engine;
    }
  }
}
