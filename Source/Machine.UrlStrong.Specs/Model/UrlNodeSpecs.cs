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

  public class UrlNodeSpecs
  {
  }
}
