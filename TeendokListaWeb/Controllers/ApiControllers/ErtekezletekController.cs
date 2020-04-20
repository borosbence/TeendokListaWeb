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
using TeendokListaWeb.Models;

namespace TeendokListaWeb.Controllers.ApiControllers
{
    public class ErtekezletekController : ApiController
    {
        private TeendokContext db = new TeendokContext();

        // GET: api/Ertekezletek
        public IQueryable<ertekezlet> Getertekezlet()
        {
            return db.ertekezlet;
        }

        // GET: api/Ertekezletek/5
        [ResponseType(typeof(ertekezlet))]
        public IHttpActionResult Getertekezlet(int id)
        {
            ertekezlet ertekezlet = db.ertekezlet.Find(id);
            if (ertekezlet == null)
            {
                return NotFound();
            }

            return Ok(ertekezlet);
        }

        // PUT: api/Ertekezletek/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putertekezlet(int id, ertekezlet ertekezlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ertekezlet.id)
            {
                return BadRequest();
            }

            db.Entry(ertekezlet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ertekezletExists(id))
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

        // POST: api/Ertekezletek
        [ResponseType(typeof(ertekezlet))]
        public IHttpActionResult Postertekezlet(ertekezlet ertekezlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ertekezlet.Add(ertekezlet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ertekezlet.id }, ertekezlet);
        }

        // DELETE: api/Ertekezletek/5
        [ResponseType(typeof(ertekezlet))]
        public IHttpActionResult Deleteertekezlet(int id)
        {
            ertekezlet ertekezlet = db.ertekezlet.Find(id);
            if (ertekezlet == null)
            {
                return NotFound();
            }

            db.ertekezlet.Remove(ertekezlet);
            db.SaveChanges();

            return Ok(ertekezlet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ertekezletExists(int id)
        {
            return db.ertekezlet.Count(e => e.id == id) > 0;
        }
    }
}