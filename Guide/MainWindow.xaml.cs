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
using TouristicGuide.Data;

namespace Guide
{
    public partial class MainWindow : Window
    {
        private readonly DataContext _dbContext;

        public MainWindow()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Data Source=LARA\\TESTSERVER;Initial Catalog=guideDatabase;Integrated Security=True")
                .Options;

            _dbContext = new DataContext(options);
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            LocationWindow locationWindow = new LocationWindow();
            locationWindow.Show();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
