
using CSharpFunctionalExtensions;
using ISEnglish.Domain.Core.Models;

namespace ISEnglish.Services.BL
{
    public interface IUserService
    {
        Task<Result<string>> Login(string email, string password);
        Task Register(string userName, string email, string password);
        Task<bool> IsUniqueUser(string userName);
        Task<List<User>> GetAllUsers();
    }
}