using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task01.Domain.Lookups
{
    public class GovernorateUserCount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GovernorateId { get; set; }
        public int UserCount { get; set; }
    }
}
