using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Parsing;
using Machine.Specifications;

namespace Machine.UrlStrong.Specs.Parsing
{
  [Subject(typeof(UsingLineParser))]
  public class when_parsing_a_using_line : UsingLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("using Foo.Bar;", listener);
    
    It should_be_able_to_parse_it = () =>
      result.ShouldBeTrue();

    It should_parse_namespace = () =>
      listener.ShouldHaveReceived(x => x.OnUsingNamespace("Foo.Bar"));
  }

  [Subject(typeof(UsingLineParser))]
  public class when_parsing_a_ : UsingLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("asdf asdf", listener);
    
    It should_not_be_able_to_parse_it = () =>
      result.ShouldBeFalse();
  }

  public class UsingLineParserSpecs : SpecsWithMocks
  {
    protected static UsingLineParser parser;
    protected static IParseListener listener;
    protected static bool result;

    Establish context = () =>
    {
      parser = new UsingLineParser();
      listener = Mock.Create<IParseListener>();
    };
  }
}
