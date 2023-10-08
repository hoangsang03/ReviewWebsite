using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Common.ValueObjects;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Host.ValueObjects;
using ReviewWebsite.Domain.Menu.Entities;
using ReviewWebsite.Domain.Menu.ValueObjects;
using ReviewWebsite.Domain.MenuReview.ValueObjects;

namespace ReviewWebsite.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId menuId,
            HostId hostId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections)
        {
            return new Menu(
                MenuId.CreateUnique(),
                hostId,
                name,
                description,
                AverageRating.CreateNew(0, 0),
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Menu()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
    }
}
