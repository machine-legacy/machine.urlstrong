using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Machine.UrlStrong.Mvc
{
  public interface IDefaultAndConstraint {}
  public interface IDefault
  {
    IDefaultAndConstraint Constraint(string constraint);
  }

  public interface IParameterConstraint
  {
    IDefaultAndConstraint Default(object @default);
  }

  public class ParameterInfo : IParameterConstraint, IDefault, IDefaultAndConstraint
  {
    object _default;
    string _constraint;

    public object GetDefault()
    {
      return _default;
    }

    public string GetConstraint()
    {
      return _constraint;
    }

    public ParameterInfo(object @default, string constraint)
    {
      _default = @default;
      _constraint = constraint;
    }

    public IDefaultAndConstraint Constraint(string constraint)
    {
      _constraint = constraint;
      return this;
    }
    
    public IDefaultAndConstraint Default(object @default)
    {
      _default = @default;
      return this;
    }
  }

  public static class Parameter
  {
    public static IParameterConstraint Constraint(string constraint)
    {
      return new ParameterInfo(null, constraint);
    }
    
    public static IDefault Default(object @default)
    {
      return new ParameterInfo(@default, null);
    }
  }

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

    public static Route MapRoute<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action, object constraints) where TController : Controller
    {
      var routeValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
      var defaults = new RouteValueDictionary();
      defaults["Controller"] = routeValues["Controller"];
      defaults["Action"] = routeValues["Action"];
      var constraintsDictionary = new RouteValueDictionary(constraints);

      foreach (var pair in url.Parameters.Where(x => x.Value != null))
      {
        var parameter = pair.Value as ParameterInfo;

        if (parameter != null)
        {
          if (parameter.GetConstraint() != null)
            constraintsDictionary[pair.Key] = parameter.GetConstraint();
          if (parameter.GetDefault() != null)
            defaults[pair.Key] = parameter.GetDefault();
        }
        else
        {
          defaults[pair.Key] = pair.Value;
        }
      }

      var routeName = url.GetRouteName();

      var route = new Route(url.GetRouteUrl(), defaults, constraintsDictionary, new MvcRouteHandler());
      routeCollection.Add(routeName, route);

      return route;
    }

    public static Route MapRoute<TController>(this RouteCollection routeCollection, IUrl url, Expression<Action<TController>> action) where TController : Controller
    {
      return routeCollection.MapRoute<TController>(url, action, null);
    }
  }
}