using LibraryManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class StocksController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // GET: Stocks
        public StocksController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        public ActionResult Index(string sortOrder, string searchString, string locationString, int page = 1, int pageSize = 5)
        {
            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "title" : sortOrder;
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;

            ViewBag.searchQuery = String.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.locationQuery = String.IsNullOrEmpty(locationString) ? "" : locationString;
            ViewBag.TitleSortParam = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.AuthorSortParam = sortOrder == "author" ? "author_desc" : "author";
            ViewBag.PublisherSortParam = sortOrder == "publisher" ? "publisher_desc" : "publisher";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentUserId = User.Identity.GetUserId();

            var query = ApplicationDbContext.Stocks
                .Include(s => s.ActionType)
                .Include(s => s.Condition)
                .Include(s => s.Item)
                .Where(x => x.Quantity > 0);
            query = string.IsNullOrEmpty(searchString) ? query : query.Where(x => x.Item.Title.Contains(searchString) ||
                                                                                  x.Item.Publisher.Name.Contains(searchString) ||
                                                                                  x.Item.Author.FirstName.Contains(searchString) ||
                                                                                  x.Item.Author.LastName.Contains(searchString));

            query = string.IsNullOrEmpty(locationString) ? query : query.Where(x => x.Owner.Location.Country.Name.Contains(locationString) ||
                                                                                  x.Owner.Location.ParentLocationId.HasValue && x.Owner.Location.ParentLocation.Name.Contains(locationString) ||
                                                                                  x.Owner.Location.Name.Contains(locationString));
            switch (sortOrder)
            {
                case "title":
                    query = query.OrderBy(x => x.Item.Title);
                    break;
                case "author":
                    query = query.OrderBy(x => x.Item.Author.FirstName);
                    break;
                case "publisher":
                    query = query.OrderBy(x => x.Item.Publisher.Name);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(x => x.Item.Title);
                    break;
                case "author_desc":
                    query = query.OrderByDescending(x => x.Item.Author.FirstName);
                    break;
                case "publisher_desc":
                    query = query.OrderByDescending(x => x.Item.Publisher.Name);
                    break;
            }

            var items = query.Select(x => new StockModel
            {
                Id = x.Id,
                ItemId = x.Item.Id,
                Title = x.Item.Title,
                AuthorId = x.Item.Author.Id,
                AuthorFirstName = x.Item.Author.FirstName,
                AuthorLastName = x.Item.Author.LastName,
                PublisherId = x.Item.Publisher.Id,
                PublisherName = x.Item.Publisher.Name,
                CategoryId = x.Item.Category.Id,
                CategoryName = x.Item.Category.Name,
                ActionTypeName = x.ActionType.Name,
                ActionTypeId = x.ActionType.Id,
                ConditionName = x.Condition.Name,
                ConditionId = x.Condition.Id,
                OwnerId = x.Owner.Id,
                OwnerUserName = x.Owner.UserName,
                CountryId = x.Owner.Location.Country.Id,
                CountryName = x.Owner.Location.Country.Name,
                LocationId = x.Owner.Location.Id,
                LocationName = x.Owner.Location.Name,
                ParentLocationId = x.Owner.Location.ParentLocation.Id,
                ParentLocationName = x.Owner.Location.ParentLocation.Name,
                Quantity = x.Quantity,
                Year = x.Item.Year
            });
            return View(items.ToPagedList(page, pageSize));
        }

        // GET: Stocks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = ApplicationDbContext.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            var stockModel = MapToStockModel(stock);
            return View(stockModel);
        }

        // GET: Stocks/Create
        [Authorize]
        public ActionResult Save(long? id)
        {
            if (id == null)
            {
                ViewBag.ActionTypeId = new SelectList(ApplicationDbContext.ActionTypes, "Id", "Name");
                ViewBag.ConditionId = new SelectList(ApplicationDbContext.Conditions, "Id", "Name");
                ViewBag.CategoryId = new SelectList(ApplicationDbContext.Categories, "Id", "Name");
                ViewBag.ItemId = new SelectList(ApplicationDbContext.Items, "Id", "Title");
                return View();
            }

            var stock = ApplicationDbContext.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            var stockModel = MapToStockModel(stock);

            PopulateDropDowns(stockModel);
            return View(stockModel);
        }

        // POST: Stocks/Save
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(StockModel stock)
        {
            if (ModelState.IsValid)
            {
                var item = SaveItem(stock);

                if (stock.Id == 0)
                {
                    var stockItem = new Stock
                    {
                        Item = item,
                        ActionType = ApplicationDbContext.ActionTypes.Find(stock.ActionTypeId),
                        Condition = ApplicationDbContext.Conditions.Find(stock.ConditionId),
                        Owner = UserManager.FindById(User.Identity.GetUserId()),
                        Quantity = stock.Quantity
                    };
                    ApplicationDbContext.Stocks.Add(stockItem);
                }
                else
                {
                    var stockItem = ApplicationDbContext.Stocks.Find(stock.Id);
                    if (stockItem == null)
                    {
                        return HttpNotFound();
                    }
                    stockItem.Item = item;
                    stockItem.ActionType = ApplicationDbContext.ActionTypes.Find(stock.ActionTypeId);
                    stockItem.Condition = ApplicationDbContext.Conditions.Find(stock.ConditionId);
                    stockItem.Quantity = stock.Quantity;

                    ApplicationDbContext.Entry(stockItem).State = EntityState.Modified;
                }
                ApplicationDbContext.SaveChanges();

                return RedirectToAction("Index");

            }

            PopulateDropDowns(stock);

            return View(stock);
        }


        // GET: Stocks/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = ApplicationDbContext.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            var stockModel = MapToStockModel(stock);
            return View(stockModel);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(long id)
        {
            Stock stock = ApplicationDbContext.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ApplicationDbContext.Stocks.Remove(stock);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropDowns(StockModel stock)
        {
            ViewBag.ActionTypeId = new SelectList(ApplicationDbContext.ActionTypes, "Id", "Name", stock.ActionTypeId);
            ViewBag.ConditionId = new SelectList(ApplicationDbContext.Conditions, "Id", "Name", stock.ConditionId);
            ViewBag.ItemId = new SelectList(ApplicationDbContext.Items, "Id", "Title", stock.ItemId);
            ViewBag.CategoryId = new SelectList(ApplicationDbContext.Categories, "Id", "Name", stock.CategoryId);
        }

        private static StockModel MapToStockModel(Stock stock)
        {
            var stockModel = new StockModel
            {
                Id = stock.Id,
                ItemId = stock.Item.Id,
                Title = stock.Item.Title,
                AuthorId = stock.Item.Author.Id,
                AuthorFirstName = stock.Item.Author.FirstName,
                AuthorLastName = stock.Item.Author.LastName,
                PublisherId = stock.Item.Publisher.Id,
                PublisherName = stock.Item.Publisher.Name,
                CategoryId = stock.Item.Category.Id,
                CategoryName = stock.Item.Category.Name,
                ActionTypeName = stock.ActionType.Name,
                ActionTypeId = stock.ActionType.Id,
                ConditionName = stock.Condition.Name,
                ConditionId = stock.Condition.Id,
                OwnerId = stock.Owner.Id,
                OwnerUserName = stock.Owner.UserName,
                Quantity = stock.Quantity,
                Year = stock.Item.Year
            };
            return stockModel;
        }

        private Item SaveItem(StockModel stock)
        {
            var item = ApplicationDbContext.Items
                .FirstOrDefault(x => x.Title.ToUpper() == stock.Title.ToUpper()
                                     && x.Publisher.Name.ToUpper() == stock.PublisherName.ToUpper() &&
                                     x.Author.FirstName.ToUpper() == stock.AuthorFirstName.ToUpper() &&
                                     x.Author.LastName.ToUpper() == stock.AuthorLastName.ToUpper() &&
                                     x.Year == stock.Year &&
                                     x.CategoryId == stock.CategoryId);
            if (item == null)
            {
                var author =
                    ApplicationDbContext.Authors.FirstOrDefault(
                        x => x.FirstName == stock.AuthorFirstName && x.LastName == stock.AuthorLastName);
                if (author == null)
                {
                    author = ApplicationDbContext.Authors.Add(
                        new Author { FirstName = stock.AuthorFirstName, LastName = stock.AuthorLastName });
                    ApplicationDbContext.SaveChanges();
                }

                var publisher = ApplicationDbContext.Publishers.FirstOrDefault(x => x.Name == stock.PublisherName);
                if (publisher == null)
                {
                    publisher = ApplicationDbContext.Publishers.Add(new Publisher { Name = stock.PublisherName });
                    ApplicationDbContext.SaveChanges();
                }

                item = new Item
                {
                    Author = author,
                    Publisher = publisher,
                    Category = ApplicationDbContext.Categories.Find(stock.CategoryId),
                    Title = stock.Title,
                    Year = stock.Year
                };
                item = ApplicationDbContext.Items.Add(item);
                ApplicationDbContext.SaveChanges();
            }
            return item;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ApplicationDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
