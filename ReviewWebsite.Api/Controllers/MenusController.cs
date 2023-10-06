using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReviewWebsite.Application.Menus.Commands.CreateMenu;
using ReviewWebsite.Contracts.Menus;

namespace ReviewWebsite.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(
            IMapper mapper,
            ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);

            if (!createMenuResult.IsError)
            {
                var value = createMenuResult.Value;
                Console.WriteLine(value);
            }

            var result = createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));

            return result;
        }
    }
}
