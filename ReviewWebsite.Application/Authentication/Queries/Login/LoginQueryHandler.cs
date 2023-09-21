using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Services.Authentication.Common;
using ReviewWebsite.Application.Services.Persistence;
using ReviewWebsite.Domain.Common.Errors;
using ReviewWebsite.Domain.Entities;

namespace ReviewWebsite.Application.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            // 1. Validate the user exists 
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            // 2. Validate the password is correct 
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            // 3. Create JWT Token 
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}
