using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MenuItem(
            MenuItemId menuItemId,
            string name,
            string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(
            string name,
            string description)
        {
            return new MenuItem(
                MenuItemId.CreateUnique(),
                name,
                description);
        }
    }
}
