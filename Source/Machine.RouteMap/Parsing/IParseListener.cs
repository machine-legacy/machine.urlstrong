namespace Machine.RouteMap.Parsing
{
  public interface IParseListener
  {
    void AddError(string line);
    void OnRouteBegin();
    void OnAcceptedVerb(HttpVerbs verb);
    void OnPart(string part);
    void OnRouteEnd();
  }
}