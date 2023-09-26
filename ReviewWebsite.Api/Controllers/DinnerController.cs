using Microsoft.AspNetCore.Mvc;

namespace ReviewWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    public class DinnerController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
