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
using WebApiAlmacen.Models;

namespace WebApiAlmacen.Controllers
{
    public class ModelosController : ApiController
    {
        private SistemaAlmacenEntities1 db = new SistemaAlmacenEntities1();

        // GET: api/Modelos
        public IQueryable<Modelo> GetModelo()
        {
            return db.Modelo;
        }

        // GET: api/Modelos/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult GetModelo(int id)
        {
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.iIdModelo)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelos
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelo.Add(modelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelo.iIdModelo }, modelo);
        }

        // DELETE: api/Modelos/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult DeleteModelo(int id)
        {
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.Modelo.Remove(modelo);
            db.SaveChanges();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modelo.Count(e => e.iIdModelo == id) > 0;
        }
    }
}