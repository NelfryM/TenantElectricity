using System.Net.Http.Json;
using TenantElectricity.Shared;
using TenantElectricity.Shared.Models;

namespace TenantElectricityUI.Services
{
    public class ApartmentService
    {
        private readonly HttpClient _httpClient;

        public ApartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7190/api/Apartment/"); // Cambia según corresponda
        }

        public async Task<List<Apartment>> GetApartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Apartment>>("apartments");
        }

        public async Task<Apartment> GetApartmentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Apartment>($"apartments/{id}");
        }

        public async Task CreateApartmentAsync(Apartment apartment)
        {
            await _httpClient.PostAsJsonAsync("apartments", apartment);
        }

        public async Task UpdateApartmentAsync(int id, Apartment apartment)
        {
            await _httpClient.PutAsJsonAsync($"apartments/{id}", apartment);
        }

        public async Task DeleteApartmentAsync(int id)
        {
            await _httpClient.DeleteAsync($"apartments/{id}");
        }
    }
}
