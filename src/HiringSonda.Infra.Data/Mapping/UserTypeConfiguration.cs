using HiringSonda.Domain.AdressAggregate;
using HiringSonda.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HiringSonda.Infra.Mapping
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.FullName).HasColumnType("varchar(100)").IsRequired();
            builder.Property<DateOnly>(e => e.BirthDate).HasConversion<DateOnlyConverter>().HasColumnType("date").IsRequired();
            builder.Property(e => e.CPF).HasColumnType("varchar(20)").IsRequired();
            builder.Property(e => e.Email).HasColumnType("varchar(100)").IsRequired();

            builder.HasOne(y => y.AddressUser)
                    .WithOne(z => z.User)
                    .HasPrincipalKey<UserDomain>(x => x.Id)
                    .HasForeignKey<AddressUserDomain>(x => x.UserID);

            builder.ToTable("User");
        }
    }
}
