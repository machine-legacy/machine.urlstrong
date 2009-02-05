namespace Machine.UrlStrong.Parsing
{
  public interface ILineParser
  {
    bool Parse(string line, IParseListener listener);
  }

  public class BlankLineSkipper : ILineParser
  {
    public bool Parse(string line, IParseListener listener)
    {
      if (string.IsNullOrEmpty(line.Trim()))
      {
        return true;
      }

      return false;
    }
  }
}