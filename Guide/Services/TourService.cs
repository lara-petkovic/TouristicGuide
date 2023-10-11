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
    public class TourService
    {
        private HttpClient client;

        public TourService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5245/");
        }

        public async Task<Tour> CreateTour(Tour tour)
        {
            var json = JsonSerializer.Serialize(tour);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/tour", content);

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Tour>(stringResponse);
            }

            return null;
        }
    }
}
