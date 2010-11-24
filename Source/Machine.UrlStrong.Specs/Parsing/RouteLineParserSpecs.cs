using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Parsing;
using Arg=Moq.It;

namespace Machine.UrlStrong.Specs.Parsing
{
  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_root_get_url : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET /", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "GET" }, "/", "",""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_simple_get_url : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "GET" }, "/home", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_get_and_post_url : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET|POST /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "GET", "POST" }, "/home", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_url_with_all_the_supported_verbs : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("GET|POST|DELETE|PUT /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "GET", "POST", "DELETE", "PUT" }, "/home", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_url_with_an_unknown_verb : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("FOOBAR /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "FOOBAR" }, "/home", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_url_with_a_wildcard_for_a_verb : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("* /home", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "*" }, "/home", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_url_with_a_parameter_embedded_in_a_part : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("* /foo[id]bar", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "*" }, "/foo[id]bar", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_url_with_a_dash_in_it : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("* /foo-bar", listener);

    It should_be_able_to_parse_it=()=>
      result.ShouldBeTrue();

    It should_parse_url=()=>
      listener.ShouldHaveReceived(x => x.OnUrl(new [] { "*" }, "/foo-bar", "", ""));
  }

  [Subject(typeof(UrlLineParser))]
  public class when_parsing_a_using_statement : UrlLineParserSpecs
  {
    Because of = () =>
      result = parser.Parse("using foo.bar;", listener);

    It should_not_be_able_to_parse_it=()=>
      result.ShouldBeFalse();
  }

  public class UrlLineParserSpecs : SpecsWithMocks
  {
    protected static UrlLineParser parser;
    protected static IParseListener listener;
    protected static bool result;

    Establish context = () =>
    {
      parser = new UrlLineParser();
      listener = Mock.Create<IParseListener>();
    };
  }
}