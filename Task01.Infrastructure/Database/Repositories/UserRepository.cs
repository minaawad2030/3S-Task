using Task01.Domain.Interfaces;
using Task01.Infrastructure.Database.Context;

namespace Task01.Infrastructure.Database.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
