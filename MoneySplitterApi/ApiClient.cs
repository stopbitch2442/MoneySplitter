using MoneySplitterApi.Models;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitterApi
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiClient(string baseUrl = "https://localhost:7097/api/")
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        /// <summary>
        ///  Debts
        /// </summary>
        /// <returns></returns>
        public async Task<Debts[]> GetDebtsAsync()
        {
            var response = await _httpClient.GetAsync("Debts");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Debts[]>(content);
        }

        public async Task<Debts[]> GetDebtAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"Debts/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Debts[]>(content);
        }

        public async Task<HttpResponseMessage> CreateDebtAsync(Debts debts)
        {
            var serializedObject = JsonConvert.SerializeObject(debts);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync("Debts/create", httpContent);
        }

        public async Task<HttpResponseMessage> EditDebtAsync(Guid id, Debts debts)
        {
            var serializedObject = JsonConvert.SerializeObject(debts);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"Debts/edit/{id}", httpContent);
        }

        public async Task<HttpResponseMessage> DeleteDebtAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"delete/{id}");
        }

        /// <summary>
        ///  Ledgers
        /// </summary>
        /// <returns></returns>
        public async Task<Ledgers[]> GetLedgersAsync()
        {
            var response = await _httpClient.GetAsync("Ledgers");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ledgers[]>(content);
        }

        public async Task<HttpResponseMessage> CreateLedgersAsync(Ledgers ledgers)
        {
            var serializedObject = JsonConvert.SerializeObject(ledgers);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync("Ledgers/create", httpContent);
        }

        public async Task<HttpResponseMessage> DeleteLedgersAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"Ledgers/delete/{id}");
        }
    
    }
}