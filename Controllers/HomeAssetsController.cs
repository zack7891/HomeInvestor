using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeInvestor.Models;
using Microsoft.AspNet.Identity;

namespace HomeInvestor.Controllers
{
    public class HomeAssetsController : Controller
    {
        private HOMEEntities db = new HOMEEntities();

        
        // GET: HomeAssets
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();  
            var assets = db.Assets.Where(a => a.Owner.UserId == userId).Include(o=> o.Owner);
            return View(assets.ToList());
        }

        // GET: HomeAssets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: HomeAssets/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "UserId", "EthAdd");
            return View();
        }

        // POST: HomeAssets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetId,OwnerId,Address,City,State,ZipCode,Bedrooms,Bathrooms,HomeValue,FilePath")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "UserId", "EthAdd", asset.OwnerUserId);
            return View(asset);
        }

        // GET: HomeAssets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "UserId", "EthAdd", asset.OwnerUserId);
            return View(asset);
        }

        // POST: HomeAssets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetId,OwnerId,Address,City,State,ZipCode,Bedrooms,Bathrooms,HomeValue,FilePath")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "UserId", "EthAdd", asset.OwnerUserId);
            return View(asset);
        }

        // GET: HomeAssets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: HomeAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
            db.SaveChanges();
            return RedirectToAction("Index");
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
