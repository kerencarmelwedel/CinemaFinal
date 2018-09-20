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
    public class HallsController : Controller
    {
        private HallManager hallManager = new HallManager();
        [Authorize]
        // GET: Halls
        public ActionResult Index()
        {
            List<Hall> hall = hallManager.GetAllHalls();
            return View(hall);
        }

        // GET: Halls/Details/5
        public ActionResult Details(int id)
        {
            Hall h = hallManager.GetHallById(id);
            if (h == null)
                return HttpNotFound();
            return View(h);

        }

        // GET: Halls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RowsCount,SeatsInRow")] Hall hall)
        {
            try {
                hallManager.AddHall(hall);
                return RedirectToAction("Index");
            }
            catch(Exception) {
                ModelState.AddModelError("error", "unable to save the hall");
                return View(hall);
            }

        }

        // GET: Halls/Edit/5
        public ActionResult Edit(int id)
        {
            Hall h = hallManager.GetHallById(id);
            if (h == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
                return HttpNotFound();
            }
            return View(h);
        }


        // POST: Halls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RowsCount,SeatsInRow")] Hall hall)
        {
            try
            {
                hallManager.EditHall(hall);
                return RedirectToAction("Index");
            }


            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again or contact your system administrator.");
            }
            return View(hall);
        }


        // GET: Halls/Delete/5
        public ActionResult Delete(int id)
        {
            Hall h = hallManager.GetHallById(id);
            if (h == null)
                return HttpNotFound();
            return View(h);
        }
        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Hall h)
        {
            h = hallManager.GetHallById(id);
            hallManager.RemoveHall(h);
            return RedirectToAction("Index");
        }

    }
}
