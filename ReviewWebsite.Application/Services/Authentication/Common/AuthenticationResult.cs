using ReviewWebsite.Domain.Entities;

namespace ReviewWebsite.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
        );
}
