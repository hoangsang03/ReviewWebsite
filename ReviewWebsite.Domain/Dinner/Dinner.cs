using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Common.ValueObjects;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Host.ValueObjects;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<ReservationId> _reservationIds = new();

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime EndedDateTime { get; set; }
        public DinnerStatus Status { get; set; }
        public bool IsPublic { get; set; }
        public int MaxGuest { get; set; }
        public Price Price { get; set; }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuest,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuest = maxGuest;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuest,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            return new Dinner(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                status,
                isPublic,
                maxGuest,
                price,
                hostId,
                menuId,
                imageUrl,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
