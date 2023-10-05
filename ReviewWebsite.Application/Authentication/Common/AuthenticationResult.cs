using ReviewWebsite.Domain.User;

namespace ReviewWebsite.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
