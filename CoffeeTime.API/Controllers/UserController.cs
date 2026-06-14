using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Services;
using CoffeeTime.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


//
//22222222222222222222222222222
//עוד לא שיניתי כאן כלוםםם
namespace CoffeeTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetList());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]

        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            //var userEntity = new User
            //{
            //    UserName = user.UserName,
            //    Phon = user.Phon
            //};

            if (user == null)
                return BadRequest();
          await  _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user); 
                //  return CreatedAtAction(nameof(user), new { id = user.UserId }, user);שיניתי בגלל שגיאה
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            var us = _userService.GetUser(id);

            if (us == null)
                return NotFound();
            user.UserId = id;//הוספתי
          await  _userService.UpdateUserAsync(user);
            return NoContent();
        }
        
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task< IActionResult >Delete(int id)
        {
            var us = _userService.GetUser(id);
            if (us == null)
                return NotFound();
           await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
