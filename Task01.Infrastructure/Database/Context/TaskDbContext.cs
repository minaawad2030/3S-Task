using Microsoft.EntityFrameworkCore;
using Task01.Domain.Entities.Users;
using Task01.Domain.Lookups;
using Task01.Infrastructure.Database.Conversions;

namespace Task01.Infrastructure.Database.Context
{
    public class TaskDbContext:DbContext
    {
        #region DbSets

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        #endregion

        public TaskDbContext(DbContextOptions<TaskDbContext> options):base(options)
        {
            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                                .HaveConversion<DateOnlyConverter>()
                                .HaveColumnType("date");
            
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
