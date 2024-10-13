using Demo.ApiClient.Models;
using Demo.ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;

namespace Demo.ApiClient
{
    public class DemoApiclientService
    {

        private readonly HttpClient _httpClient;


        public DemoApiclientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);

        }

        public async Task<List<Product>?> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>?>("/api/Product");

        }


        public async Task<Product?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product?>($"/api/Product/{id}");
        }


        public async Task SaveProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync("/api/Product", product);
        }



        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync("/api/Product/", product);
        }


        public async Task Deleteproduct(int id)
        {
            await _httpClient.DeleteAsync($"/api/Product/{id}");
        }


    }
}
