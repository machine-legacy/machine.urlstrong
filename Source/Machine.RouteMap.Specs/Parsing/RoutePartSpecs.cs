using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.RouteMap.Parsing;
using Machine.Specifications;

namespace Machine.RouteMap.Specs.Parsing
{
  [Subject(typeof(RoutePart))]
  public class when_creating_a_simple_route_part : RoutePartSpecs
  {
    Because of = () =>
      part = new RoutePart("hello");

    It should_have_no_parameters = () =>
      part.Parameters.Count().ShouldEqual(0);

    It should_be_able_to_build = () =>
      part.Build().ShouldEqual("hello");

    It should_have_the_part_in_the_part_text = () =>
      part.PartText.ShouldEqual("hello");
  }

  [Subject(typeof(RoutePart))]
  public class when_creating_a_parameter_route_part : RoutePartSpecs
  {
    Because of = () =>
      part = new RoutePart("[id]");

    It should_have_one_parameter = () =>
      part.Parameters.Count().ShouldEqual(1);

    It should_have_an_id_parameter = () =>
      part.Parameters.First().ShouldEqual("id");

    It should_have_an_underscore_in_the_part_text = () =>
      part.PartText.ShouldEqual("_");

    It should_be_able_to_build_with_a_parameter = () =>
      part.Build(3).ShouldEqual("3");

    It should_not_be_able_to_build_without_parameters = () =>
      Catch.Exception(() => part.Build()).ShouldNotBeNull();
  }

  [Subject(typeof(RoutePart))]
  public class when_creating_an_embedded_parameter_route_part : RoutePartSpecs
  {
    Because of = () =>
      part = new RoutePart("foo[id]bar");

    It should_have_one_parameter = () =>
      part.Parameters.Count().ShouldEqual(1);

    It should_have_an_id_parameter = () =>
      part.Parameters.First().ShouldEqual("id");

    It should_be_able_to_build_with_a_parameter = () =>
      part.Build(3).ShouldEqual("foo3bar");

    It should_not_be_able_to_build_without_parameters = () =>
      Catch.Exception(() => part.Build()).ShouldNotBeNull();
  }

  public class RoutePartSpecs
  {
    protected static RoutePart part;
  }
}
