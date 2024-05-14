using ISEnglish.DataAccess.Entities;
using ISEnglish.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ISEnglishDbContext _context;

        public UsersRepository(ISEnglishDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUniqueUser(string userName)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == userName);
            if(userEntity == null)
            {
                return true;
            }
            return false;
        }
        public async Task Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsGetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
            if(userEntity == null)
            {
                return false;
            }
            return true;
        }
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
                

            var userResult = User.Create(userEntity.Id, userEntity.UserName, userEntity.Email, userEntity.PasswordHash);
            if (userResult.IsFailure)
            {
                throw new Exception();
            }

            return userResult.Value;

        }

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(b => User.Create(b.Id, b.UserName, b.Email, b.PasswordHash).Value)
                .ToList();

            return users;
        }

    }
}
