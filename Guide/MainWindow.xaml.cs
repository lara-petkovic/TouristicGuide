using Guide.View;
using Microsoft.EntityFrameworkCore;
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

namespace Guide
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            LocationWindow locationWindow = new LocationWindow();
            locationWindow.Show();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
        }

        private void AddTour_Click(object sender, RoutedEventArgs e)
        {
            TourWindow tourWindow = new TourWindow();
            tourWindow.ShowDialog();
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow appointmentWindow = new AppointmentWindow();
            appointmentWindow.ShowDialog();
        }
    }
}
