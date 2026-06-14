using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
using CoffeeTime.Core.Services;
using CoffeeTime.Core.DTOs;
namespace CoffeeTime.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public List<OrderDTO> GetList()
        {
            //TODO business logic
            var orders= _orderRepository.GetAll();
            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);
            return ordersDTO;
        }
        public async Task AddOrderAsync(Order order)
        {
            //TODO business logic
            await _orderRepository.AddAsync(order);
        }
        //חדשים
        public OrderDTO GetOrder(int id)
        {
            //TODO
            var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderDTO>(order);
        }
        public async Task UpdateOrderAsync(Order order) 
            {
            //TODO
            await _orderRepository.UpdateAsync(order);
            }
        public async Task DeleteOrderAsync(int id)
            {
            //TODO
           await _orderRepository.DeleteAsync(id);
            }

        }   
}
