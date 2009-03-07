using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Machine.UrlStrong.Generator
{
  public class Program
  {
    static void Main(string[] args)
    {
      if (args.Length < 2)
      {
        Console.WriteLine("usage: urlstrong.exe <url map> <output>");
        Environment.Exit(1);
        return;
      }

      if (!File.Exists(args[0]))
      {
        Console.WriteLine("Can't find url map: " + args[0]);
        Environment.Exit(1);
        return;
      }

      var outDir = Path.GetDirectoryName(args[1]);
      if (!String.IsNullOrEmpty(outDir) && !Directory.Exists(outDir))
      {
        Console.WriteLine("Can't find output dir: " + outDir);
        Environment.Exit(1);
        return;
      }

      using(var reader = new StreamReader(args[0]))
      using(var writer = new StreamWriter(args[1]))
      {
        var doIt = new DoIt();

        doIt.Now(reader, writer);
      }
    }
  }
}