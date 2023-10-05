using ReviewWebsite.Domain.User;

namespace ReviewWebsite.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
