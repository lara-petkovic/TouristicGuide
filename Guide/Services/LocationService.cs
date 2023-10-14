using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Guide.Models;
using Newtonsoft.Json;

namespace Guide.Services
{
    public class LocationService
    {
        private HttpClient client;

        public LocationService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5245/");
        }

        public async Task<Location> CreateLocation(Location location)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/location", content);

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<Location>(stringResponse);
            }

            return null;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            var response = await client.GetAsync("api/location");

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                List<Location> locations = new List<Location>();

                using (var jsonReader = new JsonTextReader(new StringReader(stringResponse)))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.TokenType == JsonToken.StartObject)
                        {
                            var serializer = new Newtonsoft.Json.JsonSerializer();
                            locations.Add(serializer.Deserialize<Location>(jsonReader));
                        }
                    }
                }

                return locations;
            }

            return new List<Location>();
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/location/{location.Id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLocation(int locationId)
        {
            var response = await client.DeleteAsync($"api/location/{locationId}");

            return response.IsSuccessStatusCode;
        }
    }
}
