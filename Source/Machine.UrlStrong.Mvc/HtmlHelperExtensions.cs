using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Machine.UrlStrong.Mvc
{
  public static class HtmlHelperExtensions
  {
    public static string Url(this HtmlHelper htmlHelper, IUrl url)
    {
      return url.ToString();
    }
  }
}