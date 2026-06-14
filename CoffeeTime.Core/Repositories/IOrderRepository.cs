using CoffeeTime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
         public Task AddAsync(Order order);
        //חדשים:
        public Order GetById(int id);
        public Task UpdateAsync(Order order);
        public Task DeleteAsync(int id);
    }
}
