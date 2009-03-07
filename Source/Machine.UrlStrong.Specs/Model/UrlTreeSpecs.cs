using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Machine.Specifications;
using Machine.UrlStrong.Translation.Model;
using Machine.UrlStrong.Translation.Parsing;

namespace Machine.UrlStrong.Specs.Model
{
  public class when_creating_a_tree_from_no_urls
    : UrlTreeSpecs
  {

  }

  public class when_creating_a_tree_from_urls
    : UrlTreeSpecs
  {

    Establish context = () =>
    {
      var url1 = "GET /foo/bar".ToUrl();
      var url2 = "GET /foo/yadda".ToUrl();

      tree = new UrlTree(new[] {url1, url2});
    };

    It should_have_a_root =()=>
      tree.Root.ShouldNotBeNull();

    It should_have_a_root_with_one_child = () =>
      tree.Root.Children.Count().ShouldEqual(1);

    It should_have_a_root_with_a_foo_node = () =>
      tree.Root.GetChild("foo").ShouldNotBeNull();

    It should_have_a_root_with_a_foo_node_with_two_children = () =>
      tree.Root.GetChild("foo").Children.Count().ShouldEqual(2);

    It should_have_a_root_with_a_foo_node_with_bar_and_yadda_children = () =>
      tree.Root.GetChild("foo").Children.Select(x => x.Name).ToArray().ShouldContainOnly("bar", "yadda");

    static UrlTree tree;
    
  }
  public class UrlTreeSpecs
  {
  }

  public static class ExtensionMethods
  {
    public static Url ToUrl(this string str)
    {
      var resultBuilder = new ParseResultBuilder();
      var urlParser = new UrlLineParser();
      if (!urlParser.Parse(str, resultBuilder))
      {
        throw new Exception("Dunno how to parse " + str);
      }

      return resultBuilder.GetResult().UrlStrongModel.Urls.FirstOrDefault();
    }
  }
}
