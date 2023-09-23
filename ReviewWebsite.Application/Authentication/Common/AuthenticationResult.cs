using ReviewWebsite.Domain.Entities;

namespace ReviewWebsite.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
