using Microsoft.EntityFrameworkCore;
using Task01.Domain.Entities.Users;
using Task01.Domain.Interfaces;
using Task01.Infrastructure.Database.Context;

namespace Task01.Infrastructure.Database.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }

        public async Task AddUserAsync(User user)
        {
            await Context.Users.AddAsync(user);
        }

        public async Task<User> CheckExistance(string email, string mobileNumber)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email) || x.MobileNumber.Equals(mobileNumber));
        }
    }
}