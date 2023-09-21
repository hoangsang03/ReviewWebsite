using ErrorOr;
using ReviewWebsite.Application.Services.Authentication.Common;

namespace ReviewWebsite.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
