using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class CinemaFinalDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CinemaFinalDBContext() : base("name=CinemaFinalDBContext")
        {
        }

        public System.Data.Entity.DbSet<CinemaFinal.Models.Movie> Movies { get; set; }
        public System.Data.Entity.DbSet<CinemaFinal.Models.Hall> Halls { get; set; }
        public System.Data.Entity.DbSet<CinemaFinal.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<CinemaFinal.Models.Session> Sessions { get; set; }
        public System.Data.Entity.DbSet<CinemaFinal.Models.User> Users { get; set; }
    }
}
