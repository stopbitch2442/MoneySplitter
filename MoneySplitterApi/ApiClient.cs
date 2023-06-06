using MoneySplitterApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace MoneySplitterApi
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7097/api/Debts/";
        public ApiClient() 
        { 
        _httpClient= new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<Debts[]> GetDebtsAsync()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Debts[]>(content);
        }

        public async Task<Debts[]> GetDebtsAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Debts[]>(content);
        }

        public async Task<HttpResponseMessage> CreateDebtsAsync(Debts debts)
        {
            var serializedObject = JsonConvert.SerializeObject(debts);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync("create", httpContent);
        }

        public async Task<HttpResponseMessage> EditDebtsAsync(Guid id, Debts debts)
        {
            var serializedObject = JsonConvert.SerializeObject(debts);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"edit/{id}", httpContent);
        }
        
        public async Task<HttpResponseMessage> DeleteDebtsAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"delete/{id}");
        }


    }


}
