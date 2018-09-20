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
    public class UsersMoviesController : Controller
    {
        private MovieManager movieManager = new MovieManager();


        // GET: UsersMovies
        public ActionResult Index()
        {
            List<Movie> movie = movieManager.GetAllMovies();
            return View(movie);
        }

        // GET: UsersMovies/Details/5
        public ActionResult Details(int id)
        {
            Movie mo = movieManager.GetMovieById(id);
            if (mo == null)
                return HttpNotFound();
            return View(mo);
        }

    }
}

      
