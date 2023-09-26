using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewWebsite.Application.Authentication.Commands.Register;
using ReviewWebsite.Application.Authentication.Common;
using ReviewWebsite.Application.Authentication.Queries.Login;
using ReviewWebsite.Contracts.Authentication;
using ReviewWebsite.Domain.Common.Errors;

namespace ReviewWebsite.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(
            ISender mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            var response = authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

            return response;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

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
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
