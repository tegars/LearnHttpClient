using LearnHttpClient.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
