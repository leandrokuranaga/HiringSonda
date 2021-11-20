﻿using HiringSonda.Domain.Models;
using HiringSonda.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HiringSonda.Infra.Context
{
    public class Context : DbContext
    {      
        public Context(DbContextOptions op) : base(op)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AddressUser> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            modelBuilder.Entity<User>()
                .HasOne(b => b.addressUser)
                .WithOne(i => i.user)
                .HasForeignKey<AddressUser>(i => i.Id);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                                            .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}