using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MenuSection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> menuItems)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                menuItems);
        }


    }
}
