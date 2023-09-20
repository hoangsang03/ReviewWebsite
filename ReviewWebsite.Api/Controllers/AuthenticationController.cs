using Microsoft.AspNetCore.Mvc;
using ReviewWebsite.Application.Services.Authentication;
using ReviewWebsite.Contracts.Authentication;
using ReviewWebsite.Domain.Common.Errors;

namespace ReviewWebsite.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr.ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new(authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            if (authResult.IsError &&
                authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                // ControllerBase Problem
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            // ApiController Problem (has errorCodes)
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }
    }
}
