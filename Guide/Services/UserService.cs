using Guide.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var json = System.Text.Json.JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/user", content);

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<User>(stringResponse);
            }

            return null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var response = await client.GetAsync("api/user");

            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                List<User> users = new List<User>();

                using (var jsonReader = new JsonTextReader(new StringReader(stringResponse)))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.TokenType == JsonToken.StartObject)
                        {
                            var serializer = new Newtonsoft.Json.JsonSerializer();
                            users.Add(serializer.Deserialize<User>(jsonReader));
                        }
                    }
                }
                return users;
            }
            return new List<User>();
        }


        public async Task<bool> UpdateUser(User user)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/user/{user.Id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var response = await client.DeleteAsync($"api/user/{userId}");

            return response.IsSuccessStatusCode;
        }
    }
}
