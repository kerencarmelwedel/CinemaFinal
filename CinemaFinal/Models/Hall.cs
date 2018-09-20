using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class Hall
    {
        public int Id { get; set; }
        [Required]
        public int RowsCount { get; set; }
        public int SeatsInRow { get; set; }

        //// Foreign Key
        //public Movie MovieId { get; set; }
    }
}