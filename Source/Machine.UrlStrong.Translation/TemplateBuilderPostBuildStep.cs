using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using Machine.UrlStrong.Translation.Generation;
using Spark;

namespace Machine.UrlStrong.Translation
{
  [RunInstaller(true)]
  public partial class TemplateBuilderPostBuildStep : Installer
  {
    public TemplateBuilderPostBuildStep()
    {
      InitializeComponent();
    }

    public override void Install(System.Collections.IDictionary stateSaver)
    {
      var engine = new SparkViewEngineFactory().CreateViewEngine();
      string assemblyPath = GetType().Assembly.Location;
      string targetPath = Path.ChangeExtension(assemblyPath, ".Templates.dll");

      var descriptors = new List<SparkViewDescriptor>();
      descriptors.Add(new SparkViewDescriptor().AddTemplate("master.spark"));
      engine.BatchCompilation(targetPath, descriptors);
    }

    public override void Commit(IDictionary savedState)
    {
    }
  }
}
