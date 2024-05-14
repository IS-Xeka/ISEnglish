using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace ISEnglish.Domain.Core.Models
{
    public class User
    {

        private User(Guid id, string userName, string email, string passwordsHash)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordsHash;
        }
        public Guid Id { get; set; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string PasswordHash { get; } = string.Empty;

        public static Result<User> Create(Guid id, string userName, string email, string passwordsHash)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Result.Failure<User>($"{nameof(userName)} can not be Empty");
            }

            var user = new User(id, userName, email, passwordsHash);

            return Result.Success<User>(user);
        }

    }
}
