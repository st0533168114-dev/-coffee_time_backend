using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Entities
{
    public class User
    {
        public  int UserId { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public string Phon { get; set; }
        public string Password { get; set; }
        //כן שיניתי בפעולות מקוה שהכל
       // public List<Order> orders { get; set; }הורדתי לבדוק אם נכון ועל מה זה ישפיע
       //כנראה צריך מיגריישן?למה בהרצה אין שינוי?



        //זה היה קודם
        //public int UserId { get; set; }
        //public string UserName { get; set; }
        //public string Adress { get; set; }
        //public string Phon { get; set; }
    }
}
