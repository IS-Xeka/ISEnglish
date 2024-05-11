using CSharpFunctionalExtensions;

namespace ISEnglish.Domain.Core.Models
{
    public class User
    {

        private User(Guid id, string userName, string passwordsHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordsHash;
            Email = email;
        }
        public Guid Id { get; set; }
        public string UserName { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public static Result<User> Create(Guid id, string userName, string passwordsHash, string email)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Result.Failure<User>($"{nameof(userName)} can not be Empty");
            }

            var user = new User(id, userName, passwordsHash, email);

            return Result.Success<User>(user);
        }

    }
}
