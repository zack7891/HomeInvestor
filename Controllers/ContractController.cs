using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HomeInvestor.Controllers
{
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }

       //public ActionResult GetContract()
       // {
       //     var privKey = "".HexToBytes();
       //     var myKeys = new KeyPair(privKey);
       //     var scriptHash = "";

       //     return View();

       // }
    }
}