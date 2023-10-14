using Guide.Models;
using Guide.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Guide.View
{
    public partial class LocationWindow : Window
    {
        private LocationService locationService;
        public ObservableCollection<Location> Locations { get; set; }
        private Location editingLocation;
        public string cityTextBox { get; set; }
        public string countryTextBox { get; set; }

        public LocationWindow()
        {
            InitializeComponent();
            locationService = new LocationService();
            DataContext = this;
            Locations = new ObservableCollection<Location>();
            cancelButton.Visibility = Visibility.Hidden;
            updateButton.Visibility = Visibility.Hidden;

            LoadLocationsAsync();
        }

        private async void LoadLocationsAsync()
        {
            Locations.Clear();
            List<Location> locations = await locationService.GetAllLocations();
            foreach (var loc in locations)
            {
                Locations.Add(loc);
            }
        }
        private async void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location
            {
                City = cityTextBox,
                Country = countryTextBox
            };
            Location createdLocation = await locationService.CreateLocation(location);

            if (createdLocation != null)
            {
                MessageBox.Show("Location has been successfully created!");
            }
            else
            {
                MessageBox.Show("A problem occurred during location creation.");
            }
            LoadLocationsAsync();
        }
        private async void RemoveLocation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is int locationId)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this location?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        bool deleteSuccess = await locationService.DeleteLocation(locationId);

                        if (deleteSuccess)
                        {
                            var locationToRemove = Locations.FirstOrDefault(loc => loc.Id == locationId);
                            if (locationToRemove != null)
                            {
                                Locations.Remove(locationToRemove);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the location.");
                        }
                    }
                }
            }
        }
        private async void UpdateLocation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is int locationId)
                {
                    updateButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;
                    editingLocation = Locations.FirstOrDefault(loc => loc.Id == locationId);
                    tb1.Text = editingLocation.City;
                    tb2.Text = editingLocation.Country;
                }
            }
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (editingLocation != null)
            {
                editingLocation.City = cityTextBox;
                editingLocation.Country = countryTextBox;

                bool updateSuccess = await locationService.UpdateLocation(editingLocation);

                if (updateSuccess)
                {
                    MessageBox.Show("Location has been successfully updated!");
                    updateButton.Visibility = Visibility.Collapsed;
                    cancelButton.Visibility = Visibility.Collapsed;
                    cityTextBox = "";
                    countryTextBox = "";
                    tb1.Text = "";
                    tb2.Text = "";
                    editingLocation = null;
                    LoadLocationsAsync();
                }
                else
                {
                    MessageBox.Show("A problem occurred during location update.");
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            updateButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
            cityTextBox = "";
            countryTextBox = "";
            tb1.Text = "";
            tb2.Text = "";
        }
    }
}
