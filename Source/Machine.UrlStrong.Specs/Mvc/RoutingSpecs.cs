using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Machine.UrlStrong.Sample;
using Machine.UrlStrong.Mvc;
using System.Web;

namespace Machine.UrlStrong.Specs.Mvc
{
  [Subject("Routing")]
  public class when_mapping_a_simple_route : RoutingSpecs
  {
    Because of = () =>
      route = routeCollection.MapRouteTo<TestController>(Urls.root.home, x => x.SimpleAction());

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("SimpleAction");

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("home");
  }

  [Subject("Routing")]
  public class when_mapping_a_route_with_a_parameter_with_no_defaults : RoutingSpecs
  {
    Because of = () =>
      route = routeCollection.MapRouteTo<TestController>(Urls.root.user[null], x => x.ParameterAction(0));

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("ParameterAction");

    It should_not_set_default_for_parameter = () =>
      route.Defaults.ContainsKey("id").ShouldBeFalse();

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("user/{id}");
  }

  [Subject("Routing")]
  public class when_mapping_a_route_with_a_parameter_with_default : RoutingSpecs
  {
    Because of = () =>
      route = routeCollection.MapRouteTo<TestController>(Urls.root.user[3], x => x.ParameterAction(0));

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("ParameterAction");

    It should_set_default_for_parameter = () =>
      route.Defaults["id"].ShouldEqual(3);

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("user/{id}");
  }

  [Subject("Routing")]
  public class when_mapping_a_route_with_a_multiple_parameters_in_a_part : RoutingSpecs
  {
    Because of = () =>
      route = routeCollection.MapRouteTo<TestController>(Urls.root.yadda_id_blah(4), x => x.ParameterAction(0));

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("ParameterAction");

    It should_set_default_for_parameter = () =>
      route.Defaults["id"].ShouldEqual(4);

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("yadda{id}blah");
  }

  [Subject("Routing")]
  public class when_mapping_a_route_using_Parameter : RoutingSpecs
  {
    Because of = () =>
      route = routeCollection.MapRouteTo<TestController>(Urls.root.yadda_id_blah(Parameter.Default(4).Constraint("[0-9]")), x => x.ParameterAction(0));

    It should_set_the_controller = () =>
      route.Defaults["Controller"].ShouldEqual("Test");

    It should_set_the_action = () =>
      route.Defaults["Action"].ShouldEqual("ParameterAction");

    It should_set_default_for_parameter = () =>
      route.Defaults["id"].ShouldEqual(4);

    It should_set_constraint_for_parameter = () =>
      route.Constraints["id"].ShouldEqual("[0-9]");

    It should_set_the_destination = () =>
      route.Url.ShouldEqual("yadda{id}blah");
  }

  [Subject("Routing")]
  public class when_mapping_a_route_using_a_custom_routehandler : RoutingSpecs
  {
      Because of = () =>
        route = routeCollection.MapRoute(Urls.root.user[4], () => new CustomRouteHandler("testValue"));

      It should_set_the_destination = () =>
       route.Url.ShouldEqual("user/{id}");

      It should_set_default_for_parameter = () =>
       route.Defaults["id"].ShouldEqual(4);

      It should_use_the_custom_route_handler = () =>
          route.RouteHandler.ShouldBeOfType<CustomRouteHandler>();

      It should_use_the_given_custom_function_to_build_the_custom_route_handler = () =>
          (route.RouteHandler as CustomRouteHandler).CustomParameter.ShouldEqual("testValue");
  }        

  public class when_mapping_a_route_with_constraints_using_a_custom_routehandler : RoutingSpecs
  {
      Because of = () =>
        route = routeCollection.MapRoute(Urls.root.user[Parameter.Default(4).Constraint("[0-9]")], () => new CustomRouteHandler("testValue"));

      It should_set_default_for_parameter = () =>
       route.Defaults["id"].ShouldEqual(4);

      It should_set_constraint_for_parameter = () =>
       route.Constraints["id"].ShouldEqual("[0-9]");

      It should_set_the_destination = () =>
       route.Url.ShouldEqual("user/{id}");

      It should_use_the_custom_route_handler = () =>
       route.RouteHandler.ShouldBeOfType<CustomRouteHandler>();

      It should_use_the_given_custom_function_to_build_the_custom_route_handler = () =>
          (route.RouteHandler as CustomRouteHandler).CustomParameter.ShouldEqual("testValue");
  }

  [Subject("Routing")]
  public class CustomRouteHandler : IRouteHandler
    {
        public string CustomParameter { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CustomRouteHandler class.
        /// </summary>
        public CustomRouteHandler(string customParameter)
        {
            CustomParameter = customParameter;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return null;
        }

        #endregion
    }

  public class TestController : Controller
  {
    public ActionResult SimpleAction()
    {
      return View();
    }

    public ActionResult ParameterAction(int id)
    {
      return View();
    }

  }
  public class RoutingSpecs
  {
    Establish context = () =>
    {
      routeCollection = new RouteCollection();
    };

    protected static RouteCollection routeCollection;
    protected static Route route;
  }
}
