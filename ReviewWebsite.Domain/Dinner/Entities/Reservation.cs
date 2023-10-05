using ReviewWebsite.Domain.Bill.ValueObjects;
using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.Dinner.ValueObjects;
using ReviewWebsite.Domain.Guest.ValueObjects;

namespace ReviewWebsite.Domain.Dinner.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; set; }
        public ReservationStatus Status { get; set; }
        public GuestId GuestId { get; set; }
        public BillId   BillId { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime CreatedDateTime {  get; set; }
        public DateTime UpdatedDateTime { get; set;}

        private Reservation(
            ReservationId reservationId,
            ReservationStatus status,
            GuestId guestId,
            BillId billId,
            DateTime arrivalDateTime,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(reservationId)
        {
            Status = status;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Reservation Create(ReservationStatus status,
            GuestId guestId,
            BillId billId,
            DateTime arrivalDateTime)
        {
            return new Reservation(
                ReservationId.CreateUnique(),
                status,
                guestId,
                billId,
                arrivalDateTime,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
