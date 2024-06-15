using Task01.Domain.Common;
using Task01.Domain.Lookups;

namespace Task01.Domain.Entities.Users
{
    public class Address:Entity
    {
        #region Properties
        public long UserId { get; set; }
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; } 
        public string FlatNumber { get; set; }
        #endregion

        #region Navigational Properties
        public virtual User User { get; set; }
        public virtual Governorate Governorate { get; set; } 
        public virtual City City { get; set; }
        #endregion
    }
}
