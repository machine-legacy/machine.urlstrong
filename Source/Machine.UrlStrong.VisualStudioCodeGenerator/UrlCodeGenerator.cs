using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.CustomTool;
using Microsoft.Win32;

namespace Machine.UrlStrong.VisualStudioCodeGenerator
{
  [ComVisible(true)]
  [Guid("1d4c8437-c2e6-45f8-aba7-6c25a2dc0d1b")]
  public class UrlCodeGenerator : BaseCodeGeneratorWithSite
  {
    static readonly Guid CSharpCategoryGuid = new Guid("FAE04EC1-301F-11d3-BF4B-00C04F79EFBC");
    const string ToolName = "Machine.UrlStrong.VisualStudioCodeGenerator.UrlCodeGenerator";
    const string UrlFileExtension = ".urls";

    public override string GetDefaultExtension()
    {
      return ".generated.cs";
    }

    protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
    {
      return Encoding.ASCII.GetBytes(GenerateCodeString(inputFileName, inputFileContent));
    }

    static string GenerateCodeString(string inputFileName, string inputFileContent)
    {
      try
      {
        var doIt = new DoIt();
        using (var reader = new StringReader(inputFileContent))
        using (var writer = new StringWriter())
        {
          doIt.Now(reader, writer);
          return writer.ToString();
        }
      }
      catch (Exception err)
      {
        return "/*" + err + "*/";
      }
    }

    [ComRegisterFunction]
    public static void RegisterClass(Type t)
    {
      RegisterCustomTool(CSharpCategoryGuid, typeof(UrlCodeGenerator), "Machine UrlStrong CodeGenerator");
    }

    [ComUnregisterFunction]
    public static void UnregisterClass(Type t)
    {
      UnregisterCustomTool(CSharpCategoryGuid, typeof(UrlCodeGenerator));
    }

    protected static void RegisterCustomTool(Guid languageGuid, Type generatorType, string description)
    {
      string guid = ((GuidAttribute)generatorType.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
      CreateKey(GetKeyName(languageGuid, VersionInformation.VisualStudioVersion), description, guid);
      CreateKey(GetExtensionKeyName(languageGuid, VersionInformation.VisualStudioVersion), ToolName, guid);
    }

    protected static void CreateKey(string keyName, string description, string guid)
    {
      using (RegistryKey key = Registry.LocalMachine.CreateSubKey(keyName))
      {
        key.SetValue("", description);
        key.SetValue("CLSID", "{" + guid + "}");
        key.SetValue("GeneratesDesignTimeSource", 1);
      }
    }


    protected static void UnregisterCustomTool(Guid languageGuid, Type generatorType)
    {
      Registry.LocalMachine.DeleteSubKey(GetKeyName(languageGuid, VersionInformation.VisualStudioVersion), false);
      Registry.LocalMachine.DeleteSubKey(GetExtensionKeyName(languageGuid, VersionInformation.VisualStudioVersion), false);
    }

    protected static string GetExtensionKeyName(Guid languageGuid, string version)
    {
      string text1 = string.Format(@"SOFTWARE\Microsoft\VisualStudio\{0}\Generators\", version);
      return (text1 + "{" + languageGuid + @"}\" + UrlFileExtension);
    }

    protected static string GetKeyName(Guid languageGuid, string version)
    {
      string text1 = string.Format(@"SOFTWARE\Microsoft\VisualStudio\{0}\Generators\", version);
      return (text1 + "{" + languageGuid + @"}\" + ToolName);
    }


    public void asdf()
    {
      Console.WriteLine(Guid.NewGuid().ToString());
      Console.WriteLine(Guid.NewGuid().ToString());
      Console.WriteLine(Guid.NewGuid().ToString());
      Console.WriteLine(Guid.NewGuid().ToString());
    }
  }
}
