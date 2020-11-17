using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Model
{
    public class NarudzbaStavke
    {
        
            public int NarudzbaStavkeID { get; set; }
            public int Kolicina { get; set; }
            public int ProizvodID { get; set; }
            public int NarudzbaID { get; set; }

            public virtual Proizvodi Proizvodi { get; set; }
        
    }
}
