using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Model
{
    public class Proizvodi
    {
        public int ProizvodID { get; set; }
        public int VrstaProizvodaID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Model { get; set; }
        public string Tip{ get; set; }
        public decimal Cijena { get; set; }
        public byte[] SlikaThumb { get; set; }
        
        public string VrstaProizvodaNaziv { get; set; }
        public bool Statuss { get; set; }
        
        public Nullable<decimal> ProsjecnaOcjena { get; set; }

    }
}
