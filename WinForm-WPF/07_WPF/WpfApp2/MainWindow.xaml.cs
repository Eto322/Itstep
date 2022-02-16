using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        double scaleX = 1;
        double scaleY = 1;

        string filePath;
     
       

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private string get_codec()//спасибо Stack Overflow
        {
            var codecs = ImageCodecInfo.GetImageEncoders();
            var codecFilter = "Image Files|";
            foreach (var codec in codecs)
            {
                codecFilter += codec.FilenameExtension + ";";
            }
            return codecFilter;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = get_codec();
            bool? is_ok = open.ShowDialog();
            

            if (is_ok==true)
            {
                PathBox.Text = open.FileName;
                filePath= open.FileName;
                
                ImageBox.Source=new BitmapImage(new Uri(PathBox.Text));

            }
            
            
           
           
        }

        private void HeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleX = e.NewValue;
            if (!string.IsNullOrEmpty(PathBox.Text))//вот тут при запуске , Filepath=null и будет expection,поэтому такой костыль 
            {
                var image = new BitmapImage(new Uri(filePath));
                var image_Transformed = new TransformedBitmap(image, new ScaleTransform(scaleX, scaleY));
                ImageBox.Height = image_Transformed.Height;
                ImageBox.Width = image_Transformed.Width;

                ImageBox.Source = image_Transformed;
            }
           
           
            
            /*var image = new BitmapImage(new Uri(filePath));
            
            ImageBox.Source = image_Transformed;*/
            

           


        }

        private void WeidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleY = e.NewValue;
            if (!string.IsNullOrEmpty(PathBox.Text))
            {
                var image = new BitmapImage(new Uri(filePath));
                var image_Transformed = new TransformedBitmap(image, new ScaleTransform(scaleX, scaleY));
                ImageBox.Height = image_Transformed.Height;
                ImageBox.Width = image_Transformed.Width;

                ImageBox.Source = image_Transformed;
            }


        }
    }
}
