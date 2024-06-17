namespace Task01.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ILookupRepository LookupRepository { get; }
        public IUserRepository UserRepository { get; }
        Task SaveChangesAsync();

    }
}
