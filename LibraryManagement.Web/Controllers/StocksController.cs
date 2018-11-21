using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Web.Models;

namespace LibraryManagement.Web.Controllers
{
    public class StocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stocks
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.ActionType).Include(s => s.Condition).Include(s => s.Item);
            return View(stocks.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.ActionTypeId = new SelectList(db.ActionTypes, "Id", "Name");
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Title");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId,ActionTypeId,ConditionId,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActionTypeId = new SelectList(db.ActionTypes, "Id", "Name", stock.ActionTypeId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", stock.ConditionId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Title", stock.ItemId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActionTypeId = new SelectList(db.ActionTypes, "Id", "Name", stock.ActionTypeId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", stock.ConditionId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Title", stock.ItemId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,ActionTypeId,ConditionId,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActionTypeId = new SelectList(db.ActionTypes, "Id", "Name", stock.ActionTypeId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", stock.ConditionId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Title", stock.ItemId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
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
