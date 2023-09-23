using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Authentication.Common;

namespace ReviewWebsite.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
