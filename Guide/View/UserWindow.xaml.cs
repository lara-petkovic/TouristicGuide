using Guide.Models;
using Guide.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Guide.View
{
    public partial class UserWindow : Window
    {
        private UserService userService;
        public ObservableCollection<User> Users { get; set; }
        private User editingUser;

        public string usernameTextBox { get; set; }
        public string passwordTextBox { get; set; }
        public string nameTextBox { get; set; }
        public string surnameTextBox { get; set; }

        public UserWindow()
        {
            InitializeComponent();
            DataContext = this;
            Users = new ObservableCollection<User>();
            userService = new UserService();
            SetButtons();
            LoadUsersAsync();
        }

        private void SetButtons()
        {
            cancelButton.Visibility = Visibility.Hidden;
            updateButton.Visibility = Visibility.Hidden;
        }

        private async void LoadUsersAsync()
        {
            Users.Clear();
            List<User> users = await userService.GetAllUsers();
            foreach (var loc in users)
            {
                Users.Add(loc);
            }
        }

        private async void AddUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Username = usernameTextBox,
                Password = passwordTextBox,
                Name = nameTextBox,
                Surname = surnameTextBox
            };
            User createdUser = await userService.CreateUser(user);

            if (createdUser != null)
            {
                MessageBox.Show("User has been successfully created!");
            }
            else
            {
                MessageBox.Show("A problem occurred during user creation.");
            }
            Close();
        }

        private async void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is int userId)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        bool deleteSuccess = await userService.DeleteUser(userId);

                        if (deleteSuccess)
                        {
                            var userToRemove = Users.FirstOrDefault(us => us.Id ==  userId);
                            if (userToRemove != null)
                            {
                                Users.Remove(userToRemove);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the user.");
                        }
                    }
                }
            }
        }
        private async void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is int userId)
                {
                    updateButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;
                    editingUser = Users.FirstOrDefault(loc => loc.Id == userId);
                    tb1.Text = editingUser.Username;
                    tb2.Text = editingUser.Password;
                    tb3.Text = editingUser.Name;
                    tb4.Text = editingUser.Surname;
                }
            }
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (editingUser != null)
            {
                editingUser.Username = usernameTextBox;
                editingUser.Password = passwordTextBox;
                editingUser.Name = nameTextBox;
                editingUser.Surname = surnameTextBox;

                bool updateSuccess = await userService.UpdateUser(editingUser);

                if (updateSuccess)
                {
                    MessageBox.Show("User has been successfully updated!");
                    updateButton.Visibility = Visibility.Collapsed;
                    cancelButton.Visibility = Visibility.Collapsed;
                    usernameTextBox = "";
                    passwordTextBox = "";
                    nameTextBox = "";
                    surnameTextBox = "";
                    tb1.Text = "";
                    tb2.Text = "";
                    tb3.Text = "";
                    tb4.Text = "";
                    editingUser = null;
                    LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show("A problem occurred during user update.");
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            updateButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
            usernameTextBox = "";
            passwordTextBox = "";
            nameTextBox = "";
            surnameTextBox = "";
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
        }
    }
}
