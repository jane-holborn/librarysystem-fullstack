using LibrarySystem.WpfFrontend.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace LibrarySystem.WpfFrontend.Services
{
    public class ApiClient
    {

        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7084/api/");
        }
        
        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                List<User> users = await _httpClient.GetFromJsonAsync<List<User>>("library/users");
                return users ?? new List<User>();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                return new List<User>();
            }
        }
    }
}
