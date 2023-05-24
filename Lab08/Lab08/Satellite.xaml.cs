using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Lab08
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class Satellite : Window
    {
        public string path; 
        string script = "";
        string connectionString;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter1;
        public Satellite()
        {
            InitializeComponent();
            connectionString = MainWindow.connectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> planets = new List<string>();
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlExpression = "SELECT Name FROM PLANETS";
                    command = new SqlCommand(sqlExpression, connection);
                    adapter1 = new SqlDataAdapter(command);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                object name = reader.GetValue(0);
                                planets.Add(name.ToString());
                            }
                        }
                    }
                    Planets.ItemsSource = planets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    string[] parts = filePath.Split('\\');

                    path = parts[parts.Length - 1];
                    var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                    File.Copy(filePath, projectPath + "/images/" + path, true);

                    imgDynamic.Source = new BitmapImage(new Uri(projectPath + "/images/" + path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            SqlTransaction tx = null;
            script = "INSERT INTO SATELLITES (Name, Planet_Name, Radius, Planetary_Distance, Image) VALUES(@name, @planet, @radius, @distance, @image)";

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(script, connection);
                    SqlParameter nameParam = new SqlParameter("@name", Name.Text);
                    SqlParameter planetParam = new SqlParameter("@planet", Planets.SelectedItem);
                    SqlParameter radiusParam = new SqlParameter("@radius", Radius.Text);
                    SqlParameter distanceParam = new SqlParameter("@distance", Distance.Text);
                    SqlParameter imageParam = new SqlParameter("@image", path);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(planetParam);
                    command.Parameters.Add(radiusParam);
                    command.Parameters.Add(distanceParam);
                    command.Parameters.Add(imageParam);
                    tx = connection.BeginTransaction();
                    command.Transaction = tx;
                    command.ExecuteNonQuery();
                    tx.Commit();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tx.Rollback();
            }
        }

    }
}
