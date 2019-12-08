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
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace LibraryManagement.Web.Controllers
{
    [Authorize(Roles = "RegularUser")]
    public class OrderController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application ApplicationDbContext context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // GET: Stocks
        public OrderController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }
        // GET: Order
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pageSize = 10, bool showMyOrders = true)
        {
            var currentUserId = User.Identity.GetUserId();
            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "createdDate_desc" : sortOrder;
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;


            ViewBag.searchQuery = String.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.TitleSortParam = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.OrderStatusSortParam = sortOrder == "orderStatus" ? "orderStatus_desc" : "orderStatus";
            ViewBag.CreatedDateSortParam = sortOrder == "createdDate" ? "createdDate_desc" : "createdDate";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentUserId = currentUserId;
            ViewBag.ShowMyOrders = showMyOrders;

            var query = ApplicationDbContext.Orders
                .Include(s => s.Stock)
                .Include(s => s.Stock.Owner)
                .Include(s => s.CreatedBy);
            if (showMyOrders)
            {
                query = query.Where(x => x.CreatedBy.Id == currentUserId);
            }
            else
            {
                query = query.Where(x => x.Stock.Owner.Id == currentUserId);
            }
            query = string.IsNullOrEmpty(searchString) ? query : query.Where(x => x.Stock.Item.Title.Contains(searchString) ||
                                                                                  x.Stock.Item.Publisher.Name.Contains(searchString) ||
                                                                                  x.Stock.Item.Author.FirstName.Contains(searchString) ||
                                                                                  x.Stock.Item.Author.LastName.Contains(searchString));

            switch (sortOrder)
            {
                case "title":
                    query = query.OrderBy(x => x.Stock.Item.Title);
                    break;
                case "orderStatus":
                    query = query.OrderBy(x => x.OrderStatus.Name);
                    break;
                case "createdDate":
                    query = query.OrderBy(x => x.CreatedDate);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(x => x.Stock.Item.Title);
                    break;
                case "orderStatus_desc":
                    query = query.OrderByDescending(x => x.OrderStatus.Name);
                    break;
                case "createdDate_desc":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            var items = query.Select(x => new OrderModel
            {
                Id = x.Id,
                ItemId = x.Stock.Item.Id,
                Title = x.Stock.Item.Title,
                AuthorId = x.Stock.Item.Author.Id,
                AuthorFirstName = x.Stock.Item.Author.FirstName,
                AuthorLastName = x.Stock.Item.Author.LastName,
                PublisherId = x.Stock.Item.Publisher.Id,
                PublisherName = x.Stock.Item.Publisher.Name,
                CategoryId = x.Stock.Item.Category.Id,
                CategoryName = x.Stock.Item.Category.Name,
                ActionTypeName = x.Stock.ActionType.Name,
                ActionTypeId = x.Stock.ActionType.Id,
                ConditionName = x.Stock.Condition.Name,
                ConditionId = x.Stock.Condition.Id,
                OwnerId = x.Stock.Owner.Id,
                OwnerUserName = x.Stock.Owner.UserName,
                CountryId = x.Stock.Owner.Location.Country.Id,
                CountryName = x.Stock.Owner.Location.Country.Name,
                LocationId = x.Stock.Owner.Location.Id,
                LocationName = x.Stock.Owner.Location.Name,
                ParentLocationId = x.Stock.Owner.Location.ParentLocation.Id,
                ParentLocationName = x.Stock.Owner.Location.ParentLocation.Name,
                OrderQuantity = x.Quantity,
                OrderStatusId = x.OrderStatus.Id,
                OrderStatusName = x.OrderStatus.Name,
                Year = x.Stock.Item.Year,
                CreatedDate = x.CreatedDate,
                CreatedById = x.CreatedBy.Id,
                CreatedByName = x.CreatedBy.UserName,
                ModifiedDate = x.ModifiedDate,
                ModifiedById = x.ModifiedBy.Id,
                ModifiedByName = x.ModifiedBy.UserName,
            });
            return View(items.ToPagedList(page, pageSize));
        }

        public ActionResult IncomeIndex()
        {
            return RedirectToAction("Index", new { showMyOrders = false });
        }

        public long PendingOrdersCount(bool showMyOrders = true)
        {
            var currentUserId = User.Identity.GetUserId();
            var query = ApplicationDbContext.Orders.Where(x => x.OrderStatus.Name == OrderStatus.Pending);
            if (showMyOrders)
            {
                query = query.Where(x => x.CreatedBy.Id == currentUserId);
            }
            else
            {
                query = query.Where(x => x.Stock.Owner.Id == currentUserId);
            }
            return query.LongCount();
        }

        // GET: Order/Details/5
        public ActionResult Details(long? id, string sortOrder, int page = 1)
        {

            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "createdDate_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Id = id;
            ViewBag.Page = page;
            ViewBag.CreatedDateSortParam = sortOrder == "createdDate" ? "createdDate_desc" : "createdDate";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = ApplicationDbContext.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            var orderModel = MapOrderToOrderModel(order);

            switch (sortOrder)
            {
                case "createdDate":
                    orderModel.Messages = orderModel.Messages.OrderBy(x => x.CreatedDate).ToList();
                    break;
                case "createdDate_desc":
                    orderModel.Messages = orderModel.Messages.OrderByDescending(x => x.CreatedDate).ToList();
                    break;
            }

            UpdateUnSeenMessages(page, orderModel);
            return View(orderModel);
        }

        [HttpPost]
        public ActionResult Message(long? id, string text, string sortOrder, int page = 1)
        {
            sortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "createdDate_desc" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Id = id;
            ViewBag.Page = page;
            ViewBag.CreatedDateSortParam = sortOrder == "createdDate" ? "createdDate_desc" : "createdDate";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = ApplicationDbContext.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            order.Messages.Add(
                new Message
                {
                    Text = Encryption.Encrypt(text),
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = UserManager.FindById(User.Identity.GetUserId())
                });

            ApplicationDbContext.Entry(order).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();

            var orderModel = MapOrderToOrderModel(order);
            switch (sortOrder)
            {
                case "createdDate":
                    orderModel.Messages = orderModel.Messages.OrderBy(x => x.CreatedDate).ToList();
                    break;
                case "createdDate_desc":
                    orderModel.Messages = orderModel.Messages.OrderByDescending(x => x.CreatedDate).ToList();
                    break;
            }
            return View("Details", orderModel);
        }

        [Authorize]
        public ActionResult Create(long? stockId)
        {
            if (stockId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = ApplicationDbContext.Stocks.Find(stockId);
            if (stock == null)
            {
                return HttpNotFound();
            }
            var orderModel = MapToOrderModel(stock);
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(OrderModel orderModel)
        {
            CheckQuantity(orderModel);
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Stock = ApplicationDbContext.Stocks.Find(orderModel.StockId),
                    Quantity = orderModel.OrderQuantity,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = UserManager.FindById(User.Identity.GetUserId()),
                    OrderStatus = ApplicationDbContext.OrderStatuses.FirstOrDefault(x => x.Name == OrderStatus.Pending),
                };
                ApplicationDbContext.Orders.Add(order);
                ApplicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderModel);
        }

        // GET: Order/Edit/5
        public ActionResult UpdateStatus(long? id, string orderStatusName, bool showMyOrders = true)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = ApplicationDbContext.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            order.ModifiedBy = UserManager.FindById(User.Identity.GetUserId());
            order.ModifiedDate = DateTime.UtcNow;
            order.OrderStatus = ApplicationDbContext.OrderStatuses.FirstOrDefault(x => x.Name == orderStatusName);
            ApplicationDbContext.Entry(order).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();

            UpdateStockQuantity(order);

            return RedirectToAction("Index", new { showMyOrders });
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext.Entry(order).State = EntityState.Modified;
                ApplicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = ApplicationDbContext.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Order order = ApplicationDbContext.Orders.Find(id);
            ApplicationDbContext.Orders.Remove(order);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        private static OrderModel MapToOrderModel(Stock stock)
        {
            var orderModel = new OrderModel
            {
                StockId = stock.Id,
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
            return orderModel;
        }

        private OrderModel MapOrderToOrderModel(Order order)
        {
            var orderModel = MapToOrderModel(order.Stock);
            orderModel.OrderQuantity = order.Quantity;
            orderModel.OrderStatusId = order.OrderStatus.Id;
            orderModel.OrderStatusName = order.OrderStatus.Name;
            orderModel.CreatedById = order.CreatedBy.Id;
            orderModel.CreatedByName = order.CreatedBy.UserName;
            orderModel.CreatedDate = order.CreatedDate;
            orderModel.ModifiedById = order.ModifiedBy?.Id;
            orderModel.ModifiedByName = order.ModifiedBy?.UserName;
            orderModel.ModifiedDate = order.ModifiedDate;
            orderModel.OrderId = order.Id;

            orderModel.Messages = ApplicationDbContext.Messages
                .Where(x => x.OrderId == order.Id)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new MessageModel
                {
                    UserName = x.CreatedBy.UserName,
                    CreatedById = x.CreatedBy.Id,
                    Id = x.Id,
                    ItemTitle = x.Order.Stock.Item.Title,
                    OrderId = x.OrderId,
                    CreatedDate = x.CreatedDate,
                    Seen = x.Seen,
                    Text = x.Text
                })
                .ToList();

            orderModel.Messages.ForEach(x => x.Text = Encryption.Decrypt(x.Text));

            return orderModel;
        }

        private void CheckQuantity(OrderModel orderModel)
        {
            if (orderModel.OrderQuantity > orderModel.Quantity)
            {
                ModelState.AddModelError("OrderQuantity", "The order quantity must be less or equal to stock quantity");
            }
        }

        private void UpdateStockQuantity(Order order)
        {
            if (order.OrderStatus.Name != OrderStatus.Closed) return;
            var stock = ApplicationDbContext.Stocks.Find(order.Stock.Id);
            if (stock == null)
            {
                throw new NullReferenceException("Stock wasn't found for the order");
            }

            stock.Quantity = stock.Quantity - order.Quantity;
            ApplicationDbContext.Entry(stock).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();
        }

        private void UpdateUnSeenMessages(int page, OrderModel orderModel)
        {
            var pageSize = 10;
            var currentUserId = User.Identity.GetUserId();

            var unseenMessagesToUpdate = orderModel.Messages.Skip(page > 1 ? (page - 1) * pageSize : 0).Take(pageSize);
            foreach (var messageModel in unseenMessagesToUpdate)
            {
                if (messageModel.CreatedById != currentUserId && !messageModel.Seen)
                {
                    var message = ApplicationDbContext.Messages.FirstOrDefault(x => x.Id == messageModel.Id);
                    if (message != null)
                    {
                        messageModel.Seen = true;
                        message.Seen = true;
                        ApplicationDbContext.Entry(message).State = EntityState.Modified;
                    }
                }
            }
            ApplicationDbContext.SaveChanges();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ApplicationDbContext.Dispose();
                UserManager.Dispose();
            }
            base.Dispose(disposing);
        }

        public void AddMessage(int id, string message)
        {
            Order order = ApplicationDbContext.Orders.Find(id);

            order.Messages.Add(new Message
            {
                Text = Encryption.Encrypt(message),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId())
            });

            ApplicationDbContext.Entry(order).State = EntityState.Modified;
            ApplicationDbContext.SaveChangesAsync();
        }
    }
}
