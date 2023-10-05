using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

