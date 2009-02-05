using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Parsing;
using Arg=Moq.It;

namespace Machine.UrlStrong.Specs.Parsing
{
  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_simple_get_route : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "GET" }, "/home"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_get_and_post_route : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET|POST /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "GET", "POST" }, "/home"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_route_with_all_the_supported_verbs : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET|POST|DELETE|PUT /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "GET", "POST", "DELETE", "PUT" }, "/home"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_route_with_an_unknown_verb : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("FOOBAR /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "FOOBAR" }, "/home"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_route_with_a_wildcard_for_a_verb : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("* /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "*" }, "/home"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_route_with_a_parameter_embedded_in_a_part : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("* /foo[id]bar", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_route=()=>
      listener.ShouldHaveReceived(x => x.OnRoute(new [] { "*" }, "/foo[id]bar"));
  }

  [Subject(typeof(RouteLineParser))]
  public class when_parsing_a_using_statement : RouteLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("using foo.bar;", listener);

    It should_not_be_able_to_parse_it=()=>
      result.ShouldBeFalse();
  }

  public class RouteLineParserSpecs : SpecsWithMocks
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