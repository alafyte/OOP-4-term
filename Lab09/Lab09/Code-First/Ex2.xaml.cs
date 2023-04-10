using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Lab09
{
    /// <summary>
    /// Interaction logic for Ex2.xaml
    /// </summary>
    public partial class Ex2 : Page
    {
        private readonly Context db;
        public Ex2()
        {
            InitializeComponent();

            var context = new Context();
            context.Database.CreateIfNotExists();

            db = new Context();
            db.Orders.Load();
            ordersGrid.ItemsSource = db.Orders.Local.ToBindingList();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await db.SaveChangesAsync();
                ordersGrid.ItemsSource = null;
                ordersGrid.ItemsSource = db.Orders.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ordersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ordersGrid.SelectedItems.Count; i++)
                {
                    Order order = ordersGrid.SelectedItems[i] as Order;
                    if (order != null)
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                db.Orders.Remove(order);
                                db.SaveChanges();
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
