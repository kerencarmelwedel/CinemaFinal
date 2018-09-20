using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Director { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
     
        public virtual ICollection<Session> Sessions { get; set; }
    }
}