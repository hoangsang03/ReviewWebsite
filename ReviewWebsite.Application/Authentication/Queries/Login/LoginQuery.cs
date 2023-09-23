using ErrorOr;
using MediatR;
using ReviewWebsite.Application.Authentication.Common;

namespace ReviewWebsite.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
