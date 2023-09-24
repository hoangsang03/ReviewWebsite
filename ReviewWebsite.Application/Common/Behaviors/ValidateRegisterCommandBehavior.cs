using ErrorOr;
using FluentValidation;
using MediatR;
using ReviewWebsite.Application.Authentication.Commands.Register;
using ReviewWebsite.Application.Authentication.Common;

namespace ReviewWebsite.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehavior :
        IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            return errors; // call ApiController.Problem()
        }
    }
}
