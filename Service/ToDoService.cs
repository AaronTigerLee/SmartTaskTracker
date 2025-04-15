using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SmartTaskTracker.Model;

namespace SmartTaskTracker.Service
{
    public class ToDoService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "http://localhost:____/api/tasks";
        // Will change everytime api is brought down / brought back up

        public ToDoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ToDo>> GetToDosAsync()
            => await _httpClient.GetFromJsonAsync<List<ToDo>>(apiUrl) ?? new List<ToDo>();

        public async Task<ToDo?> GetToDoAsync(int id)
            => await _httpClient.GetFromJsonAsync<ToDo>($"{apiUrl}/{id}");

        public async Task<bool> CreateToDoAsync(ToDo toDo)
        {
            var response = await _httpClient.PostAsJsonAsync(apiUrl, toDo);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateToDoAsync(ToDo toDo)
        {
            var response = await _httpClient.PutAsJsonAsync($"{apiUrl}/{toDo.Id}", toDo);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
