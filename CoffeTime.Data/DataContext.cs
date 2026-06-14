using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using Microsoft.EntityFrameworkCore;
using CoffeeTime.Core;
using Microsoft.Extensions.Configuration;// בשביל הקונפיגוריישן
namespace CoffeeTime.Data
{
    //הסתבכתי עם הקונפיגוריישן אז החזרתי את מחרוזת החיבור לכאן
   public class DataContext: DbContext
    {
        public DbSet<Order> OrdersList { get; set; }
        public DbSet<Product> ProductsList { get; set; }
        public DbSet<User> UsersList { get; set; }
        private readonly IConfiguration _configuration;//מה עוד בשביל המחרוזת חיבור?
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration; 
            //    OrdersList = new List<Order>()
            //    {
            //      new Order(){OrderId=101,UserId=1,ProductsId=new List<int>(){11,22,33} },
            //      new Order(){OrderId=102,UserId=3,ProductsId=new List<int>(){22} },
            //      new Order(){OrderId=103,UserId=2,ProductsId=new List<int>(){33} }
            //    };

            //    ProductsList = new DbSet<Product>()
            //{
            //   new Product(){ProductId=11,ProductName="Pizza",Price=35},
            //   new Product(){ProductId=22,ProductName="Kola",Price=10},
            //   new Product(){ProductId=33,ProductName="Pasta",Price=40}
            //};
            //    UsersList = new List<User>()
            //{
            //   new User(){UserId=1,UserName="David",Adress="Hifha",Phon="0527631000"},
            //   new User(){UserId=2,UserName="Yoni",Adress="Nesher",Phon="0577771000"},
            //   new User(){UserId=3,UserName="Moshe",Adress="Rechasim",Phon="0577771000"}
            //};

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server =DESKTOP-L9S4R74; Database = CoffyTime;Integrated Security=True;TrustServerCertificate=True;");
            string connectionString = _configuration["Connection_String"];
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
    
}
