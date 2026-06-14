using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Services;
using CoffeeTime.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public  ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_productService.GetList());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // POST api/<ProductController>
        [HttpPost]

        public async Task< ActionResult<Product>> Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
            //return CreatedAtAction(nameof(product), new { id = product.ProductId }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult >Put(int id, Product product)
        {
          
            var prod = _productService.GetProduct(id);
            if (prod == null)
                return NotFound();
            product.ProductId = id;//הוספתי
            await _productService.UpdateProductAsync(product);
           
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();
           await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
