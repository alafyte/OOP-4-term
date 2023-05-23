using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Windows;
using System.Data.SqlClient;
using System.IO;

namespace Lab08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string str;
        string script = "";
        string connectionString;
        bool connectionChecked = false;
        DataTable planetsTable;
        DataTable satellitesTable;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter1;
        SqlDataAdapter adapter2;
        public MainWindow()
        {
            InitializeComponent();
            Sort_Planets.Items.Add("Все строки и столбцы");
            Sort_Planets.Items.Add("По названию");
            Sort_Planets.Items.Add("По радиусу (возрастанию)");
            Sort_Planets.Items.Add("По радиусу (убыванию)");
            Sort_Planets.Items.Add("По температуре ядра (возрастанию)");
            Sort_Planets.Items.Add("По температуре ядра (убыванию)");

            Sort_Satellites.Items.Add("Все строки и столбцы");
            Sort_Satellites.Items.Add("По названию");
            Sort_Satellites.Items.Add("По радиусу (возрастанию)");
            Sort_Satellites.Items.Add("По радиусу (убыванию)");
            Sort_Satellites.Items.Add("По расстоянию от планеты (возрастанию)");
            Sort_Satellites.Items.Add("По расстоянию от планеты (убыванию)");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(!connectionChecked)
                CheckConnection();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sqlExpression = "SELECT * FROM PLANETS";
                planetsTable = new DataTable();
                command = new SqlCommand(sqlExpression, connection);
                adapter1 = new SqlDataAdapter(command);
                adapter1.Fill(planetsTable);
                PlanetsGrid.ItemsSource = planetsTable.DefaultView;
                sqlExpression = "SELECT * FROM SATELLITES";
                satellitesTable = new DataTable();
                command = new SqlCommand(sqlExpression, connection);
                adapter2 = new SqlDataAdapter(command);
                adapter2.Fill(satellitesTable);
                SatellitesGrid.ItemsSource = satellitesTable.DefaultView;

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
        private void CheckConnection()
        {

            using (connection = new SqlConnection("Data Source=DESKTOP-MFP40AR;Initial Catalog=Planets;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    using (connection = new SqlConnection("Data Source=DESKTOP-MFP40AR;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();
                            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                            string createDBQuery = "CREATE DATABASE Planets";
                            SqlCommand createDBCommand = new SqlCommand(createDBQuery, connection);
                            createDBCommand.ExecuteNonQuery();
                            string createTablesQuery = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery1.sql");
                            SqlCommand createTablesCommand = new SqlCommand(createTablesQuery, connection);
                            createTablesCommand.ExecuteNonQuery();
                            string insertDataTablesQuery = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery2.sql");
                            SqlCommand insertCommand = new SqlCommand(insertDataTablesQuery, connection);
                            insertCommand.ExecuteNonQuery();
                            string createProc1Query = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery3.sql");
                            SqlCommand createProc1Command = new SqlCommand(createProc1Query, connection);
                            createProc1Command.ExecuteNonQuery();
                            string createProc2Query = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery4.sql");
                            SqlCommand createProc2Command = new SqlCommand(createProc2Query, connection);
                            createProc2Command.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                    connectionString = "Data Source=DESKTOP-MFP40AR;Initial Catalog=Planets;Integrated Security=True";
                    connectionChecked = true;
                }
            }
        }
        private void Procedure1_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "PROC_COUNT_PLANETS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t\n";

                    while (reader.Read())
                    {
                        object count = reader.GetValue(0);
                        str += $"{count}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
                Window_Loaded(new object(), new RoutedEventArgs());
            }
        }
        private void Procedure2_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "PROC_COUNT_SATELLITES";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t\n";

                    while (reader.Read())
                    {
                        object count = reader.GetValue(0);
                        str += $"{count}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
                Window_Loaded(new object(), new RoutedEventArgs());
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(planetsTable);
            adapter1.Update(satellitesTable);
            Window_Loaded(sender, e);
        }
        private void Delete_Planet_Click(object sender, RoutedEventArgs e)
        {
            if (PlanetsGrid.SelectedItems != null)
            {
                for (int i = 0; i < PlanetsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = PlanetsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(planetsTable);
            Window_Loaded(sender, e);
        }
        private void Delete_Satellite_Click(object sender, RoutedEventArgs e)
        {
            if (SatellitesGrid.SelectedItems != null)
            {
                for (int i = 0; i < SatellitesGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = SatellitesGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter2);
            adapter2.Update(satellitesTable);
            Window_Loaded(sender, e);
        }
        private void SortSatellites(object sender, RoutedEventArgs e)
        {
            switch (Sort_Satellites.SelectedIndex)
            {
                case 0:
                    script = "Name ASC";
                    break;
                case 1:
                    script = "Name ASC";
                    break;
                case 2:
                    script = "Radius ASC";
                    break;
                case 3:
                    script = "Radius DESC";
                    break;
                case 4:
                    script = "Planetary_Distance ASC";
                    break;
                case 5:
                    script = "Planetary_Distance DESC";
                    break;
            }
            satellitesTable.DefaultView.Sort = script;
            SatellitesGrid.ItemsSource = satellitesTable.DefaultView;
        }
        private void SortPlanets(object sender, RoutedEventArgs e)
        {
            switch (Sort_Planets.SelectedIndex)
            {
                case 0:
                    script = "Name ASC";
                    break;
                case 1:
                    script = "Name ASC";
                    break;
                case 2:
                    script = "Radius ASC";
                    break;
                case 3:
                    script = "Radius DESC";
                    break;
                case 4:
                    script = "Core_Temperature ASC";
                    break;
                case 5:
                    script = "Core_Temperature DESC";
                    break;
            }
            planetsTable.DefaultView.Sort = script;
            PlanetsGrid.ItemsSource = planetsTable.DefaultView;
        }
        private void Add_Planet_Click(object sender, RoutedEventArgs e)
        {
            var pl = new Planet();
            try
            {
                pl.ShowDialog();
                Window_Loaded(sender, e);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                pl.Close();
            }
        }

        private void Add_Satellite_Click(object sender, RoutedEventArgs e)
        {
            var sat = new Satellite();
            try
            {
                sat.ShowDialog();
                Window_Loaded(sender, e);
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                sat.Close();
            }
        }
    }
}
