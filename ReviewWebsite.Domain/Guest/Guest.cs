using ReviewWebsite.Domain.Bill.ValueObjects;
using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Common.ValueObjects;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Guest.ValueObjects;
using ReviewWebsite.Domain.MenuReview.ValueObjects;
using ReviewWebsite.Domain.User.ValueObjects;
using Rating = ReviewWebsite.Domain.Guest.Entities.Rating;

namespace ReviewWebsite.Domain.Guest
{
    public class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<Rating> _ratings = new();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public AverageRating AverageRating { get; set; }
        public int UserId { get; set; }
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Guest(
            GuestId guestId,
            List<DinnerId> upcomingDinnerIds,
            List<DinnerId> pastDinnerIds,
            List<DinnerId> pendingDinnerIds,
            List<BillId> billIds,
            List<MenuReviewId> menuReviewIds,
            List<Rating> ratings,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            int userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(guestId)
        {
            _upcomingDinnerIds = upcomingDinnerIds;
            _pastDinnerIds = pastDinnerIds;
            _pendingDinnerIds = pendingDinnerIds;
            _billIds = billIds;
            _menuReviewIds = menuReviewIds;
            _ratings = ratings;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Guest Create(List<DinnerId> upcomingDinnerIds,
            List<DinnerId> pastDinnerIds,
            List<DinnerId> pendingDinnerIds,
            List<BillId> billIds,
            List<MenuReviewId> menuReviewIds,
            List<Rating> ratings,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            int userId)
        {
            return new Guest(
                GuestId.CreateUnique(),
                upcomingDinnerIds,
                pastDinnerIds,
                pendingDinnerIds,
                billIds,
                menuReviewIds,
                ratings,
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);

        }
    }
}
