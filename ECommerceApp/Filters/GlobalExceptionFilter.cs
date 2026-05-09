using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ECommerceApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // 1. Write the incident report (Log the error)
            _logger.LogError("[ERROR] The Paramedic caught an error: {ErrorMessage}", context.Exception.Message);

            // 2. Show a friendly HTML message to the user instead of a scary crash screen
            context.Result = new ContentResult
            {
                Content = "<h2>Oops! Something went wrong.</h2><p>Don't panic! Our Paramedic safely caught the crash.</p>",
                ContentType = "text/html", // This tells the browser to make the text look nice
                StatusCode = 500 // 500 is the official internet code for "Server Error"
            };

            // 3. Tell the system: "Don't panic, I handled the situation!"
            context.ExceptionHandled = true;
        }
    }
}