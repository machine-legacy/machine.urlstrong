using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Specs.Parsing
{
  [Subject(typeof(UsingLineParser))]
  public class when_parsing_a_class_line : ClassLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("class Foobar;", listener);
    
    It should_be_able_to_parse_it = () =>
      result.ShouldBeTrue();

    It should_parse_namespace = () =>
      listener.ShouldHaveReceived(x => x.OnClassName("Foobar"));
  }

  [Subject(typeof(UsingLineParser))]
  public class when_parsing_some_jibberish : ClassLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("asdf asdf", listener);
    
    It should_not_be_able_to_parse_it = () =>
      result.ShouldBeFalse();
  }

  public class ClassLineParserSpecs : SpecsWithMocks
  {
    protected static ClassLineParser parser;
    protected static IParseListener listener;
    protected static bool result;

    Establish context = () =>
    {
      parser = new ClassLineParser();
      listener = Mock.Create<IParseListener>();
    };
  }
}
