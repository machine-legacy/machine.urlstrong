using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.UrlStrong.Translation.Model;
using Spark;

namespace Machine.UrlStrong.Translation.Generation
{
  public abstract class TemplateBase : AbstractSparkView
  {
    public UrlStrongModel Model { get; set; }
  }
}