using Task01.Domain.Common;

namespace Task01.Domain.Lookups
{
    public class City : Lookup
    {
        public int GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }
    }
}
