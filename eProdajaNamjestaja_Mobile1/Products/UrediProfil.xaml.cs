
using eProdajaNamjestaja_PCL1.Model;
using eProdajaNamjestaja_PCL1.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace eProdajaNamjestaja_Mobile1.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UrediProfil : Page
    {
        WeAPIHelper service = new WeAPIHelper("http://localhost:5966/", "api/Kupci");
        Kupci k;
        public UrediProfil()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            int kupacID = Global.prijavljeniKupac.KupacID;
            HttpResponseMessage response = service.GetActionDbResponse("GetKupciById", kupacID);
            if (response.IsSuccessStatusCode)
            {
                k = response.Content.ReadAsAsync<Kupci>().Result;
                if (k != null)
                {
                    imeInput.Text = k.Ime;
                    prezimeInput.Text = k.Prezime;
                    korisnickoImeInput.Text = k.KorisnickoIme;
                    emailInput.Text = k.Mail;
                }
            }
        }

        private async void btn_SpasiPromjene_Click(object sender, RoutedEventArgs e)
        {
            string validacija = Validacija();
            if (validacija != "")
            {
                MessageDialog v = new MessageDialog(validacija);
                await v.ShowAsync();
                return;

            }

            Kupci k = new Kupci();
            k.KupacID = Global.prijavljeniKupac.KupacID;
            k.Ime = imeInput.Text;
            k.Prezime = prezimeInput.Text;
            k.Mail = emailInput.Text;
            k.KorisnickoIme = korisnickoImeInput.Text;
            k.LozinkaSalt = UIHelper.GenerateSalt();
            k.LozinkaHash = UIHelper.GenerateHash(lozinkaInput.Password, k.LozinkaSalt);
            k.DatumRegistracije = DateTime.Now;
            k.Statuss = true;

            string poruka = "";

            HttpResponseMessage response = service.PutResponse(k.KupacID, k);
            if (response.IsSuccessStatusCode)
            {
                poruka = "Uspješno ste uredili Vaše podatke.";
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                poruka = "Došlo je do greške. Molimo pokušajte ponovo.";
            }

            MessageDialog msg = new MessageDialog(poruka);
            await msg.ShowAsync();
        }


        public string Validacija()
        {
            string poruka = "";

            if (imeInput.Text == "")
                poruka += "Ime je obavezno polje! \n";

            else if (!Regex.IsMatch(imeInput.Text, @"^([ \u00c0-\u01ffa-zA-Z'\-])+$"))
                poruka += "Ime smije sadržavati samo slova! \n";

            if (prezimeInput.Text == "")
                poruka += "Prezime je obavezno polje! \n";

            else if (!Regex.IsMatch(prezimeInput.Text, @"^([ \u00c0-\u01ffa-zA-Z'\-])+$"))
                poruka += "Prezime smije sadržavati samo slova! \n";

            if (emailInput.Text == "")
                poruka += "E-mail je obavezno polje! \n";

            else if (!Regex.IsMatch(emailInput.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                poruka += "Pogrešan format e-maila! \n";

            if (korisnickoImeInput.Text.Length < 5)
                poruka += "Korisničko ime mora sadržavati najmanje 5 karaktera! \n";

            if (lozinkaInput.Password.Length < 4)
                poruka += "Lozinka mora sadržavati najmanje 4 karaktera! \n";

            return poruka;
        }
    }
}
