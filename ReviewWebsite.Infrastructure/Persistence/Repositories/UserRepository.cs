﻿using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Domain.User;

namespace ReviewWebsite.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
