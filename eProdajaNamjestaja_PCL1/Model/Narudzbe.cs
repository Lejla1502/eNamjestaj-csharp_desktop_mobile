using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Model
{
    public class Narudzbe
    {
        public Narudzbe()
        {
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
        }

        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public System.DateTime Datum { get; set; }
        public bool Statuss { get; set; }
        public bool Otkazano { get; set; }
        public int KupacID { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Iznos { get; set; }
        
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}
