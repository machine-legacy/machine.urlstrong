using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Model;

namespace Machine.UrlStrong.Specs.Model
{
  [Subject(typeof(UrlNode))]
  public class when_creating_a_UrlNode_with_parameters
  {
    static UrlNode node;
    Establish context = () =>
    {
      node = new UrlNode(new ParsedUrlPart("foo[id]bar"));
    };

    It should_have_a_format_string_with_parameters = () =>
      node.FormatString.ShouldEqual("foo{0}bar");
  }

  [Subject(typeof(UrlNode))]
  public class when_creating_a_UrlNode_with_a_dash
  {
    static UrlNode node;
    Establish context = () =>
    {
      node = new UrlNode(new ParsedUrlPart("foo-bar"));
    };

    It should_have_ClassName_with_underscore = () =>
      node.ClassName.ShouldEqual("Foo_bar");

    It should_have_AccessorName_with_underscore = () =>
      node.AccessorName.ShouldEqual("foo_bar");

    It should_have_a_format_string_with_dash = () =>
      node.FormatString.ShouldEqual("foo-bar");
  }

  public class UrlNodeSpecs
  {
  }
}
