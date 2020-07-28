using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeInvestor.Controllers
{
    public class AngularTemplateController : Controller
    {
        // GET: AngularTemplate
        public PartialViewResult RenderView(string name)
        {
            return PartialView($"~/app/templates/{name}");
        }
    }
}