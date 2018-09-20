using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class HallManager
    {
        private CinemaFinalDBContext DB = new CinemaFinalDBContext();
        //get all sessionss from database and present them
        public List<Hall> GetAllHalls()
        {
            return DB.Halls.ToList();
        }

        //public List<Session> GetHallsBySession(int sessionId)
        //{
        //    var query = from sd in DB.Halls
        //                where sd.SessionId == sessionId
        //                select sd;
            //List<Hall> sessions = new List<Hall>();
            //foreach (var sd in query.ToList())
            //{
            //    Session s = new Session
            //    {
            //        Id = sd.Id,
            //        MovieId = sd.MovieId,
            //        HallId = sd.HallId,
            //        ShowDate = sd.ShowDate,
            //        ShowTime = sd.ShowTime
            //    };
            //    sessions.Add(s);
            //}
            //return sessions;
        

        public void AddHall(Hall h)
        {
            DB.Halls.Add(h);
            DB.SaveChanges();
        }

        public void EditHall(Hall h)
        {
            DB.Entry(h).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public void RemoveHall(Hall h)
        {
            DB.Halls.Remove(h);
            DB.SaveChanges();
        }

        //find a session by its id

        public Hall GetHallById(int id)
        {
            Hall h = DB.Halls.Find(id);
            return (h);
        }
    }
}
    
