using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Planet.xaml
    /// </summary>
    public partial class Planet : Window
    {
        public string path;
        string script = "";
        string connectionString;
        SqlConnection connection;
        public Planet()
        {
            InitializeComponent();
            connectionString = MainWindow.connectionString;
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
            script = "INSERT INTO PLANETS (Name, Radius, Core_Temperature, Have_Atmosphere, Have_Life, Image) VALUES(@name, @radius, @temp, @atm, @life, @image)";

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(script, connection);
                    SqlParameter nameParam = new SqlParameter("@name", Name.Text);
                    SqlParameter radiusParam = new SqlParameter("@radius", Radius.Text);
                    SqlParameter tempParam = new SqlParameter("@temp", Temp.Text);
                    SqlParameter atmParam = new SqlParameter("@atm", Atm.IsChecked);
                    SqlParameter lifeParam = new SqlParameter("@life", Life.IsChecked);
                    SqlParameter imageParam = new SqlParameter("@image", path);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(radiusParam);
                    command.Parameters.Add(tempParam);
                    command.Parameters.Add(atmParam);
                    command.Parameters.Add(lifeParam);
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
