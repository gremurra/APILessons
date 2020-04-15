﻿using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        //starting by saying what type of methods these are
        //must create an object before you do anything with it
        
        [HttpPost]   //Create in CRUD Example
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            //because of the type of method, you can see if the model being passed in is valid
            //valid if the objects have the required fields (in Restaurant Class: name, address, rating)
            if (ModelState.IsValid)
            {
                //database  //table we want  //.Adding to table //object being added
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest(ModelState);
        }

        //GET ALL
        [HttpGet]   //Read 1 in CRUD Example
        public async Task<IHttpActionResult> Get()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //GET BY ID
        [HttpGet]   //Read 2 in CRUD Example
        public async Task<IHttpActionResult> GetById(int id)
        {
            //Need to pass in ID
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            //searching entire database for that one object
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }

        [HttpPut]    //Update in CRUD example

        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model)
        {
            if (ModelState.IsValid)
            {                                                       //FindAsync method returns null if it doesnt work
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);
                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Address = model.Address;
                    restaurant.Rating = model.Rating;

                    await _context.SaveChangesAsync();
                    return Ok();    //this is the 200 on Postman
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}
