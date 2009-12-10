using System.Linq;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Model;

namespace Machine.UrlStrong.Specs.Model
{
  [Subject(typeof(ParsedUrlPart))]
  public class when_creating_a_simple_url_part : UrlPartSpecs
  {
    Because of = () =>
                 part = new ParsedUrlPart("hello");

    It should_have_no_parameters = () =>
      part.Parameters.Count().ShouldEqual(0);

    It should_be_able_to_build = () =>
      part.Build().ShouldEqual("hello");

    It should_have_the_part_in_the_part_text = () =>
      part.PartName.ShouldEqual("hello");
  }

  [Subject(typeof(ParsedUrlPart))]
  public class when_creating_a_url_part_with_a_dash : UrlPartSpecs
  {
    Because of = () =>
                 part = new ParsedUrlPart("foo-bar");

    It should_have_no_parameters = () =>
      part.Parameters.Count().ShouldEqual(0);

    It should_be_able_to_build = () =>
      part.Build().ShouldEqual("foo-bar");

    It should_have_the_part_in_the_part_text = () =>
      part.PartName.ShouldEqual("foo-bar");
  }

  [Subject(typeof(ParsedUrlPart))]
  public class when_creating_a_parameter_url_part : UrlPartSpecs
  {
    Because of = () =>
                 part = new ParsedUrlPart("[id]");

    It should_have_one_parameter = () =>
      part.Parameters.Count().ShouldEqual(1);

    It should_have_an_id_parameter = () =>
      part.Parameters.First().ShouldEqual("id");

    It should_have_a_part_name_surrounded_by_underscores = () =>
      part.PartName.ShouldEqual("_id_");

    It should_be_able_to_build_with_a_parameter = () =>
      part.Build(3).ShouldEqual("3");

    It should_not_be_able_to_build_without_parameters = () =>
      Catch.Exception(() => part.Build()).ShouldNotBeNull();
  }

  [Subject(typeof(ParsedUrlPart))]
  public class when_creating_an_embedded_parameter_url_part : UrlPartSpecs
  {
    Because of = () =>
                 part = new ParsedUrlPart("foo[id]bar");

    It should_have_one_parameter = () =>
      part.Parameters.Count().ShouldEqual(1);

    It should_have_an_id_parameter = () =>
      part.Parameters.First().ShouldEqual("id");

    It should_have_a_part_name_with_the_parameter_name_surrounded_by_underscores = () =>
      part.PartName.ShouldEqual("foo_id_bar");

    It should_be_able_to_build_with_a_parameter = () =>
      part.Build(3).ShouldEqual("foo3bar");

    It should_not_be_able_to_build_without_parameters = () =>
      Catch.Exception(() => part.Build()).ShouldNotBeNull();
  }

  [Subject(typeof(ParsedUrlPart))]
  public class when_creating_an_embedded_parameter_url_part_with_multiple_parameters : UrlPartSpecs
  {
    Because of = () =>
                 part = new ParsedUrlPart("foo[id]bar[xx]yadda");

    It should_have_two_parameters = () =>
      part.Parameters.Count().ShouldEqual(2);

    It should_have_an_both_parameters = () =>
      part.Parameters.ShouldContainOnly("id", "xx");

    It should_be_able_to_build_with_both_parameters = () =>
      part.Build(3, 4).ShouldEqual("foo3bar4yadda");

    It should_not_be_able_to_build_without_parameters = () =>
      Catch.Exception(() => part.Build()).ShouldNotBeNull();
  }

  public class UrlPartSpecs
  {
    protected static ParsedUrlPart part;
  }
}


