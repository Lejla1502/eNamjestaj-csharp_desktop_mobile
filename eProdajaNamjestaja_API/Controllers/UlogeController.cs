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
    public class UlogeController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Uloge
        public IQueryable<Uloge> GetUloge()
        {
            return db.Uloge.OrderBy(x=>x.Naziv);
        }

        [HttpGet]
        [Route("api/Uloge/UlogeByKorisnikID/{id}")]
        public List<Uloge> UlogeByKorisnikID(int id)
        { return db.esp_Uloge_SelectByKorisnikId(id).ToList(); }


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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}