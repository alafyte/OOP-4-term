using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : Window
    {
        private Product product;
        private string img;


        public ProductDialog()
        {
            InitializeComponent();
            EditBtn.Visibility = Visibility.Collapsed;
            AddBtn.Visibility = Visibility.Visible;
            Cursor = CursorCollection.GetCursor();
        }

        public ProductDialog(Product product)
        {
            InitializeComponent();
            Cursor = CursorCollection.GetCursor();
            EditBtn.Visibility = Visibility.Visible;
            AddBtn.Visibility = Visibility.Collapsed;

            nameFieldRus.Text = product.PNameRus;
            nameFieldEn.Text = product.PNameEn;
            descriptionFieldEn.Text = product.PDescriptionEn;
            descriptionFieldRus.Text = product.PDescriptionRus;
            priceField.Text = product.Price.ToString();
            quantityField.Text = product.Quantity.ToString();

            string selection = "type" + product.ProductType;

            ProductType.SelectedItem = ProductType.Items.GetItemAt(product.ProductType - 1);

            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            var source = new BitmapImage(new Uri(projectPath + "/images/" + product.PImage));
            ImageBrush imgBrush = new ImageBrush(source);

            image.Fill = imgBrush;
            image.Stroke = Brushes.Transparent;
            this.product = product;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            var filePicker = new OpenFileDialog();

            filePicker.DefaultExt = ".jpg";
            filePicker.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";

            bool? result = filePicker.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filePath = filePicker.FileName;

                string[] parts = filePath.Split('\\');

                string fileName = parts[parts.Length - 1];
                img = fileName;

                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                File.Copy(filePath, projectPath + "/images/" + fileName, true);

                var source = new BitmapImage(new Uri(projectPath + "/images/" + fileName));
                ImageBrush imgBrush = new ImageBrush(source);

                image.Fill = imgBrush;
                image.Stroke = Brushes.Transparent;
            }
        }

        private void EditProductInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = StoreDb.products.First(o => o.ProductCode == product.ProductCode);

                item.PNameRus = nameFieldRus.Text;
                item.PNameEn = nameFieldEn.Text;
                item.PDescriptionRus = descriptionFieldRus.Text;
                item.PDescriptionEn = descriptionFieldEn.Text;
                if (priceField.Text.Length != 0)
                {
                    try
                    {
                        item.Price = decimal.Parse(priceField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongProductPrice");
                    }
                }
                else
                    throw new ArgumentException("WrongProductPrice");
                if (quantityField.Text.Length != 0)
                {
                    try
                    {
                        item.Quantity = int.Parse(quantityField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongProductQuantity");
                    }
                }
                else
                    throw new ArgumentException("WrongProductQuantity");

                item.ProductType = ProductType.SelectedIndex + 1;
                if (img != null)
                    item.PImage = img;

                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(item);
                if (!Validator.TryValidateObject(item, context, results, true))
                    new Message(results.First().ToString()).ShowDialog();
                else
                {
                    new Message("Success").ShowDialog();
                    Close();
                }
            }
            catch (ArgumentException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
            catch (FormatException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                product = new Product();
                int code = StoreDb.products.Last().ProductCode + 1;

                product.ProductCode = code;
                product.PNameRus = nameFieldRus.Text;
                product.PNameEn = nameFieldEn.Text;
                product.PDescriptionRus = descriptionFieldRus.Text;
                product.PDescriptionEn = descriptionFieldEn.Text;
                if (priceField.Text.Length != 0)
                {
                    try
                    {
                        product.Price = decimal.Parse(priceField.Text);
                    }
                    catch(FormatException)
                    {
                        throw new FormatException("WrongProductPrice");
                    }
                }
                else
                    throw new ArgumentException("WrongProductPrice");
                if (quantityField.Text.Length != 0)
                {
                    try
                    {
                        product.Quantity = int.Parse(quantityField.Text);
                    }
                    catch(FormatException)
                    {
                        throw new FormatException("WrongProductQuantity");
                    }
                }
                else
                    throw new ArgumentException("WrongProductQuantity");
                product.ProductType = ProductType.SelectedIndex + 1;

                if (img != null)
                    product.PImage = img;
                else
                    throw new ArgumentException("WrongImageSource");

                product.isActive = 1;
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(product);
                if (!Validator.TryValidateObject(product, context, results, true))
                    new Message(results.First().ToString()).ShowDialog();
                else
                {
                    StoreDb.products.Add(product);
                    new Message("Success").ShowDialog();
                    Close();
                }
            }
            catch(ArgumentException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
            catch (FormatException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
        }
        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string[] parts = files[0].Split('\\');

                string fileName = parts[parts.Length - 1];
                img = fileName;

                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                File.Copy(files[0], projectPath + "/images/" + fileName, true);

                var source = new BitmapImage(new Uri(projectPath + "/images/" + fileName));
                ImageBrush imgBrush = new ImageBrush(source);

                image.Fill = imgBrush;
                image.Stroke = Brushes.Transparent;
            }
        }
        private void Drop_DragEnter(object sender, DragEventArgs e)
        {
            image.Fill = Application.Current.Resources["PrimaryHueLightBrush"] as Brush;
        }
        private void Drop_DragLeave(object sender, DragEventArgs e)
        {
            image.Fill = Brushes.Transparent;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

