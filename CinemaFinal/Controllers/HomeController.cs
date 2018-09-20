using CinemaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaFinal.Controllers
{
    public class HomeController : Controller
      {
        //private CinemaFinalDBContext context = new CinemaFinalDBContext();
        private MovieManager movieManager = new MovieManager();
        public ActionResult Index()
        {
            //   List<Movie> list = movieManager.GetPopularMovies();
            //Session["PopularMovies"] = list;
            //List<Movie> movieList = (List<Movie>)Session["PopularMovies"];
            //    return View(list.ToList());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Users = "Admin")]
        public ActionResult AdminAction()
        {
            return View();
        }
        public ActionResult Search(string prefix)
        {            
            var query = /*from m in context.Movies*/
                            from m in movieManager.GetAllMovies()
                        where m.Name.StartsWith(prefix)
                         select new { m.Name};

                      //  return Json(query, JsonRequestBehavior.AllowGet);
                        return PartialView("_MoviesTable", query);
        }

        //Finds movie results based on movieName 
    //    Console.WriteLine(Movie.Name);
    //        List<Movie> movies = movieMAnager.getMoviesbyName(Name);
    //        if (movies != null && movies.Count > 0) //Found Movies based on this search string.
    //        {
    //            ViewData["MoviesList"] = movies;
    //        }
    //        {  foreach(var session in sessions)
    //                    {
    //                        var movie = moviemanager.GetMovieById(session.MovieId);
    //Movies.Add(movie);
    //                    }
    //                }
    //                ViewData["MoviesList"] = allMovies;
            
                        

        
    }
}