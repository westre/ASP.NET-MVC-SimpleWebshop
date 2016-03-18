using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WindesheimWebshop.DAL;
using WindesheimWebshop.Models;
using System.Web.Routing;

namespace WindesheimWebshop.Controllers
{
    [RoutePrefix("api/producten")]
    public class ProductsAPIController : ApiController
    {
        private WebshopContext db = new WebshopContext();

        // GET: api/producten
        [Route("")]
        [HttpGet]
        public IQueryable<Product> GetProducten()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.Producten.Include(p => p.Aanbiedingen).Include(p => p.Categorieen);
        }

        // GET: api/producten/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/producten
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            product.Plaatje = "http://placehold.it/300x300";

            product.Categorieen = new List<Categorie>();
            product.Categorieen.Add(db.Categorieen.Find(6));

            db.Producten.Add(product);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
            return Ok();
        }

        // PUT: api/ProductsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ProductsAPI/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Producten.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Producten.Count(e => e.ID == id) > 0;
        }
    }
}