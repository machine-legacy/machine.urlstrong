using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Route66.RouteModel;

namespace Machine.Route66.Sample.Controllers
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
