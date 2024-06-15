using Task01.Infrastructure.Database.Context;

namespace Task01.Infrastructure.Database.Repositories
{
    public abstract class RepositoryBase
    {
        protected TaskDbContext Context { get; }
        public RepositoryBase(TaskDbContext taskDbContext)
        {
            Context = taskDbContext;
        }
    }
}
