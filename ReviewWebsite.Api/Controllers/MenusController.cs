using Microsoft.AspNetCore.Mvc;
using ReviewWebsite.Contracts.Menus;

namespace ReviewWebsite.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        [HttpPost]
        public IActionResult CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            return Ok(request);
        }
    }
}
