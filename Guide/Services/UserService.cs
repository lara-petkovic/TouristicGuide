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
    public class UserService
    {
        private HttpClient client;

        public UserService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5245/");
        }

        public async Task<User> CreateUser(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/user", content);

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(stringResponse);
            }

            return null;
        }
    }
}
