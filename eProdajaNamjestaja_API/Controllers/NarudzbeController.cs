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
    public class NarudzbeController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Narudzbe
        public IQueryable<Narudzbe> GetNarudzbe()
        {
            return db.Narudzbe;
        }

        // GET: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult GetNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            return Ok(narudzbe);
        }

        [HttpGet]
        [Route("api/Narudzbe/GetBrojAktivnihNarudzbi")]
        public int GetBrojAktivnihNarudzbi()
        {
            return db.Narudzbe.Where(x => x.Statuss == true).Count();
        }

        [HttpGet]
        [Route("api/Narudzbe/GetAktivneNarudzbe")]
        public List<esp_Narudzbe_SelectAktivne_Result> GetAktivneNarudzbe()
        {
            return db.esp_Narudzbe_SelectAktivne().ToList();
        }
        

        [HttpGet]
        [Route("api/Narudzbe/GetNarudzbeByKupacId/{kupacId}")]
        public List<esp_Narudzbe_SelectByKupacId_Result> GetAktivneNarudzbeByKupacId(int kupacId)
        {
            return db.esp_Narudzbe_SelectByKupacId(kupacId).ToList();
        }

        [HttpGet]
        [Route("api/Narudzbe/GetStavkeNarudzbe/{id}")]
        public List<esp_NarudzbeStavke_SelectByNarudzbaID_Result> GetStavkeNarudzbe(int id)
        {
            return db.esp_NarudzbeStavke_SelectByNarudzbaID(id).ToList();
        }

        [HttpPost]
        [Route("api/Narudzbe/ProcesirajNarudzbu")]
        public void ProcesirajNarudzbu(Izlazi izlaz)
        {




            db.esp_Izlazi_InsertByNarudzbaID( izlaz.NarudzbaID, izlaz.IznosSaPDV,
                izlaz.IznosBezPDV, izlaz.SkladisteID, izlaz.KorisnikID);
        }

        

        [HttpGet]
        [Route("api/Narudzbe/HistorijaNarudzbiByKupacID/{kupacID}")]
        public List<esp_HistorijaNarudzbiByKupacID_Result> HistorijaNarudzbiByKupacID(int kupacID)
        {
            return db.esp_HistorijaNarudzbiByKupacID(kupacID).ToList();
        }

        // PUT: api/Narudzbe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzbe(int id, Narudzbe narudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzbe.NarudzbaID)
            {
                return BadRequest();
            }

            db.Entry(narudzbe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbeExists(id))
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

        // POST: api/Narudzbe
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult PostNarudzbe(Narudzbe narudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            narudzbe.NarudzbaID = Convert.ToInt32(db.esp_Narudzbe_Insert(narudzbe.KupacID).FirstOrDefault());
            int temp = narudzbe.NarudzbaID;
            foreach (NarudzbaStavke item in narudzbe.NarudzbaStavke)
            {
                db.esp_NarudzbaStavke_Insert(narudzbe.NarudzbaID, item.ProizvodID, item.Kolicina);
            }
            return CreatedAtRoute("DefaultApi", new { id = narudzbe.NarudzbaID }, narudzbe);
        }

        // DELETE: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult DeleteNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            db.Narudzbe.Remove(narudzbe);
            db.SaveChanges();

            return Ok(narudzbe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbeExists(int id)
        {
            return db.Narudzbe.Count(e => e.NarudzbaID == id) > 0;
        }
    }
}