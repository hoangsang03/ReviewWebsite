using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Bill.ValueObjects
{
    public class Price : ValueObject
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        private Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Price Create(
            double amount,
            string currency)
        {
            return new Price(amount, currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
