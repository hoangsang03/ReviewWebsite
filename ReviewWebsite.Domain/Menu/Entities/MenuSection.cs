using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem>? _items = new();
        public string Name { get; set; }
        public string Description { get; set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem>? items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem>? menuItems)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                menuItems);
        }
    }
}
