using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Machine.UrlStrong.MSBuild
{
  public class GenerateUrlsTask : Task
  {
    [Required]
    public ITaskItem[] InputFiles { get; set; }

    public ITaskItem OutputDir { get; set; }

    [Output]
    public ITaskItem[] OutputFiles { get; private set; }

    public override bool Execute()
    {
      var outputFiles = new List<ITaskItem>();

      foreach (var item in InputFiles)
      {
        if (item.ItemSpec.Length == 0) continue;

        var input = item.ItemSpec;
        if (!File.Exists(input))
        {
          Log.LogError("Couldn't find url file: {0}", item.ItemSpec);
          return false;
        }

        string outputDir;
        if (OutputDir != null && OutputDir.ItemSpec.Length > 0)
        {
          if (!Directory.Exists(OutputDir.ItemSpec))
          {
            Log.LogError("Output directory doesn't exist: {0}", OutputDir.ItemSpec);
            return false;
          }

          outputDir = OutputDir.ItemSpec;
        }
        else
        {
          outputDir = Path.GetDirectoryName(input);
        }

        var output = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(input) + ".generated.cs");

        using (var reader = new StreamReader(input))
        using (var writer = new StreamWriter(output))
        {
          var doIt = new DoIt();

          doIt.Now(reader, writer);
          outputFiles.Add(new TaskItem(output));
        }
      }
      OutputFiles = outputFiles.ToArray<ITaskItem>();
      return true;
    }
  }
}
