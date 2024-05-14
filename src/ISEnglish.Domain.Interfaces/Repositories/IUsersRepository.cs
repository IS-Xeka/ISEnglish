using ISEnglish.Domain.Core.Models;

namespace ISEnglish.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);

        Task<bool> IsGetByEmail(string email);
        Task<List<User>> Get();

        Task<bool> IsUniqueUser(string userName);
    }
}