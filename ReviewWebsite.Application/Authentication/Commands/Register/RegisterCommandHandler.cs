using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Authentication.Common;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Domain.Common.Errors;
using ReviewWebsite.Domain.User;

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
            await Task.CompletedTask;
            // 1. validate the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            // 2. create user (generate unique id) and persist to DB
            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Password);

            _userRepository.Add(user);

            // 3.create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);

        }
    }
}
