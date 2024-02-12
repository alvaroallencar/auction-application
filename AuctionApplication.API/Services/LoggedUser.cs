using AuctionApplication.Contracts;
using AuctionApplication.Entities;
using AuctionApplication.Repositories;

namespace AuctionApplication.Services;

public class LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) : ILoggedUser
{
    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = httpContext.HttpContext!.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing");
        }

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}