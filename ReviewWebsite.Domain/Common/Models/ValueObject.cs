namespace ReviewWebsite.Domain.Common.Models
{
    /// <summary>
    /// DOC: 
    /// https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// https://rules.sonarsource.com/csharp/RSPEC-4035/
    /// </summary>
#pragma warning disable S4035 // Classes implementing "IEquatable<T>" should be sealed
    public abstract class ValueObject : IEquatable<ValueObject>
#pragma warning restore S4035 // Classes implementing "IEquatable<T>" should be sealed
    {
#pragma warning disable S3875 // "operator==" should not be overloaded on reference types
        public static bool operator ==(ValueObject one, ValueObject two)
#pragma warning restore S3875 // "operator==" should not be overloaded on reference types
        {
            return Equals(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return !Equals(one, two);
        }
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return ReferenceEquals(left, right) || left.Equals(right);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }
        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0) //  x ?. null ? x.GetHashCode() : 0
                .Aggregate((x, y) => x ^ y);
        }



        public ValueObject? GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }

        // Other utility methods
    }
}
