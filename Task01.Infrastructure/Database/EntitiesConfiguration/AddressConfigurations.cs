using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task01.Domain.Entities.Users;

namespace Task01.Infrastructure.Database.EntitiesConfiguration
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(x => x.HasTrigger("trg_UpdateGovernorateUserCount"));
        }
    }
}
