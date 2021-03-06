﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Web.Models;
using PagedList;

namespace LibraryManagement.Web.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Authors
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pageSize = 10)
        {
            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "firstName" : sortOrder;
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;

            ViewBag.searchQuery = String.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.FirstNameSortParam = sortOrder == "firstName" ? "firstName_desc" : "firstName";
            ViewBag.LastNameSortParam = sortOrder == "lastName" ? "lastName_desc" : "lastName";
            ViewBag.CurrentSort = sortOrder;


            var query = db.Authors.AsQueryable();
            query = string.IsNullOrEmpty(searchString) ? query : query.Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            switch (sortOrder)
            {
                case "firstName":
                    query = query.OrderBy(x => x.FirstName);
                    break;
                case "lastName":
                    query = query.OrderBy(x => x.LastName);
                    break;
                case "firstName_desc":
                    query = query.OrderByDescending(x => x.FirstName);
                    break;
                case "lastName_desc":
                    query = query.OrderByDescending(x => x.LastName);
                    break;
            }
            return View(query.ToPagedList(page, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetFirstNames(string term = "")
        {
            var firstNames = db.Authors
                .Where(x => x.FirstName.ToUpper().Contains(term.ToUpper()))
                .GroupBy(x => x.FirstName).Select(x => x.FirstOrDefault())
                .OrderBy(x => x.FirstName)
                .ToList();
            return Json(firstNames);
        }

        public JsonResult GetLastNames(string term = "")
        {
            var lastNames = db.Authors
                .Where(x => x.LastName.ToUpper().Contains(term.ToUpper()))
                .GroupBy(x => x.LastName).Select(x => x.FirstOrDefault())
                .OrderBy(x => x.LastName).ToList();
            return Json(lastNames);
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
