using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Services;
using CoffeeTime.Service;
using Microsoft.AspNetCore.Mvc;
//משהו בהכנסת הנתונים לא עובד!!!!!!!!!!!!!!!!!!!!!!!!!!!



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_orderService.GetList());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
           var order= _orderService.GetOrder(id);
           if(order == null)
           {
                return NotFound();
           }
           return Ok(order);
        }


    // POST api/<OrderController>
    [HttpPost]
    //אם מכניסים ערך לבד יש שגיאה!
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();
            await _orderService.AddOrderAsync(order);
            //return CreatedAtAction(nameof(order), new { id = order.OrderId }, order); 
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }




        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Order order)
        {
            var ord = _orderService.GetOrder(id);
            if (ord == null)
                return NotFound();
            order.OrderId = id;//הוספתי
            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }
        
        
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task <IActionResult >Delete(int id)
        {
            var ord = _orderService.GetOrder(id);
            if(ord == null)
                return NotFound();
           await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
