using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
namespace CoffeeTime.Data.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public List<Order> GetAll()
        {
            return _context.OrdersList.ToList();
        }
        public async Task AddAsync(Order order)
        {
         _context.OrdersList.Add(order);
            await _context.SaveChangesAsync();
        }
        //חדשים
        public Order GetById(int id)
        {
            return _context.OrdersList.ToList().Find(o=>o.OrderId==id);
        }
        public async Task UpdateAsync(Order order)
        {
            Order o= _context.OrdersList.ToList().Find(o => o.OrderId == order.OrderId);
          
            if(o!=null)
            {
                o.OrderPrice = order.OrderPrice;
                o.OrderDate = order.OrderDate;
                o.User=order.User;
                o.Products = order.Products;
               
            }
           await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Order o= _context.OrdersList.ToList().Find(o => o.OrderId ==id);
            if(o!=null) 
               _context.OrdersList.Remove(o);
            await _context.SaveChangesAsync();

        }
    }
    
}
