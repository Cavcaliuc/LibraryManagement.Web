using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Web.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace LibraryManagement.Web.Controllers
{

    [Authorize(Roles = "RegularUser")]
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Message
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pageSize = 10)
        {
            var currentUserId = User.Identity.GetUserId();
            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "createdDate_desc" : sortOrder;
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;


            ViewBag.searchQuery = String.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.TitleSortParam = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.CreatedDateSortParam = sortOrder == "createdDate" ? "createdDate_desc" : "createdDate";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentUserId = currentUserId;

            var query = db.Orders.Include(m => m.Messages).Include(m => m.Stock)
                .Select(m => m.Messages
                            .OrderByDescending(y => y.CreatedDate)
                            .FirstOrDefault(x => x.CreatedBy.Id == currentUserId ||
                                                  x.Order.Stock.Owner.Id == currentUserId ||
                                                  x.Order.CreatedBy.Id == currentUserId))
                .Where(x => x != null);


            query = string.IsNullOrEmpty(searchString) ? query : query.Where(x => x.Order.Stock.Item.Title.Contains(searchString) ||
                                                                                  x.CreatedBy.UserName.Contains(searchString));

            switch (sortOrder)
            {
                case "title":
                    query = query.OrderBy(x => x.Order.Stock.Item.Title);
                    break;
                case "createdDate":
                    query = query.OrderBy(x => x.CreatedDate);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(x => x.Order.Stock.Item.Title);
                    break;
                case "createdDate_desc":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            var pagedList = query.ToPagedList(page, pageSize);

            foreach (var message in pagedList)
            {
                message.Text = Encryption.Decrypt(message.Text);

                if (message.CreatedBy.Id != currentUserId && !message.Seen)
                {
                    message.Seen = true;
                    db.Entry(message).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }

            return View(pagedList);
        }

        public long UnseenMessagesCount()
        {
            var currentUserId = User.Identity.GetUserId();
            var query = db.Messages
            .Where(x => x.CreatedBy.Id != currentUserId && !x.Seen &&
            (x.Order.Stock.Owner.Id == currentUserId || x.Order.CreatedBy.Id == currentUserId));
            return query.LongCount();
        }

        // GET: Message/Details/5
        public ActionResult MarkAsSeen(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            message.Seen = true;
            db.Entry(message).State = EntityState.Modified;
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
