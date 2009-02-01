using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.RouteMap.RouteModel;

namespace Machine.RouteMap.Sample.Controllers
{
  public class HomeController
  {
    public void Index()
    {
      Redirect(root.user[3].friend.list);
    }

    public void Redirect(ISupportGet route)
    {
      
    }
  }
}
