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
    public sealed partial class HistorijaNarudzbi : Page
    {
        WeAPIHelper narudzbaService = new WeAPIHelper("http://localhost:5966/", "api/Narudzbe");

        public HistorijaNarudzbi()
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

            BindNarudzbe();
        }

        private async void BindNarudzbe()
        {
            HttpResponseMessage response = narudzbaService.GetActionDbResponse("HistorijaNarudzbiByKupacID", Global.prijavljeniKupac.KupacID);

            if (response.IsSuccessStatusCode)
            {
                List<Narudzbe> narudzbe = response.Content.ReadAsAsync<List<Narudzbe>>().Result;
                if (narudzbe != null)
                    historijaNarudzbiList.ItemsSource = narudzbe;

            }
            else
            {
                MessageDialog msg = new MessageDialog("Status code: " + response.StatusCode + " - " + response.ReasonPhrase);
                await msg.ShowAsync();
            }

        }
    }
}
