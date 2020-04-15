using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required] //whenever I new up a restaurant, I will have to give it a name, address, rating
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}