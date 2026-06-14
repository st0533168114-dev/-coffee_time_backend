using CoffeeTime.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            //כאן יהיה אימות משתמש מול המסד נתונים
        //דוגמא לאמות
        if(login.UserName=="test"&& login.Password=="password")
          {
              var token = _jwtService.GenerateToken(login.UserName);
              return Ok(token);
          }
        return Unauthorized();
        }
    }
    public class LoginModel
    {
        public string UserName { get;  set; }
        public string Password { get; set; }

    }

}
