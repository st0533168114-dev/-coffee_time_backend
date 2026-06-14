using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;

namespace CoffeeTime.Core.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
       // public List<Order> orders { get; set; }
    }
}
