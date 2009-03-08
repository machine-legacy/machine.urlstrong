using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Model;
using Spark;

namespace Machine.UrlStrong.Translation.Generation
{
  public abstract class TemplateBase : AbstractSparkView
  {
    public UrlStrongModel Model { get; set; }

    public string Indent(int tabs, string code)
    {
      var indentation = "  ";
      for (int i = 0; i < tabs - 1; i++)
      {
        indentation += "  ";
      }

      var builder = new StringBuilder();
      var reader = new StringReader(code);
      var line = reader.ReadLine();

      while (line != null)
      {
        builder.Append(indentation);
        builder.AppendLine(line);
        line = reader.ReadLine();
      }

      return builder.ToString();
    }

    public string Indent(string code)
    {
      return Indent(1, code);
    }
  }
}