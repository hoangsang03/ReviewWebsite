using ReviewWebsite.Domain.Entities;

namespace ReviewWebsite.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
        );
}
