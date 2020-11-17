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
    public class UlaziController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Ulazi
        public IQueryable<Ulazi> GetUlazi()
        {
            return db.Ulazi;
        }

        
        // GET: api/Ulazi/5
        [ResponseType(typeof(Ulazi))]
        public IHttpActionResult GetUlazi(int id)
        {
            Ulazi ulazi = db.Ulazi.Find(id);
            if (ulazi == null)
            {
                return NotFound();
            }

            return Ok(ulazi);
        }

        // PUT: api/Ulazi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUlazi(int id, Ulazi ulazi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ulazi.UlaziID)
            {
                return BadRequest();
            }

            db.Entry(ulazi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlaziExists(id))
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

        // POST: api/Ulazi
        [ResponseType(typeof(Ulazi))]
        public IHttpActionResult PostUlazi(Ulazi ulaz)
        {

            try
            {
                db.esp_UlaziInsert(ulaz.BrojFakture, ulaz.Datum, ulaz.IznosRacuna, ulaz.DobavljacID, ulaz.KorisnikID, ulaz.SkladisteID, ulaz.Napomena, ulaz.PDV);
                int ulazId = db.Ulazi.OrderByDescending(u => u.UlaziID).Select(u => u.UlaziID).FirstOrDefault();
                foreach (UlaziStavke item in ulaz.UlaziStavke)
                {
                    string sifra = db.Proizvodi.Where(p => p.ProizvodID == item.ProizvodID).Select(p => p.Sifra).FirstOrDefault();

                    db.esp_UlaziStavke_Insert(item.Cijena, item.Kolicina, item.ProizvodID, ulazId);
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Ulazi/5
        [ResponseType(typeof(Ulazi))]
        public IHttpActionResult DeleteUlazi(int id)
        {
            Ulazi ulazi = db.Ulazi.Find(id);
            if (ulazi == null)
            {
                return NotFound();
            }

            db.Ulazi.Remove(ulazi);
            db.SaveChanges();

            return Ok(ulazi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UlaziExists(int id)
        {
            return db.Ulazi.Count(e => e.UlaziID == id) > 0;
        }
    }
}