using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public MenuItem(
            MenuItemId menuItemId,
            string name,
            string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MenuItem()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
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
