using System;
using System.Collections.Generic;
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

namespace Lab06
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string errorMessage)
        {
            InitializeComponent();
            Cursor = CursorCollection.GetCursor();
            switch (errorMessage)
            {
                case "WrongProductName":
                    MessageContainer.Text = Application.Current.Resources["ErrorProductName"].ToString();
                    break;
                case "WrongProductPrice":
                    MessageContainer.Text = Application.Current.Resources["ErrorProductPrice"].ToString();
                    break;
                case "WrongProductQuantity":
                    MessageContainer.Text = Application.Current.Resources["ErrorProductQuantity"].ToString();
                    break;
                case "WrongProductType":
                    MessageContainer.Text = Application.Current.Resources["ErrorProductType"].ToString();
                    break;
                case "WrongImageSource":
                    MessageContainer.Text = Application.Current.Resources["ErrorProductImage"].ToString();
                    break;
                case "Success":
                    MessageContainer.Text = Application.Current.Resources["Success"].ToString();
                    break;
            }
        }

        private void OKButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
