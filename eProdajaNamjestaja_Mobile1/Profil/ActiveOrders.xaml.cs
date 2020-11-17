using eProdajaNamjestaja_PCL1.Model;
using eProdajaNamjestaja_PCL1.Util;
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
using System.Net.Http;
using Windows.UI.Popups;
using eProdajaNamjestaja_Mobile1.Products;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace eProdajaNamjestaja_Mobile1.Profil
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActiveOrders : Page
    {
        WeAPIHelper narudzbeService = new WeAPIHelper("http://localhost:5966/", "api/Narudzbe");
        public int proizvodID = 0;
        public ActiveOrders()
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
            proizvodID = Convert.ToInt32(e.Parameter);
            BindData();
        }

        private void BindData()
        {
            if (Global.aktivnaNarudzba != null)
            {
                narudzbaList.ItemsSource = Global.aktivnaNarudzba.NarudzbaStavke;
                zakljuciButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                
                decimal iznos = 0;
                foreach (NarudzbaStavke item in Global.aktivnaNarudzba.NarudzbaStavke)
                {
                    iznos += item.Proizvodi.Cijena * item.Kolicina;
                }
                iznosLabel.Text = "Ukupan iznos: " + Math.Round(iznos, 2) + " KM";
            }
            else
                narudzbaNull.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private async void zakljuciButton_Click(object sender, RoutedEventArgs e)
        {
            
            HttpResponseMessage response = narudzbeService.PostResponse(Global.aktivnaNarudzba);
            if (response.IsSuccessStatusCode)
            {
                MessageDialog message =new MessageDialog( "Uspjesno ste zaključili narudžbu!");
                await message.ShowAsync();
                Global.aktivnaNarudzba = null;
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                MessageDialog message =new MessageDialog( "Narudzba nije dodata -> " + response.ReasonPhrase);
                await message.ShowAsync();
            }

            
        }
    }
}
