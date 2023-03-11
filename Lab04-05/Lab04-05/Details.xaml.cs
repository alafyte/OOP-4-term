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
using System.Windows.Shapes;

namespace Lab04_05
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details(Product product)
        {
            InitializeComponent();
            Cursor = CursorCollection.GetCursor();
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var source = new BitmapImage(new Uri(projectPath + "/images/" + product.PImage));
            ProductImage.Source = source;
            switch (Settings.Lang)
            {
                case Settings.Languages.RU:
                    ProductName.Text = product.PNameRus;
                    break;
                case Settings.Languages.EN:
                    ProductName.Text = product.PNameEn;
                    break;
            }
            Price.Text = product.Price.ToString() + "$";
            switch (Settings.Lang)
            {
                case Settings.Languages.RU:
                    ProductDescription.Text = product.PDescriptionRus;
                    break;
                case Settings.Languages.EN:
                    ProductDescription.Text = product.PDescriptionEn;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
