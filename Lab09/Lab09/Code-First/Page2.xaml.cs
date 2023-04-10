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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab09
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field1.Text = string.Empty;

            if (fromPrice.Text.Length > 0 || toPrice.Text.Length > 0)
            {

                Context db = new Context();
                try
                {
                    int firstOption = Convert.ToInt32(fromPrice.Text);
                    int secondOption = Convert.ToInt32(toPrice.Text);
                    string query = "SELECT * FROM Orders WHERE Order_price BETWEEN " + firstOption + " and " + secondOption;
                    var res = db.Database.SqlQuery<Order>(query).ToArray();

                    if (res.Count() != 0)
                    {
                        foreach (Order a in res)
                        {
                            Field1.Text += a.ToString();
                            Field1.Text += '\n';
                        }
                    }
                    else
                        Field1.Text = "Ничего не найдено";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Данные введены неверно!");
                }
                finally
                {
                    fromPrice.Text = string.Empty;
                    toPrice.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Одно из полей пустое!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Field2.Text = string.Empty;
            if (clientId.Text.Length > 0)
            {
                using (Context db = new Context())
                {
                    try
                    {
                        int id = Convert.ToInt32(clientId.Text);
                        string query = "SELECT COUNT(*) FROM ORDERS WHERE PersonId = " + id;
                        int results = db.Database.SqlQuery<int>(query).FirstOrDefault();
                        Field2.Text += "Количество заказов: " + Convert.ToString(results);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Данные введены неверно!");
                    }
                    finally
                    {
                        clientId.Text = string.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                string query = "SELECT SUM(Order_price) FROM Orders";
                try
                {
                    int sumCredit = db.Database.SqlQuery<int>(query).FirstOrDefault();
                    Field3.Text = "Сумма стоимости всех заказов: " + Convert.ToString(sumCredit);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }
    }
}
