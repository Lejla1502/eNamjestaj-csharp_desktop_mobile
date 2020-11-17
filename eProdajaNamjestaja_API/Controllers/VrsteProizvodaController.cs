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
    public class VrsteProizvodaController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/VrsteProizvoda
        public IQueryable<VrsteProizvoda> GetVrsteProizvoda()
        {
            return db.VrsteProizvoda.OrderBy(x=>x.Naziv);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VrsteProizvodaExists(int id)
        {
            return db.VrsteProizvoda.Count(e => e.VrstaProizvoda == id) > 0;
        }
    }
}