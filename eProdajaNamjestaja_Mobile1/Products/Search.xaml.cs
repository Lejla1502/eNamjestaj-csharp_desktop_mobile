using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using eProdajaNamjestaja_PCL1.Model;
using eProdajaNamjestaja_PCL1.Util;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace eProdajaNamjestaja_Mobile1.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        WeAPIHelper vrsteProizvodaService = new WeAPIHelper("http://localhost:5966/", "api/VrsteProizvoda");
        WeAPIHelper proizvodiService = new WeAPIHelper("http://localhost:5966/", "api/Proizvodi");

        public Search()
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
            BindVrsteProizvoda();
            BindProizvodi();
        }

       

        private void BindProizvodi()
        {
            int vrstaID = 0;
            if (VrsteProizvodaList.SelectedIndex != -1)
            {
                vrstaID = ((VrsteProizvoda)VrsteProizvodaList.SelectedValue).VrstaProizvoda;
            }
            HttpResponseMessage response = proizvodiService.GetActionResponse("SearchProizvodiByVrsta", vrstaID.ToString());
            if (response.IsSuccessStatusCode)
            {
                ProizvodiList.ItemsSource = response.Content.ReadAsAsync<List<Proizvodi>>().Result;
            }
        }

        private async void BindVrsteProizvoda()
        {
            HttpResponseMessage response = vrsteProizvodaService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<VrsteProizvoda> listaVrsta = response.Content.ReadAsAsync<List<VrsteProizvoda>>().Result;
                listaVrsta.Insert(0, new VrsteProizvoda(0, "Odaberite vrstu"));
                VrsteProizvodaList.ItemsSource = listaVrsta;
                VrsteProizvodaList.DisplayMemberPath = "Naziv";

            }
            else
            {
                MessageDialog mg = new MessageDialog("Došlo je do greške: " + response.ReasonPhrase);
                await mg.ShowAsync();
            }
        }

        private void ProizvodiList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(OcjenjivanjeIPreporuka), ((Proizvodi)e.ClickedItem).ProizvodID);
        }

        private void VrsteProizvodaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindProizvodi();
        }
    }
}
