using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LearnHttpClient.Helper;
using LearnHttpClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LearnHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallApiController : ControllerBase
    {
        private readonly HttpClient _freshdeskClient;
        private readonly IConfiguration _configuration;
        public CallApiController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _freshdeskClient = clientFactory.CreateClient("freshdesk");
            _configuration = configuration;
        }
        [HttpGet("GetDatas")]
        public async Task<ActionResult> GetDatas()
        {
            List<Product> products = await CallApi.Products(_configuration, _freshdeskClient);
            return Ok("check via debugging");
        }
        [HttpGet("GetData")]
        public async Task<ActionResult> GetData()
        {
            var productId = Guid.NewGuid();
            Product products = await CallApi.Product(_configuration, _freshdeskClient, productId);
            return Ok("check via debugging");
        }
        [HttpGet("SendProduct")]
        public async Task<ActionResult> SendProduct()
        {
            var product = new Product() {
                Id = Guid.NewGuid(),
                Name = "zzz",
                Harga = "Rp. 8.000.000",
                Warna = "Merah zzz"
            };
            var result = await CallApi.CreateProduct(_configuration, _freshdeskClient, product);
            return Ok("check via debugging");
        }
    }
}