using eProdajaNamjestaja_PCL1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace eProdajaNamjestaja_Mobile1.Products
{
    public class ImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            MemoryStream ms = new MemoryStream(((Proizvodi)value).SlikaThumb);

            BitmapImage image = new BitmapImage();
            image.SetSourceAsync(ms.AsRandomAccessStream());

            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }   
    }
}
