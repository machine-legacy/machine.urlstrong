using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Machine.UrlStrong.Sample;
using Machine.UrlStrong.Mvc;

namespace Machine.UrlStrong.Specs.Mvc
{
  [Subject("Routing")]
  public class when_mapping_a_simple_route
  {
    Establish context = () =>
    {
      routeCollection = new RouteCollection();
    };

    Because of = () =>
      route = routeCollection.MapRoute<TestController>(Url.root.home, x => x.SimpleAction());

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("SimpleAction");

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("home");

    static RouteCollection routeCollection;
    static Route route;
  }

  public class TestController : Controller
  {
    public ActionResult SimpleAction()
    {
      return View();
    }

  }
  public class RoutingSpecs
  {
  }
}
