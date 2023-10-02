using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Common.ValueObjects;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Guest.ValueObjects;
using ReviewWebsite.Domain.Host.ValueObjects;
using ReviewWebsite.Domain.Menu.ValueObjects;
using ReviewWebsite.Domain.MenuReview.ValueObjects;

namespace ReviewWebsite.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }
        public GuestId GuestId { get; set; }
        public DinnerId DinnerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private MenuReview(
            MenuReviewId menuReviewId,
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public MenuReview Create(
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
        {
            return new MenuReview(
                MenuReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
