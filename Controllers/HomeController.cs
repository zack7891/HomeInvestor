using HomeInvestor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Microsoft.Ajax.Utilities;
using ContractLib.AssetTransferContract.ContractDefinition;
using ContractLib.AssetTransferContract;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Nethereum.JsonRpc.Client;
using System.Configuration;
using Neo.IO.Data.LevelDB;

namespace HomeInvestor.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string UrlRPC = ConfigurationManager.AppSettings["EtherRPC"];
        private HOMEEntities db = new HOMEEntities();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var asset = new AssetVM { OwnerUserId = userId};
            return View(asset);
        }

        [HttpPost]
        public ActionResult AddContract(AssetVM assetVM)
        {
            if (ModelState.IsValid) 
            {
                var model = assetVM.ConvertToAsset();
                var owners = db.Owners.Find(assetVM.OwnerUserId);
              
             
                db.Assets.Add(model);
                db.SaveChanges();

                CreateContract(assetVM.PrivateKey, owners.EthAdd);
                return RedirectToAction("Index", "Asset");
            }
            return View(assetVM);
        }

        
        private string CreateContract(string privateKey,string buyer)
        {
       
                var account = new Account(privateKey);
                var web3 = new Web3(account, UrlRPC);
                



             
                var deployment = new AssetTransferContractDeployment() { Seller = buyer, Duration = 30, Ownership= 5,  AmountToSend = 3};
               
                var receipt =  AssetTransferContractService.DeployContractAndWaitForReceiptAsync(web3, deployment).Result;
                var service = new AssetTransferContractService(web3, receipt.ContractAddress);

                return receipt.ContractAddress;
                //var buyerQuery =  web3.Eth.GetContract
                //var sellerQuery = service.SellerQueryAsync(account);
           
                
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