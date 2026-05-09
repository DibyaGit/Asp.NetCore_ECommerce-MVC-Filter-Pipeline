using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceApp.Filters
{
    // IAuthorizationFilter is a special filter that runs BEFORE anything else. Perfect for a bouncer!
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly IAuthService _authService;

        // Dependency Injection: The system hands the Bouncer a radio to talk to the Manager.
        public AuthFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // The Bouncer uses the radio to ask the Manager if the user is logged in
            bool isLoggedIn = _authService.IsUserLoggedIn();

            if (isLoggedIn == false)
            {
                // If the user is NOT logged in, stop them immediately!
                // We show them a simple text message instead of the webpage.
                context.Result = new ContentResult
                {
                    Content = "Access Denied! You are not logged in. Please log in to view this VIP page.",
                    StatusCode = 401 // 401 is the official internet code for "Unauthorized"
                };
            }
        }
    }
}