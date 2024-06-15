using Task01.Domain.Interfaces;
using Task01.Infrastructure.Database.Context;

namespace Task01.Infrastructure.Database.Repositories
{
    public class LookupsRepository : RepositoryBase, ILookupRepository
    {
        public LookupsRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
