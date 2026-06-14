using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
using CoffeeTime.Core.Services;
using CoffeeTime.Core.DTOs;
using AutoMapper;
namespace CoffeeTime.Service
{
    public class ProductsService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductDTO> GetList()
        {
            //TODO business logic
            var products = _productRepository.GetAll();
            return _mapper.Map<List<ProductDTO>>(products);

        }
        public async Task AddProductAsync(Product product)
        {
            //TODO business logic
            await _productRepository.AddAsync(product);
        }
        //חדשים
       public ProductDTO GetProduct(int id)
        {
            //TODO
           var product= _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            //TODO
            await _productRepository.DeleteAsync(id);
        }

    }
}
