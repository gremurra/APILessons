using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext 
    {
        //like an empty constructor
        public RestaurantDbContext() : base("DefaultConnection") { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}