using Guide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Guide.Services
{
    public class AppointmentService
    {
        private HttpClient client;

        public AppointmentService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5245/");
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            var json = JsonSerializer.Serialize(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/appointment", content);

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Appointment>(stringResponse);
            }

            return null;
        }
    }
}
