    using eProdajaNamjestaja_PCL1.Model;
    using eProdajaNamjestaja_PCL1.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace eProdajaNamjestaja_Mobile1.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OcjenjivanjeIPreporuka : Page
    {
        WeAPIHelper proizvodiService = new WeAPIHelper("http://localhost:5966/", "api/Proizvodi");
        WeAPIHelper skladistaProizvodiService = new WeAPIHelper("http://localhost:5966/", "api/SkladistaProizvod");
        WeAPIHelper skladistaService = new WeAPIHelper("http://localhost:5966/", "api/Skladista");

        WeAPIHelper ocjeneService = new WeAPIHelper("http://localhost:5966/", "api/Ocjene");
        public Proizvodi proizvod { get; set; }
        
        public OcjenjivanjeIPreporuka()
        {
            this.InitializeComponent();
        }


       
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            int proizvodID =  Convert.ToInt32(e.Parameter);

            HttpResponseMessage response = proizvodiService.GetResponse(e.Parameter.ToString());

            if (response.IsSuccessStatusCode)
            {
                proizvod = response.Content.ReadAsAsync<Proizvodi>().Result;

                
               vrstaLabel.Text = "Vrsta: "+proizvod.VrstaProizvodaNaziv;
                nazivLabel.Text = proizvod.Naziv;
                sifraLabel.Text = "Šifra: "+proizvod.Sifra;
                cijenaLabel.Text = "Cijena: "+proizvod.Cijena.ToString();
                modelProizvodaLabel.Text = "Model: "+proizvod.Model;
                tipProizvodaLabel.Text = "Materijal: "+proizvod.Tip;


                if (proizvod.ProsjecnaOcjena != null)
                    prosjekLabel.Text = "Ocjena: " + Math.Round((decimal)proizvod.ProsjecnaOcjena, 2).ToString();

                if (proizvod.SlikaThumb != null)
                {
                    MemoryStream ms = new MemoryStream(proizvod.SlikaThumb);
                    BitmapImage image = new BitmapImage();

                    await image.SetSourceAsync(ms.AsRandomAccessStream());

                    proizvodImage.Source = image;
                }
                if (Global.prijavljeniKupac != null)
                {
                    KolicinaInput.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    KupiButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }


                HttpResponseMessage recommendResponse = proizvodiService.GetActionResponse("RecommendProduct", proizvodID.ToString());
                if (recommendResponse.IsSuccessStatusCode)
                {
                    List<Proizvodi> recommendProduct = recommendResponse.Content.ReadAsAsync<List<Proizvodi>>().Result;
                    if (recommendProduct.Count()>0)
                        slicniProizvodiLabel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    PreporuceniProizvodiList.ItemsSource = recommendProduct;
                }
            }
        }
        

        private async void KupiButton_Click(object sender, RoutedEventArgs e)
        {
             int i = 0;
            if (Global.aktivnaNarudzba == null)
            {
                Global.aktivnaNarudzba = new Narudzbe();
                Global.aktivnaNarudzba.KupacID = Global.prijavljeniKupac.KupacID;
                
            }
            bool ProizvodPostoji = false;
            bool viseOd2000 = false;

            if (KolicinaInput.Text == "")
            {
                MessageDialog r = new MessageDialog("Unesite kolicinu!");
                await r.ShowAsync();
            }
            else if (Convert.ToInt32(KolicinaInput.Text) <= 0)
            {
                MessageDialog m = new MessageDialog("Unesite ispravnu količinu!");
                await m.ShowAsync();
            }
            else if (Convert.ToInt32(KolicinaInput.Text) > 2000)
            {
                MessageDialog d = new MessageDialog("Ne možete naručiti više od 2000 komada jednog proizvoda!");
                await d.ShowAsync();
            }
            else
            {
                foreach (NarudzbaStavke item in Global.aktivnaNarudzba.NarudzbaStavke)
                {
                    if (proizvod.ProizvodID == item.ProizvodID)
                    {
                        int kol = item.Kolicina;
                        if ((kol += Convert.ToInt32(KolicinaInput.Text)) > 2000)
                        {
                            viseOd2000 = true;
                            break; 
                        }
                        else
                        {
                            item.Kolicina += Convert.ToInt32(KolicinaInput.Text);
                            ProizvodPostoji = true;
                            break;
                        }
                    }

                }
                if (!viseOd2000)
                {
                    string message = "Uspjesno ste dodali proizvod u korpu";

                    bool kolicinaNaSlkadistu=Provjera(proizvod.ProizvodID);

                    if (!kolicinaNaSlkadistu)
                    {
                        MessageDialog ms = new MessageDialog("Proizvoda na skladištu nema! ");
                        await ms.ShowAsync();
                        KolicinaInput.Text = "";
                    }
                    else
                    {
                        if (ProizvodPostoji)
                        {
                            message = "Uspjesno ste izmijenili kolicinu proizvoda u korpi";
                            KolicinaInput.Text = "";
                        }

                        else
                        {
                            NarudzbaStavke s = new NarudzbaStavke();
                            s.ProizvodID = proizvod.ProizvodID;
                            s.Proizvodi = proizvod;
                            s.Kolicina = Convert.ToInt32(KolicinaInput.Text);
                            Global.aktivnaNarudzba.NarudzbaStavke.Add(s);
                            KolicinaInput.Text = "";

                        }
                        MessageDialog msg = new MessageDialog(message);
                        await msg.ShowAsync();
                        NarudzbaInfoLabel.Text = "Broj narucenih proizvoda:" + Global.aktivnaNarudzba.NarudzbaStavke.Count;
                        zakljuciButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    }
                   
                }
                else
                {
                    MessageDialog ms = new MessageDialog("Ne možete naručiti više od 2000 komada jednog proizvoda!");
                    await ms.ShowAsync();
                    KolicinaInput.Text = "";
                }
            }
        }

        private bool Provjera(int proizvodID)
        {
            bool proizvodPostojiNaSkladistu = true;
            HttpResponseMessage response2 = skladistaService.GetResponse();
            if (response2.IsSuccessStatusCode)
            {
                List<Skladista> skl = response2.Content.ReadAsAsync<List<Skladista>>().Result;
                foreach (var s in skl)
                {
                    HttpResponseMessage response1 = skladistaProizvodiService.GetActionResponse3("ProvjeraStanja", proizvodID,s.SkladistaID);
                    if (response1.IsSuccessStatusCode)
                    {
                        int? stanje = response1.Content.ReadAsAsync<int?>().Result;
                        if (stanje == null)
                            proizvodPostojiNaSkladistu = false;
                        else
                            proizvodPostojiNaSkladistu = true;

                    }
                }
            }

            return proizvodPostojiNaSkladistu;
        }

        private  void zakljuciButton_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(Profil.ActiveOrders));
        }

        private async void star1_Click(object sender, RoutedEventArgs e)
        {
            if (Global.prijavljeniKupac == null)
            {
                MessageDialog msg = new MessageDialog("Morate se prijaviti da biste mogli ocijeniti proizvod");
                await msg.ShowAsync();
                return;
            }
            HttpResponseMessage response = ocjeneService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Ocjene> listOcjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                foreach (var item in listOcjene)
                {
                    if (item.ProizvodID == proizvod.ProizvodID && item.KupacID == Global.prijavljeniKupac.KupacID)
                    {
                        MessageDialog msg = new MessageDialog("Već ste ocijenili ovaj proizvod");
                        await msg.ShowAsync();
                        return;
                    }
                }


            }

            star1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star1Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (proizvodiService.GetActionResponseResponse("OcjenaProizvoda", proizvod.ProizvodID.ToString(), Global.prijavljeniKupac.KupacID.ToString(), "1").IsSuccessStatusCode)
            {
                MessageDialog ms = new MessageDialog("Uspjesno ste ocijenili proizvod!");
                await ms.ShowAsync();

                HttpResponseMessage recommendResponse = proizvodiService.GetActionResponse("RecommendProduct", proizvod.ProizvodID.ToString());
                if (recommendResponse.IsSuccessStatusCode)
                {
                    List<Proizvodi> recommendProduct = recommendResponse.Content.ReadAsAsync<List<Proizvodi>>().Result;
                    if (recommendProduct.Count() > 0)
                        slicniProizvodiLabel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    PreporuceniProizvodiList.ItemsSource = recommendProduct;
                }
            }
            else
            {
                MessageDialog ms = new MessageDialog("Niste ocijenili proizvod!");
                await ms.ShowAsync();
            }

            
        }


        private async void star2_Click(object sender, RoutedEventArgs e)
        {
            if (Global.prijavljeniKupac == null)
            {
                MessageDialog msg = new MessageDialog("Morate se prijaviti da biste mogli ocijeniti proizvod");
                await msg.ShowAsync();
                return;
            }
            HttpResponseMessage response = ocjeneService.GetResponse();
            
                if (response.IsSuccessStatusCode)
                {
                    List<Ocjene> listOcjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                    foreach (var item in listOcjene)
                    {
                        if (item.ProizvodID == proizvod.ProizvodID && item.KupacID == Global.prijavljeniKupac.KupacID)
                        {
                            MessageDialog msg = new MessageDialog("Već ste ocijenili ovaj proizvod");
                            await msg.ShowAsync();
                            return;
                        }
                    }
                }
            

            star1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star1Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star2Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (proizvodiService.GetActionResponseResponse("OcjenaProizvoda", proizvod.ProizvodID.ToString(), Global.prijavljeniKupac.KupacID.ToString(), "2").IsSuccessStatusCode)
            {
                MessageDialog ms = new MessageDialog("Uspjesno ste ocijenili proizvod!");
                await ms.ShowAsync();
            }
            else
            {
                MessageDialog ms = new MessageDialog("Niste ocijenili proizvod!");
                await ms.ShowAsync();
            }
        }

        private async void star3_Click(object sender, RoutedEventArgs e)
        {
            if (Global.prijavljeniKupac == null)
            {
                MessageDialog msg = new MessageDialog("Morate se prijaviti da biste mogli ocijeniti proizvod");
                await msg.ShowAsync();
                return;
            }
            HttpResponseMessage response = ocjeneService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Ocjene> listOcjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                foreach (var item in listOcjene)
                {
                    if (item.ProizvodID == proizvod.ProizvodID && item.KupacID == Global.prijavljeniKupac.KupacID)
                    {
                        MessageDialog msg = new MessageDialog("Već ste ocijenili ovaj proizvod");
                        await msg.ShowAsync();
                        return;
                    }
                }

            }

            star1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star1Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star2Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star3Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (proizvodiService.GetActionResponseResponse("OcjenaProizvoda", proizvod.ProizvodID.ToString(), Global.prijavljeniKupac.KupacID.ToString(), "3").IsSuccessStatusCode)
            {
                MessageDialog ms = new MessageDialog("Uspjesno ste ocijenili proizvod!");
                await ms.ShowAsync();
            }
            else
            {
                MessageDialog ms = new MessageDialog("Niste ocijenili proizvod!");
                await ms.ShowAsync();
            }
        }

        private async void star4_Click(object sender, RoutedEventArgs e)
        {
            if (Global.prijavljeniKupac == null)
            {
                MessageDialog msg = new MessageDialog("Morate se prijaviti da biste mogli ocijeniti proizvod");
                await msg.ShowAsync();
                return;
            }

            HttpResponseMessage response = ocjeneService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Ocjene> listOcjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                foreach (var item in listOcjene)
                {
                    if (item.ProizvodID == proizvod.ProizvodID && item.KupacID == Global.prijavljeniKupac.KupacID)
                    {
                        MessageDialog msg = new MessageDialog("Već ste ocijenili ovaj proizvod");
                        await msg.ShowAsync();
                        return;
                    }
                }

            }

            star1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star1Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star2Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star3Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star4Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (proizvodiService.GetActionResponseResponse("OcjenaProizvoda", proizvod.ProizvodID.ToString(), Global.prijavljeniKupac.KupacID.ToString(), "4").IsSuccessStatusCode)
            {
                MessageDialog ms = new MessageDialog("Uspjesno ste ocijenili proizvod!");
                await ms.ShowAsync();
            }
            else
            {
                MessageDialog ms = new MessageDialog("Niste ocijenili proizvod!");
                await ms.ShowAsync();
            }
        }

        private async void star5_Click(object sender, RoutedEventArgs e)
        {
            if (Global.prijavljeniKupac == null)
            {
                MessageDialog msg = new MessageDialog("Morate se prijaviti da biste mogli ocijeniti proizvod");
                await msg.ShowAsync();
                return;
            }

            HttpResponseMessage response = ocjeneService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Ocjene> listOcjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                foreach (var item in listOcjene)
                {
                    if (item.ProizvodID == proizvod.ProizvodID && item.KupacID == Global.prijavljeniKupac.KupacID)
                    {
                        MessageDialog msg = new MessageDialog("Već ste ocijenili ovaj proizvod");
                        await msg.ShowAsync();
                        return;
                    }
                }

            }

            star1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star1Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star2Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star3Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star4Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            star5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            star5Full.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (proizvodiService.GetActionResponseResponse("OcjenaProizvoda", proizvod.ProizvodID.ToString(), Global.prijavljeniKupac.KupacID.ToString(), "5").IsSuccessStatusCode)
            {
                MessageDialog ms = new MessageDialog("Uspjesno ste ocijenili proizvod!");
                await ms.ShowAsync();
            }
            else
            {
                MessageDialog ms = new MessageDialog("Niste ocijenili proizvod!");
                await ms.ShowAsync();
            }
        }


        private void KolicinaInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Contains('.'))
            {
                txt.Text = txt.Text.Replace(".", "");
                txt.SelectionStart = txt.Text.Length;
            }
        }

        private void PreporuceniProizvodiList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(OcjenjivanjeIPreporuka), ((Proizvodi)e.ClickedItem).ProizvodID);
        }
    }
}

    