using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
namespace CoffeeTime.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.ProductsList.ToList();
        }
        public async Task AddAsync(Product product)
        {
            _context.ProductsList.Add(product);
            await _context.SaveChangesAsync();
        }
        //חדשים
        public Product GetById(int id)
        {
            return _context.ProductsList.ToList().Find(p => p.ProductId == id);
        }
        public async Task UpdateAsync(Product product)
        {
            
            Product p= _context.ProductsList.ToList().Find(p=>p.ProductId == product.ProductId);
          if(p != null)
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
           //    הורדתי לבדוק  p.orders=product.orders;
                
                
            }
           await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Product p= _context.ProductsList.ToList().Find(p => p.ProductId == id);
          if(p != null)
                _context.ProductsList.Remove(p);
    
            await _context.SaveChangesAsync();

        }
    }
}
