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
using RestauranteWebAPI.Models;
using System.Web.Http.Cors;

namespace RestauranteWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PratosController : ApiController
    {
        private RestauranteContext db = new RestauranteContext();

        // GET: api/Pratos
        public IQueryable<Prato> GetPratos()
        {
            return db.Pratos;
        }

        // GET: api/Pratos/5
        [ResponseType(typeof(Prato))]
        public IHttpActionResult GetPrato(int id)
        {
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }

            return Ok(prato);
        }

        // PUT: api/Pratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrato(int id, Prato prato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prato.Id)
            {
                return BadRequest();
            }

            db.Entry(prato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PratoExists(id))
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

        // POST: api/Pratos
        [ResponseType(typeof(Prato))]
        public IHttpActionResult PostPrato(Prato prato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pratos.Add(prato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prato.Id }, prato);
        }

        // DELETE: api/Pratos/5
        [ResponseType(typeof(Prato))]
        public IHttpActionResult DeletePrato(int id)
        {
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }

            db.Pratos.Remove(prato);
            db.SaveChanges();

            return Ok(prato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PratoExists(int id)
        {
            return db.Pratos.Count(e => e.Id == id) > 0;
        }
    }
}