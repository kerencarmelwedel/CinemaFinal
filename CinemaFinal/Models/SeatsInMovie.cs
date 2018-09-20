using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class SeatsInMovie
    {
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int MovieKey { get; set; }
        public String MovieName { get; set; }
        public int BookedSeats { get; set; }
        public Movie Movie { get; set; }
    }
}