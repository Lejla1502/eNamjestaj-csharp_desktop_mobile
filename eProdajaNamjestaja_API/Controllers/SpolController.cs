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
using eProdajaNamjestaja_API.Models;

namespace eProdajaNamjestaja_API.Controllers
{
    public class SpolController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Spol
        public IQueryable<Spol> GetSpol()
        {
            return db.Spol;
        }

        // GET: api/Spol/5
        [ResponseType(typeof(Spol))]
        public IHttpActionResult GetSpol(int id)
        {
            Spol spol = db.Spol.Find(id);
            if (spol == null)
            {
                return NotFound();
            }

            return Ok(spol);
        }

        // PUT: api/Spol/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpol(int id, Spol spol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spol.SpolID)
            {
                return BadRequest();
            }

            db.Entry(spol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpolExists(id))
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

        // POST: api/Spol
        [ResponseType(typeof(Spol))]
        public IHttpActionResult PostSpol(Spol spol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spol.Add(spol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spol.SpolID }, spol);
        }

        // DELETE: api/Spol/5
        [ResponseType(typeof(Spol))]
        public IHttpActionResult DeleteSpol(int id)
        {
            Spol spol = db.Spol.Find(id);
            if (spol == null)
            {
                return NotFound();
            }

            db.Spol.Remove(spol);
            db.SaveChanges();

            return Ok(spol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpolExists(int id)
        {
            return db.Spol.Count(e => e.SpolID == id) > 0;
        }
    }
}