using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Route66.Model;
using Spark;
using Spark.FileSystem;

namespace Machine.Route66.Generation
{
  public class Generator
  {

    public void GenerateSafeUrls(RouteConfig config, TextWriter writer)
    {
      var settings = new SparkSettings().SetPageBaseType(typeof(RouteConfig));
      var templates = new InMemoryViewFolder();
      var engine = new SparkViewEngine(settings) {ViewFolder = templates};

      templates.Add("routes.spark", @"



");
    }
  }
}