using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.UrlStrong.Sample.Controllers
{
  public class HomeController
  {
    public void Index()
    {
      Redirect(Url.root.user[3].friend.list);
    }

    public void Redirect(ISupportGet url)
    {
      
    }
  }
}
