using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Guest.ValueObjects;
using ReviewWebsite.Domain.Host.ValueObjects;

namespace ReviewWebsite.Domain.Guest.Entities
{
    public class Rating : Entity<RatingId>
    {
        public HostId HostId { get; set; }
        public DinnerId DinnerId { get; set; }
        public int RatingScore { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private Rating(
            RatingId ratingId,
            HostId hostId,
            DinnerId dinnerId,
            int rating,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            RatingScore = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Rating Create(HostId hostId, DinnerId dinnerId, int rating)
        {
            return new Rating(
                RatingId.CreateUnique(),
                hostId,
                dinnerId,
                rating,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
