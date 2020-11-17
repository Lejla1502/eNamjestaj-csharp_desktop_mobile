using eProdajaNamjestaja_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_UI
{
    public class Global
    {
        
        public static Korisnici prijavljeniKorisnik { get; set; }
        public static Korisnici selektovaniKorisnik { get; set; }

        public static string GetMessage(string key)
        {
            ResourceManager rm = new ResourceManager("eProdajaNamjestaja_UI.Messages", Assembly.GetExecutingAssembly());
            return rm.GetString(key);
        }

        public static List<PomProizvod> proizvodiNabavke { get; set; }

        public class PomProizvod
        {
            public int Proizvod1ID { get; set; }
            public string Naziv { get; set; }

            public int Kolicina1 { get; set; }
            public decimal Cijena1 { get; set; }
        }
    }
}
