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
using eProdajaNamjestaja_API.Util;

namespace eProdajaNamjestaja_API.Controllers
{
    public class ProizvodiController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/Proizvodis
        [Route("api/Proizvodi")]
        [HttpGet]
        public IQueryable<Proizvodi> GetProizvodi()
        {
            return db.Proizvodi;
        }

        [Route("api/Proizvodi/SviProizvodi")]
        [HttpGet]
        public List<Proizvodi> SviProizvodi()
        {
            List<Proizvodi> data = db.esp_Proizvodi_Select().ToList();
            return data;
        }

        [Route("api/Proizvodi/Provjera/{sifra}")]
        [HttpGet]
        public int Provjera(string sifra)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(db.esp_GetPoizvodIDBySifra(sifra).FirstOrDefault());
                return Id;
            }
            catch (Exception)
            {
                return Id;
            }
        }

        [Route("api/Proizvodi/ProvjeraNaziv/{naziv}")]
        [HttpGet]
        public int ProvjeraNaziv(string naziv)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(db.esp_GetPoizvodIDByNaziv(naziv).FirstOrDefault());
                return Id;
            }
            catch (Exception)
            {
                return Id;
            }
        }



        // GET: api/Proizvodis/5
        [ResponseType(typeof(esp_Proizvodi_SelectById_Result))]

        [Route("api/Proizvodi/{id}")]
        [HttpGet]
        public IHttpActionResult GetProizvod(int id)
            {
            esp_Proizvodi_SelectById_Result proizvodi = db.esp_Proizvodi_SelectById(id).FirstOrDefault();
            if (proizvodi == null)
            {
                return NotFound();
            }

            return Ok(proizvodi);
        }

        [HttpGet]
        [Route("api/Proizvodi/SearchProizvodiByVrstaModelTip/{vrsta}/{model}/{tip}")]
        public List<esp_SelectProizvodiByVrstaModelTip_Result> SearchProizvodiByVrstaModelTip(string vrsta , string model ,string tip)
        {
            return db.esp_SelectProizvodiByVrstaModelTip(vrsta,model,tip).ToList();
            
        }

        [HttpGet]
        [Route("api/Proizvodi/RecommendProduct/{productID}")]
        public List<esp_Proizvodi_SelectById_Result> RecommendProduct(int productID)
        {
            Preporuka p = new Preporuka();
            return p.GetSlicneProizvode(productID);
        }

        [HttpGet]
        [Route("api/Proizvodi/SearchProizvodiByVrsta/{typeId}")]
        public List<esp_Proizvodi_SelectByVrsta_Result> SearchProizvodiByVrsta(int typeId)
        {
            return db.esp_Proizvodi_SelectByVrsta(typeId).ToList();
        }
        // PUT: api/Proizvodis/5
        [ResponseType(typeof(void))]
        [HttpPut]

        [Route("api/Proizvodi/{id}")]
        public IHttpActionResult PutProizvodi(int id, Proizvodi proizvodi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvodi.ProizvodID)
            {
                return BadRequest();
            }

            db.esp_Proizvodi_Update(id, proizvodi.Naziv, proizvodi.Sifra, proizvodi.Cijena, proizvodi.VrstaProizvoda,
                                     proizvodi.Slika, proizvodi.SlikaThumb,proizvodi.TipID,proizvodi.ModelID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Proizvodis
        [ResponseType(typeof(Proizvodi))]
        [HttpPost]
       [Route("api/Proizvodi")]
        public IHttpActionResult PostProizvodi(Proizvodi proizvodi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.esp_Proizvodi_Insert(proizvodi.Naziv, proizvodi.Sifra, proizvodi.Cijena, proizvodi.VrstaProizvoda, proizvodi.TipID, proizvodi.ModelID, proizvodi.Slika, proizvodi.SlikaThumb);



            return CreatedAtRoute("DefaultApi", new { id = proizvodi.ProizvodID }, proizvodi);
        }

        // DELETE: api/Proizvodis/5
        [ResponseType(typeof(Proizvodi))]
        public IHttpActionResult DeleteProizvodi(int id)
        {
            Proizvodi proizvodi = db.Proizvodi.Find(id);
            if (proizvodi == null)
            {
                return NotFound();
            }

            db.Proizvodi.Remove(proizvodi);
            db.SaveChanges();

            return Ok(proizvodi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodiExists(int id)
        {
            return db.Proizvodi.Count(e => e.ProizvodID == id) > 0;
        }

        [HttpGet]
        [Route("api/Proizvodi/OcjenaProizvoda/{proizvodId}/{kupacId}/{ocjena}")]
        public void OcjenaProizvoda(int proizvodId, int kupacId, int ocjena)
        {
            Ocjene o = new Ocjene();
            o.ProizvodID = proizvodId;
            o.KupacID = kupacId;
            o.Ocjena = ocjena;
            o.Datum = DateTime.Now;
            db.Ocjene.Add(o);
            db.SaveChanges();
        }
    }
}