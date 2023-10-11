using Guide.Models;
using Guide.Services;
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
    public partial class LocationWindow : Window
    {
        private LocationService locationService;
        private Location location {  get; set; }

        public LocationWindow()
        {
            InitializeComponent();
            locationService = new LocationService();
            location = new Location();
            DataContext = location;
        }

        private async void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            Location createdLocation = await locationService.CreateLocation(location);

            if (createdLocation != null)
            {
                MessageBox.Show("Location has been successfully created!");
            }
            else
            {
                MessageBox.Show("A problem occurred during location creation.");
            }
            Close();
        }
    }
}
