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

        // GET: api/Ertekezlet
        public IQueryable<ertekezlet> Getertekezlet()
        {
            return db.ertekezlet;
        }

        // GET: api/Ertekezlet/5
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

        // PUT: api/Ertekezlet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putertekezlet(ertekezlet ertekezlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(ertekezlet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ertekezletExists(ertekezlet.id))
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

        // POST: api/Ertekezlet
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

        // DELETE: api/Ertekezlet/5
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