using HomeInvestor.Models;
using HomeInvestor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeInvestor.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            List<HouseModel> houseModels = new List<HouseModel>();
            List<Owner.GetOwner> owners = new List<Owner.GetOwner>();



            List<AssetVM> assetVMs = new List<AssetVM>();

            foreach (var item in assetVMs)
            {
                AssetVM asset = new AssetVM();
                asset.HouseId = item.HouseId;
                asset.EthAddress = item.EthAddress;
                asset.City = item.City;
                asset.State = item.State;
                asset.HomeValue = item.HomeValue;
                asset.Bedrooms = item.Bedrooms;
                asset.Bathrooms = item.Bathrooms;
                assetVMs.Add(asset);
            }
            return View(assetVMs);
        }
    }
}