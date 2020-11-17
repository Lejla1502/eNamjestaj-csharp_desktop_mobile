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
    public class SkladistaController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Skladistas
        public IQueryable<Skladista> GetSkladista()
        {
            return db.Skladista;
        }

        // GET: api/Skladistas/5
        [ResponseType(typeof(Skladista))]
        public IHttpActionResult GetSkladista(int id)
        {
            Skladista skladista = db.Skladista.Find(id);
            if (skladista == null)
            {
                return NotFound();
            }

            return Ok(skladista);
        }

        [Route("api/Skladista/ProvjeraNaziv/{naziv}")]
        [HttpGet]
        public int ProvjeraNaziv(string naziv)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(db.esp_GetSkladisteIDByNaziv(naziv).FirstOrDefault());
                return Id;
            }
            catch (Exception)
            {
                return Id;
            }
        }


        [HttpGet]
        [Route("api/Skladista/SearchSkladista/{name?}")]
        public List<Skladista> SearchSkladista(string name = "")
        {
            return db.esp_Skladista_SelectByNaziv(name).ToList();
        }

        // PUT: api/Skladistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkladista(int id, Skladista skladista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skladista.SkladistaID)
            {
                return BadRequest();
            }

            db.Entry(skladista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkladistaExists(id))
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

        // POST: api/Skladistas
        [ResponseType(typeof(Skladista))]
        public IHttpActionResult PostSkladista(Skladista skladista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_Skladista_Insert(skladista.Naziv, skladista.Opis, skladista.Adresa);

            return CreatedAtRoute("DefaultApi", new { id = skladista.SkladistaID }, skladista);
        }

        // DELETE: api/Skladistas/5
        [ResponseType(typeof(Skladista))]
        public IHttpActionResult DeleteSkladista(int id)
        {
            Skladista skladista = db.Skladista.Find(id);
            if (skladista == null)
            {
                return NotFound();
            }

            db.Skladista.Remove(skladista);
            db.SaveChanges();

            return Ok(skladista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkladistaExists(int id)
        {
            return db.Skladista.Count(e => e.SkladistaID == id) > 0;
        }
    }
}