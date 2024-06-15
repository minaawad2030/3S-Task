using Task01.Domain.Common;

namespace Task01.Domain.Entities.Users
{
    public class User : Entity
    {
        #region Properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; } 
        #endregion

        #region Navigational Properties
        public virtual ICollection<Address> Addresses { get; set; }=new HashSet<Address>();
        #endregion
    }
}
