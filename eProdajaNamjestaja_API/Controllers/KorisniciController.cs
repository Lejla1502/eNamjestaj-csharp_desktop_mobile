using System;
using System.IO;
using System.Configuration;
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
using System.Data.Entity.Core;
using eProdajaNamjestaja_API.Util;

namespace eProdajaNamjestaja_API.Controllers
{
    public class KorisniciController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Korisnici
        public List<esp_Korisnici_SelectAll_Result> GetKorisnici()
        {
            return db.esp_Korisnici_SelectAll().ToList();
        }

        [HttpGet]
        [Route("api/Korisnici/SearchKorisnici/{name?}")]
        public List<Korisnici> SearchKorisnici(string name="")
        {
            return db.esp_Korisnici_SelectByImePrezime(name).ToList();
        }
        
        [HttpGet]
        [Route ("api/Korisnici/UserByID/{id}")]
        public Korisnici UserByID(int id)
        { return db.esp_Korisnik_SelectById(id).FirstOrDefault(); }


        // GET: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult GetKorisnici(int id)
        {
            Korisnici korisnici = db.Korisnici.Find(id);
            if (korisnici == null)
            {
                return NotFound();
            }

            return Ok(korisnici);
        }

        [ResponseType(typeof(Korisnici))]
        [Route("api/Korisnici/{username}")]
        public IHttpActionResult GetKorisnici(string username)
        {
            Korisnici korisnik = db.Korisnici.Where(x=>x.KorisnickoIme==username).FirstOrDefault();
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT: api/Korisnici/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Korisnici/{id}")]
        public IHttpActionResult PutKorisnici(int id, Korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnici.KorisnikID)
            {
                return BadRequest();
            }

            db.esp_Korisnici_Update(korisnici.Ime, korisnici.Prezime, korisnici.Mail, korisnici.Telefon,
                        korisnici.KorisnickoIme, korisnici.LozinkaSalt, korisnici.LozinkaHash,id,korisnici.SpolID,korisnici.GradID);


            db.esp_KorisniciUloge_Delete(korisnici.KorisnikID);

            foreach (Uloge u in korisnici.Uloge)
                db.esp_KorisniciUloge_Insert(korisnici.KorisnikID, u.UlogaID);


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Korisnici
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult PostKorisnici(Korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            try
            {
                korisnici.KorisnikID = Convert.ToInt32(db.esp_Korisnici_Insert(korisnici.Ime, korisnici.Prezime, korisnici.Mail, korisnici.Telefon,
                        korisnici.KorisnickoIme, korisnici.LozinkaSalt, korisnici.LozinkaHash,korisnici.SpolID,korisnici.GradID).FirstOrDefault());

            }
            catch (EntityException ex)
            {
                throw CreateHttpResponseException(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
            }

           foreach (Uloge u in korisnici.Uloge)
               db.esp_KorisniciUloge_Insert(korisnici.KorisnikID, u.UlogaID);


            return CreatedAtRoute("DefaultApi", new { id = korisnici.KorisnikID }, korisnici);
        }

        private HttpResponseException CreateHttpResponseException(string reason, HttpStatusCode status)
        {
            HttpResponseMessage msg = new HttpResponseMessage
            {
                StatusCode = status,
                ReasonPhrase = reason,
                Content = new StringContent(reason)
            };

            return new HttpResponseException(msg);
        }

        // DELETE: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult DeleteKorisnici(int id)
        {
            Korisnici korisnici = db.Korisnici.Find(id);
            if (korisnici == null)
            {
                return NotFound();
            }

            db.Korisnici.Remove(korisnici);
            db.SaveChanges();

            return Ok(korisnici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisniciExists(int id)
        {
            return db.Korisnici.Count(e => e.KorisnikID == id) > 0;
        }
    }
}