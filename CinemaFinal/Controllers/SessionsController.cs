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
    public class SessionsController : Controller
    {
        private SessionManager sessionManager = new SessionManager();
        private MovieManager movieManager = new MovieManager();
        private HallManager hallManager = new HallManager();
        // GET: Sessions
        [Authorize]
        public ActionResult Index(int? MovieId)
        {
            ViewBag.Movies = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            List<Session> sessions;
            if (MovieId == null)
            {
                sessions = sessionManager.GetAllSessions();
            }
            else
            {
                sessions = sessionManager.GetSessionsByMovie(MovieId.Value);
            }
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];
            return View(sessions);
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int id)
        {

            Session ms = sessionManager.GetSessionById(id);
            if (ms == null)
                return HttpNotFound();
            return View(ms);
        }

        // GET: Sessions/Create
        [Authorize]
        public ActionResult Create()

        {
            ViewBag.HallId = new SelectList(hallManager.GetAllHalls(), "Id", "Id");
            ViewBag.MovieId = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            var exemploList = new SelectList(new[] { "21:00", "18:00", "15:00" });
            ViewBag.ExemploList = exemploList;
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="SessionId,ShowDate,ShowTime,MovieId,HallId")] Session session)
        {
                try
                {
                    if ((session.ShowTime != "21:00") && (session.ShowTime != "18:00") && (session.ShowTime != "15:00"))
                    {
                        return View();
                    }
                    else
                    {
                        sessionManager.AddSession(session);
                        return RedirectToAction("Index");

                    }


                }
                catch (Exception)
                {
                    ModelState.AddModelError("error", "unable to save the session");
                    return View(session);
                }
            }

        // GET: Sessions/Edit/5
        public ActionResult Edit(int Id)
        {
            Session ms = sessionManager.GetSessionById(Id);
            if (ms == null)
            {
                return HttpNotFound();
            }
            ViewBag.HallId = new SelectList(hallManager.GetAllHalls(), "Id", "Id");
            ViewBag.MovieId = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            return View(ms);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShowDate,ShowTime,BookedSeats,MovieId,HallId")]int Id, Session ms)
        {
            if (ModelState.IsValid)
            {
            //    try
            //{
                sessionManager.EditSession(ms);
                return RedirectToAction("Index");
            }
            ViewBag.HallId = new SelectList(hallManager.GetAllHalls(), "Id", "Id");
            ViewBag.MovieId = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            return View(ms);

            //catch (Exception e)
            //{
            //    return View(ms);
            //}
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(int id)
        {
            Session ms = sessionManager.GetSessionById(id);
            if (ms == null)
                return HttpNotFound();
            return View(ms);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Session ms)
        {
            try
            {
                ms = sessionManager.GetSessionById(id);
                sessionManager.RemoveSession(ms);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ms);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        }
    }
