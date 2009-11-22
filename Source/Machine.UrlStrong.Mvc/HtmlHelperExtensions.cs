using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Machine.UrlStrong.Mvc
{
  public static class HtmlHelperExtensions
  {
    public static string Url(this HtmlHelper htmlHelper, IUrl url)
    {
      return url.ToString();
    }
  }

  public static class RoutingCollectionExtensions
  {
    public static string GetRouteUrl(this IUrl url)
    {
      var routeUrl = url.ToString();
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

    public static Route MapRoute<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action) where TController : Controller
    {
      var defaults = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);

      var routeName = url.GetRouteName();

      var route = new Route(url.GetRouteUrl(), defaults, new MvcRouteHandler());
      routeCollection.Add(routeName, route);

      return route;
    }
  }
}