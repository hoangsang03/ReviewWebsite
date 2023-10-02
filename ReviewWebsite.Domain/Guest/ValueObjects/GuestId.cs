using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Guest.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new GuestId(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
