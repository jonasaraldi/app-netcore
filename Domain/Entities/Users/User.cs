using System;

namespace Domain.Entities.Users
{
    public class User : Entity
    {
        public User(long id, string fullName, string email, string password, string role)
            : base(id)
        {
            SetFullName(fullName);
            SetPassword(password);
            SetRole(role);
            SetEmail(email);
        }

        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; set; }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                AddError("O e-mail não foi informado.");
                return;
            }

            Email = email;
        }

        public void SetFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                AddError("O nome completo do usuário não foi informado.");
                return;
            }

            FullName = fullName;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                AddError("A senha não foi informada.");
                return;
            }

            Password = password;
        }

        public void SetRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                AddError("O perfil não foi informado.");
                return;
            }

            Role = role;
        }
    }
}