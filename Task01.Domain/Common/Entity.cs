namespace Task01.Domain.Common
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public bool IsDeleted { get; protected set; } = false;
    }
}