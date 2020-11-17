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
    public class KupciController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Kupcis
        public IQueryable<Kupci> GetKupci()
        {
            return db.Kupci;
        }

        // GET: api/Kupcis/5
        [HttpGet]
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult GetKupci(int id)
        {
            Kupci kupci = db.Kupci.Find(id);
            if (kupci == null)
            {
                return NotFound();
            }

            return Ok(kupci);
        }


        [Route("api/Kupci/GetKupciByUsername/{name?}")]
        [HttpGet]
        public IHttpActionResult GetKupciByUsername(string name = "")
        {
            Kupci kupci = db.Kupci.Where(x => x.KorisnickoIme == name && x.Statuss == true).FirstOrDefault();

            if (kupci == null)
            {
                return NotFound();
            }

            return Ok(kupci);
        }

        [HttpGet]
        [Route("api/Kupci/GetKupciById/{kupacId}")]
        public esp_Kupac_SelectById_Result SearchKupci(int kupacId)
        {
            esp_Kupac_SelectById_Result kupci = db.esp_Kupac_SelectById(kupacId).FirstOrDefault();
            return kupci;
        }
        [HttpGet]
        [Route("api/Kupci/SearchKupci/{name?}")]
        public List<Kupci> SearchKupci(string name = "")
        {
            List<Kupci> kupci = db.esp_Kupci_SelectByImePrezime(name).ToList();
            return kupci;
        }

        // PUT: api/Kupcis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKupci(int id, Kupci kupci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kupci.KupacID)
            {
                return BadRequest();
            }

            db.Entry(kupci).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupciExists(id))
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

        [Route("api/Kupci/Provjera/{username}")]
        [HttpGet]
        public IHttpActionResult Provjera(string username)
        {
            //int Id = 0;
            //try
            //{
            //    Id = Convert.ToInt32(db.esp_GetDobavljacIDByNaziv(naziv).FirstOrDefault());
            //    return Id;
            //}
            //catch (Exception)
            //{
            //    return Id;
            //}

            Kupci kupci = db.Kupci.Where(x => x.KorisnickoIme == username ).FirstOrDefault();

            if (kupci == null)
            {
                return NotFound();
            }

            return Ok(kupci);
        }

        // POST: api/Kupcis
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult PostKupci(Kupci kupci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_Kupci_Insert(kupci.Ime, kupci.Prezime, kupci.Mail, kupci.KorisnickoIme
                , kupci.LozinkaSalt, kupci.LozinkaHash, kupci.DatumRegistracije, kupci.Statuss);

            return CreatedAtRoute("DefaultApi", new { id = kupci.KupacID }, kupci);
        }

        // DELETE: api/Kupcis/5
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult DeleteKupci(int id)
        {
            Kupci kupci = db.Kupci.Find(id);
            if (kupci == null)
            {
                return NotFound();
            }

            db.Kupci.Remove(kupci);
            db.SaveChanges();

            return Ok(kupci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KupciExists(int id)
        {
            return db.Kupci.Count(e => e.KupacID == id) > 0;
        }
    }
}