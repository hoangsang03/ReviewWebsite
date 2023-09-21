using ErrorOr;
using ReviewWebsite.Application.Services.Authentication.Common;

namespace ReviewWebsite.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    }
}
