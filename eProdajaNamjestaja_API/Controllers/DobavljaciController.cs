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
    public class DobavljaciController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Dobavljaci
        [HttpGet]
        public List<Dobavljaci> GetDobavljaci()
        {
            return db.esp_Dobavljaci_GetAll().ToList();
            

        }

        [Route("api/Dobavljaci/ProvjeraNaziv/{naziv}")]
        [HttpGet]
        public int ProvjeraNaziv(string naziv)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(db.esp_GetDobavljacIDByNaziv(naziv).FirstOrDefault());
                return Id;
            }
            catch (Exception)
            {
                return Id;
            }
        }

        

        [Route("api/Dobavljaci/ProvjeraZiroRacun/{naziv}")]
        [HttpGet]
        public int ProvjeraZiroRacun(string naziv)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(db.esp_GetDobavljacIDByZiroRacun(naziv).FirstOrDefault());
                return Id;
            }
            catch (Exception)
            {
                return Id;
            }
        }

        [HttpGet]
        [Route("api/Dobavljaci/SearchDobavljaci/{name?}")]
        public List<Dobavljaci> SearchDobavljaci(string name = "")
        {
            List<Dobavljaci> dobavljaci = db.esp_Dobavljaci_SelectByNaziv(name).ToList();
            return dobavljaci;
        }

        // GET: api/Dobavljaci/5
        [ResponseType(typeof(Dobavljaci))]
        public IHttpActionResult GetDobavljaci(int id)
        {
            Dobavljaci dobavljaci = db.Dobavljaci.Find(id);
            if (dobavljaci == null)
            {
                return NotFound();
            }

            return Ok(dobavljaci);
        }

        // PUT: api/Dobavljaci/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDobavljaci(int id, Dobavljaci dobavljaci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dobavljaci.DobavljacID)
            {
                return BadRequest();
            }

            db.Entry(dobavljaci).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobavljaciExists(id))
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

        // POST: api/Dobavljaci
        [ResponseType(typeof(Dobavljaci))]
        public IHttpActionResult PostDobavljaci(Dobavljaci dobavljaci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_Dobavljaci_Insert(dobavljaci.Naziv, dobavljaci.KontaktOsoba, dobavljaci.Mail, dobavljaci.Telefon,
                dobavljaci.Fax, dobavljaci.Adresa, dobavljaci.Web, dobavljaci.Statusa, dobavljaci.ZiroRacun, dobavljaci.Napomena);

            return CreatedAtRoute("DefaultApi", new { id = dobavljaci.DobavljacID }, dobavljaci);
        }

        // DELETE: api/Dobavljaci/5
        [ResponseType(typeof(Dobavljaci))]
        public IHttpActionResult DeleteDobavljaci(int id)
        {
            Dobavljaci dobavljaci = db.Dobavljaci.Find(id);
            if (dobavljaci == null)
            {
                return NotFound();
            }

            db.Dobavljaci.Remove(dobavljaci);
            db.SaveChanges();

            return Ok(dobavljaci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DobavljaciExists(int id)
        {
            return db.Dobavljaci.Count(e => e.DobavljacID == id) > 0;
        }
    }
}