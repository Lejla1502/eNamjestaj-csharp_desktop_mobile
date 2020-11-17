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

namespace eProdajaNamjestaja_Mobile1
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        WeAPIHelper kupciService = new WeAPIHelper("http://localhost:5966/", "api/Kupci");
        public Registration()
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
        }


        private async void registracijaButton_Click(object sender, RoutedEventArgs e)
        {
            string validacija = Validacija();
            if (validacija != "")
            {
                MessageDialog v = new MessageDialog(validacija);
                await v.ShowAsync();
                return;

            }
            Kupci kupac = new Kupci();
            kupac.Ime = imeInput.Text;
            kupac.Prezime = prezimeInput.Text;
            kupac.Mail = emailInput.Text;
            kupac.KorisnickoIme = korisnickoImeInput.Text;
            kupac.LozinkaSalt = UIHelper.GenerateSalt();
            kupac.LozinkaHash = UIHelper.GenerateHash(lozinkaInput.Password, kupac.LozinkaSalt);
            kupac.Statuss = true;
            kupac.DatumRegistracije = DateTime.Now;

            HttpResponseMessage response1 = kupciService.GetActionResponse("Provjera", korisnickoImeInput.Text);
            if (response1.IsSuccessStatusCode)
            {
                MessageDialog mg = new MessageDialog("Username već postoji!!");
                await mg.ShowAsync();
            }
            else
            {

                HttpResponseMessage response = kupciService.PostResponse(kupac);

                if (response.IsSuccessStatusCode)
                {
                    MessageDialog mg = new MessageDialog("Registracija uspješna");
                    await mg.ShowAsync();
                    Frame.Navigate(typeof(Login));
                }
                else
                {
                    MessageDialog mg = new MessageDialog("Došlo je do greške: " + response.ReasonPhrase);
                    await mg.ShowAsync();
                }
            }
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

            if (korisnickoImeInput.Text == "")
                poruka += "Korisnicko ime je obavezno polje! \n";
            else if (korisnickoImeInput.Text.Length < 5)
                poruka += "Korisničko ime mora sadržavati najmanje 5 karaktera! \n";

            if (lozinkaInput.Password.Length == 0)
                poruka += "Lozinka je obavezno polje! \n";
            else if (lozinkaInput.Password.Length < 4)
                poruka += "Lozinka mora sadržavati najmanje 4 karaktera! \n";

            return poruka;
        }
    }

    }

