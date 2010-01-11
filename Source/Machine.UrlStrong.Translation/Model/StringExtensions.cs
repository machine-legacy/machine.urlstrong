using System.Collections.Generic;

namespace Machine.UrlStrong.Translation.Model
{
  public static class StringExtensions
  {

    public static string ReplaceDashes(this string str)
    {
      return str.Replace('-', '_');
    }

    public static string EscapeReservedWords(this string str)
    {
      if (_reservedWords.ContainsKey(str))
        return '@' + str;

      return str;
    }

    readonly static IDictionary<string, bool> _reservedWords;
    static StringExtensions()
    {
      _reservedWords = new Dictionary<string, bool>();
      _reservedWords["abstract"] = true;
      _reservedWords["event"] = true;
      _reservedWords["new"] = true;
      _reservedWords["struct"] = true;
      _reservedWords["as"] = true;
      _reservedWords["explicit"] = true;
      _reservedWords["null"] = true;
      _reservedWords["switch"] = true;
      _reservedWords["base"] = true;
      _reservedWords["extern"] = true;
      _reservedWords["object"] = true;
      _reservedWords["this"] = true;
      _reservedWords["bool"] = true;
      _reservedWords["false"] = true;
      _reservedWords["operator"] = true;
      _reservedWords["throw"] = true;
      _reservedWords["break"] = true;
      _reservedWords["finally"] = true;
      _reservedWords["out"] = true;
      _reservedWords["true"] = true;
      _reservedWords["byte"] = true;
      _reservedWords["fixed"] = true;
      _reservedWords["override"] = true;
      _reservedWords["try"] = true;
      _reservedWords["case"] = true;
      _reservedWords["float"] = true;
      _reservedWords["params"] = true;
      _reservedWords["typeof"] = true;
      _reservedWords["catch"] = true;
      _reservedWords["for"] = true;
      _reservedWords["private"] = true;
      _reservedWords["uint"] = true;
      _reservedWords["char"] = true;
      _reservedWords["foreach"] = true;
      _reservedWords["protected"] = true;
      _reservedWords["ulong"] = true;
      _reservedWords["checked"] = true;
      _reservedWords["goto"] = true;
      _reservedWords["public"] = true;
      _reservedWords["unchecked"] = true;
      _reservedWords["class"] = true;
      _reservedWords["if"] = true;
      _reservedWords["readonly"] = true;
      _reservedWords["unsafe"] = true;
      _reservedWords["const"] = true;
      _reservedWords["implicit"] = true;
      _reservedWords["ref"] = true;
      _reservedWords["ushort"] = true;
      _reservedWords["continue"] = true;
      _reservedWords["in"] = true;
      _reservedWords["return"] = true;
      _reservedWords["using"] = true;
      _reservedWords["decimal"] = true;
      _reservedWords["int"] = true;
      _reservedWords["sbyte"] = true;
      _reservedWords["virtual"] = true;
      _reservedWords["default"] = true;
      _reservedWords["interface"] = true;
      _reservedWords["sealed"] = true;
      _reservedWords["volatile"] = true;
      _reservedWords["delegate"] = true;
      _reservedWords["internal"] = true;
      _reservedWords["short"] = true;
      _reservedWords["void"] = true;
      _reservedWords["do"] = true;
      _reservedWords["is"] = true;
      _reservedWords["sizeof"] = true;
      _reservedWords["while"] = true;
      _reservedWords["double"] = true;
      _reservedWords["lock"] = true;
      _reservedWords["stackalloc"] = true;
      _reservedWords["else"] = true;
      _reservedWords["long"] = true;
      _reservedWords["static"] = true;
      _reservedWords["enum"] = true;
      _reservedWords["namespace"] = true;
      _reservedWords["string"] = true;
    }
  }
}