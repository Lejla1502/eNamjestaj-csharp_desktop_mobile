using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_PCL1.Model
{
    public class Ocjene
    {
        public int OcjeneID { get; set; }
        public System.DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public int ProizvodID { get; set; }
        public int KupacID { get; set; }
    }
}
