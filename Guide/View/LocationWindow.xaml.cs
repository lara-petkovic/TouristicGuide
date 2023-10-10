using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace Guide.View
{
    /// <summary>
    /// Interaction logic for LocationWindow.xaml
    /// </summary>
    public partial class LocationWindow : Window
    {
        public LocationWindow()
        {
            InitializeComponent();
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server=LARA\\TESTSERVER;Initial Catalog=guideDatabase;Integrated Security=True"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlInsert = "INSERT INTO LOCATIONS (City, Country) VALUES (" + cityTextBox.ToString() + "," + countryTextBox.ToString() + ")";
                SqlCommand command = new SqlCommand(sqlInsert, connection);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data added to the database successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add data to the database.");
                }
            }
        }
    }
}
