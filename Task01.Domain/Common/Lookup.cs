namespace Task01.Domain.Common
{
    public abstract class Lookup
    {
        public int Id { get; protected set; }
        public bool IsDeleted { get; protected set; } = false;
        public string Name { get; protected set; }
    }
}
