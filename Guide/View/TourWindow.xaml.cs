using Guide.Models;
using Guide.Services;
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
using System.Windows.Shapes;

namespace Guide.View
{
    public partial class TourWindow : Window
    {
        private TourService tourService;
        private Tour tour {  get; set; }
        public TourWindow()
        {
            InitializeComponent();
            tourService = new TourService();
            tour = new Tour();
            DataContext = tour;
        }

        private async void AddTour_Click(object sender, RoutedEventArgs e)
        {
            Tour createdLocation = await tourService.CreateTour(tour);

            if (createdLocation != null)
            {
                MessageBox.Show("Tour has been successfully created!");
            }
            else
            {
                MessageBox.Show("A problem occurred during tour creation.");
            }
            Close();
        }
    }
}
