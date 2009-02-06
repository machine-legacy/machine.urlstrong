using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Model;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Specs.Parsing
{
  [Subject("Parse Result")]
  public class when_parsed_from_simple_get_url : UrlParserSpecs
  {
    Because of = () =>
      result = Parse("GET /home");

    It should_not_have_errors = () =>
      result.HasErrors.ShouldBeFalse();

    It should_have_only_one_url = () =>
      result.UrlStrongModel.Urls.Count().ShouldEqual(1);

    It should_have_a_get_url = () =>
      result.UrlStrongModel.Urls.First().AcceptedVerbs.ShouldContainOnly(HttpVerbs.Get);

    It should_have_a_url_with_only_one_part = () =>
      result.UrlStrongModel.Urls.First().Parts.Count().ShouldEqual(1);

    It should_have_a_url_with_a_home_part = () =>
      result.UrlStrongModel.Urls.First().Parts.First().ShouldEqual(new UrlPart("home"));
 }

  [Subject("Parse Result")]
  public class when_parsed_from_a_sample_url_map : UrlParserSpecs
  {
    Because of = () =>
      result = Parse(@"
using Machine.UrlStrong.Sample.Controllers;

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

    It should_have_eight_urls = () =>
      result.UrlStrongModel.Urls.Count().ShouldEqual(8);

    It should_have_one_namespace = () =>
      result.UrlStrongModel.Namespaces.Count().ShouldEqual(1);
 }

  public class UrlParserSpecs
  {
    protected static UrlMapParser parser;
    protected static ParseResult result;

    Establish context = () =>
    {
      parser = new UrlMapParser();
    };

    protected static ParseResult Parse(string urls)
    {
      var builder = new ParseResultBuilder();
      parser.Parse(new StringReader(urls), builder);

      return builder.GetResult();
    }
  }
}
