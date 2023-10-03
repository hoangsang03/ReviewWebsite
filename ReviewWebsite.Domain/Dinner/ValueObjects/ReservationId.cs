using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Dinner.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new ReservationId(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
