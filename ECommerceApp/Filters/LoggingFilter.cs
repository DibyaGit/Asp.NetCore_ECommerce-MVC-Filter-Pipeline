using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ECommerceApp.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var url = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;

            // We changed the format here to make Visual Studio happy!
            _logger.LogInformation("[LOG] Request started. Trying to visit: {Url} using {Method} method.", url, method);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var statusCode = context.HttpContext.Response.StatusCode;

            // We changed the format here too!
            _logger.LogInformation("[LOG] Request finished. Status code: {StatusCode}", statusCode);
        }
    }
}