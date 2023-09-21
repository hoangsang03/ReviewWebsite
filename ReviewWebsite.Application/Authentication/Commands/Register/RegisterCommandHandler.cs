﻿using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Services.Authentication.Common;
using ReviewWebsite.Application.Services.Persistence;
using ReviewWebsite.Domain.Common.Errors;
using ReviewWebsite.Domain.Entities;

namespace ReviewWebsite.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            // 1. validate the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            // 2. create user (generate unique id) and persist to DB
            var user = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            // 3.create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);

        }
    }
}
