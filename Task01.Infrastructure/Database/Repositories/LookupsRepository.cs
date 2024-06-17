using Microsoft.EntityFrameworkCore;
using Task01.Domain.Interfaces;
using Task01.Domain.Lookups;
using Task01.Infrastructure.Database.Context;

namespace Task01.Infrastructure.Database.Repositories
{
    public class LookupsRepository : RepositoryBase, ILookupRepository
    {
        public LookupsRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }

        public async Task<List<City>> GetCities(int governateId)
        {
            return await Context.Cities.Where(x => x.GovernorateId == governateId).ToListAsync();
        }

        public async Task<List<Governorate>> GetGovernorates()
        {
            return await Context.Governorates.ToListAsync();
        }
    }
}
