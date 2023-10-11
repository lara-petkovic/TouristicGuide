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
    public partial class UserWindow : Window
    {
        private UserService userService;
        private User user {  get; set; }
        public UserWindow()
        {
            InitializeComponent();
            user = new User();
            userService = new UserService();
            DataContext = user;
        }

        private async void AddUser_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
