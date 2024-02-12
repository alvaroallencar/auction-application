using AuctionApplication.Contracts;
using AuctionApplication.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuctionApplication.Filters;

public class AuthenticationUserAttribute(IUserRepository repository) : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exist = repository.ExistUserWithEmail(email);

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("Invalid E-mail");
            }
        }
        catch (Exception exception)
        {
            context.Result = new UnauthorizedObjectResult(exception.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

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