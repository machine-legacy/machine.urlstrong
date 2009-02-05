using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Model;
using Spark;
using Spark.FileSystem;

namespace Machine.UrlStrong.Translation.Generation
{
  public class Generator
  {

    public void GenerateSafeUrls(UrlConfig config, TextWriter writer)
    {
      var settings = new SparkSettings().SetPageBaseType(typeof(UrlConfig));
      var templates = new InMemoryViewFolder();
      var engine = new SparkViewEngine(settings) {ViewFolder = templates};

      templates.Add("urls.spark", @"



");
    }
  }
}