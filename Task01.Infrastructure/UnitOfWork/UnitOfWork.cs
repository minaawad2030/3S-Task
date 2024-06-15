using Task01.Domain.Interfaces;
using Task01.Infrastructure.Database.Context;
using Task01.Infrastructure.Database.Repositories;

namespace Task01.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _taskDbContext;
        public UnitOfWork(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;

            #region Repos Init
            UserRepository=new UserRepository(_taskDbContext);
            LookupRepository = new LookupsRepository(_taskDbContext);
            #endregion
        }

        public ILookupRepository LookupRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _taskDbContext.SaveChangesAsync();
        }
    }
}
