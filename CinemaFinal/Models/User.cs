using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
      //  [Index(IsUnique = true)]
        [MaxLength(20)]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(80)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}