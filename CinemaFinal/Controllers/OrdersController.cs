using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaFinal.Models;

namespace CinemaFinal.Controllers
{
    public class OrdersController : Controller
    {
        private OrderManager orderManager = new OrderManager();
        private SessionManager sessionManager = new SessionManager();
        private MovieManager movieManager = new MovieManager();
        private CinemaFinalDBContext db = new CinemaFinalDBContext();

        // GET: Orders
        public ActionResult Index()
        {
            List<Order> orders = orderManager.GetAllOrders();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order or = orderManager.GetOrderById(id);
            if (or == null)
                return HttpNotFound();
            return View(or);

        }

        // GET: Orders/Create
        public ActionResult Create(string BookedSeats)
        {
            Session s = (Session)Session["Session"];
            User u = (User)Session["User"];
            ViewBag.sessionDetails = s;
            ViewBag.userDetails = u;

            Session session = s;
            string[] a = BookedSeats.Split(',');
            Order order = new Order { NumOfTickets = a.Count() };
            return View(order);

        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Movie.Name,BookedSeats,NumOfTickets,OrderDate,SessionId,UserId")] Order order, int SessionId)
        {
            if (ModelState.IsValid)

            {
                order.OrderDate = DateTime.Now;
                orderManager.AddOrder(order);
                Session session = sessionManager.GetSessionById(SessionId);
                if (session.BookedSeats == null)
                {
                    session.BookedSeats += order.BookedSeats;
                }
                else
                {
                    session.BookedSeats += "," + order.BookedSeats;
                }

                // db.SaveChanges();
                // orderManager.AddOrder(order);


                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            ViewBag.SessionId = new SelectList(sessionManager.GetAllSessions(), "Id", "ShowTime", order.SessionId );
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", order.UserId);

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order o = orderManager.GetOrderById(id);
            if (o == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
                return HttpNotFound();
            }
            return View(o);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookedSeats,NumOfTickets,OrderDate,SessionId,UserId")] Order order)
        {
            if (ModelState.IsValid)
            {
                orderManager.EditOrder(order);
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again or contact your system administrator.");
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "ShowTime", order.SessionId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order o = orderManager.GetOrderById(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Order o)
        {
            try
            {
                o = orderManager.GetOrderById(id);
                orderManager.RemoveOrder(o);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(o);
            };
            //}
            //protected override void Dispose(bool disposing)
            //{
            //    if (disposing)
            //    {
            //        db.Dispose();
            //    }
            //    base.Dispose(disposing);
            //}
        }
    }
}
