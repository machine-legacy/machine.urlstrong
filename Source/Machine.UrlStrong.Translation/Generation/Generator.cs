using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Machine.UrlStrong.Translation.Model;
using Spark;
using Spark.FileSystem;

namespace Machine.UrlStrong.Translation.Generation
{
  public class Generator
  {
    public void GenerateStrongUrls(UrlStrongModel strongModel, TextWriter writer)
    {
      var engine = new SparkViewEngineFactory().CreateViewEngine();

      var descriptor = new SparkViewDescriptor().AddTemplate("master.spark");

      var template = (TemplateBase)engine.CreateInstance(descriptor);

      template.Model = strongModel;
      template.RenderView(writer);
    }
  }
}