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
    public class SkladistaProizvodController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/SkladistaProizvod
        public IQueryable<SkladistaProizvod> GetSkladistaProizvod()
        {
            return db.SkladistaProizvod;
        }

        [HttpGet]
        [Route("api/SkladistaProizvod/ProvjeraStanja/{proizvodId}/{skladisteId}")]
        public int? ProvjeraStanja(int proizvodId,int skladisteId)
        {
            
            int? e= db.esp_SkladistaProizvod_ProvjeraStanja(proizvodId,skladisteId).FirstOrDefault();
            return e;
        }

        // GET: api/SkladistaProizvod/5
        [ResponseType(typeof(SkladistaProizvod))]
        public IHttpActionResult GetSkladistaProizvod(int id)
        {
            SkladistaProizvod skladistaProizvod = db.SkladistaProizvod.Find(id);
            if (skladistaProizvod == null)
            {
                return NotFound();
            }

            return Ok(skladistaProizvod);
        }

        // PUT: api/SkladistaProizvod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkladistaProizvod(int id, SkladistaProizvod skladistaProizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skladistaProizvod.SkladisteProizvodID)
            {
                return BadRequest();
            }

            db.Entry(skladistaProizvod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkladistaProizvodExists(id))
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

        // POST: api/SkladistaProizvod
        [ResponseType(typeof(SkladistaProizvod))]
        public IHttpActionResult PostSkladistaProizvod(SkladistaProizvod skladistaProizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkladistaProizvod.Add(skladistaProizvod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skladistaProizvod.SkladisteProizvodID }, skladistaProizvod);
        }

        // DELETE: api/SkladistaProizvod/5
        [ResponseType(typeof(SkladistaProizvod))]
        public IHttpActionResult DeleteSkladistaProizvod(int id)
        {
            SkladistaProizvod skladistaProizvod = db.SkladistaProizvod.Find(id);
            if (skladistaProizvod == null)
            {
                return NotFound();
            }

            db.SkladistaProizvod.Remove(skladistaProizvod);
            db.SaveChanges();

            return Ok(skladistaProizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkladistaProizvodExists(int id)
        {
            return db.SkladistaProizvod.Count(e => e.SkladisteProizvodID == id) > 0;
        }
    }
}