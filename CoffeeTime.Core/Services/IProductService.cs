using CoffeeTime.Core.Entities;
using CoffeeTime.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Services
{
    public interface IProductService
    {
        public List<ProductDTO> GetList();
        public Task AddProductAsync(Product product);
        //חדשים:
        
        public ProductDTO GetProduct(int id);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(int id);
       
        
     
    }
}
