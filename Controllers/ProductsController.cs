using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnHttpClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            List<Product> products = new List<Product>();
            var product1 = new Product() { 
                Id = Guid.NewGuid(),
                Name = "Kickers",
                Harga = "Rp. 800.000",
                Warna = "Merah"
            };
            var product2 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Gucci",
                Harga = "Rp. 500.000",
                Warna = "Hijau"
            };
            products.Add(product1);
            products.Add(product2);
            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var product = new Product()
            {
                Id = id,
                Name = "Kickers",
                Harga = "Rp. 800.000",
                Warna = "Merah"
            };
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult Post(Product product)
        {
            var tmp = product;
            return Ok(tmp);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
