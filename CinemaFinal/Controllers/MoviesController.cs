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
    [Authorize]
    public class MoviesController : Controller
    {
        private MovieManager movieManager = new MovieManager();

        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movie = movieManager.GetAllMovies();
            return View(movie);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie mo = movieManager.GetMovieById(id);
            if (mo == null)
                return HttpNotFound();
            return View(mo);

        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Director,Description")] Movie movie, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                movieManager.AddMovie(movie);
                // await db.SaveChangesAsync();
                string filePath = Server.MapPath("~/images/" + movie.Id + ".jpg");
                image.SaveAs(filePath);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(movieManager.GetAllMovies(), "MovieId", "Name");
            return View(movie);
        }
        //catch (Exception)
        //{
        //    ModelState.AddModelError("error", "Unable to save the movie");
        //    return View(movie);
        
        // Get: Movies/Edit
        public ActionResult Edit(int id)
        {

            Movie m = movieManager.GetMovieById(id);
            if (m == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
                return HttpNotFound();
            }
            return View(m);
        }


        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Name,Director,Description")] Movie movie)
        {
            try
            {
                movieManager.EditMovie(movie);
                return RedirectToAction("Index");
            }


            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again or contact your system administrator.");
            }
            return View(movie);
        }
        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {

            Movie m = movieManager.GetMovieById(id);
            if (m == null)
                return HttpNotFound();
            return View(m);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Movie m)
        {
           
                m = movieManager.GetMovieById(id);
                movieManager.RemoveMovie(m);
                return RedirectToAction("Index");
        }

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
