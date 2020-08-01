using HomeInvestor.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeInvestor.Controllers
{
    public class AssetController : Controller
    {
        private HOMEEntities db = new HOMEEntities();

        // GET: Asset
        [Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var owner = db.Owners.Find(userId);
            var assets = owner.Assets;

            return View(assets.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}