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
    public class UsersSessionsController : Controller
    {
        private SessionManager sessionManager = new SessionManager();
        private MovieManager movieManager = new MovieManager();

        // GET: UsersSessions
        public ActionResult Index(int? Id)
        {
            ViewBag.Movies = new SelectList(movieManager.GetAllMovies(), "Id", "Name");
            List<Session> sessions;
            if (Id == null)
            {
                sessions = sessionManager.GetAllSessions();
            }
            else
            {
                sessions = sessionManager.GetSessionsByMovie(Id.Value);
            }
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];
            return View(sessions);
        }


        // GET: UsersSessions/Details/5
        public ActionResult Details(int id)
        {

            Session ms = sessionManager.GetSessionById(id);
            if (ms == null)
                return HttpNotFound();
            return View(ms);
        }

        // GET: UsersSessions/Create
        public ActionResult Create()
        {
            ViewBag.Movies = new SelectList(movieManager.GetAllMovies(), "MovieId", "Name");
            var exemploList = new SelectList(new[] { "21:00", "18:00", "15:00" });
            ViewBag.ExemploList = exemploList;
            return View();
        }

        // POST: UsersSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShowDate,ShowTime,bookedSeats,MovieId,HallId")] Session session)
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

        // GET: UsersSessions/Edit/5
        public ActionResult Edit(int sessionId)
        {
            Session ms = sessionManager.GetSessionById(sessionId);
            if (ms == null)
                return HttpNotFound();
            return View(ms);
        }

        // POST: UsersSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int sessionId, Session ms)
        {
            try
            {
                sessionManager.EditSession(ms);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(ms);
            }
        }

    }
}