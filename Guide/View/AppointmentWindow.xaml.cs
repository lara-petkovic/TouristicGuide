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
    public partial class AppointmentWindow : Window
    {
        private AppointmentService appointmentService { get; set; }
        private Appointment appointment {  get; set; }
        public AppointmentWindow()
        {
            InitializeComponent();
            appointmentService = new AppointmentService();
            appointment = new Appointment();
            DataContext = appointment;
        }
        private async void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment createdAppointment = await appointmentService.CreateAppointment(appointment);

            if (createdAppointment != null)
            {
                MessageBox.Show("Appointment has been successfully created!");
            }
            else
            {
                MessageBox.Show("A problem occurred during appointment creation.");
            }
            Close();
        }
    }
}
