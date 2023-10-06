namespace ReviewWebsite.Contracts.Menus
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        List<MenuSection> Sections);

    public record MenuSection(
        string Name,
        string Desciption,
        List<MenuItem> Items);

    public record MenuItem(
        string Name,
        string Desciption);
}
