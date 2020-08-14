using Domain.Entities.Users;
using System;

namespace Domain.Builders.Users
{
    public class UserBuilder : IBuilder<User>
    {
        private string Email { get; set; }
        private string FullName { get; set; }
        private long Id { get; set; }
        private string Password { get; set; }
        private string Role { get; set; }

        public User Build()
            => new User(Id, FullName, Email, Password, Role);

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder WithFullName(string fullName)
        {
            FullName = fullName;
            return this;
        }

        public UserBuilder WithId(long id)
        {
            Id = id;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public UserBuilder WithRole(string role)
        {
            Role = role;
            return this;
        }
    }
}