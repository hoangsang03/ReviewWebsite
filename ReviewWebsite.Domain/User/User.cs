using ReviewWebsite.Domain.Common.Models;
using ReviewWebsite.Domain.User.ValueObjects;

namespace ReviewWebsite.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private User(
            UserId userId,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(string firstName,
            string lastName,
            string email,
            string password)
        {
            return new User(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
