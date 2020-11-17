using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Model
{
    public class VrsteProizvoda
    {
        
        public VrsteProizvoda(int v1, string v2)
        {
            this.VrstaProizvoda = v1;
            this.Naziv = v2;
        }

        public int VrstaProizvoda { get; set; }
        public string Naziv { get; set; }

    }
}
