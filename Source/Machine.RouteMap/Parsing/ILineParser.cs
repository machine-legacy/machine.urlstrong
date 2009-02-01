namespace Machine.RouteMap.Parsing
{
  public interface ILineParser
  {
    bool Parse(string line, IParseListener listener);
  }
}