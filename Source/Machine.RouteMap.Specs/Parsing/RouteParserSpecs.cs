using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.RouteMap.Parsing;
using Machine.Specifications;

namespace Machine.RouteMap.Specs.Parsing
{
  [Subject("Parse Result")]
  public class when_parsed_from_simple_get_route : RouteParserSpecs
  {
    Because of = () =>
      result = parser.Parse(new StringReader("GET /home"));

    It should_not_have_errors = () =>
      result.HasErrors.ShouldBeFalse();

    It should_have_only_one_route = () =>
      result.Routes.Count().ShouldEqual(1);

    It should_have_a_get_route = () =>
      result.Routes.First().AcceptedVerbs.ShouldContainOnly(HttpVerbs.Get);

    It should_have_a_route_with_only_one_part = () =>
      result.Routes.First().Parts.Count().ShouldEqual(1);

    It should_have_a_route_with_a_home_part = () =>
      result.Routes.First().Parts.First().ShouldEqual(new SimpleRoutePart("home"));
 }

  public class RouteParserSpecs
  {
    protected static RouteParser parser;
    protected static ParseResult result;

    Establish context = () =>
    {
      parser = new RouteParser();
    };
  }
}
