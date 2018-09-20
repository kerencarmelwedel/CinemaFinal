using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class SessionManager
    {
        private CinemaFinalDBContext DB = new CinemaFinalDBContext();
        //get all sessionss from database and present them
        public List<Session> GetAllSessions()
        {
            return DB.Sessions.ToList();
        }

        public List<Session> GetSessionsByMovie(int movieId)
        {
            var query = from sd in DB.Sessions
                        where sd.MovieId == movieId
                        select sd;
            List<Session> sessions = new List<Session>();
            foreach (var sd in query.ToList())
            {
                Session s = new Session
                {
                    Id = sd.Id,
                    MovieId = sd.MovieId,
                    HallId = sd.HallId,
                    ShowDate = sd.ShowDate,
                    ShowTime = sd.ShowTime
                };
                sessions.Add(s);
            }
            return sessions;
        }

        public void AddSession(Session s)
        {
            DB.Sessions.Add(s);
            DB.SaveChanges();
        }

        public void EditSession(Session s)
        {
            DB.Entry(s).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public void RemoveSession(Session s)
        {
            DB.Sessions.Remove(s);
            DB.SaveChanges();
        }

        //find a session by its id

        public Session GetSessionById(int id)
        {
            Session s = DB.Sessions.Find(id);
            return (s);
        }
    }
}