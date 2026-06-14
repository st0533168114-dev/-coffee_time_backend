using CoffeeTime.Core.Entities;
using CoffeeTime.Core.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Core.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Task AddAsync(Product product);
        //חדשים:
        public Product GetById(int id);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);

 
    }
}
