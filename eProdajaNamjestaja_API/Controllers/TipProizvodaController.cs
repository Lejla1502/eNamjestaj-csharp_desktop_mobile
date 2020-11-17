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
    public class TipProizvodaController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/TipProizvodas
        public IQueryable<TipProizvoda> GetTipProizvoda()
        {
            return db.TipProizvoda;
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipProizvodaExists(int id)
        {
            return db.TipProizvoda.Count(e => e.TipID == id) > 0;
        }
    }
}