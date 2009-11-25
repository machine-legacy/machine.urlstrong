using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.UrlStrong.Mvc.Parameters;

namespace Machine.UrlStrong.Mvc
{
  public static class RoutingCollectionExtensions
  {
    public static string GetRouteUrl(this IUrl url)
    {
      var routeUrl = url.ToParameterizedUrl();
      if (routeUrl.StartsWith("/"))
      {
        routeUrl = routeUrl.Substring(1);
      }

      return routeUrl;
    }

    public static string GetRouteName(this IUrl url)
    {
      return url.GetType().ToString();
    }

    public static Route MapRoute(this RouteCollection routeCollection, IUrl url)
    {
      return routeCollection.MapRoute(url, null, null);
    }
    public static Route MapRoute(this RouteCollection routeCollection, IUrl url, object defaults)
    {
      return routeCollection.MapRoute(url, defaults, null);
    }
    public static Route MapRoute(this RouteCollection routeCollection, IUrl url, object defaults, object constraints)
    {
      var defaultDictionary = new RouteValueDictionary(defaults);
      var constraintDictionary = new RouteValueDictionary(constraints);
      ExtractDefaultsAndConstraints(url, defaultDictionary, constraintDictionary);

      return CreateRoute(defaultDictionary, url, constraintDictionary, routeCollection);
    }

    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url) where TController : Controller
    {
      return routeCollection.MapRouteTo<TController>(url, null, null);
    }
    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url, object defaults) where TController : Controller
    {
      return routeCollection.MapRouteTo<TController>(url, defaults, null);
    }
    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url, object defaults, object constraints) where TController : Controller
    {
      var name = typeof(TController).Name;
      if (!name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
      {
        throw new ArgumentException("TController name must end with 'Controller'");
      }

      name = name.Substring(0, name.Length - "Controller".Length);
      
      var defaultDictionary = new RouteValueDictionary(defaults);
      var constraintDictionary = new RouteValueDictionary(constraints);
      defaultDictionary["Controller"] = name;
      ExtractDefaultsAndConstraints(url, defaultDictionary, constraintDictionary);

      return CreateRoute(defaultDictionary, url, constraintDictionary, routeCollection);
    }

    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action) where TController : Controller
    {
      return routeCollection.MapRouteTo(url, action, null, null);
    }
    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action, object defaults) where TController : Controller
    {
      return routeCollection.MapRouteTo(url, action, defaults, null);
    }
    public static Route MapRouteTo<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action, object defaults, object constraints) where TController : Controller
    {
      var defaultDictionary = new RouteValueDictionary(defaults);
      var constraintDictionary = new RouteValueDictionary(constraints);

      if (action != null)
      {
        var routeValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
        defaultDictionary["Controller"] = routeValues["Controller"];
        defaultDictionary["Action"] = routeValues["Action"];
      }

      ExtractDefaultsAndConstraints(url, defaultDictionary, constraintDictionary);

      return CreateRoute(defaultDictionary, url, constraintDictionary, routeCollection);
    }

    static Route CreateRoute(RouteValueDictionary defaults, IUrl url, RouteValueDictionary constraints, RouteCollection routeCollection)
    {
      var routeName = url.GetRouteName();

      var route = new Route(url.GetRouteUrl(), defaults, constraints, new MvcRouteHandler());
      routeCollection.Add(routeName, route);
      return route;
    }

    static void ExtractDefaultsAndConstraints(IUrl url, RouteValueDictionary defaults, RouteValueDictionary constraints)
    {
      foreach (var pair in url.Parameters.Where(x => x.Value != null))
      {
        var parameter = pair.Value as ParameterInfo;

        if (parameter != null)
        {
          if (parameter.GetConstraint() != null)
            constraints[pair.Key] = parameter.GetConstraint();
          if (parameter.GetDefault() != null)
            defaults[pair.Key] = parameter.GetDefault();
        }
        else
        {
          defaults[pair.Key] = pair.Value;
        }
      }
    }
  }
}