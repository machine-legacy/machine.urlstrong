using System.IO;
using System.Linq;
using System.Text;
using Machine.RouteMap.Parsing;
using Machine.Specifications;

namespace Machine.RouteMap.Specs.Parsing
{
  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_simple_get_route : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route_beginning =()=>
      listener.ShouldHaveBeenToldTo(x => x.OnRouteBegin());

    It should_parse_get_accepted_verb =()=> 
      listener.ShouldHaveBeenToldTo(x => x.OnAcceptedVerb(HttpVerbs.Get));

    It should_parse_the_route_part =()=>
      listener.ShouldHaveBeenToldTo(x => x.OnPart("home"));

    It should_parse_route_ending =()=>
      listener.ShouldHaveBeenToldTo(x => x.OnRouteEnd());
  }

  public class RouteLineParserSpecs 
  {
    protected static RouteLineParser parser;
    protected static IParseListener listener;
    protected static bool result;

    Establish context = () =>
    {
      parser = new RouteLineParser();
      listener = Mock.Create<IParseListener>();
    };
  }
}