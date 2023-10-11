using Guide.View;
using System.Windows;

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
