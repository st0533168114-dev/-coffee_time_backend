using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeTime.Core.DTOs;
using CoffeeTime.Core.Entities;
namespace CoffeeTime.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
       
    }
}
