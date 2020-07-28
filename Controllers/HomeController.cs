using HomeInvestor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeInvestor.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        ModelContext db = new ModelContext();
        
        [HttpPost]
        public ActionResult AddContract(HouseModel house)
        {
            

            db.Houses.Add(house);
            db.SaveChanges();
            return View("Index");
        }
        
    }
}