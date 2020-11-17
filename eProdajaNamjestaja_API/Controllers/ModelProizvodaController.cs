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
    public class ModelProizvodaController : ApiController
    {
        private eNamjestajEntities db = new eNamjestajEntities();

        // GET: api/ModelProizvoda
        public IQueryable<ModelProizvoda> GetModelProizvoda()
        {
            return db.ModelProizvoda;
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelProizvodaExists(int id)
        {
            return db.ModelProizvoda.Count(e => e.ModelID == id) > 0;
        }
    }
}