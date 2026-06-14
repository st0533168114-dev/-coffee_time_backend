using CoffeeTime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.DTOs;
namespace CoffeeTime.Core.Services
{
    public interface IOrderService
    {
        public List<OrderDTO> GetList();
        public Task AddOrderAsync( Order order);
        //חדשים
        public OrderDTO GetOrder(int id);
        public Task UpdateOrderAsync(Order order);
        public Task DeleteOrderAsync(int id);

    }
}
