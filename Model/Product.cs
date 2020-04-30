using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnHttpClient.Model
{
    public class Product
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Harga { set; get; }
        public string Warna { set; get; }
    }
}
