﻿using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Authentication.Common;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Domain.Common.Errors;
using ReviewWebsite.Domain.User;

namespace ReviewWebsite.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
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
            await Task.CompletedTask;
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
