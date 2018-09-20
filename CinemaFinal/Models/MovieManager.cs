using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace CinemaFinal.Models
{
    public class MovieManager
    {
        private CinemaFinalDBContext DB = new CinemaFinalDBContext();

        public List<Movie> GetAllMovies()
        {
            return DB.Movies.ToList();
        }
        public void AddMovie(Movie m)
        {
            DB.Movies.Add(m);
            DB.SaveChanges();
        }
        public void EditMovie(Movie m)
        {
            DB.Entry(m).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            Movie m = DB.Movies.Find(id);
            return m;
        }
        public void RemoveMovie(Movie m)
        {
            DB.Movies.Remove(m);
            DB.SaveChanges();
        }
        //public List<Movie> GetPopularMovies()
        //{

        //DateTime today = DateTime.Today;
        //DateTime OneMonthEarlier = today.AddMonths(-1);

        //var custQuery = from p in DB.SeatsInMovie
        //                where p.DateOrder >= OneMonthEarlier
        //                group p by new
        //                { p.MovieKey } into l
        //                select new
        //                {
        //                    id = l.Key.MovieKey,
        //                    totalAmmount = (System.Int32?)l.Sum(s => s.BookedSeats)
        //                };

        //            var topThree = (from i in custQuery
        //                            orderby i.totalAmmount descending
        //                            select i.id).Take(4);

        //            List<Movie> movieList = new List<Movie>();
        //            foreach (var item in topThree)
        //            {
        //                Movie movie = DB.Movies.Find(item);
        //                movieList.Add(movie);
        //            }

        //            Cache cache = HttpContext.Current.Cache;
        //            if (cache["PopularMovies"] != null)
        //            {
        //                return (List<Movie>)cache["PopularMovies"];
        //            }
        //            else
        //            {
        //                cache.Insert("PopularMovies", movieList, null, DateTime.Now.AddMinutes(1), new TimeSpan());
        //                return (movieList.ToList());

        //            }
        //        }
    }
}

    
    
