using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Dinner.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }

        private DinnerId(Guid value)
        {
            Value = value;
        }

        private DinnerId()
        {
        }

        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }

        public static DinnerId Create(Guid value)
        {
            return new DinnerId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
