using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.UrlStrong.RouteModel;

namespace Machine.UrlStrong.Sample.Controllers
{
  public class HomeController
  {
    public void Index()
    {
      Redirect(Routes.root.user[3].friend.list);
    }

    public void Redirect(ISupportGet route)
    {
      
    }
  }
}
