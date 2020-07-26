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
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HouseModels house)
        {
            int HouseId = house.HouseId;
            string Address = house.Address;
            string City = house.City;
            string State = house.State;
            int Zipcode = house.Zipcode;
            int Bedrooms = house.Bedrooms;
            int Bathrooms = house.Bathrooms;
            int HomeValue = house.HomeValue;

           
            return View();
        }
        
    }
}