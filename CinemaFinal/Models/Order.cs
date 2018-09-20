using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class Order
    {
        //[Key]
        public int Id { get; set; }
        [Required]
        public string BookedSeats { get; set; }
        public int NumOfTickets { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime OrderDate { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        // Foreign Key
        //public int MovieId { get; set; }
        //public virtual Movie Movie { get; set; }
        //property
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}