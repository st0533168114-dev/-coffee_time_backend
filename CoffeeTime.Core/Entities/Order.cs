using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Entities
{
    public class Order
    {
       //משהו לא נכון בהכנסת הנתונים!!!!!!!!!!!!!!!!!
            public int OrderId { get; set; }
            public User User { get; set; }
            public List<Product> Products { get; set; }
            public double OrderPrice { get; set; }
            public DateTime OrderDate { get; set; }
       //זה היה קודםלבדוק שלא צריך לשנות דברים במסד
        //   public int OrderId { get; set; }
        //public int UserId { get; set; }
        //public List<int> ProductsId { get; set; }
        //public double OrderPrice { get; set; }
        //public DateTime OrderDate { get; set; }
    }
}
 