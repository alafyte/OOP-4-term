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

namespace Lab04_05
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
                case "WrongName":
                    MessageContainer.Text = Application.Current.Resources["ErrorName"].ToString();
                    break;
                case "WrongLastName":
                    MessageContainer.Text = Application.Current.Resources["ErrorLastName"].ToString();
                    break;
                case "WrongLogin":
                    MessageContainer.Text = Application.Current.Resources["ErrorLogin"].ToString();
                    break;
                case "LoginAlreadyExists":
                    MessageContainer.Text = Application.Current.Resources["ErrorLoginExists"].ToString();
                    break;
                case "WrongPassword":
                    MessageContainer.FontSize = 14;
                    MessageContainer.Text = Application.Current.Resources["ErrorPassword"].ToString();
                    break;
                case "WrongEmail":
                    MessageContainer.Text = Application.Current.Resources["ErrorEmail"].ToString();
                    break;
                case "EmailAlreadyInUse":
                    MessageContainer.Text = Application.Current.Resources["ErrorEmailInUse"].ToString();
                    break;
                case "WrongDateOfBirth":
                    MessageContainer.Text = Application.Current.Resources["ErrorDateBirth"].ToString();
                    break;
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
