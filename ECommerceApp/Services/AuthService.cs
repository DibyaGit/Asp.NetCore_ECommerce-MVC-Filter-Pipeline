namespace ECommerceApp.Services
{
    // This is the actual Manager that follows the IAuthService rulebook.
    public class AuthService : IAuthService
    {
        public bool IsUserLoggedIn()
        {
            // For our testing right now, we will pretend the user is NOT logged in.
            // So we return "false".
            return false;
        }
    }
}