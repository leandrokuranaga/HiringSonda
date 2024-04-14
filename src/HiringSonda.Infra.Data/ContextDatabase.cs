using HiringSonda.Domain.AdressAggregate;
using HiringSonda.Domain.UserAggregate;
using HiringSonda.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HiringSonda.Infra.Data
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions op) : base(op)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<AddressUserDomain> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDatabase).Assembly);

            modelBuilder.Entity<UserDomain>()
                .HasOne(b => b.AddressUser)
                .WithOne(i => i.User)
                .HasForeignKey<AddressUserDomain>(i => i.UserID);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                                            .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
