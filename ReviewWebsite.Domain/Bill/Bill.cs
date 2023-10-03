using ReviewWebsite.Domain.Bill.ValueObjects;
using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Common.ValueObjects;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Guest.ValueObjects;
using ReviewWebsite.Domain.Host.ValueObjects;

namespace ReviewWebsite.Domain.Bill
{
    public class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; set; }
        public GuestId GuestId { get; set; }
        public HostId HostId { get; set; }
        public Price Price { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private Bill(
            BillId billId,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Bill Create(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new Bill(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

    }
}
