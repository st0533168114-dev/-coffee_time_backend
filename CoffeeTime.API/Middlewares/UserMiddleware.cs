using CoffeeTime.Core.Entities;

namespace CoffeeTime.API.Middlewares
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserMiddleware> _logger;


        public UserMiddleware(RequestDelegate next, ILogger<UserMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var requestSeq = Guid.NewGuid().ToString();
            _logger.LogInformation($"Request Start {requestSeq}");
            context.Items.Add($"RequestSequence", requestSeq);
            await _next(context);
            _logger.LogInformation($"Request Ends{requestSeq}");

        }
    }
}
