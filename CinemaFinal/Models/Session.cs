using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class Session
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShowDate { get; set; }

        [Required]
        public string ShowTime { get; set; }

        public string BookedSeats { get; set; }
        public virtual int MovieId { get; set; }
        public virtual int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Movie Movie { get; set; }
    }
}