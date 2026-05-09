namespace ECommerceApp.Services
{
    // An 'Interface' is just a rulebook. It tells our app what the service CAN do.
    public interface IAuthService
    {
        bool IsUserLoggedIn();
    }
}