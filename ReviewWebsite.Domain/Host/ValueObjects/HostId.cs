using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public string Value { get; }

        private HostId(string value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid().ToString());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static HostId Create(string hostId)
        {
            return new HostId(hostId);
        }
    }
}
