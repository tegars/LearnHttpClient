using LearnHttpClient.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnHttpClient.Helper
{
    public static class CallApi
    {
        public static async Task<List<Product>> Products(IConfiguration configuration, HttpClient client)
        {
            var address = $"products";
            HttpResponseMessage responseFreshDesk = await client.GetAsync(address);
            if (!responseFreshDesk.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var products = await responseFreshDesk.Content.ReadAsAsync<List<Product>>();
            return products;
        }
        public static async Task<Product> Product(IConfiguration configuration, HttpClient client, Guid productId)
        {
            var address = $"products/"+productId;
            HttpResponseMessage responseFreshDesk = await client.GetAsync(address);
            if (!responseFreshDesk.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var products = await responseFreshDesk.Content.ReadAsAsync<Product>();
            return products;
        }
        public static async Task<Product> CreateProduct(IConfiguration configuration, HttpClient client, Product product)
        {
            var address = $"products/";
            var normalizedBody = JsonSerializer.Serialize(product);
            StringContent content = new StringContent(normalizedBody, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseFreshDesk = await client.PostAsync(address, content);
            if (!responseFreshDesk.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var products = await responseFreshDesk.Content.ReadAsAsync<Product>();
            return products;
        }
    }
}
