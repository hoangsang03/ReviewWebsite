using ErrorOr;
using MediatR;
using ReviewWebsite.Domain.Menu;

namespace ReviewWebsite.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name,
        string Desciption,
        List<MenuItemCommand> Items);

    public record MenuItemCommand(
        string Name,
        string Desciption);
}
