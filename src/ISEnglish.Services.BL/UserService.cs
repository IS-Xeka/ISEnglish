using CSharpFunctionalExtensions;
using ISEnglish.DataAccess.Repositories;
using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Interfaces.Auth;
using ISEnglish.Domain.Interfaces.Repositories;
using ISEnglish.Infrastructure;

namespace ISEnglish.Services.BL
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IJwtProvider jwtProvider, IUsersRepository usersRepository, IPasswordHasher passwordHasher)
        {
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
        }

        public async Task<bool> IsUniqueUser(string userName)
        {
            return await _usersRepository.IsUniqueUser(userName);
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var userResult = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

            await _usersRepository.Add(userResult.Value);
        }

        public async Task<Result<string>> Login(string email, string password)
        {
            if (await _usersRepository.IsGetByEmail(email))
            {
                var user = await _usersRepository.GetByEmail(email);

                var result = _passwordHasher.Verify(password, user.PasswordHash);

                if (result == false)
                {
                    return Result.Failure<string>("Incorrect password");
                }

                var token = _jwtProvider.GenerateToken(user);

                return Result.Success<string>(token);
            }

            return Result.Failure<string>("Can not found");
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }
    }
}
