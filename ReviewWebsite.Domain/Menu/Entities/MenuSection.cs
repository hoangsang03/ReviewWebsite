using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _item = new();
        public string Name { get; set; }
        public string Description { get; set; }

        public IReadOnlyList<MenuItem> Item => _item.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(
            string name,
            string description)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description);
        }
    }
}
