using System;
using System.Collections.Generic;
using System.IO;
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

namespace LemonIcon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.DynamicDirectory+"icon.png", FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)Drawer.ActualWidth,
                        (int)Drawer.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
            bmp.Render(Drawer);
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        }
    }
}
