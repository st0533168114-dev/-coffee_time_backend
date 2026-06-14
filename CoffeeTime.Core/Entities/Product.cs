using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        //אני מורידה את זה זה נכון?וצריך עוד משהו לשנות???בשביל זה
        // public List<Order> orders { get; set; }//??????????????????????????
        //כנראה צריך מיגריישן?למה בהרצה אין שינוי?

        //זה היה קודם
        //public int ProductId { get; set; }
        //public string ProductName { get; set; }
        //public double Price { get; set; }
    }
}
