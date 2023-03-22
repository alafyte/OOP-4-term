using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab06
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        Product selectedItem;
        private string currentPage;
        private string key;
        private Stack<ObservableCollection<Product>> undoStates = new Stack<ObservableCollection<Product>>();
        private Stack<ObservableCollection<Product>> redoStates = new Stack<ObservableCollection<Product>>();


        public ProductsPage()
        {
            InitializeComponent();
            ShowAll();
            Cursor = CursorCollection.GetCursor();
            Settings.changeLang += ChangeLang;
        }

        private void ChangeLang()
        {
            switch(currentPage)
            {
                case "ShowAll":
                    ShowAll();
                    break;
                case "ShowFilter":
                    ShowFilter(key);
                    break;
            }
        }

        private void ShowAll()
        {

            products.Children.Clear();
            foreach (Product p in StoreDb.products)
            {
                if (p.isActive == 1)
                {
                    Button btn = new Button();
                    btn.Style = (Style)FindResource("ButtonStyle");

                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Style = (Style)FindResource("StackPanelStyle");

                    Image image = new Image();

                    var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                    image.Source = new BitmapImage(new Uri(projectPath + "/images/" + p.PImage));
                    image.Style = (Style)Resources["ImageStyle"];

                    Label name = new Label();
                    name.HorizontalAlignment = HorizontalAlignment.Center;
                    switch (Settings.Lang)
                    {
                        case Settings.Languages.RU:
                            name.Content = p.PNameRus;
                            break;
                        case Settings.Languages.EN:
                            name.Content = p.PNameEn;
                            break;
                    }
                    name.FontWeight = FontWeights.DemiBold;
                    name.FontSize = 11;


                    Label price = new Label();
                    price.HorizontalAlignment = HorizontalAlignment.Center;
                    price.Content = p.Price + "$";
                    price.FontSize = 11;

                    Button button = new Button();
                    button.Style = (Style)FindResource("ButtonDescription");
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/icons8-align-left-16.png"));
                    button.Content = img;
                    button.Name = "btn" + p.ProductCode.ToString();
                    button.Click += new RoutedEventHandler(openDescription);

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(name);
                    stackPanel.Children.Add(price);
                    stackPanel.Children.Add(button);

                    btn.Content = stackPanel;
                    btn.Name = "btn" + p.ProductCode.ToString();
                    btn.Click += new RoutedEventHandler(selectItem);
                    products.Children.Add(btn);
                }
            }
            currentPage = "ShowAll";
        }

        private void Refresh()
        {
            ShowAll();
        }

        private void Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                key = SearchField.Text;
                ShowFilter(key);
            }
        }

        private void ShowFilter(string key)
        {
            currentPage = "ShowFilter";
            products.Children.Clear();
            foreach (Product p in StoreDb.products)
            {
                if (p.isActive == 1 && (p.PNameRus.ToUpper().Contains(key.ToUpper()) || p.PNameEn.ToUpper().Contains(key.ToUpper())))
                {
                    Button btn = new Button();
                    btn.Style = (Style)FindResource("ButtonStyle");

                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Style = (Style)FindResource("StackPanelStyle");

                    Image image = new Image();

                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/" + p.PImage));
                    image.Style = Resources["ImageStyle"] as Style;

                    Label name = new Label();
                    name.HorizontalAlignment = HorizontalAlignment.Center;
                    switch (Settings.Lang)
                    {
                        case Settings.Languages.RU:
                            name.Content = p.PNameRus;
                            break;
                        case Settings.Languages.EN:
                            name.Content = p.PNameEn;
                            break;
                    }
                    name.FontWeight = FontWeights.DemiBold;
                    name.FontSize = 11;


                    Label price = new Label();
                    price.HorizontalAlignment = HorizontalAlignment.Center;
                    price.Content = p.Price + "$";
                    price.FontSize = 11;

                    Button button = new Button();
                    button.Style = (Style)Resources["ButtonDescription"];
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/icons8-align-left-16.png"));
                    button.Content = img;
                    button.Name = "btn" + p.ProductCode.ToString();
                    button.Click += new RoutedEventHandler(openDescription);


                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(name);
                    stackPanel.Children.Add(price);
                    stackPanel.Children.Add(button);

                    btn.Content = stackPanel;
                    btn.Name = "btn" + p.ProductCode.ToString();
                    btn.Click += new RoutedEventHandler(selectItem);
                    products.Children.Add(btn);
                }

            }
        }
        private void openDescription(object sender, RoutedEventArgs e)
        {
            string btn = (sender as Button).Name.ToString();
            int id = int.Parse(btn.Remove(0, 3));

            Product product = StoreDb.products.First(o => o.ProductCode == id);
            new Details(product).Show();
        }
        private void selectItem(object sender, RoutedEventArgs e)
        {
            string btn = (sender as Button).Name.ToString();
            int id = int.Parse(btn.Remove(0, 3));

            Product product = StoreDb.products.First(o => o.ProductCode == id);

            if (selectedItem != null)
            {

                foreach (var b in products.Children.OfType<Button>())
                {
                    if (b.Name == "btn" + selectedItem.ProductCode)
                    {
                        b.Background = Brushes.Transparent;
                        break;
                    }
                }
                selectedItem = null;
                deleteBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
            }

            if (product.Equals(selectedItem))
            {
                (sender as Button).Background = Brushes.Transparent;
                selectedItem = null;
                deleteBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
            }
            else
            {
                BrushConverter bc = new BrushConverter();
                (sender as Button).Background = (Brush)bc.ConvertFrom("#DDDFDE");
                selectedItem = product;
            }

            if (selectedItem != null)
            {
                deleteBtn.IsEnabled = true;
                editBtn.IsEnabled = true;
            }
            else
            {
                deleteBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
            }

        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Product> undoState = undoStates.Peek();
                ObservableCollection<Product> state = new ObservableCollection<Product>();
                foreach (var p in StoreDb.products)
                    state.Add(p.Clone() as Product);
                redoStates.Push(state);
                StoreDb.products = undoState;
                undoStates.Pop();
                Refresh();
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Redo(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Product> redoState = redoStates.Peek();
                ObservableCollection<Product> state = new ObservableCollection<Product>();
                foreach (var p in StoreDb.products)
                    state.Add(p.Clone() as Product);
                undoStates.Push(state);
                StoreDb.products = redoState;
                redoStates.Pop();
                Refresh();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> state = new ObservableCollection<Product>();
            foreach (var p in StoreDb.products)
                state.Add(p.Clone() as Product);
            undoStates.Push(state);
            selectedItem.isActive = 0;
            new Message("Success").ShowDialog();
            ShowAll();
            deleteBtn.IsEnabled = false;
            editBtn.IsEnabled = false;
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> state = new ObservableCollection<Product>();
            foreach (var p in StoreDb.products)
                state.Add(p.Clone() as Product);
            undoStates.Push(state);
            ProductDialog pd = new ProductDialog();
            pd.Closed += (s, ee) => Refresh();
            pd.Show();
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> state = new ObservableCollection<Product>();
            foreach (var p in StoreDb.products)
                state.Add(p.Clone() as Product);
            undoStates.Push(state);
            ProductDialog pd = new ProductDialog(selectedItem);
            pd.Closed += (s, ee) => Refresh();
            pd.Show();
        }

    }
}
