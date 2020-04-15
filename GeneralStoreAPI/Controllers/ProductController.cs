using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //POST
        [HttpPost]
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //GET ALL
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        //GET BY ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //PUT
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("Product Id is a mismatch");
                }
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        /*      ALTERNATE WAY TO MAKE A PUT METHOD
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    product.ProductName = model.ProductName;
                    product.UPC = model.UPC;
                    product.Price = model.Price;
                    product.Quantity = model.Quantity;

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        */

        //DELETE
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
