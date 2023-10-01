using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; set; }
        public int NumRatings { get; set; }

        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }

        public static AverageRating CreateNew(double value, int numRatings)
        {
            return new AverageRating(value, numRatings);
        }
        public void AddNewRating(Rating rating)
        {
            Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        }

        public void RemoveRating(Rating rating)
        {
            Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return NumRatings;
        }
    }
}
