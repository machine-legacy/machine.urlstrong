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
      result = Parse("GET /home");

    It should_not_have_errors = () =>
      result.HasErrors.ShouldBeFalse();

    It should_have_only_one_route = () =>
      result.Routes.Count().ShouldEqual(1);

    It should_have_a_get_route = () =>
      result.Routes.First().AcceptedVerbs.ShouldContainOnly(HttpVerbs.Get);

    It should_have_a_route_with_only_one_part = () =>
      result.Routes.First().Parts.Count().ShouldEqual(1);

    It should_have_a_route_with_a_home_part = () =>
      result.Routes.First().Parts.First().ShouldEqual(new RoutePart("home"));
 }

  [Subject("Parse Result")]
  public class when_parsed_from_a_sample_route_map : RouteParserSpecs
  {
    Because of = () =>
      result = Parse(@"
using Machine.RouteMap.Sample.Controllers;

GET /home
GET /user/[id]
GET /user/[id]/friend/list
GET|POST /user/[id]/friend/[friendId]
GET /foo/[id]
GET /foo/[id]/[id2]
GET /foo/[id]/[id2]/bar
GET /yadda[id]blah");

    It should_not_have_errors = () =>
      result.HasErrors.ShouldBeFalse();

    It should_have_eight_routes = () =>
      result.Routes.Count().ShouldEqual(8);

    It should_have_one_namespace = () =>
      result.Namespaces.Count().ShouldEqual(1);
 }

  public class RouteParserSpecs
  {
    protected static RouteParser parser;
    protected static ParseResult result;

    Establish context = () =>
    {
      parser = new RouteParser();
    };

    protected static ParseResult Parse(string routes)
    {
      var builder = new ParseResultBuilder();
      parser.Parse(new StringReader(routes), builder);

      return builder.BuildResult();
    }
  }
}
