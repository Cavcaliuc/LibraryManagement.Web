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
    public class ActionTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActionType
        public ActionResult Index()
        {
            return View(db.ActionTypes.ToList());
        }

        // GET: ActionType/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionType actionType = db.ActionTypes.Find(id);
            if (actionType == null)
            {
                return HttpNotFound();
            }
            return View(actionType);
        }

        // GET: ActionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ActionType actionType)
        {
            CheckName(actionType);
            if (ModelState.IsValid)
            {
                db.ActionTypes.Add(actionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionType);
        }

        // GET: ActionType/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionType actionType = db.ActionTypes.Find(id);
            if (actionType == null)
            {
                return HttpNotFound();
            }
            return View(actionType);
        }

        // POST: ActionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ActionType actionType)
        {
            CheckName(actionType);
            if (ModelState.IsValid)
            {
                db.Entry(actionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionType);
        }

        // GET: ActionType/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionType actionType = db.ActionTypes.Find(id);
            if (actionType == null)
            {
                return HttpNotFound();
            }
            return View(actionType);
        }

        // POST: ActionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            ActionType actionType = db.ActionTypes.Find(id);
            db.ActionTypes.Remove(actionType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CheckName(ActionType actionType)
        {
            if (db.ActionTypes.Any(x => x.Name.ToUpper() == actionType.Name.ToUpper()))
            {
                ModelState.AddModelError("Name", "Action Type already in use");
            }
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
