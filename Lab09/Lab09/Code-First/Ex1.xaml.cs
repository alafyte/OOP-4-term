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
    /// Interaction logic for Ex1.xaml
    /// </summary>
    public partial class Ex1 : Page
    {
        private Context db;
        public Ex1()
        {
            InitializeComponent();

            var context = new Context();
            context.Database.CreateIfNotExists();

            db = new Context();
            db.People.Load();
            peopleGrid.ItemsSource = db.People.Local.ToBindingList();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await db.SaveChangesAsync();
                peopleGrid.ItemsSource = null;
                peopleGrid.ItemsSource = db.People.Local.ToBindingList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (peopleGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < peopleGrid.SelectedItems.Count; i++)
                {
                    Person per = peopleGrid.SelectedItems[i] as Person;
                    if (per != null)
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var orders = db.Orders.Where(o => o.PersonId == per.ID);
                                foreach (var o in orders)
                                    db.Orders.Remove(o);
                                db.People.Remove(per);
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
