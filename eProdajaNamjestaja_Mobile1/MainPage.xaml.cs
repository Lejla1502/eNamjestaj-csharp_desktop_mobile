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
using eProdajaNamjestaja_Mobile1.Products;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace eProdajaNamjestaja_Mobile1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame != null)
                if (rootFrame.CanGoBack)
                {
                    Frame.GoBack();
                    e.Handled = true;
                }
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            if (Global.prijavljeniKupac != null)
            {
                PrijavaButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ProfilButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                HistorijaButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                IzmjenaButton.Visibility= Windows.UI.Xaml.Visibility.Visible;
                OdjavaButton.Visibility= Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void PrijavaButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void ProizvodiButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Products.Search));
        }

        private void ProfilButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Profil.ActiveOrders));
        }


        

        private void IzmjenaButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UrediProfil));
        }

        private void HistorijaButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Products.HistorijaNarudzbi));
        }

        private void OdjavaButton_Click(object sender, RoutedEventArgs e)
        {
            Global.prijavljeniKupac = null;
            PrijavaButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ProfilButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            HistorijaButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            IzmjenaButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            OdjavaButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
