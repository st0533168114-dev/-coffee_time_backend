using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;

namespace CoffeeTime.Core.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        //מה לשנות??????????????
    }
}
