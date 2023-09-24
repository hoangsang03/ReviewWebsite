using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ReviewWebsite.Api.Common.Http;

namespace ReviewWebsite.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            // call ReviewWebsiteProblemDetailFactory.CreateProblemDetails()
            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
