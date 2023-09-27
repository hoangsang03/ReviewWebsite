using System.Linq.Expressions;

namespace ReviewWebsite.Domain.Common.Models
{
#pragma warning disable S4035 // Classes implementing "IEquatable<T>" should be sealed
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
#pragma warning restore S4035 // Classes implementing "IEquatable<T>" should be sealed
        where TId : notnull
    {
        public TId Id { get; set; }

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        protected Entity(TId id)
        {
            Id = id;
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return NotEqualOperator(left, right);
        }

        protected static bool EqualOperator(Entity<TId> left, Entity<TId> right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return ReferenceEquals(left, right) || left.Equals(right);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        protected static bool NotEqualOperator(Entity<TId> left, Entity<TId> right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }
        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
